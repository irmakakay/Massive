using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Massive.DataService.Lib;

namespace Massive.DataService
{    
    public class Service : IService
    {
        private readonly IMassiveDataService _service = new MassiveDataService();        


    }
}
