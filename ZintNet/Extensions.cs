using System;
using System.Text;

namespace System.Text.Extensions
{
    /// <summary>
    /// StringBuilder class extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Clears the contents of the string builder.
        /// </summary>
        /// <param name="value">the stringbuilder to clear</param>
        public static void Clear(this StringBuilder value)
        {
            value.Length = 0;
            value.Capacity = 32;
        }

        /// <summary>
        /// Tests for a substring within the string builder
        /// </summary>
        /// <param name="value"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool Contains(this StringBuilder value, string c)
        {
            return value.ToString().Contains(c);
        }
    }
}
