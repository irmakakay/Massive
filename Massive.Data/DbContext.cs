using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Shared;
using MongoDB.Bson;
using Massive.Model;

namespace Massive.Data
{
    public class DbContext
    {        
        private readonly MongoServer _server;

        private readonly MongoDatabase _store;

        public DbContext(string connectionString)
        {
            var builder = new MongoConnectionStringBuilder(connectionString);

            var client = new MongoClient(builder.ConnectionString);

            _server = client.GetServer();

            _store = _server.GetDatabase(builder.DatabaseName);            
        }

        public MongoCollection<IGraph> Graphs
        {
            get
            {
                return _store.GetCollection<IGraph>("graphs");
            }
        }
    }
}
