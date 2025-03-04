using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Configuration;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestAutomation.Drivers
{
    public static class DriverSetup
    {
        private static IWebDriver? _driver;
        private static readonly string browserName = ConfigurationManager.AppSettings["Browser"] ?? "chrome";

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                _driver = InitializeDriver(browserName);
            }
            return _driver;
        }

        private static IWebDriver InitializeDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    return new ChromeDriver(chromeOptions);

                //case "firefox":
                //    new DriverManager().SetUpDriver(new FirefoxConfig());
                //    return new FirefoxDriver();

                //case "ie":
                //    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                //    return new InternetExplorerDriver();

                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    return new EdgeDriver();

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}. Please check app.config.");
            }
        }

        public static void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}

