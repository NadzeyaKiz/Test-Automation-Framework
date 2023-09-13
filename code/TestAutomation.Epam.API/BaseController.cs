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

        protected (RestResponse response, T ) Get<T>(string resource)
        {
            var request = new RestRequest(resource, Method.Get);
            var response = _restClient.ExecuteGet(request);

            return (typeof(T) == typeof(RestResponse))
                ? (response, default)
                : (response, GetDeserializedView<T>(response));
        }


        protected (RestResponse response, T?) Post<T, TPayload>(string resource, TPayload payload) where TPayload : class
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddJsonBody(payload);

            var response = _restClient.ExecutePost(request);

            return (typeof(T) == typeof(RestResponse))
                ? (response, default)
                : (response, GetDeserializedView<T>(response));
        }

        private T? GetDeserializedView<T>(RestResponse response)
        {
            var resp = JsonConvert.DeserializeObject<T>(response.Content);
            return resp;
        }

    }
}
