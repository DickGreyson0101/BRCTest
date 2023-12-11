using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumUITest.BasePage;

namespace BRCtest.BasePage
{
    

    // Base component class
    public abstract class BaseComponent 
    {
        protected readonly IWebDriver Driver;


        protected BaseComponent(IWebDriver driver)
        {
            Driver = BaseClass.GetDriver();
        }

    }

    public class InputComponent : BaseComponent
    {
        private readonly By _locator;

        public InputComponent(IWebDriver driver, By locator) : base(driver)
        {
            _locator = locator;
        }

        public void EnterText(string text)
        {
            Driver.FindElement(_locator).SendKeys(text);
        }

       
    }
    public class ButtonComponent : BaseComponent
    {
        private readonly By _locator;

        public ButtonComponent(IWebDriver driver, By locator) : base(driver)
        {
            _locator = locator;
        }

        public void Click()
        {
            Driver.FindElement(_locator).Click();
        }

        
    }

    public class LinkComponent : BaseComponent
    {
        private readonly By _locator;

        public LinkComponent(IWebDriver driver, By locator) : base(driver)
        {
            _locator = locator;
        }

        public void Click()
        {
            Driver.FindElement(_locator).Click();
        }

        
    }




}
