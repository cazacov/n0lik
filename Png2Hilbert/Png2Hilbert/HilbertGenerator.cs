﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Png2Hilbert
{
    public class HilbertGenerator : IDisposable
    {
        public EventHandler<Bitmap> OnLoad;
        public EventHandler<Bitmap> OnPathGenerated;

        private Bitmap sourceImage;
        public List<Point> Path { get; private set; }
        public HilbertCurve Curve { get; private set; }

        private Stopwatch stopwatch = new Stopwatch();

        public void LoadImage(string fileName)
        {
            if (this.sourceImage != null)
            {
                this.sourceImage.Dispose();
                this.sourceImage = null;
            }

            using (var bmp = Image.FromFile(fileName, true))
            {
                this.sourceImage = new Bitmap(bmp);
            }

            OnLoad?.Invoke(this, this.sourceImage);
        }

        public long LastCalculationTimeInMs => stopwatch.ElapsedMilliseconds;

        public void PrepareCurve(int maxOrder)
        {
            ResetTimer();
            this.Curve = new HilbertCurve(Direction.Up, maxOrder, new Rectangle(0, 0, sourceImage.Width, sourceImage.Height));
            CalculateBrightness(this.sourceImage, this.Curve, new Rectangle(0, 0, this.sourceImage.Width, this.sourceImage.Height));
            stopwatch.Stop();
        }

        private void ResetTimer()
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
            }
            stopwatch.Reset();
            stopwatch.Start();
        }

        public void Dispose()
        {
            sourceImage?.Dispose();
            sourceImage = null;
        }

        public void GenerateCurve(double gamma, int maxOrder)
        {
            ResetTimer();

            var zeroLevel = Math.Max(sourceImage.Width >> (maxOrder + 1), 1);

            this.Path = new List<Point>();
            TracePath(this.Curve, this.Path, gamma, zeroLevel);
            GeneratePreview(this.Path, this.sourceImage.Width, this.sourceImage.Height);
        }

        private void TracePath(HilbertCurve curve, List<Point> points, double gamma, int zeroLevel)
        {
            if (!curve.Children.Any())
            {
                points.Add(curve.EnterPoint);
                return;
            }

            foreach (var child in curve.Children)
            {
                if (BlockIsWhite(child, gamma, zeroLevel))
                {
                    // add enter and exit points and do not go deeper
                    points.Add(child.EnterPoint);
                    if (child.ExitPoint != child.EnterPoint)
                    {
                        points.Add(child.ExitPoint);
                    }
                }
                else
                {
                    // recursive call
                    TracePath(child, points, gamma, zeroLevel);            
                }
            }
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
                    stopwatch.Stop();
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
