using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Massive.Model
{
    public interface ILabel
    {
        string Label { get; }
    }

    public interface INode : ILabel
    {
        int _id { get; }

        List<INode> AdjacentNodes { get; }
    }  

    [DataContract(Name = "node", Namespace = "")]
    public class GraphNode : INode, IEquatable<INode>
    {
        [DataMember(Name="id")]
        public int _id { get; set; }

        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name = "adjacentNodes")]
        public List<INode> AdjacentNodes { get; set; }

        public GraphNode()
        {
            AdjacentNodes = new List<INode>(4);
        }

        public bool Equals(INode other)
        {
            return _id == other._id;
        }

        public override bool Equals(object obj)
        {
            var other = obj as INode;

            if (other == null) return false;

            return Equals(other);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        
    }    
}
