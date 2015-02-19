using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;


namespace Massive.Infrastructure
{
    public static class Extensions
    {
        public static void PushRange<T>(this Stack<T> self, IEnumerable<T> range)
        {
            foreach (var r in range) self.Push(r);
        }

        public static XElement ToXElement(this StreamReader self)
        {
            return XElement.Parse(self.ReadToEnd());
        }
    }
}
