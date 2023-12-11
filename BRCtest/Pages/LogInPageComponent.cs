using BRCtest.BasePage;
using OpenQA.Selenium;
using SeleniumUITest.BasePage;

namespace SeleniumUITest.Pages
{
    public class LogInPageComponent : BaseComponent
    {
        private IWebDriver driver;

        // Định nghĩa các phần tử trên trang đăng nhập
        //private readonly By helpLink = By.XPath("//a[contains(text(), 'Help')]");
        //private readonly By privacyLink = By.XPath("//a[contains(text(), 'Privacy')]");
        //private readonly By tCLink = By.XPath("//a[contains(text(), 'T&Cs')]");
        //private readonly By emailAddressField = By.Id("uxLogin");
        //private readonly By passwordField = By.Name("uxPassword");
        private readonly By rememberMeCheckbox = By.Id("uxRemember");
        //private readonly By signInButton = By.Id("uxSingIn");
        private readonly By forgotPasswordLink = By.ClassName("x-link");

        // Constructor
        public LogInPageComponent(IWebDriver driver) : base(driver)
        {

        }

        
        public LinkComponent HelpLink => new LinkComponent(driver, By.XPath("//a[contains(text(), 'Help')]"));
        public LinkComponent PrivacyLink => new LinkComponent(driver, By.XPath("//a[contains(text(), 'Privacy')]"));
        public LinkComponent TCLink => new LinkComponent(driver, By.XPath("//a[contains(text(), 'T&Cs')]"));
        public InputComponent EmailInput => new InputComponent(driver, By.Id("uxLogin"));
        public InputComponent PasswordInput => new InputComponent(driver, By.Name("uxPassword"));
        public ButtonComponent LoginButton => new ButtonComponent(driver, By.Id("uxSingIn"));
        public void Login(string username, string password)
        {
            EmailInput.EnterText(username);
            PasswordInput.EnterText(password);
            LoginButton.Click();
        }

        public void ClickLink(string linkName )
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
        public void TickRememberMe()
        {
            driver.FindElement(rememberMeCheckbox).Click();
        }

        // Phương thức click vào nút đăng nhập
        //public void ClickSignInButton()
        //{
        //    driver.FindElement(signInButton).Click();
        //}

        // Phương thức click vào liên kết 'Quên mật khẩu'
        public void ClickForgotPasswordLink()
        {
            driver.FindElement(forgotPasswordLink).Click();
        }


    }
}
