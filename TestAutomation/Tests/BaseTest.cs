using OpenQA.Selenium;
using TestAutomation.Drivers;
using TestAutomation.Utils;

namespace TestAutomation.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;
        public IWebDriver GetDriver()
        {
            return DriverSetup.GetDriver();

        }

        [SetUp]
        public void Setup()
        {
            driver = GetDriver();
            driver.Navigate().GoToUrl(Config.BaseUrl);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Cleanup()
        {
            DriverSetup.QuitDriver();
            driver.Dispose();
        }
    }
}
