using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netguru.Core.PageObjects
{
    public class LoginPage :Page
    {
        public LoginPage() : base()
        {
            CurrentUrl = "login";
        }
        public enum TextBox
        {
            Login,
            Password
        }
        public enum Button
        {
            SignIn
        }
        private readonly Dictionary<TextBox, string> textboxes = new Dictionary<TextBox, string>
        {
            {TextBox.Login, "//input[@id='user']" },
            {TextBox.Password, "//input[@id='password']" }
        };
        private readonly Dictionary<Button, string> buttons = new Dictionary<Button, string>
        {
            {Button.SignIn, "//input[@id='login']" }
        };
        public void Type(TextBox box,string text)
        {
           TypeText(textboxes[box], text);
        }
        public void Click(Button button)
        {
            ClickButton(buttons[button]);
        }
        public string GetPopupMessage()
        {
            return Driver.FindElement(By.ClassName("error-message")).GetAttribute("innerText");
        }
    }
}
