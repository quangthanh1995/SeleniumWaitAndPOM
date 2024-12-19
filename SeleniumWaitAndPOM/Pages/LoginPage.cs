using OpenQA.Selenium;

namespace SeleniumWaitAndPOM.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver _driver) : base(_driver)
        {
        }

        // web element
        private IWebElement inputUsername => driver.FindElement(By.XPath("//input[@name='username']"));

        private IWebElement inputPassword => driver.FindElement(By.XPath("//input[@name='password']"));

        private IWebElement buttonLogin => driver.FindElement(By.XPath("//button[contains(., 'Login')]"));

        // method interact
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

        public void EnterUsernameAndPassword(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
        }
    }
}
