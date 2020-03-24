using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        /// returns the number of milliseconds since Jan 1, 1970 (useful for converting C# dates to JS dates)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string UnixTicks(this DateTime dt)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = dt.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            return Math.Round(ts.TotalMilliseconds).ToString();
        }
    }
}
