using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Png2Hilbert
{
    [DebuggerDisplay("{Direction} {EnterPoint}-{ExitPoint} {Square.Width} ")]
    public class HilbertCurve
    {
        public HilbertCurve(Direction dir, int order, Rectangle square)
        {
            this.Direction = dir;
            this.Square = square;
            this.Order = order;
            this.Children = new List<HilbertCurve>();


            if (order == 0)
            {
                this.EnterPoint = square.Middle();
                this.ExitPoint = square.Middle();
            }
            else
            {
                switch (dir)
                {
                    case Direction.Up:
                        this.Children.Add(new HilbertCurve(Direction.Right, order - 1, square.BottomLeft()));
                        this.Children.Add(new HilbertCurve(Direction.Up, order - 1, square.TopLeft()));
                        this.Children.Add(new HilbertCurve(Direction.Up, order - 1, square.TopRight()));
                        this.Children.Add(new HilbertCurve(Direction.Left, order - 1, square.BottomRight()));
                        break;
                    case Direction.Down:
                        this.Children.Add(new HilbertCurve(Direction.Left, order - 1, square.TopRight()));
                        this.Children.Add(new HilbertCurve(Direction.Down, order - 1, square.BottomRight()));
                        this.Children.Add(new HilbertCurve(Direction.Down, order - 1, square.BottomLeft()));
                        this.Children.Add(new HilbertCurve(Direction.Right, order - 1, square.TopLeft()));
                        break;
                    case Direction.Left:
                        this.Children.Add(new HilbertCurve(Direction.Down, order - 1, square.TopRight()));
                        this.Children.Add(new HilbertCurve(Direction.Left, order - 1, square.TopLeft()));
                        this.Children.Add(new HilbertCurve(Direction.Left, order - 1, square.BottomLeft()));
                        this.Children.Add(new HilbertCurve(Direction.Up, order - 1, square.BottomRight()));
                        break;
                    case Direction.Right:
                        this.Children.Add(new HilbertCurve(Direction.Up, order - 1, square.BottomLeft()));
                        this.Children.Add(new HilbertCurve(Direction.Right, order - 1, square.BottomRight()));
                        this.Children.Add(new HilbertCurve(Direction.Right, order - 1, square.TopRight()));
                        this.Children.Add(new HilbertCurve(Direction.Down, order - 1, square.TopLeft()));
                        break;
                }
                this.EnterPoint = this.Children.First().EnterPoint;
                this.ExitPoint = this.Children.Last().ExitPoint;
            }
        }

        public int Order { get; set; }

        public Rectangle Square { get; set; }

        public List<HilbertCurve> Children { get; set; }
        public int Size { get; set; }
        public Point Start { get; set; }
        public Direction Direction { get; set; }
        public Point EnterPoint { get; private set; }
        public Point ExitPoint { get; private set; }
    }
}