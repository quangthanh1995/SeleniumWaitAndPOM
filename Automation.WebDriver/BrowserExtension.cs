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

        public static void WaitForElement(this IWebDriver driver, By locator, int? timeoutInSeconds = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds ?? 0));
            wait.Until(d => d.FindElement(locator).Displayed);
        }

        public static void HoverOverElement(this IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }
    }
}
