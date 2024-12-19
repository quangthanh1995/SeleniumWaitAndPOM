using OpenQA.Selenium;

namespace SeleniumWaitAndPOM.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver _driver)
        {
            driver = _driver;
        }
    }
}
