using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;


namespace TestForTest
{
    [TestClass]
    public class Run
    {

        protected IWebDriver _driver;
        protected MyExtentReports _reports;
        public TestContext TestContext { get; set; }
        private bool _isExcptionOccur = false;

        [TestInitialize]
        public void SetUp()
        {
            _reports = new MyExtentReports(TestContext.TestName);
            Utiils.GetTestData();
            DriverInitializ initDriver = new DriverInitializ();
            _driver = initDriver.initializDriver(Utiils.TestData["driver"], _reports);
            _reports.Log(_driver.GetType().Name);
            _reports.Log("Test Start");
        }

        [TestCleanup]
        public void AfterMethod()
        {
            if (!_isExcptionOccur == true)
            {
                _reports.Log("Test End");
            }
            _reports.Extent.Flush();
            Utiils.TestData.Clear();
            _driver.Quit();
        }

        protected void FlowTestMethod(Action action, string testName)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                _reports.Log("Test Fail", Status.Fail);
                _reports.Log($"Exception Message:  {ex.Message}", Status.Fail);
                _reports.TestLog.AddScreenCaptureFromPath(Utiils.GetScreenShot(TestContext.TestName, _driver));
                _isExcptionOccur = true;
                throw;
            }
        }

    }
}
