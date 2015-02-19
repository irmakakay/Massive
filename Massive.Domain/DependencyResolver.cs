using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

using Massive.Model;

namespace Massive.Domain
{
    public class DependencyResolver
    {
        private readonly Dictionary<int, HashSet<INode>> _lookup = new Dictionary<int, HashSet<INode>>();

        private readonly HashSet<INode> _set = new HashSet<INode>();

        private readonly IEnumerable<XElement> _nodes;

        public IGraph Graph { get; private set; }

        public DependencyResolver(IEnumerable<XElement> nodes, IGraph graph)
        {
            _nodes = nodes;

            Graph = graph;
        }

        public void Resolve()
        {            
            if (!_nodes.All(n => _set.Add(Create(n))))
            {
                throw new InvalidOperationException("Invalid input data!");
            }

            _set.ForEach(e =>
            {
                if (_lookup.ContainsKey(e._id))
                {
                    _lookup[e._id].ForEach(a => Graph.AddUndirectedEdge(a, e));
                }
                Graph.AddNode(e);
            });            
        }

        private INode Create(XElement element)
        {
            var node = new GraphNode
            {
                _id = Int32.Parse(element.XPathSelectElement("./id").Value),
                Label = element.XPathSelectElement("./label").Value
            };

            element.XPathSelectElements("./adjacentNodes/id")
                .ForEach(e =>
                    {
                        var id = Int32.Parse(e.Value);

                        HashSet<INode> hs;
                        if (_lookup.TryGetValue(id, out hs))
                        {
                            hs.Add(node);
                        }
                        else
                        {
                            _lookup.Add(id, new HashSet<INode>(new[] { node }));
                        }
                    });

            return node;
        }
    }
}
