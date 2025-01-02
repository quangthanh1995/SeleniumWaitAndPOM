using Newtonsoft.Json;
using RestSharp;

namespace Automation.Core.Helpers
{
    public class ApiHelper
    {
        private static RestClient _client;

        public static RestClient GetClient()
        {
            if (_client == null)
            {
                _client = new RestClient(ConfigurationHelper.GetValue<string>("reqResUrl"));
            }
            return _client;
        }

        public static RestRequest CreateRequest(string endpoint, Method method) {
            var request = new RestRequest(endpoint, method);
            request.AddHeader("Content-Type", "application/json");
            return request;
        }

        public static RestRequest UpdateRequest(string endpoint, object body) {
            var request = CreateRequest(endpoint, Method.Put);
            request.AddJsonBody(body);
            return request;
        }

        public static RestRequest DeleteRequest(string endpoint) {
            return CreateRequest(endpoint, Method.Delete);
        }
    }
}
