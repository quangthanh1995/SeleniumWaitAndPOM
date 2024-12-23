using SeleniumWaitAndPOM.Pages;

namespace SeleniumWaitAndPOM.Tests
{
    [TestClass]
    public class DashboardTest : BaseTest
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        [TestInitialize]
        public void SetupDashboardTest()
        {
            // init pages
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
        }

        [TestMethod]
        public void Verify_Leave_Configure_Test()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("Admin", "admin123");

            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/leave/viewLeaveList");
            DashboardPage dashboard = new DashboardPage(driver);
            dashboardPage.clickNavTabConfigure();
        }
    }
}
