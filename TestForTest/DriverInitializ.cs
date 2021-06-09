using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace TestForTest
{
    public class DriverInitializ
    {

        private IWebDriver driver;

        public IWebDriver initializDriver(string brwserType, MyExtentReports reports)
        {
            switch (brwserType)
            {
                case "chrome":

                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    return driver;
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    return driver;
                default:
                    reports.Log("Web Driver Not Valid");
                    return null;
            }
        }
    }



}
