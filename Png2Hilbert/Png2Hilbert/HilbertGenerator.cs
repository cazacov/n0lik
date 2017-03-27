using System;
using System.Collections.Generic;
using System.Drawing;

namespace Png2Hilbert
{
    public class HilbertGenerator : IDisposable
    {
        public EventHandler<Bitmap> OnLoad;
        public EventHandler<Bitmap> OnPathGenerated;

        private Bitmap bitmap;
        public List<Point> Path { get; private set; }

        public void LoadImage(string fileName)
        {
            this.bitmap = (Bitmap)Image.FromFile(fileName, true);
            OnLoad?.Invoke(this, this.bitmap);
        }

        public void Dispose()
        {
            bitmap?.Dispose();
        }

        public void GenerateCurve()
        {
            const int order = 9;
            this.Path = new List<Point>();
            HilbertUp(order, new Point(0,0), Path);
        }

        

        private void HilbertUp(int order, Point point, List<Point> path)
        {
            var lineLength = (1 << order) - 1;
            if (order == 2 ||  BlockIsWhite(point, lineLength, lineLength))
            {
                point.Offset(lineLength * 3, 0);
                path.Add(point);
                return;
            }
            else
            {
                HilbertRight(order - 1, point, path);
                point.Offset(0, lineLength);
                path.Add(point);

                HilbertUp(order - 1, point, path);
                point.Offset(lineLength, 0);
                path.Add(point);

                HilbertUp(order - 1, point, path);
                point.Offset(0, -lineLength);
                path.Add(point);

                HilbertLeft(order - 1, point, path);
            }
        }

        private void HilbertLeft(int order, Point point, List<Point> path)
        {
            var lineLength = (1 << order) - 1;
            if (order == 2 || BlockIsWhite(point, -lineLength, -lineLength))
            {
                point.Offset(0, -lineLength * 3);
                path.Add(point);
                return;
            }
            else
            {
                HilbertDown(order - 1, point, path);
                point.Offset(-lineLength, 0);
                path.Add(point);

                HilbertLeft(order - 1, point, path);
                point.Offset(0, -lineLength);
                path.Add(point);

                HilbertLeft(order - 1, point, path);
                point.Offset(lineLength, 0);
                path.Add(point);

                HilbertUp(order - 1, point, path);
            }
        }

        private void HilbertDown(int order, Point point, List<Point> path)
        {
            var lineLength = (1 << order) - 1;
            if (order == 2 || BlockIsWhite(point, -lineLength, -lineLength))
            {
                point.Offset(-lineLength * 3, 0);
                path.Add(point);
                return;
            }

            HilbertLeft(order - 1, point, path);
            point.Offset(0, -lineLength);
            path.Add(point);

            HilbertDown(order - 1, point, path);
            point.Offset(-lineLength, 0);
            path.Add(point);

            HilbertDown(order - 1, point, path);
            point.Offset(0, lineLength);
            path.Add(point);

            HilbertRight(order - 1, point, path);
        }

        private void HilbertRight(int order, Point point, List<Point> path)
        {
            var lineLength = (1 << order) - 1;
            if (order == 2 || BlockIsWhite(point, lineLength, lineLength))
            {
                point.Offset(0, lineLength * 3);
                path.Add(point);
                return;
            }

            HilbertUp(order - 1, point, path);
            point.Offset(lineLength, 0);
            path.Add(point);

            HilbertRight(order - 1, point, path);
            point.Offset(0, lineLength);
            path.Add(point);

            HilbertRight(order - 1, point, path);
            point.Offset(-lineLength, 0);
            path.Add(point);

            HilbertDown(order - 1, point, path);
        }



        bool BlockIsWhite(Point from, int dx, int dy)
        {
            return true;

            //const double threshold = 1.2;

            //int l = Math.Min(from.X, to.X);
            //int r = Math.Max(from.X, to.X);
            //int t = Math.Min(from.Y, to.Y);
            //int b = Math.Max(from.Y, to.Y);

            //long intensity = 0;
            //for (var i = l; i < r; ++i)
            //{
            //    for (var j = t; j < b; ++j)
            //    {
            //        intensity += bitmap.GetPixel(i, j).G; // use green component
            //    }
            //}
            //intensity /= (b - t) * (r - l);

            //return intensity / (b - t) * (r - l) * 255.0 > threshold * (1 - Math.Log(2) / Math.Log(b - t));
        }
    }
}
