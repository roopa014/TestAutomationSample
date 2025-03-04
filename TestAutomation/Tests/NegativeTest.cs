using TestAutomation.Pages;
using TestAutomation.Utils;

namespace TestAutomation.Tests
{
    class NegativeTest : BaseTest
    {
        private LoginPage loginPage;
        private ProductPage productPage;
        private CheckoutPage checkoutPage;

        [SetUp]
        public void TestSetup()
        {
            loginPage = new LoginPage(driver);
            productPage = new ProductPage(driver);
            checkoutPage = new CheckoutPage(driver);
        }

        [Test]
        public void Verify_Login_With_Invalid_Credentials()
        {
            loginPage = new LoginPage(driver);
            loginPage.Login("invaliduser@example.com", "WrongPassword");

            string errorMessage = loginPage.GetLoginErrorMessage();
            Assert.That(errorMessage, Does.Contain("The account sign-in was incorrect"), "Expected login error message not displayed.");
        }

        [Test]
        public void Verify_SQL_Injection_Attack()
        {
            loginPage.Login("admin' OR 1=1 --", "password");
            string errorMsg = loginPage.GetLoginErrorMessageForEmail();
            Assert.That(errorMsg, Does.Contain("Please enter "), "SQL injection vulnerability detected!");
        }

        [Test]
        public void Verify_Login_With_Empty_Credentials()
        {
            loginPage = new LoginPage(driver);
            loginPage.Login("", "");
            string errorMessage = loginPage.GetLoginErrorMessageForEmail();
            Assert.That(errorMessage, Does.Contain("required field"), "Expected login error message not displayed.");
        }

        [Test]
        public void Verify_XSSInjectionOnLogin()
        {
            // Use an XSS payload in the email field.
            loginPage.Login("<script>alert('XSS')</script>", "anyPassword");
            string errorMessage = loginPage.GetLoginErrorMessage();
            Assert.That(errorMessage, Does.Not.Contain("<script>"), "XSS vulnerability detected!");
        }
    }
}
