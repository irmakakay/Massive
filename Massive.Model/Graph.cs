using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Massive.Model
{
    public interface IGraph
    {
        void AddUndirectedEdge(INode from, INode to);

        void AddNode(INode node);

        IEnumerable<INode> GetAdjacentNodes(INode from);
    }

    [DataContract(Namespace = "")]
    public class Graph : IGraph, IMappable
    {
        private readonly List<INode> _nodeList;

        public Graph(IList<INode> nodes = null)
        {
            _nodeList = new List<INode>();

            if (nodes != null) _nodeList.AddRange(nodes);
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }        

        [DataMember(Name = "nodes")]
        public List<INode> Nodes { get { return _nodeList; } }

        public IEnumerable<INode> GetAdjacentNodes(INode from)
        {
            var node = LocateNode(from);

            return node.AdjacentNodes;
        }

        public void AddNode(INode node)
        {
            _nodeList.Add(node);
        }

        public void AddUndirectedEdge(INode from, INode to)
        {
            from.AdjacentNodes.Add(to);

            to.AdjacentNodes.Add(from);
        }

        public INode LocateNode(INode node)
        {
            return _nodeList.FirstOrDefault(n => n.Id == node.Id);
        }

        public bool Contains(INode value)
        {
            return LocateNode(value) != null;
        }

        public bool RemoveNode(INode node)
        {
            var n = LocateNode(node);

            _nodeList.Remove(n);

            _nodeList.ForEach(i =>
                                  {
                                      var index = i.AdjacentNodes.IndexOf(node);

                                      if (index > -1)
                                      {
                                          i.AdjacentNodes.RemoveAt(index);
                                      }
                                  });

            return true;
        }       
    }
}
