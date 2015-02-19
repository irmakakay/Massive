using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Massive.Model;
using Massive.DataService.Interface;
using Massive.Data;
using System.Configuration;

namespace Massive.DataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MassiveDataService : IMassiveDataService
    {
        private readonly DbContext _context = 
            new DbContext(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);

        public Graph GetGraph()
        {
            throw new NotImplementedException();
        }

        public void SaveGraph(Graph graph)
        {
            throw new NotImplementedException();
        }
    }
}
