using System;
using System.Collections.Generic;
using System.Text;

namespace Netguru.Core.PageObjects
{
    public class SignupPage:Page
    {
        public SignupPage() : base()
        {
            CurrentUrl = "signup";
        }
        public enum TextBox
        {
            Email,
            Password,
            Name
        }
        public enum Button
        {
            Continue,
            SignUp
        }
        private readonly Dictionary<TextBox, string> textboxes = new Dictionary<TextBox, string>
        {
            {TextBox.Email, "//input[@id='email']" },
            {TextBox.Name, "//input[@id='name']" },
            {TextBox.Password, "//input[@id='password']" }
        };
        private readonly Dictionary<Button, string> buttons = new Dictionary<Button, string>
        {
            {Button.Continue, "//input[@id='signup-submit']" },
            {Button.SignUp, "//input[@id='signup-submit']" },
        };
        public void Type(TextBox box, string text)
        {
            TypeText(textboxes[box], text);
        }
        public void Click(Button button)
        {
            ClickButton(buttons[button]);
        }
        public bool IsEnabled(Button button)
        {
            var elem = WaitForElement(buttons[button]);
            return elem.Enabled;
        }
        public bool IsElementVisible(TextBox box)
        {
            return IsElementVisible(textboxes[box]);
        }
    }
}
