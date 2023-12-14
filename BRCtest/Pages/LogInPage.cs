using BRCtest.BRCWebDriver;
using BRCtest.Components;
using OpenQA.Selenium;
using SeleniumUITest.BasePage;
using System.Configuration;

namespace SeleniumUITest.Pages
{
    public class LogInPage
    {
        public LogInPage()
        {
            BRCWebDriver.GetInstance().Manage().Window.Maximize();
            BRCWebDriver.GetInstance().Navigate().GoToUrl(ConfigurationManager.AppSettings["loginUrl"]);
        }

        // Định nghĩa các phần tử trên trang đăng nhập
        //private readonly By helpLink = By.XPath("//a[contains(text(), 'Help')]");
        //private readonly By privacyLink = By.XPath("//a[contains(text(), 'Privacy')]");
        //private readonly By tCLink = By.XPath("//a[contains(text(), 'T&Cs')]");
        //private readonly By emailAddressField = By.Id("uxLogin");
        //private readonly By passwordField = By.Name("uxPassword");
        // private readonly By rememberMeCheckbox = By.Id("uxRemember");
        // private readonly By signInButton = By.Id("uxSingIn");
        // private readonly By forgotPasswordLink = By.ClassName("x-link");


        public LinkComponent HelpLink => new LinkComponent(By.XPath("//a[contains(text(), 'Help')]"), BRCWebDriver.GetInstance());
        public LinkComponent PrivacyLink => new LinkComponent(By.XPath("//a[contains(text(), 'Privacy')]"), BRCWebDriver.GetInstance());
        public LinkComponent TCLink => new LinkComponent(By.XPath("//a[contains(text(), 'T&Cs')]"), BRCWebDriver.GetInstance());
        public InputComponent EmailInput => new InputComponent(By.Id("uxLogin"), BRCWebDriver.GetInstance());
        public InputComponent PasswordInput => new InputComponent(By.Name("uxPassword"), BRCWebDriver.GetInstance());
        public ButtonComponent LoginButton => new ButtonComponent(By.Id("uxSingIn"), BRCWebDriver.GetInstance());

        public By SuccessfulMessage = By.CssSelector("#tab-1057-btnIconEl");

        public void Login(string username, string password)
        {
            EmailInput.EnterText(username);
            PasswordInput.EnterText(password);
            LoginButton.Click();
        }

        public void ClickLink(string linkName)
        {
            switch (linkName)
            {
                case "Help":
                    HelpLink.Click();
                    break;
                case "Privacy":
                    PrivacyLink.Click();
                    break;
                case "T&Cs":
                    TCLink.Click();
                    break;
            }

        }
        // Phương thức nhập email
        //public void EnterEmail(string email)
        //{
        //    driver.FindElement(emailAddressField).SendKeys(email);
        //}

        // Phương thức nhập mật khẩu
        //public void EnterPassword(string password)
        //{
        //    driver.FindElement(passwordField).SendKeys(password);
        //}

        // Phương thức click vào checkbox 'Remember Me'
        //public void TickRememberMe()
        //{
        //    driver.FindElement(rememberMeCheckbox).Click();
        //}

        // Phương thức click vào nút đăng nhập
        //public void ClickSignInButton()
        //{
        //    driver.FindElement(signInButton).Click();
        //}

        // Phương thức click vào liên kết 'Quên mật khẩu'
        //public void ClickForgotPasswordLink()
        //{
        //    driver.FindElement(forgotPasswordLink).Click();
        //}


    }
}