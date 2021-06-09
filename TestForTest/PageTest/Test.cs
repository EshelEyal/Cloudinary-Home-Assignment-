using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestForTest.Pages;

namespace TestForTest
{
    public class Test : Base
    {

        private MyExtentReports _reports;
        private LogIn logInPage;
        private MediaLibraryPage mediaLibPage;

        public Test(IWebDriver driver, MyExtentReports reports) : base(driver, reports)
        {
            this._reports = reports;
            logInPage = new LogIn(driver, reports);
            mediaLibPage = new MediaLibraryPage(driver, reports);
        }

        public void HomeAssignmentTest (string url, string imageName)
        {
            logInPage.LogInToCloudinaryMediaLab(url);
            mediaLibPage.GoToManagePic(Utiils.TestData["samplePic"]);
            string name = mediaLibPage.GetImageTitle();
            Assert.AreEqual(imageName, name,$"Valid Image Name: {imageName} Is Not Equal To Image Name On The Web Page {name}");

        }


        
    }
}
