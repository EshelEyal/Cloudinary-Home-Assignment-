using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;


namespace TestForTest.Pages
{
    public class LogIn : Base
    {
        private MyExtentReports _reports;
        public LogIn(IWebDriver driver, MyExtentReports reports) : base(driver, reports)
        {
            this._reports = reports;
        }

        public void LogInToCloudinaryMediaLab(string url)
        {
            GoToUrl(url);
            SendKeysToElement(Utiils.TestData["E-mail"], Utiils.TestData["userName"]);
            SendKeysToElement(Utiils.TestData["passEl"], Utiils.TestData["password"]);
            ClickOnElement(Utiils.TestData["signInBtn"], "Sign In Button");
            ClickOnElement(Utiils.TestData["MediaLibTab"], "Media Library Tab");
            string currentUrl = GetCurrentUrl();
            Assert.IsTrue(currentUrl.Contains("media_library/folders"),$"The {currentUrl} Is Not The Media Library Page");
            _reports.Log("Media Library Page Is Up");

        }
    }
}
