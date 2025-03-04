using OpenQA.Selenium;
using TestAutomation.Utils;

namespace TestAutomation.Pages
{
    public class CartPage
    {
        private IWebDriver driver;
        private By quantityField = By.XPath("//input[@title='Qty']");
        private By updateButton = By.XPath("//button[@title='Update Cart']");
        private By proceedToCheckout = By.XPath("//li/button[@title='Proceed to Checkout']");
        private By editField = By.XPath("//a[@title='Edit item']");
        private By cartIcon = By.XPath("//a[contains(@class, 'showcart')]");

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenCart()
        {
            Helper.ScrollAndClick(driver, cartIcon, 20);
            if (!Helper.IsElementPresent(driver, editField))
                Helper.ScrollAndClick(driver, cartIcon, 20);
        }

        public void UpdateQuantity(int quantity)
        {
            Helper.Click(driver, editField, 20);
            driver.FindElement(quantityField).Clear();
            driver.FindElement(quantityField).SendKeys(quantity.ToString());
            driver.FindElement(updateButton).Click();
        }

        public void ProceedToCheckout()
        {

            Helper.ScrollAndClick(driver, proceedToCheckout);
        }
    }
}
