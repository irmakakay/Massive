using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Massive.Console
{
    public interface IReaderConfiguration
    {
        string SourceFolder { get; }
    }

    public class ReaderConfiguration : IReaderConfiguration
    {
        public string SourceFolder
        {
            get { return ConfigurationManager.AppSettings["source"]; }
        }
    }
}
