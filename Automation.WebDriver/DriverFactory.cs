using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Automation.WebDriver
{
    public static class DriverFactory
    {
        public static IWebDriver InitBrowser(string browserType, int timeout)
        {
            IWebDriver driver;

            switch (browserType)
            {
                case "CHROME":
                    driver = new ChromeDriver();
                    break;
                case "FIREFOX":
                    driver = new FirefoxDriver();
                    break;
                case "EDGE":
                    driver = new EdgeDriver();
                    break;
                default:
                    throw new Exception("This browser is not supported.");
            }

            // set implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
