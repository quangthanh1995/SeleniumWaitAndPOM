﻿using SeleniumWaitAndPOM.Services;

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
        public void Verify_Course_Info()
        {
            var result = databaseService.GetCourseInformation();
            Assert.AreEqual(result.Name, "Data Science Basics");
            Assert.AreEqual(result.IdCourse, 1);
        }

        [TestMethod("TC-DB-02: Verify get mentee with highest avg score successfully")]
        public void Verify_Get_Mentee_With_Highest_Avg_Score()
        {
            var result = databaseService.GetMenteeWithHighestAvgScore();
            Assert.AreEqual(result.IdMentee, 5);
            Assert.AreEqual(result.Fullname, "Vu Minh Tuan");
            Assert.AreEqual(result.AvgScore, 92.20);
        }
    }
}
