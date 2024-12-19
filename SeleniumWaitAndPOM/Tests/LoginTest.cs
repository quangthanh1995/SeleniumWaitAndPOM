using FluentAssert;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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

        [TestMethod]
        public void Verify_Login_Test()
        {
            // maximize browser window
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");


            // Type username and password
            loginPage.EnterUsernameAndPassword("Admin", "admin123");

            // click button Login
            loginPage.ClickButtonLogin();

            // verify url
            driver.Url.ShouldContain("dashboard/index");

            // verify chart display time
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //wait.Until(d => driver.FindElement(By.XPath("//div[@class='emp-attendance-chart']")).Displayed);
            wait.Until(d => dashboardPage.IsChartTimeAtWorkDisplay());
        }
    }
}
