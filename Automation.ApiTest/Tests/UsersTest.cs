using System.Net;
using Automation.ApiTest.Models;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;

namespace Automation.ApiTest.Tests
{
    [TestClass]
    public class UsersTest : BaseTest
    {
        [TestMethod("TC-001: Verify get list of user by page successfully")]
        public void Verify_Get_List_User_By_Page()
        {
            var randomPage = new Random().Next(1, 2+1);
            var request = new RestRequest("/api/users?page=" + randomPage, Method.Get);

            RestResponse response = client.Execute<RestResponse>(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseData = JsonConvert.DeserializeObject<ListUsersModel>(response.Content);
            responseData.page.Should().Be(randomPage);
            responseData.data.Should().HaveCountGreaterThan(0);
        }

        [TestMethod("TC-002: Verify add new user successfully")]
        public void Verify_Create_User()
        {
            var requestBody = new AddUserRequestModel();
            requestBody.name = "thanh";
            requestBody.job = "dev";

            var request = new RestRequest("/api/users", Method.Post);
            request.AddJsonBody(requestBody);

            RestResponse response = client.Execute(request);
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var responseData = JsonConvert.DeserializeObject<AddUserResponseModel>(response.Content);
            responseData.name.Should().Be(requestBody.name);
            responseData.job.Should().Be(requestBody.job);

        }
    }
}
