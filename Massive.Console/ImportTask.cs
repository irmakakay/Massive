using System;
using System.Collections.Generic;
using System.Linq;
using Massive.Infrastructure;
using Massive.Model;
using Massive.Domain;

namespace Massive.Console
{
    public interface ITask
    {
        List<Exception> Errors { get; }

        void Run();
    }

    public class ImportTask<T> : ITask where T : INode
    {
        private readonly IImportConfiguration _configuration;

        private readonly IReader _reader;

        private readonly List<Exception> _errors = new List<Exception>();

        public ImportTask(IImportConfiguration configuration, IReader reader)
        {
            _configuration = configuration;

            _reader = reader;
        }

        public List<Exception> Errors { get { return _errors; } }

        public void Run()
        {
            try
            {                
                var resolver = new DependencyResolver(_reader.Read(), new Graph());

                var factory = new GraphFactory(resolver);

                var graph = factory.Create();
            }
            catch (Exception ex)
            {
                _errors.Add(ex);                
            }
        }
    }
}
