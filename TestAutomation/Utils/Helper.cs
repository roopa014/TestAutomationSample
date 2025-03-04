using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Configuration;

namespace TestAutomation.Utils
{
    public static class Helper
    {

        // Generic Wait for Element
        public static IWebElement WaitForElement(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        // Click with optional wait
        public static void Click(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WaitForElement(driver, locator, timeoutInSeconds).Click();
        }

        // Send Keys with optional wait
        public static void SendKeys(IWebDriver driver, By locator, string text, int timeoutInSeconds = 1)
        {
            WaitForElement(driver, locator, timeoutInSeconds).SendKeys(text);
        }

        // Scroll and Click
        public static void ScrollAndClick(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            IWebElement element = WaitForElement(driver, locator, timeoutInSeconds);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }

        public static void ClickElement(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            IWebElement ele = WaitForElement(driver, locator, timeoutInSeconds);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", ele);

        }

        public static bool IsElementPresent(IWebDriver driver, By locator, int timeoutInSeconds = 5)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(driver => driver.FindElements(locator).Count > 0);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }

        }

        public static void MoveToElement(IWebDriver driver, By locator, int timeoutInSeconds = 5)
        {
            IWebElement webElement = Helper.WaitForElement(driver, locator);
            Actions actions = new Actions(driver);
            actions.MoveToElement(webElement).Perform();
        }
    }
}
