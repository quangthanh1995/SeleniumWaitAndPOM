
using OpenQA.Selenium;

namespace SeleniumWaitAndPOM.Pages
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver _driver) : base(_driver)
        {
        }

        // web element
        private IWebElement chartTimeAtWork => driver.FindElement(By.XPath("//div[@class='emp-attendance-chart']"));

        private IWebElement userAreaDropdown => driver.FindElement(By.XPath("//div[@class='oxd-topbar-header-userarea']"));

        private IWebElement logoutButton => driver.FindElement(By.XPath("//a[@href='/web/index.php/auth/logout']"));

        // method interact with element
        public bool IsChartTimeAtWorkDisplay()
        {
            return chartTimeAtWork.Displayed;
        }

        public void ClickLogoutButton()
        {
            userAreaDropdown.Click();
            logoutButton.Click();
        }
    }
}
