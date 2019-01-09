using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace Framework.Driver
{
    class Driver
    {
        private static IWebDriver driver;

        private Driver() { }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new FirefoxDriver();
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(3000));
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}
