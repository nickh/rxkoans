using System;
using System.Collections.Generic;
using System.Linq;

namespace Koans.Utils
{
    public static class StringUtils
    {
        public static Func<object, object> reset = (s => "Please Fill in the Blank");
        public static Func<object, object> call = reset;

        public static void Reset()
        {
            call = reset;
        }
        public static string AsString(this IEnumerable<object> list)
        {
            return "[" + String.Join(", ", list.Select(x => x.ToString())) + "]";
        }

        public static string ___(this string s)
        {
            return (String)doCall(s);
        }
        public static object ___(this Object o)
        {
            return doCall(o);
        }
        public static object ____<T>(this IObservable<T> o, Action<T> action)
        {
            return doCall(o);
        }

        private static object doCall(object o)
        {
            var r = call(o);
             return r;
        }

        public static bool IsEven(this int number)
        {
            return number%2 == 0;
        }
        public static void OnNext<T>(this IObserver<T> o, params T[] events)
        {
            foreach (var e in events)
            {
                o.OnNext(e);
            }
        }
    }
}