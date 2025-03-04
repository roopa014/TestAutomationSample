using OpenQA.Selenium;
using TestAutomation.Utils;

namespace TestAutomation.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private By signInButton = By.XPath("//a[contains(text(),'Sign In')]");
        private By usernameField = By.Id("email");
        private By passwordField = By.Id("pass");
        private By loginButton = By.Id("send2");
        private By errorMessageLocator = By.CssSelector(".message-error.error.message");
        private By accountMenu = By.CssSelector("a[href*='customer/account']");
        private By errorMessageEmail = By.Id("email-error");

        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public void Login(string username, string password)
        {
            Helper.Click(driver, signInButton,20);
            Helper.SendKeys(driver, usernameField,username);
            Helper.SendKeys(driver, passwordField,password);
            Helper.Click(driver, loginButton, 20);
        }

        public string GetLoginErrorMessage()
        {
            if (Helper.IsElementPresent(driver, errorMessageLocator))
                return driver.FindElement(errorMessageLocator).Text;
            return string.Empty;
        }

        public string GetLoginErrorMessageForEmail()
        {
            if (Helper.IsElementPresent(driver, errorMessageEmail))
                return driver.FindElement(errorMessageEmail).Text;
            return string.Empty;
        }

        public void ValidateHomePage()
        {
            if (!Helper.IsElementPresent(driver, accountMenu))
                throw new Exception("Home page validation failed: account menu not found.");
        }


    }
}
