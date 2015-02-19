using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace Massive.Data
{
    public static class Extensions
    {
        public static IQueryable<T> AsQueryable<T>(this MongoCollection<T> collection)
        {
            return collection.AsQueryable();             
        }
    }
}
