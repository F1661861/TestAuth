using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestAuth.Infrastructrue
{
    /// <summary>
    /// json序列化帮助类
    /// </summary>
    public class JsonHelper
    {
        public static JsonHelper Instance { get; } = new JsonHelper();

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
        }

        public T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}
