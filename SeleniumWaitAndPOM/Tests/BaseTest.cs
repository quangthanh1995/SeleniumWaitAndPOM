using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWaitAndPOM.Pages;

namespace SeleniumWaitAndPOM.Tests
{
    [TestClass]
    public class BaseTest
    {
        protected static IWebDriver driver;

        [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
        public static void SetupAndOpenDriver(TestContext testContext)
        {

            // init driver
            driver = new ChromeDriver();

            // set implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [ClassCleanup(InheritanceBehavior.BeforeEachDerivedClass)]
        public static void Cleanup()
        {
            driver.Quit();
        }
    }
}
