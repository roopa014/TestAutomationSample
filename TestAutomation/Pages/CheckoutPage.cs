using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestAutomation.Utils;

namespace TestAutomation.Pages
{
    public class CheckoutPage
    {
        private IWebDriver driver;
        private By placeOrderButton = By.XPath("//button[@title='Place Order']");
        private By orderSuccessMessage = By.XPath("//span[contains(text(), 'Thank you for your purchase')]");
        private By orderId = By.CssSelector(".order-number");
        private By shippingAddressField = By.XPath("//input[@name='street[0]']");
        private By shippingCityField = By.XPath("//input[@name='city']");
        private By shippingZipField = By.XPath("//input[@name='postcode']");
        private By countryDropdown = By.Name("country_id");
        private By phoneNumberField = By.Name("telephone");
        private By preselectedAddress = By.CssSelector(".shipping-address-item.selected-item");
        private By nextButton = By.XPath("//*[@id='shipping-method-buttons-container']//span");
        private By radio = By.XPath("//input[@type='radio']");
        private By shippingMethod = By.XPath("//input[@name='ko_unique_1']");  // Selecting a shipping method
        private By continueToPaymentButton = By.XPath("//button[@data-role='opc-continue']");
        private By shippingErrorMessage = By.CssSelector(".message-error");

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void PlaceOrder()
        {
            Helper.ClickElement(driver, placeOrderButton, 15);
        }

        public void FillShippingDetails(string address, string city, string zip)
        {
            if (Helper.IsElementPresent(driver, preselectedAddress))
            {
                Console.WriteLine("✅ Preselected address found. Skipping shipping details.");
                Helper.Click(driver, radio);
                Helper.Click(driver, nextButton);
                return;
            }
            Helper.SendKeys(driver, shippingAddressField, address, 20);
            Helper.SendKeys(driver, shippingCityField, city);
            Helper.SendKeys(driver, shippingZipField, zip);
            SelectElement countrySelect = new SelectElement(driver.FindElement(countryDropdown));
            countrySelect.SelectByIndex(2);

            Helper.SendKeys(driver, phoneNumberField, "9958");
            Helper.Click(driver, radio);
            Helper.Click(driver, nextButton);
        }

        public bool VerifySuccessMessage()
        {
            return Helper.WaitForElement(driver, orderSuccessMessage, 30).Displayed;
        }

        public string GetOrderId()
        {
            return Helper.WaitForElement(driver, orderId).Text;
        }

        
        public void SkipShippingDetails()
        {
            // For negative scenario
            Helper.Click(driver, nextButton);
        }

        public string GetShippingErrorMessage()
        {
            if (Helper.IsElementPresent(driver, shippingErrorMessage))
                return driver.FindElement(shippingErrorMessage).Text;
            return string.Empty;
        }
    }
}
