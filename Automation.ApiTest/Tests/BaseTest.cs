using Automation.Core.Helpers;
using RestSharp;

namespace Automation.ApiTest.Tests
{
    [TestClass]
    public class BaseTest
    {
        protected RestClient client;
        protected string mockDataFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\MockData\mock_data.json");
        protected int randomPage = new Random().Next(1,3);
        protected int randomUserId = new Random().Next(1,7);

        [TestInitialize]
        public void SetupRestClient()
        {
            client = new RestClient(ConfigurationHelper.GetValue<string>("reqResUrl"));
        }
    }
}
