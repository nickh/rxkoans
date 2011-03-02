using System;
using System.Collections.Generic;
using System.Linq;

namespace Koans.Utils
{
    public static class StringUtils
    {
        public static Func<string, string> call = (s => "Please Fill in the Blank");

        public static string AsString(this IEnumerable<object> list)
        {
            return "[" + String.Join(", ", list.Select(x => x.ToString())) + "]";
        }

        public static string ___(this string s)
        {
            return call(s);
        }

        public static bool IsEven(this int number)
        {
            return number%2 == 0;
        }
    }
}