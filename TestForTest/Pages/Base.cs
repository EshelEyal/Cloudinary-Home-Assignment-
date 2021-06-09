using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TestForTest
{
    public class Base
    {
        private IWebDriver _driver;
        private IJavaScriptExecutor _jsDriver;
        private WebDriverWait _wait;
        private MyExtentReports _reports;
        private Actions action;

        public Base(IWebDriver driver, MyExtentReports reports)
        {
            this._driver = driver;
            _jsDriver = (IJavaScriptExecutor)driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            this._reports = reports;
            action = new Actions(_driver);
        }

        private void ExecuteScript(String script, params object[] args)
        {
            IJavaScriptExecutor exe = (IJavaScriptExecutor)_driver;
            exe.ExecuteScript(script, args);
        }

        protected void HighlightElement(IWebElement el)
        {
            ExecuteScript("arguments[0].setAttribute('style', 'border: 1px solid red;');", el);
        }

        protected void ClickOnElement(string elementName, string log)
        {
            IWebElement el = Getlocator(elementName);
            _wait.Until(ExpectedConditions.ElementToBeClickable(el));
            HighlightElement(el);
            el.Click();
            _reports.Log($"Click On {log}");
        }

        protected string GetCurrentUrl()
        {
            return _driver.Url;
        }

        protected string GetTextFromElement(string elementName)
        {
            IWebElement el = Getlocator(elementName);
            HighlightElement(el);
            string txt = el.Text;
            return txt;
        }

        protected string GetAttributeText(string elementName)
        {
            IWebElement el = Getlocator(elementName);
            HighlightElement(el);
            string txt = el.GetAttribute("value");
            return txt;
        }

        protected void SendKeysToElement(string elementName, string text)
        {
            IWebElement el = Getlocator(elementName);
            HighlightElement(el);
            bool flag = el.Enabled;
            el.SendKeys(text);
        }

        protected void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _reports.Log( $"Navigate To {url}");
        }

        protected IWebElement Getlocator(string elName)
        {
            string[] locator = elName.Split(':');
            string type =locator[0];
            string path = locator[1];

            switch (type)
            {
                case "xpath":
                    return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
                case "css":
                    return _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(path)));
                default:
                    return null;

            }
        }

        protected void RightClickOn(string elemntName)
        {
            action.ContextClick(Getlocator(elemntName));
            action.Perform();
            // The pause only to show that the step has taken place
            Thread.Sleep(1000);
        }

    }
}
