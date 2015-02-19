using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Massive.Model;
using Massive.Infrastructure;


namespace Massive.Domain
{
    public class BreadthFirstTraversePolicy : ITraversePolicy
    {
        private readonly IGraph _graph;

        private readonly Queue<INode> _queue = new Queue<INode>();

        private readonly HashSet<INode> _visited = new HashSet<INode>();

        public BreadthFirstTraversePolicy(IGraph graph)
        {
            _graph = graph;
        }

        public IEnumerable<INode> Traverse(INode start)
        {
            _queue.Enqueue(start);

            while (_queue.Any())
            {
                var n = _queue.Dequeue();

                if (!_visited.Add(n)) continue;

                yield return n;

                var neighbors = _graph.GetAdjacentNodes(n)
                                        .Where(nb => !_visited.Contains(nb));

                _queue.EnqueueRange(neighbors);
            }

        }
    }
}
