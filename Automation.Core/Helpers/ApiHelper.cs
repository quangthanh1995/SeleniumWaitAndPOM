using Newtonsoft.Json;
using RestSharp;

namespace Automation.Core.Helpers
{
    public class ApiHelper
    {
        public static RestRequest CreateRequest(string endpoint, Method method) {
            var request = new RestRequest(endpoint, method);
            request.AddHeader("Content-Type", "application/json");
            return request;
        }

        public static RestRequest GetUserWithIdRequest(string endpoint, Method method)
        {
            var request = new RestRequest(endpoint, method);
            return request;
        }

        public static RestRequest AddUserRequest(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            return request;
        }

        public static RestRequest UpdateUserRequest(string endpoint, object body) {
            var request = CreateRequest(endpoint, Method.Put);
            request.AddJsonBody(body);
            return request;
        }

        public static RestRequest DeleteUserRequest(string endpoint) {
            return CreateRequest(endpoint, Method.Delete);
        }
    }
}
