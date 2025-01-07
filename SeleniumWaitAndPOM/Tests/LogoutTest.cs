using SeleniumWaitAndPOM.Pages;

namespace SeleniumWaitAndPOM.Tests
{
    [TestClass]
    public class LogoutTest : BaseTest
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        [TestInitialize]
        public void SetUpLogoutTest()
        {
            // init pages
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
        }


        [TestMethod("TC03: Test the logout function")]
        public void  Verify_Logout_Test()
        {
            // Step of pre-condition
            loginPage.WaitForButtonLogin();
            loginPage.Login(username, password);

            // Step 1: Click the button Logout
            dashboardPage.WaitForUserAreaDropdown();
            dashboardPage.ClickButtonLogout();

            // Step 2: Verify if the current Url is containing auth/login
            currentUrl = driver.Url;
            Assert.IsTrue(currentUrl.Contains("auth/login"), $"Expected Url to contains 'auth/login', but found: {currentUrl}");

            // log logout info to the report
            reportHelper.LogMessage("Info", "Verify the function logout");
        }
    }
}
