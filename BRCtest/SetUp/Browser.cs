using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
