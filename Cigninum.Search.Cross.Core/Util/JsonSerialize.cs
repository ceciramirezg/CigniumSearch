using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Cigninum.Search.Cross.Core.Util
{
    public static class JsonSerialize
    {
        public static T JsonToObject<T>(this string jsonText)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonText)))
            {
                // Deserialization from JSON  
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
                return (T)deserializer.ReadObject(ms);              
            }

        }
    }
}
