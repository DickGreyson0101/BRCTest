using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using BRCtest.SetUp;

namespace SeleniumUITest.BasePage
{
    public class SetUp
    {
        static IWebDriver driver;

        //public SetUp()
        //{
        //    driver = GetDriver();

        //}
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
        string browserType = "chrome";
        public IWebDriver GetDriver()
        {
            if (driver == null || true)
            {
                try
                {
                    driver = GetBrowser(browserType).CreateWebDriver();
                    //driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl("https://brc-uat.azurewebsites.net/Login.aspx?ReturnUrl=%2fDefault.aspx");
                }
                catch (WebDriverException e)
                {
                    // Handle exceptions related to WebDriver initialization here
                    Console.WriteLine("WebDriver initialization failed: " + e.Message);
                    throw; // Re-throw the exception if necessary
                }
            }
            return driver;
        }

        [TestCleanup]
        public void Cleanup()
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