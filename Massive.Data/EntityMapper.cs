using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Massive.Model;

namespace Massive.Data
{
    public class EntityMapper
    {
        public EntityMapper()
        {
            RegisterType<GraphNode>();
            RegisterType<Graph>();
        }

        internal void RegisterType<T>() where T : IMappable
        {
            BsonClassMap.RegisterClassMap<T>(cm =>
                {
                    cm.MapIdField(c => c.Id);                    
                });
        }
    }
}
