using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumUITest.Pages;
using SeleniumUITest.BasePage;
using System.Collections.Generic;

namespace SeleniumUITest.Tests
{
    [TestClass]
    public class LogInTest : BaseClass
    {
        private LogInPageComponent logInPage;
        [TestInitialize]
        public void Init()
        {
            // Sử dụng PageFactory để tạo các trang
            logInPage = new LogInPageComponent(driver);
        }

        [DataTestMethod]
        [DataRow("linh.phan@idealogic.com.vn", "Welkom01", true, DisplayName = "Login_Success")]
        [DataRow("linh.phan@idealogic.com.vn", "wrongPassword", false, DisplayName = "Login_Fail_WrongPassword")]
        [DataRow("invalid_email@example.com", "Welkom01", false, DisplayName = "Login_Fail_InvalidEmail")]
        [DataRow("invalid_email@example.com", "wrongPassword", false, DisplayName = "Login_Fail_InvalidCredentials")]
        [DataRow("", "Welkom01", false, DisplayName = "Login_Fail_EmptyEmail")]
        [DataRow("linh.phan@idealogic.com.vn", "", false, DisplayName = "Login_Fail_EmptyPassword")]
        [DataRow("", "", false, DisplayName = "Login_Fail_EmptyEmailAndPassword")]
        public void VerifyLoginFunctionality(string email, string password, bool expectedResult)
        {
            logInPage.Login(email, password);

            // Thêm kiểm tra URL và thông báo thành công
            string currentUrl = GetDriver().Url;
            bool urlCheck = currentUrl.Contains("https://brc-uat.azurewebsites.net/Home.aspx");

            bool messageDisplayed = false;
            if (urlCheck)
            {
                try
                {
                    IWebElement successMessage = GetDriver().FindElement(By.CssSelector("#tab-1057-btnIconEl"));
                    messageDisplayed = successMessage.Displayed;
                }
                catch (NoSuchElementException)
                {
                    messageDisplayed = false;
                }
            }
            bool result = urlCheck && messageDisplayed;
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow("Help")]
        [DataRow("Privacy")]
        [DataRow("T&Cs")]
        public void VerifyLink(string linkName)
        {

            string originalWindowHandle = GetDriver().CurrentWindowHandle;
            logInPage.ClickLink(linkName);
            foreach (string windowHandle in GetDriver().WindowHandles)
            {
                if (windowHandle != originalWindowHandle)
                {
                    GetDriver().SwitchTo().Window(windowHandle);
                    break;
                }
            }
            string currentUrl =     GetDriver().Url;
            string urlNew = string.Empty;
            switch (linkName)
            {
                case "Help":
                    urlNew = "https://bigredcloud.com/support/";
                    break;
                case "Privacy":
                    urlNew = "https://bigredcloud.com/privacy-policy/";
                    break;
                case "T&Cs":
                    urlNew = "https://bigredcloud.com/terms-and-conditions/";
                    break;
            }

            bool urlCheck = currentUrl.Contains(urlNew);

            Assert.AreEqual(true, urlCheck);
        }

        [TestMethod]
        //public void VerifyRememberMeFunctionality()
        //{
        //    // Bước 1: Đăng nhập với tùy chọn 'Remember Me'
        //    logInPage.EnterEmail("valid_email@example.com");
        //    logInPage.EnterPassword("validPassword");
        //    logInPage.TickRememberMe();
        //    logInPage.ClickSignInButton();

        //    // Thêm mã để kiểm tra đăng nhập thành công tại đây

        //    // Bước 2: Đóng và mở lại trình duyệt
        //    BaseClass.Cleanup();
        //    var driver = BaseClass.GetDriver();
        //    driver.Navigate().GoToUrl("https://brc-uat.azurewebsites.net/Login.aspx?ReturnUrl=%2fDefault.aspx");

        //    // Bước 3: Kiểm tra xem người dùng có tự động đăng nhập không
        //    // Đây là bước phức tạp, tùy thuộc vào cách thức ứng dụng web của bạn xử lý 'Remember Me'
        //    // Có thể cần kiểm tra cookie, local storage, hoặc xác minh trực tiếp trên giao diện người dùng

        //    // Ví dụ kiểm tra xem đã tự động đăng nhập hay chưa
        //    bool isLoggedin = false;
        //    try
        //    {
        //        // Thay thế "selector" với selector phù hợp để xác nhận trạng thái đăng nhập
        //        IWebElement loggedInElement = driver.FindElement(By.CssSelector("your_logged_in_selector"));
        //        isLoggedin = loggedInElement != null && loggedInElement.Displayed;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        isLoggedin = false;
        //    }

        //    // Kiểm tra kết quả
        //    Assert.IsTrue(isLoggedin, "User is not logged in automatically with 'Remember Me'");

        //    // Đóng trình duyệt sau khi kiểm thử
        //    BaseClass.Cleanup();
        //}


        [TestCleanup]
        public void Cleanup()
        {
            if (GetDriver() != null)
            {
                GetDriver().Quit();
            }
        }

    }
}
