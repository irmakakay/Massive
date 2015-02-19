using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Massive.Model;
using Massive.Infrastructure;
using Massive.DataService.Lib;

namespace Massive.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new DataReader(new ReaderConfiguration(), new Serializer());            

            var task = new ImportTask<GraphNode>(new ImportConfiguration(), 
                new ServiceChannel<IMassiveDataService>(), reader);

            Run(task);
        }

        private static void Run(ITask task)
        {
            try
            {
                task.Run();

                if (task.Errors.Any()) throw new AggregateException(task.Errors);
            }
            catch (Exception ex)
            {
                // log the fatal exception
                throw;
            }
        }
    }
}
