using System;

namespace Png2Hilbert.Gui
{
    public static class HelperExtensions
    {
        public static int ToIntDef(this string str, int defaultValue = 0)
        {
            int result = defaultValue;

            if (Int32.TryParse(str, out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }
        }
    }
}
