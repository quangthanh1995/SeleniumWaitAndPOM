using Automation.Core.Helpers;
using Automation.WebDriver;
using OpenQA.Selenium;

namespace SeleniumWaitAndPOM.Tests
{
    [TestClass]
    public class BaseTest
    {
        protected IWebDriver driver;

        // report helper
        protected ReportHelper reportHelper;

        // test context
        public TestContext TestContext { get; set; }

        // retrieve data from Configuration Helper
        protected string loginUrl = ConfigurationHelper.GetValue<string>("loginUrl");
        protected string username = ConfigurationHelper.GetValue<string>("username");
        protected string password = ConfigurationHelper.GetValue<string>("password");
        protected string wrongPassword = ConfigurationHelper.GetValue<string>("wrongPassword");

        public virtual void SetupPageObject()
        {
            //
        }

        [TestInitialize]
        public void SetupAndOpenDriver()
        {
            // Step 1: Read configuration and init browser
            string browserType = ConfigurationHelper.GetValue<string>("browser");
            int timeout = ConfigurationHelper.GetValue<int>("timeout");
            driver = DriverFactory.InitBrowser(browserType, timeout);

            // Step 2: Navigate to the login url
            driver.Go(loginUrl);

            // Step 3: Setup page object
            SetupPageObject();

            // init report helper
            reportHelper = new ReportHelper();

            // get test context description
            var testMethod = TestContext?.TestName;
            var method = GetType().GetMethods().FirstOrDefault(m => m.GetCustomAttributes(typeof(TestMethodAttribute), false).Any() && m.Name == testMethod);
            var testMethodAttribute = method.GetCustomAttributes(typeof(TestMethodAttribute), false).Cast<TestMethodAttribute>().FirstOrDefault();
            string testDescription = testMethodAttribute?.DisplayName ?? method.Name;

            // create test case
            reportHelper.CreateTestCase(TestContext.TestName, testDescription);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // if test failed, take screenshot
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                string imgBase64 = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                reportHelper.LogMessage("Fail", "Test case failed!!!", imgBase64);
            }
            else if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
            {
                reportHelper.LogMessage("Pass", "Test case passed!!!");
            }

            // close driver
            driver.Quit();

            // export report to Spark html file
            reportHelper.ExportReport();
        }
    }
}
