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
        public static IBrowser GetBrowser(string browserType)
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    return new Browser();
                // Add cases for other browser types (e.g., "firefox", "edge")
                default:
                    throw new ArgumentException("Unsupported browser type");
            }
        }
        public static IWebDriver GetDriver()
        {
            try
            {
                IWebDriver webDriver = GetBrowser(ConfigurationManager.AppSettings["browserType"]).CreateWebDriver();
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