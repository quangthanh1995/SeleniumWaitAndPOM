using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWaitAndPOM.Pages;

namespace SeleniumWaitAndPOM.Tests
{
    [TestClass]
    public class BaseTest
    {
        protected IWebDriver driver;

        public virtual void SetupPageObject()
        {
            //
        }

        [TestInitialize]
        public void SetupAndOpenDriver()
        {

            // init driver
            driver = new ChromeDriver();

            // maximize browser window
            driver.Manage().Window.Maximize();

            // set implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            // setup page object
            SetupPageObject();

        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
