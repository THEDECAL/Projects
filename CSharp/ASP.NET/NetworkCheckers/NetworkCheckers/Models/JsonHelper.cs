using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace NetworkCheckers.Models
{
    static public class JsonHelper
    {
        static public string Serialize<T>(T @object)
        {
            using (var ms = new MemoryStream())
            {
                //var serializer = new DataContractJsonSerializer(typeof(T));
                //serializer.WriteObject(ms, @object);

                var text = JsonConvert.SerializeObject(@object);

                return text;
            }
        }
        static public T Deserialize<T>(string text)
        {
            var deserializer = JsonConvert.DeserializeObject(text);

            return (T)deserializer;
        }
    }
}