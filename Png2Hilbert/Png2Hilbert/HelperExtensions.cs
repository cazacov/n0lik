using System.Drawing;

namespace Png2Hilbert
{
    public static class HelperExtensions
    {
        public static Point Middle(this Rectangle rect)
        {
            return new Point((rect.Right + rect.Left) / 2, (rect.Bottom + rect.Top) / 2);
        }

        public static Rectangle BottomLeft(this Rectangle rect)
        {
            return new Rectangle(rect.Left, (rect.Bottom + rect.Top) / 2, rect.Width / 2, rect.Height / 2);
        }

        public static Rectangle BottomRight(this Rectangle rect)
        {
            return new Rectangle((rect.Right + rect.Left) / 2, (rect.Bottom + rect.Top) / 2, rect.Width / 2, rect.Height / 2);
        }

        public static Rectangle TopLeft(this Rectangle rect)
        {
            return new Rectangle(rect.Left, rect.Top, rect.Width / 2, rect.Height / 2);
        }

        public static Rectangle TopRight(this Rectangle rect)
        {
            return new Rectangle((rect.Right + rect.Left) / 2, rect.Top, rect.Width / 2, rect.Height / 2);
        }
    }
}