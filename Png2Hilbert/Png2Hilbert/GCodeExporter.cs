using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace Png2Hilbert
{
    public class GCodeExporter
    {
        private readonly int pageWidthMm;
        private readonly int pageHeightMm;

        public string Header { get; private set; }
        public string Footer { get; private set; }
        public string PenUp { get; private set; }
        public string PenDown { get; private set; }

        public GCodeExporter(int pageWidthMm, int pageHeightMm, string header = "", string footer = "", string penUp = "", string penDown = "")
        {
            Header = "G21\nM3 S100\nG0 F5000\n";
            Footer = "M3 S120\n";
            PenUp = "M3 S120\n";
            PenDown = "M3 S0\n";

            this.pageWidthMm = pageWidthMm;
            this.pageHeightMm = pageHeightMm;
            if (!String.IsNullOrWhiteSpace(header))
            {
                this.Header = header;
            }
            if (!String.IsNullOrWhiteSpace(footer))
            {
                this.Footer = footer;
            }
            if (!String.IsNullOrWhiteSpace(penUp))
            {
                this.PenUp = penUp;
            }
            if (!String.IsNullOrWhiteSpace(penDown))
            {
                this.PenDown = penDown;
            }
        }

        public void ExportGCode(IList<Point> path, string outputFileName)
        {
            var maxX = path.Max(p => p.X);
            var minX = path.Min(p => p.X);
            var maxY = path.Max(p => p.Y);
            var minY = path.Min(p => p.Y);

            var maxPathSize = Math.Max(maxX - minX, maxY - minY);
            var minPageSize = Math.Min(pageWidthMm, pageHeightMm);

            var scale = (double)minPageSize / maxPathSize;
            var offsetX = (pageWidthMm - (maxX + minX) * scale) / 2;
            var offsetY = (pageHeightMm - (maxY + minY) * scale) / 2;

            var locale = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = locale;

            using (var textWriter = File.CreateText(outputFileName))
            {
                textWriter.WriteLine(this.Header);

                Point lastPoint;

                if (path.Count > 1)
                {
                    textWriter.WriteLine("G0 X{0} Y{1}", path[0].X * scale + offsetX,
                    pageHeightMm - path[0].Y * scale - offsetY);
                    textWriter.WriteLine(this.PenDown);

                    lastPoint = path[0];

                    for (int i = 1; i < path.Count; i++)
                    {
                        var point = path[i];
                        if (i < path.Count - 1)
                        {
                            var nextPoint = path[i + 1];

                            if (lastPoint.X == point.X && nextPoint.X == point.X)
                            {
                                // 3 points on the same line, skip the middle one
                                continue;
                            }
                            if (lastPoint.Y == point.Y && nextPoint.Y == point.Y)
                            {
                                // 3 points on the same line, skip the middle one
                                continue;
                            }
                        }

                        textWriter.WriteLine("G1 X{0:0.00} Y{1:0.00}", point.X * scale + offsetX,
                            pageHeightMm - point.Y * scale - offsetY);

                        lastPoint = point;
                    }
                }

                textWriter.WriteLine(this.PenUp);

                textWriter.WriteLine(this.Footer);
            }
        }
    }
}
