using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Netguru.Core.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Netguru.Test
{
    [TestClass]
    public class LoginPageTests
    {
        private static LoginPage LoginPage;
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            LoginPage = new LoginPage();
        }
        [TestInitialize]
        public void TestInit()
        {
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            LoginPage.CloseSession();
        }
        [TestMethod]
        public void InvalidEmailInput()
        {
            LoginPage.Type(LoginPage.TextBox.Login, "test@gmail.com");
            LoginPage.Click(LoginPage.Button.SignIn);
            Thread.Sleep(1000);
            Assert.AreEqual("Invalid password", LoginPage.GetPopupMessage());
        }
    }
}
