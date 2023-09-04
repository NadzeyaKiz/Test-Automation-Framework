using Newtonsoft.Json;

namespace TestAutomation.Utilities
{
    public static class JsonParser
    {
        public static T DeserializeJsonToObject<T>(string json) where T : class => JsonConvert.DeserializeObject<T>(json);

        public static List<T> DeserializeJsonToList<T>(string json) where T : class => JsonConvert.DeserializeObject<List<T>>(json);

        public static string SerializeJson(object content) => JsonConvert.SerializeObject(content);
    }
}