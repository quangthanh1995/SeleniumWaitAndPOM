using OpenQA.Selenium;
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
            WebDriverWait waitForLogin = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitForLogin.Until(d => driver.FindElement(By.XPath("//button[contains(., 'Login')]")).Displayed);

            loginPage.Login("Admin", "admin123");

            var dashboardPage = new DashboardPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d => driver.FindElement(By.XPath("//div[@class='oxd-topbar-header-userarea']")).Displayed);
            dashboardPage.ClickLogoutButton();

        }

    }
}
