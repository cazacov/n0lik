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
            OnLoad?.Invoke(this, this.bitmap);
        }

        public void PrepareCurve(int maxOrder)
        {
            this.Curve = new HilbertCurve(Direction.Up, maxOrder, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            CalculateBrightness(this.bitmap, this.Curve, new Rectangle(0, 0, this.bitmap.Width, this.bitmap.Height));
        }

        public void Dispose()
        {
            bitmap?.Dispose();
            bitmap = null;
        }

        public void GenerateCurve(double gamma, int maxOrder)
        {
            this.Path = new List<Point>();

            int zeroLevel = Math.Max(bitmap.Width >> (maxOrder + 1), 1);

            TracePath(this.Curve, this.Path, gamma, zeroLevel);
            GeneratePreview(this.Path, this.bitmap.Width, this.bitmap.Height);
        }

        private void TracePath(HilbertCurve curve, List<Point> points, double gamma, int zeroLevel)
        {
            if (!curve.Children.Any())
            {
                points.Add(curve.EnterPoint);
                return;
            }

            curve.Children.ForEach(childCurve =>
                {
                    if (BlockIsWhite(childCurve, gamma, zeroLevel))
                    {
                        points.Add(childCurve.EnterPoint);
                        if (childCurve.ExitPoint != childCurve.EnterPoint)
                        {
                            points.Add(childCurve.ExitPoint);
                        }
                    }
                    else
                    {
                        TracePath(childCurve, points, gamma, zeroLevel);            
                    }
                }
            );
        }

        private bool BlockIsWhite(HilbertCurve c, double gamma, int zeroLevel)
        {
            var threshold = 1.0 / (zeroLevel << c.Order);
            var result = Math.Pow(c.Blackness, 1.0 / gamma) < threshold;
            return result;
        }

        private void GeneratePreview(List<Point> path, int width, int height)
        {
            using (var bmp = new Bitmap(width, height))
            {
                using (var grp = Graphics.FromImage(bmp))
                {
                    grp.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
                    var pen = Pens.Black;
                    grp.DrawLines(pen, path.ToArray());
                    OnPathGenerated?.Invoke(this, bmp);
                }
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
