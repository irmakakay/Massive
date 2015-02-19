using Massive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Massive.DataService.Lib
{    
    [ServiceContract]
    public interface IMassiveDataService
    {        
        [OperationContract]
        List<Graph> GetGraphs();

        [OperationContract]
        void SaveGraph(Graph graph);
    }
}
