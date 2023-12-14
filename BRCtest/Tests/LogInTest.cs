using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumUITest.Pages;
using SeleniumUITest.BasePage;
using System.Collections.Generic;
using BRCtest.BRCWebDriver;

namespace SeleniumUITest.Tests
{
    [TestClass]
    public class LogInTest
    {
        private LogInPage logInPage;

        [TestInitialize]
        public void Init()
        {
            logInPage = new LogInPage();
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
            string currentUrl = BRCWebDriver.GetInstance().Url;
            bool urlCheck = currentUrl.Contains("https://brc-uat.azurewebsites.net/Home.aspx");

            bool messageDisplayed = false;
            if (urlCheck)
            {
                try
                {
                    IWebElement successMessage = BRCWebDriver.GetInstance().FindElement(logInPage.SuccessfulMessage);
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

            string originalWindowHandle = BRCWebDriver.GetInstance().CurrentWindowHandle;
            logInPage.ClickLink(linkName);
            foreach (string windowHandle in BRCWebDriver.GetInstance().WindowHandles)
            {
                if (windowHandle != originalWindowHandle)
                {
                    BRCWebDriver.GetInstance().SwitchTo().Window(windowHandle);
                    break;
                }
            }
            string currentUrl = BRCWebDriver.GetInstance().Url;
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



        //[TestCleanup]
        //public void Cleanup()
        //{
        //    if (driver != null)
        //    {
        //        driver.Quit();
        //    }
        //}


        [ClassCleanup]
        public static void CleanupAfterAllTests()
        {
            SetUp.Cleanup();
        }

    }
}