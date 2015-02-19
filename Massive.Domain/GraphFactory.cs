using System;
using System.Collections.Generic;
using System.Linq;

using Massive.Model;

namespace Massive.Domain
{
    public interface IGraphFactory
    {
        IGraph Create();
    }

    public class GraphFactory : IGraphFactory
    {        
        private readonly DependencyResolver _resolver;

        public GraphFactory(DependencyResolver resolver)
        {            
            _resolver = resolver;
        }

        public IGraph Create()
        {
            _resolver.Resolve();

            return _resolver.Graph;
        }           
    }
}
