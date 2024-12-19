using OpenQA.Selenium.Support.UI;
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

        [TestMethod]
        public void  Verify_Logout_Test()
        {
            // maximize browser window
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            var loginPage = new LoginPage(driver);
            loginPage.EnterUsernameAndPassword("Admin", "admin123");
            loginPage.ClickButtonLogin();

            var dashboardPage = new DashboardPage(driver);
            dashboardPage.ClickLogoutButton();

        }

    }
}
