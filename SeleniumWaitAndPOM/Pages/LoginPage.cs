using Automation.WebDriver;
using OpenQA.Selenium;

namespace SeleniumWaitAndPOM.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver _driver) : base(_driver)
        {
        }

        // web elements
        private IWebElement inputUsername => driver.FindElementByXPath("//input[@name='username']");

        private IWebElement inputPassword => driver.FindElementByXPath("//input[@name='password']");

        private IWebElement buttonLogin => driver.FindElementByXPath("//button[contains(., 'Login')]");

        public By buttonLoginLocator => By.XPath("//button[contains(., 'Login')]");

        // interact methods
        public void EnterUsername(string username)
        {
            inputUsername.SendKeys(username);
        }

        public void EnterPassword(string password) {
            inputPassword.SendKeys(password);
        }

        public void ClickButtonLogin()
        {
            buttonLogin.Click();
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickButtonLogin();
        }
    }
}
