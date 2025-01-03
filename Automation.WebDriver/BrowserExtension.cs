using Automation.Core.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Automation.WebDriver
{
    public static class BrowserExtension
    {
        public static void Go(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void GoBack(this IWebDriver driver)
        {
            driver.Navigate().Back();
        }

        public static IWebElement FindElementByXPath(this IWebDriver driver, string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }

        public static bool WaitForElement(this IWebDriver driver, IWebElement element)
        {
            var explicitTimeout = ConfigurationHelper.GetValue<int>("explicitTimeout");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(explicitTimeout));
            return wait.Until(d => element.Displayed);
        }

        public static void HoverOverElement(this IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }
    }
}
