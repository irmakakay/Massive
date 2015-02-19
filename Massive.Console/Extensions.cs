using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive.Console
{
    public static class Extensions
    {
        public static void Assert(this string self)
        {
            if (string.IsNullOrEmpty(self)) throw new InvalidOperationException("Source folder not defined!");
        }
    }
}
