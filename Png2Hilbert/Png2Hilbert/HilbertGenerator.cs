using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Png2Hilbert
{
    public class HilbertGenerator : IDisposable
    {
        public EventHandler<Bitmap> OnLoad;
        public EventHandler<Bitmap> OnPathGenerated;

        private Bitmap bitmap;
        public List<Point> Path { get; private set; }
        public HilbertCurve Curve { get; private set; }

        public void LoadImage(string fileName)
        {
            if (this.bitmap != null)
            {
                this.bitmap.Dispose();
                this.bitmap = null;
            }

            using (var bmp = Image.FromFile(fileName, true))
            {
                this.bitmap = new Bitmap(bmp);
            }
            this.Curve = new HilbertCurve(Direction.Up, 8, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            CalculateBrightness(this.bitmap, this.Curve, new Rectangle(0, 0, this.bitmap.Width, this.bitmap.Height));
            OnLoad?.Invoke(this, this.bitmap);
        }

        public void Dispose()
        {
            bitmap?.Dispose();
            bitmap = null;
        }

        public void GenerateCurve(double gamma)
        {
            this.Path = new List<Point>();
            TracePath(this.Curve, this.Path, gamma);
            GeneratePreview(this.bitmap, Path);
            OnPathGenerated?.Invoke(this, bitmap);
        }

        private void TracePath(HilbertCurve curve, List<Point> points, double gamma)
        {
            if (!curve.Children.Any())
            {
                points.Add(curve.EnterPoint);
                return;
            }

            curve.Children.ForEach(childCurve =>
                {
                    if (BlockIsWhite(childCurve, gamma))
                    {
                        points.Add(childCurve.EnterPoint);
                        if (childCurve.ExitPoint != childCurve.EnterPoint)
                        {
                            points.Add(childCurve.ExitPoint);
                        }
                    }
                    else
                    {
                        TracePath(childCurve, points, gamma);            
                    }
                }
            );
        }

        private bool BlockIsWhite(HilbertCurve c, double gamma)
        {
            var threshold = 1.0 / (1 << c.Order);
            var result = Math.Pow(c.Blackness, 1.0 / gamma) < threshold;
            return result;
        }

        //bool BlockIsWhite(Rectangle rect, int order)
        //{
        //    const double gamma = 0.85;

        //    long intensity = 0;
        //    for (var y = rect.Top; y < rect.Bottom; y++)
        //    {
        //        for (var x = rect.Left; x < rect.Right; x++)
        //        {
        //            intensity += bitmap.GetPixel(x, y).G; // use green component
        //        }
        //    }
        //    intensity /= rect.Width * rect.Height;

        //    var threshold = 1.0 / (1 << order);

        //    var result =  Math.Pow(1 - intensity / 255.0, 1.0 / gamma) < threshold;
        //    return result;
        //}

        private void GeneratePreview(Bitmap bmp, List<Point> path)
        {
            using (var graphics = Graphics.FromImage(bmp))
            {
                graphics.FillRectangle(Brushes.White, 0,0, bmp.Width, bmp.Height);

                var pen = Pens.Black;
                graphics.DrawLines(pen, path.ToArray());
            }
        }

        private void CalculateBrightness(Bitmap bmp, HilbertCurve curve, Rectangle rect)
        {
            if (!curve.Children.Any())
            {
                long intensity = 0;
                for (var y = rect.Top; y < rect.Bottom; y++)
                {
                    for (var x = rect.Left; x < rect.Right; x++)
                    {
                        intensity += bmp.GetPixel(x, y).G; // use green component
                    }
                }
                curve.Blackness = 1.0 - intensity / (rect.Width * rect.Height * 255.0);
                return;
            }
            else
            {
                var b = 0.0;
                foreach (var child in curve.Children)
                {
                    CalculateBrightness(bmp, child, child.Square);
                    b += child.Blackness;
                }
                curve.Blackness = b / curve.Children.Count();
            }
        }
    }
}
