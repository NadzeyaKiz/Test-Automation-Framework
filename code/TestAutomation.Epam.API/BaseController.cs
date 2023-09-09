using Newtonsoft.Json;
using RestSharp;


namespace TestAutomation.Epam.API
{
    public class BaseController
    {
        private readonly RestClient _restClient;
        public BaseController (CustomRestClient client, Service service, string apiKey = "")
        {
            _restClient = client.CreateRestClient(service);
           if (service == Service.Bibles)
            {
                _restClient.AddDefaultHeader("api-key", apiKey);
            }
        }
        protected (RestResponse Response, T ResponceModel) Get<T>(string resource)
        {
            var request = new RestRequest(resource, Method.Get);
            var responce = _restClient.ExecuteGet(request);

            return (typeof(T) == typeof(RestResponse))
                ? (responce, default)
                : (responce, GetDeserializedView<T>(responce));
        }

        private T? GetDeserializedView<T>(RestResponse responce) 
        {
            return JsonConvert.DeserializeObject<T>(responce.Content);
        }
    }
}
