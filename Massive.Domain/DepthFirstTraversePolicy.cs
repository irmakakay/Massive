using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Massive.Model;
using Massive.Infrastructure;

namespace Massive.Domain
{
    public interface ITraversePolicy
    {
        IEnumerable<INode> Traverse(INode start);
    }

    public class DepthFirstTraversePolicy : ITraversePolicy
    {
        private readonly IGraph _graph;

        private readonly Stack<INode> _stack = new Stack<INode>();

        private readonly HashSet<INode> _visited = new HashSet<INode>();

        public DepthFirstTraversePolicy(IGraph graph)
        {
            _graph = graph;
        }

        public IEnumerable<INode> Traverse(INode start)
        {
            _stack.Push(start);

            while (_stack.Any())
            {
                var n = _stack.Pop();

                if (!_visited.Add(n)) continue;

                yield return n;

                var neighbors = _graph.GetAdjacentNodes(n)
                                        .Where(nb => !_visited.Contains(nb));

                _stack.PushRange(neighbors);
            }
        }
    }

    
}
