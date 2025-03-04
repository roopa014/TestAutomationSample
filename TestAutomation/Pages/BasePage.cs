using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

    }
}
