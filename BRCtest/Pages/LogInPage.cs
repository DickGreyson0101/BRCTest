using BRCtest.Components;
using OpenQA.Selenium;
using SeleniumUITest.BasePage;

namespace SeleniumUITest.Pages
{
    public class LogInPage 
    {
        private IWebDriver driver;

        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
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

        
        public LinkComponent HelpLink => new LinkComponent(By.XPath("//a[contains(text(), 'Help')]"), driver);
        public LinkComponent PrivacyLink => new LinkComponent(By.XPath("//a[contains(text(), 'Privacy')]"), driver);
        public LinkComponent TCLink => new LinkComponent(By.XPath("//a[contains(text(), 'T&Cs')]"), driver);
        public InputComponent EmailInput => new InputComponent(By.Id("uxLogin"), driver);
        public InputComponent PasswordInput => new InputComponent(By.Name("uxPassword"), driver);
        public ButtonComponent LoginButton => new ButtonComponent(By.Id("uxSingIn"), driver);
        
        public By SuccessfulMessage = By.CssSelector("#tab-1057-btnIconEl");

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
