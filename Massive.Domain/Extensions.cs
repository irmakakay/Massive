using System;
using System.Collections.Generic;
using System.Linq;

namespace Massive.Domain
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var s in self) action(s);
        }

        public static void ForEach<T>(this HashSet<T> self, Action<T> action)
        {
            foreach (var s in self) action(s);
        }
    }
}
