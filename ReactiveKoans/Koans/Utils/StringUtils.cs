using System;
using System.Collections.Generic;
using System.Linq;

namespace Koans.Utils
{
    public static class StringUtils
    {
        public static Func<object, object[],object> reset = ((s,p) => "Please Fill in the Blank");
        public static Func<object, object[], object> call = reset;
				
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
        	var r = call((object) s,null);
        	return (String)r;
        }

    	public static object ___(this Object o)
        {
    		var r = call(o,null);
    		return r;
        }
        public static object ____<T>(this IObservable<T> o, Action<T> action)
        {
            return call(o, new []{action});
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