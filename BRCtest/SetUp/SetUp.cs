using OpenQA.Selenium;
using System;
using BRCtest.SetUp;
using System.Configuration;
using BRCtest.BRCWebDriver;

namespace SeleniumUITest.BasePage
{
    public static class SetUp
    {
        public static void Cleanup()
        {
            if (BRCWebDriver.GetInstance() != null)
            {
                try
                {
                    BRCWebDriver.GetInstance().Quit();
                }
                catch (WebDriverException e)
                {
                    Console.WriteLine("Error during WebDriver cleanup: " + e.Message);
                }
                finally
                {
                    BRCWebDriver.driver = null;
                }
            }
        }
    }
}