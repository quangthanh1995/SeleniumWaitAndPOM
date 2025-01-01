
using Automation.WebDriver;
using OpenQA.Selenium;

namespace SeleniumWaitAndPOM.Pages
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver _driver) : base(_driver)
        {
            //
        }

        // web elements
        private IWebElement chartTimeAtWork => driver.FindElementByXPath("//div[@class='emp-attendance-chart']");
        private IWebElement userAreaDropdown => driver.FindElementByXPath("//div[@class='oxd-topbar-header-userarea']");
        private IWebElement logoutButton => driver.FindElementByXPath("//a[@href='/web/index.php/auth/logout']");
        private IWebElement mainMenuItemLeave => driver.FindElementByXPath("//a[@href='/web/index.php/leave/viewLeaveModule']");
        private IWebElement navTabConfigure => driver.FindElementByXPath("//*/span[text()='Configure ']");
        private IWebElement dropdownItemLeavePeriod => driver.FindElementByXPath("//a[text()='Leave Period']");
        private IWebElement dropdownItemLeaveTypes => driver.FindElementByXPath("//a[text()='Leave Types']");
        private IWebElement dropdownItemWorkWeek => driver.FindElementByXPath("//a[text()='Work Week']");
        private IWebElement dropdownItemHolidays => driver.FindElementByXPath("//a[text()='Holidays']");

        // methods that interact with elements
        public bool IsChartTimeAtWorkDisplay()
        {
            return chartTimeAtWork.Displayed;
        }

        public void clickMainMenuItemLeave()
        {
            mainMenuItemLeave.Click();
        }

        public void WaitForNavTabConfigure()
        {
            driver.WaitForElement(navTabConfigure);
        }

        public void HoverOverNavTabConfigure()
        {
            driver.HoverOverElement(navTabConfigure);
        }

        public void GoBackToLeavePage()
        {
            mainMenuItemLeave.Click();
        }

        public void WaitForChartTimeAtWork()
        {
            driver.WaitForElement(chartTimeAtWork);
        }

        public void WaitForUserAreaDropdown()
        {
            driver.WaitForElement(userAreaDropdown);
        }

        public void clickNavTabConfigure()
        {
            navTabConfigure.Click();
        }

        public void clickDropdownItemLeavePeriod()
        {
            dropdownItemLeavePeriod.Click();
        }

        public void clickDropdownItemLeaveTypes()
        {
            dropdownItemLeaveTypes.Click();
        }

        public void clickDropdownItemWorkWeek()
        {
            dropdownItemWorkWeek.Click();
        }

        public void clickDropdownItemHolidays()
        {
            dropdownItemHolidays.Click();
        }

        public void ClickButtonLogout()
        {
            userAreaDropdown.Click();
            logoutButton.Click();
        }
    }
}
