﻿using SeleniumWaitAndPOM.Pages;

namespace SeleniumWaitAndPOM.Tests
{
    [TestClass]
    public class DashboardTest : BaseTest
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        [TestInitialize]
        public void SetupDashboardTest()
        {
            // init pages
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
        }

        [TestMethod("TC04: Test the usability of the Leave>Configure menu")]
        [TestCategory("smoketest")]
        public void Verify_Leave_Configure_Test()
        {
            // Step of pre-condition
            loginPage.Login(username, password);

            // Step 1: Click on the main menu item "Leave"
            dashboardPage.clickMainMenuItemLeave();

            // Step 2: Click on the nav tab "Configure"
            dashboardPage.WaitForNavTabConfigure();

            // Step 3: Hover on the nav tab "Configure"
            dashboardPage.HoverOverNavTabConfigure();

            // Step 4: Click on the nav tab "Configure"
            dashboardPage.clickNavTabConfigure();

            // Step 5: Click on the dropdown item "Leave Period"
            dashboardPage.clickDropdownItemLeavePeriod();

            // Step 6: Verify the current Url should contain "leave/defineLeavePeriod"
            currentUrl = driver.Url;
            Assert.IsTrue(currentUrl.Contains("leave/defineLeavePeriod"), $"Expected Url to contain 'leave/defineLeavePeriod', but found: {currentUrl}");

            // Step 7: Go back to View Leave List screen
            dashboardPage.GoBackToLeavePage();

            // Step 8: Click on the nav tab "Configure"
            dashboardPage.clickNavTabConfigure();

            // Step 9:  Click on dropdown menu item "Leave Types"
            dashboardPage.clickDropdownItemLeaveTypes();

            // Step 10: Verify the current Url should contain "leave/defineLeavePeriod"
            currentUrl = driver.Url;
            Assert.IsTrue(currentUrl.Contains("leave/leaveTypeList"), $"Expected Url to contain 'leave/leaveTypeList', but found: {currentUrl}");

            // Step 11: Go back to View Leave List screen
            dashboardPage.GoBackToLeavePage();

            // Step 12: Click on the nav tab "Configure"
            dashboardPage.clickNavTabConfigure();

            // Step 13:  Click on dropdown menu item "Work Week"
            dashboardPage.clickDropdownItemWorkWeek();

            // Step 14: Verify the current Url should contain "leave/defineLeavePeriod"
            currentUrl = driver.Url;
            Assert.IsTrue(currentUrl.Contains("leave/defineWorkWeek"), $"Expected Url to contain 'leave/defineWorkWeek', but found: {currentUrl}");

            // Step 15: Go back to View Leave List screen
            dashboardPage.GoBackToLeavePage();

            // Step 16: Click on the nav tab "Configure"
            dashboardPage.clickNavTabConfigure();

            // Step 17:  Click on dropdown menu item "Holidays"
            dashboardPage.clickDropdownItemHolidays();

            // Step 18: Verify the current Url should contain "leave/defineLeavePeriod"
            currentUrl = driver.Url;
            Assert.IsTrue(currentUrl.Contains("leave/viewHolidayList"), $"Expected Url to contain 'leave/viewHolidayList', but found: {currentUrl}");

            reportHelper.LogMessage("Info", "Verify usability of Dashboard>Leave>Configure");
        }
    }
}
