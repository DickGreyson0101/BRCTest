using OpenQA.Selenium;
using SeleniumUITest.BasePage;

namespace SeleniumUITest.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        // Sử dụng WebDriver từ BaseClass

        public string GetTitle()
        {
            return driver.Title;
        }


    }
}
