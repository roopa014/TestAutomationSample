using TestAutomation.Pages;
using TestAutomation.Utils;

namespace TestAutomation.Tests
{
    class LoginTest : BaseTest
    {
        private LoginPage? loginPage;
    
        
        [Test]
        public void Verify_Login_With_valid_Credentials()
        {
            loginPage = new LoginPage(driver);
            loginPage.Login(Config.Username, Config.Password);
            loginPage.ValidateHomePage();
        }

       
    }
}
