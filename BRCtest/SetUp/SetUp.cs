using OpenQA.Selenium;
using System;
using BRCtest.SetUp;
using System.Configuration;

namespace SeleniumUITest.BasePage
{
    public static class SetUp
    {
        private static IWebDriver _driver;

        public static IWebDriver driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = GetDriver();
                }
                return _driver;
            }
            set
            {
                if (_driver == null)
                {
                    _driver = value;
                }
            }
        }
        public static IWebDriver GetBrowser(string browserType)
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    {
                        IBrowserFactory browserFactory = new ChromeBrowserFactory();
                        return browserFactory.CreateWebDriver();
                    }
                case "firefox":
                    {
                        IBrowserFactory browserFactory = new FirefoxBrowserFactory();
                        return browserFactory.CreateWebDriver();
                    }
                default:
                    throw new ArgumentException("Unsupported browser type");
            }
        }
        public static IWebDriver GetDriver()
        {
            try
            {
                IWebDriver webDriver = GetBrowser(ConfigurationManager.AppSettings["browserType"]);
                return webDriver;
            }
            catch (WebDriverException e)
            {
                // Handle exceptions related to WebDriver initialization here
                Console.WriteLine("WebDriver initialization failed: " + e.Message);
                throw; // Re-throw the exception if necessary
            }
            
        }

        public static void Cleanup()
        {
            if (driver != null)
            {
                try
                {
                    driver.Quit();
                }
                catch (WebDriverException e)
                {
                    Console.WriteLine("Error during WebDriver cleanup: " + e.Message);
                }
                finally
                {
                    driver = null;
                }
            }
        }
    }
}