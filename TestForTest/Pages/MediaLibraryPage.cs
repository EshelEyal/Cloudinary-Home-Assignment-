using OpenQA.Selenium;

namespace TestForTest.Pages
{
    public class MediaLibraryPage : Base
    {
        public MediaLibraryPage(IWebDriver driver, MyExtentReports reports) : base(driver, reports)
        {
        }

        public void GoToManagePic(string elName)
        {
            
            RightClickOn(elName);
            ClickOnElement(Utiils.TestData["picManage"],"Manage In Right Click Menu");
        }

        public string GetImageTitle()
        {
            return GetAttributeText(Utiils.TestData["imageTitle"]);
        }
      
    }
}
