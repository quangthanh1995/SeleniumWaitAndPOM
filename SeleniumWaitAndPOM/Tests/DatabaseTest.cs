using SeleniumWaitAndPOM.Services;

namespace SeleniumWaitAndPOM.Tests
{
    [TestClass]
    public class DatabaseTest : BaseTest
    {
        DatabaseService databaseService;
        public DatabaseTest()
        {
            databaseService = new DatabaseService();
        }

        [TestMethod("TC-DB-01: Verify get course successfully")]
        public void VerifyCourseInfo()
        {
            var result = databaseService.GetCourseInformation();
            Assert.AreEqual(result.Name, "Data Science Basics");
            Assert.AreEqual(result.IdCourse, 1);
        }
    }
}
