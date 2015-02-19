using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Massive.Infrastructure
{
    public interface ISerializer
    {
        T Deserialize<T>(StreamReader reader);

        T Deserialize<T>(string xml);

        string Serialize<T>(T graph);
    }

    public class Serializer : ISerializer
    {
        public T Deserialize<T>(StreamReader reader)
        {
            return Deserialize<T>(reader.ReadToEnd());
        }

        public T Deserialize<T>(string xml)
        {
            var serializer = new DataContractSerializer(typeof(T));

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                return (T)serializer.ReadObject(stream);
        }

        public string Serialize<T>(T graph)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));

            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, graph);

                using (var reader = new StreamReader(stream))
                {
                    stream.Position = 0;

                    return reader.ReadToEnd();
                }
            }
        }
    }
}
