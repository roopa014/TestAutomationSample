using OpenQA.Selenium;
using TestAutomation.Pages;
using TestAutomation.Utils;
using NUnit.Framework;

namespace TestAutomation.Tests
{
    [TestFixture]
    public class PurchaseTest :BaseTest
    {
        private LoginPage loginPage;
        private ProductPage productPage;
        private CartPage cartPage;
        private CheckoutPage checkoutPage;

        [Test]
        public void Test_Purchase_Watch()
        {
            loginPage = new LoginPage(driver);
            productPage = new ProductPage(driver);
            cartPage = new CartPage(driver);
            checkoutPage = new CheckoutPage(driver);
            loginPage.Login(Config.Username, Config.Password);

            productPage.NavigateToWatches();            
            productPage.SelectMetalWatch();
            productPage.SelectFirstWatchAndAddToCart();

            cartPage.OpenCart();
            cartPage.UpdateQuantity(2);
            cartPage.ProceedToCheckout();

            checkoutPage.FillShippingDetails("123 Street", "Los Angeles", "90001");
            // Complete Purchase
            checkoutPage.PlaceOrder();
            // Verify success and get Order ID
            Assert.That(checkoutPage.VerifySuccessMessage(), Is.True, "Purchase was not successful.");
            string orderId = checkoutPage.GetOrderId();
            Assert.That(orderId,Is.Not.Empty, "Order ID was not captured.");
            TestContext.WriteLine($"Order successfully placed. Order ID: {orderId}");
        }

    }
}
