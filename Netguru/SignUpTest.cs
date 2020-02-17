using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Netguru.Core.PageObjects;

namespace Netguru.Test
{
    [TestClass]
    public class SignUpTest
    {
        private static SignupPage SignupPage;
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            SignupPage = new SignupPage();
        }
        [TestInitialize]
        public void TestInit()
        {
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            SignupPage.CloseSession();
        }
        [TestMethod]
        public void ValidEmailSignUp()
        {
            SignupPage.Type(SignupPage.TextBox.Email, "test@gmail.com");
            SignupPage.Click(SignupPage.Button.Continue);
            Assert.IsTrue(SignupPage.IsElementVisible(SignupPage.TextBox.Password));
        }
    }
}
