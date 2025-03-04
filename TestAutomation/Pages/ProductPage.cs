using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestAutomation.Utils;

namespace TestAutomation.Pages
{
    public class ProductPage
    {
        private IWebDriver driver;
        private By watchesCategory = By.LinkText("Watches");
        private By metalFilter = By.XPath("//a[contains(text(), 'Metal')]");
        private By addToCartButton = By.XPath("//button[@title='Add to Cart']");
        private By gearMenu = By.XPath("//span[text()='Gear']");
        private By materialType = By.XPath("//div[text()='Material']");
        private By firstWatch = By.XPath("//a[contains(@class, 'product-item-link')]");
        private By myCart = By.XPath("//a/span[text()='My Cart']");
        private By hoverAddToCartButton = By.XPath("//div[contains(@class, 'product-item')]//button[contains(@class, 'tocart')]"); // Add to cart in grid view
        private By checkoutButton = By.Id("top-cart-btn-checkout");
        private By addToCartButtonOnProductPage = By.Id("product-addtocart-button");
        private By addToCartErrorMessage = By.CssSelector(".message-error");

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToWatches()
        {
            // Click Gear menu then Watches link
            Helper.Click(driver, gearMenu);
            Helper.Click(driver, watchesCategory);
        }

        public void SelectMetalWatch()
        {
            Helper.Click(driver, materialType);
            Helper.Click(driver, metalFilter);
        }

        public void SelectFirstWatchAndAddToCart()
        {
            Helper.MoveToElement(driver, firstWatch); // Hover over the product
            Helper.Click(driver, hoverAddToCartButton);
        }
    }
}
