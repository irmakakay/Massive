using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Massive.DataService.Lib;

namespace Massive.Console
{
    public interface IServiceChannel<T>
    {
        T ServiceClient { get; }

        void Close();
    }

    public class ServiceChannel<T> : IServiceChannel<T>
    {
        private readonly ChannelFactory<T> _channelFactory;

        public ServiceChannel()
        {
            var factory = new ChannelFactory<T>("*");

            _channelFactory = new ChannelFactory<T>();
        }

        public T ServiceClient
        {
            get { return _channelFactory.CreateChannel(); }
        }

        public void Close()
        {
            _channelFactory.Close();
        }
    }
}
