using SeleniumWaitAndPOM.Pages;

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
            //dashboardPage.hoverNavTabConfigure();
            dashboardPage.HoverOverNavTabConfigure();

            // Step 4: Click on the nav tab "Configure"
            dashboardPage.clickNavTabConfigure();

            // Step 5: Click on the dropdown item "Leave Period"
            dashboardPage.clickDropdownItemLeavePeriod();

            // Step 6: Go back to View Leave List screen
            dashboardPage.GoBackToLeavePage();

            // Step 7: Click on the nav tab "Configure"
            dashboardPage.clickNavTabConfigure();

            // Step 8:  Click on dropdown menu item "Leave Types"
            dashboardPage.clickDropdownItemLeaveTypes();

            // Step 9: Go back to View Leave List screen
            dashboardPage.GoBackToLeavePage();

            // Step 10: Click on the nav tab "Configure"
            dashboardPage.clickNavTabConfigure();

            // Step 11:  Click on dropdown menu item "Work Week"
            dashboardPage.clickDropdownItemWorkWeek();

            // Step 12: Go back to View Leave List screen
            dashboardPage.GoBackToLeavePage();

            // Step 13: Click on the nav tab "Configure"
            dashboardPage.clickNavTabConfigure();

            // Step 14:  Click on dropdown menu item "Holidays"
            dashboardPage.clickDropdownItemHolidays();

            // Step 15: Go back to View Leave List screen
            dashboardPage.GoBackToLeavePage();
        }
    }
}
