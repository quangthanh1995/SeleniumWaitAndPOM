using SeleniumWaitAndPOM.Pages;

namespace SeleniumWaitAndPOM.Tests
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        [TestInitialize]
        public void SetupLoginTest()
        {
            // init pages
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
        }

        [TestMethod("TC01: Login with valid user")]
        public void Verify_Login_Test()
        {
            // Step 1: Type username and password
            loginPage.Login(username, password);

            // Step 2: Verify the current Url
            string currentUrl = driver.Url;
            Assert.IsTrue(currentUrl.Contains("dashboard/index"), $"Expected Url to contains 'dashboard/index', but found: {currentUrl}");

            // Step 3: Verify if the emp attendance chart is displayed
            //driver.WaitForElement(dashboardPage.empAttendanceChartLocator, 20);
            dashboardPage.WaitForChartTimeAtWork();

            // log login info to the report
            reportHelper.LogMessage("Info", "Login with username: " + username);
            reportHelper.LogMessage("Info", "Login with password: " + password);
        }

        [TestMethod("TC02: Login with invalid user")]
        public void Verify_Login_Failed_Test()
        {
            // Step 1: Type username and a wrong password
            loginPage.Login(username, wrongPassword);

            // Step 2: Verify the current Url
            string currentUrl = driver.Url;
            Assert.IsFalse(currentUrl.Contains("dashboard/index"), $"Expected Url to contains 'dashboard/index', but found: {currentUrl}");
        }
    }
}
