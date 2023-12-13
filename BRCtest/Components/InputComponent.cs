using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumUITest.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRCtest.Components
{
    public class InputComponent
    {
        private readonly By _locator;

        private IWebDriver driver;


        public InputComponent(By locator, IWebDriver driver)
        {
            _locator = locator;
            this.driver = driver;
        }

        public void EnterText(string text)
        {
            driver.FindElement(_locator).SendKeys(text);
        }


    }
}
