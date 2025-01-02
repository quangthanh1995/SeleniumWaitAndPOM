using System.Net;
using Automation.ApiTest.Models;
using Automation.Core.Helpers;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;

namespace Automation.ApiTest.Tests
{
    [TestClass]
    public class UsersTest : BaseTest
    {
        string mockDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\MockData\mock_data.json");

        [TestMethod("TC-API-01: Verify get list of user by page successfully")]
        public void Verify_Get_List_User_By_Page()
        {
            var randomPage = new Random().Next(1, 2 + 1);
            var request = new RestRequest("/api/users?page=" + randomPage, Method.Get);

            RestResponse response = client.Execute<RestResponse>(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseData = JsonConvert.DeserializeObject<ListUsersModel>(response.Content);
            responseData.page.Should().Be(randomPage);
            responseData.data.Should().HaveCountGreaterThan(0);
        }

        [TestMethod("TC-API-02: Verify add new user successfully")]
        public void Verify_Create_User()
        {

            var requestBody = MockDataHelper.LoadMockData(mockDataFilePath, "createUser");

            var addUserRequest = new AddUserRequestModel
            {
                name = requestBody.name,
                job = requestBody.job,
            };

            var request = ApiHelper.CreateRequest("/api/users", Method.Post);
            request.AddJsonBody(addUserRequest);

            RestResponse response = client.Execute<RestResponse>(request);
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var responseData = JsonConvert.DeserializeObject<AddUserResponseModel>(response.Content);
            responseData.name.Should().Be(addUserRequest.name);
            responseData.job.Should().Be(addUserRequest.job);
        }

        [TestMethod("TC-API-03: Verify update user successfully")]
        public void Verify_Update_User()
        {
            var requestBody = MockDataHelper.LoadMockData(mockDataFilePath, "updateUser");

            var updateUserRequest = new UpdateUserRequestModel
            {
                name = requestBody.name,
                job = requestBody.job,
            };

            var request = ApiHelper.UpdateRequest("/api/users/2", updateUserRequest);
            RestResponse response = client.Execute<RestResponse>(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseData = JsonConvert.DeserializeObject<UpdateUserResponseModel>(response.Content);
            responseData.name.Should().Be(updateUserRequest.name);
            responseData.job.Should().Be(updateUserRequest.job);
        }

        [TestMethod("TC-API-04: Verify delete user successfully")]
        public void Verify_Delete_User()
        {
            var request = ApiHelper.DeleteRequest("/api/user/2");
            RestResponse response = client.Execute<RestResponse>(request);
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
