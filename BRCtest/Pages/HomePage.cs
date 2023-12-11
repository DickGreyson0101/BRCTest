using OpenQA.Selenium;
using SeleniumUITest.BasePage;

namespace SeleniumUITest.Pages
{
    public class HomePage
    {
        // Sử dụng WebDriver từ BaseClass
        private IWebDriver driver = BaseClass.GetDriver();

        public string GetTitle()
        {
            return driver.Title;
        }


    }
}
