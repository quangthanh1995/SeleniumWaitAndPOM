
using Automation.WebDriver;
using OpenQA.Selenium;
//using OpenQA.Selenium.Interactions;

namespace SeleniumWaitAndPOM.Pages
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver _driver) : base(_driver)
        {
        }

        // web elements
        private IWebElement chartTimeAtWork => driver.FindElementByXPath("//div[@class='emp-attendance-chart']");

        private IWebElement userAreaDropdown => driver.FindElementByXPath("//div[@class='oxd-topbar-header-userarea']");

        public By userAreaDropdownLocator => By.XPath("//div[@class='oxd-topbar-header-userarea']");

        private IWebElement logoutButton => driver.FindElementByXPath("//a[@href='/web/index.php/auth/logout']");

        private IWebElement mainMenuItemLeave => driver.FindElementByXPath("//a[@href='/web/index.php/leave/viewLeaveModule']");

        public IWebElement navTabConfigure => driver.FindElementByXPath("//*/span[text()='Configure ']");

        public By navTabConfigureLocator => By.XPath("//*/span[text()='Configure ']");

        public By empAttendanceChartLocator => By.XPath("//div[@class='emp-attendance-chart']");

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

        // use Actions to simulate mouse hovering
        //public void hoverNavTabConfigure()
        //{
        //    Actions actions = new Actions(driver);
        //    actions.MoveToElement(navTabConfigure).Perform();
        //}

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

        public void ClickLogoutButton()
        {
            userAreaDropdown.Click();
            logoutButton.Click();
        }
    }
}
