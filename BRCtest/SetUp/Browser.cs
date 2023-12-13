using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace BRCtest.SetUp
{
    public interface IBrowser
    {
        IWebDriver CreateWebDriver();
    }
    public class Browser : IBrowser
    {
        public IWebDriver CreateWebDriver()
        {
            return new ChromeDriver();
        }
    }
      
    // other browsers 
    //public class Browser : IBrowser
    //{
    //    public IWebDriver CreateWebDriver()
    //    {
    //        return new ChromeDriver();
    //    }
    //}
}
