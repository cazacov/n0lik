using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Png2Hilbert
{
    public class HilbertGenerator : IDisposable
    {
        public EventHandler<Bitmap> OnLoad;
        public EventHandler<Bitmap> OnPathGenerated;

        private Bitmap bitmap;
        public List<Point> Path { get; private set; }

        private const int minOrder = 7;

        public void LoadImage(string fileName)
        {
            this.bitmap = (Bitmap)Image.FromFile(fileName, true);
            OnLoad?.Invoke(this, this.bitmap);
        }

        public void Dispose()
        {
            bitmap?.Dispose();
        }

        public void GenerateCurve(double d)
        {
            this.Curve = new HilbertCurve(Direction.Up, 8, new Rectangle(0, 0, bitmap.Width, bitmap.Height));

            this.Path = new List<Point>();
            TracePath(this.Curve, this.Path);
            GeneratePreview(this.bitmap, Path);
            OnPathGenerated?.Invoke(this, bitmap);
        }

        private void TracePath(HilbertCurve curve, List<Point> points)
        {
            if (!curve.Children.Any())
            {
                points.Add(curve.EnterPoint);
                return;
            }

            curve.Children.ForEach(c =>
                {
                    if (BlockIsWhite(c.Square, c.Order))
                    {
                        points.Add(c.EnterPoint);
                        if (c.ExitPoint != c.EnterPoint)
                        {
                            points.Add(c.ExitPoint);
                        }
                    }
                    else
                    {
                        TracePath(c, points);            
                    }
                }
            );

            //var nonWhiteChildren = curve.Children.Where(c => !BlockIsWhite(c.Square, c.Order)).ToList();
            //nonWhiteChildren.ForEach(c => TracePath(c, points));
        }

        public HilbertCurve Curve { get; set; }

        bool BlockIsWhite(Rectangle rect, int order)
        {
            const double gamma = 0.85;

            long intensity = 0;
            for (var y = rect.Top; y < rect.Bottom; y++)
            {
                for (var x = rect.Left; x < rect.Right; x++)
                {
                    intensity += bitmap.GetPixel(x, y).G; // use green component
                }
            }
            intensity /= rect.Width * rect.Height;

            var threshold = 1.0 / (1 << order);

            var result =  Math.Pow(1 - intensity / 255.0, 1.0 / gamma) < threshold;
            return result;
        }

        private void GeneratePreview(Bitmap bmp, List<Point> path)
        {
            using (var graphics = Graphics.FromImage(bmp))
            {
                graphics.FillRectangle(Brushes.White, 0,0, bmp.Width, bmp.Height);

                var pen = Pens.Black;
                graphics.DrawLines(pen, path.ToArray());
            }
        }

        
    }
}
