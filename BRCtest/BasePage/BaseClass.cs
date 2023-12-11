using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace SeleniumUITest.BasePage
{
    public abstract class BaseClass
    {
        protected IWebDriver driver;

        public BaseClass() {
            driver = GetDriver();

        }

        public IWebDriver GetDriver()
        {
            if (driver == null)
            {
                try
                {
                    driver = new ChromeDriver();
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
