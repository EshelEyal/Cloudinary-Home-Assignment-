using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Reflection;

namespace TestForTest
{
    public class MyExtentReports
    {

        private string _extentReportHtmlFilePath;
        public  string ReportPath { get { return _extentReportHtmlFilePath; } }
        private  string _ExtentReportHtmlPath;
        private  ExtentTest _testLog;
        public  ExtentTest TestLog { get { return _testLog; } set { _testLog = value; } }
        private  ExtentReports _extent;
        public  ExtentReports Extent { get { return _extent; } }
            
        public MyExtentReports(string testName)
        {
            // Create Report Directory And Report File Path 
            var reportPath = "Target/HtmlReports/";
            string reportPth = Assembly.GetCallingAssembly().CodeBase;
            string reportActualPath = reportPth.Substring(0, reportPth.LastIndexOf("bin"));
            string reporProjectPath = new Uri(reportActualPath).LocalPath;
            string reportDirectoryPath = reporProjectPath + reportPath;
           
            _ExtentReportHtmlPath = reportDirectoryPath + " - " + Utiils.GetCurrentDateAndTime() + ".html";
            _extentReportHtmlFilePath = reportDirectoryPath + testName + " - " + Utiils.GetCurrentDateAndTime() + ".html";

            // initialize the HtmlReporter
            _extent = new ExtentReports();
            var htmlReporter = new ExtentV3HtmlReporter(_extentReportHtmlFilePath);
            _extent.AttachReporter(htmlReporter);
            _testLog = _extent.CreateTest(testName);
        }


        public void Log(string logText, Status status = Status.Pass)
        {
            _testLog.Log(status, logText);
        }

    }
}
