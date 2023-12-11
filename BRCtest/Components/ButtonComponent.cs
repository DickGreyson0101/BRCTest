using OpenQA.Selenium;
using SeleniumUITest.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRCtest.Components
{
    public class ButtonComponent
    {
        private readonly By _locator;

        private IWebDriver driver;

        public ButtonComponent(By locator, IWebDriver driver)
        {
            _locator = locator;
            this.driver = driver;
        }

        public void Click()
        {
            driver.FindElement(_locator).Click();
        }


    }
}
