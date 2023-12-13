using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace BRCtest.SetUp
{
    public interface IBrowserFactory
    {
        IWebDriver CreateWebDriver();
    }
    public class ChromeBrowserFactory : IBrowserFactory
    {
        public IWebDriver CreateWebDriver()
        {
            return new ChromeDriver();
        }
    }
    public class FirefoxBrowserFactory : IBrowserFactory
    {
        public IWebDriver CreateWebDriver()
        {
            return new FirefoxDriver();
        }
    }
}
