using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Massive.Model;
using Massive.Infrastructure;
using System.Xml;
using System.Xml.Linq;


namespace Massive.Console
{
    public interface IReader
    {
        IEnumerable<XElement> Read();
    }

    public class DataReader : IReader
    {
        private readonly IReaderConfiguration _configuration;

        private readonly ISerializer _serializer;

        public DataReader(IReaderConfiguration configuration, ISerializer serializer)
        {
            _configuration = configuration;

            _serializer = serializer;
        }

        public IEnumerable<XElement> Read()
        {                        
            return SourceFiles.Select(s => s.OpenText().ToXElement());            
        }

        #region Helpers

        private IEnumerable<FileInfo> SourceFiles
        {
            get 
            {
                _configuration.SourceFolder.Assert();

                return new DirectoryInfo(_configuration.SourceFolder).GetFiles();                
            }
        }

        #endregion
    }
}
