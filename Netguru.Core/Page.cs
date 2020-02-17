using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using WebDriverWaitExtensions;

namespace Netguru.Core
{
    public abstract class Page
    {
        protected IWebDriver Driver;
        private string UrlPrefix = "https://trello.com/";
        private WebDriverWait wait;
        internal Page()
        {
            Driver = new ChromeDriver(Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,@"..\..\..\..\")));
            wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 60));
            Driver.Navigate().GoToUrl(UrlPrefix);
        }
        protected string CurrentUrl
        {
            get
            {
                return Driver.Url;
            }
            set
            {
                Driver.Navigate().GoToUrl(UrlPrefix + value);
            }
        }
        protected void ClickButton(string path)
        {
            var elem = WaitForElement(path);
            elem.Click();
        }
        protected void TypeText(string path, string text)
        {
            var elem = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(path)));
            elem.SendKeys(text);
        }
        public void CloseSession()
        {
            Driver.Close();
        }
        protected IWebElement WaitForElement(string path)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
        }
        protected bool IsElementVisible(string path)
        {
            try
            {
                return WaitForElement(path).Displayed;
            }
            catch { return false; }         
        }
    }
}
