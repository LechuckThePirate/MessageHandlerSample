using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageHandlerSample
{
    public static class Utils
    {
        public static void ForEach<T>(this IEnumerable<T> ienumerable, Action<T> action)
        {
            ienumerable.ToList().ForEach(action);
        }
    }
}
