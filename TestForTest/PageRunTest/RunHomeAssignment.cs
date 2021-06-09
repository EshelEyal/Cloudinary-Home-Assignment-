using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestForTest.PageRunTest
{
    [TestClass]
  public class RunHomeAssignment : Run
    {

        [TestMethod]
        public void HomeAssignmentTest()
        {
            FlowTestMethod(() =>
            {
                Test run = new Test(_driver, _reports);
                run.HomeAssignmentTest(Utiils.TestData["url"],Utiils.TestData["imageNameForValidate"]);
            }, "HomeAssignmentTest");
        }

    }
}
