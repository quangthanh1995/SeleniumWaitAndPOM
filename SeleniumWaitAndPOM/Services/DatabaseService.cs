using Automation.Core.Helpers;
using SeleniumWaitAndPOM.Models;
using SeleniumWaitAndPOM.SqlQueries;

namespace SeleniumWaitAndPOM.Services
{
    public class DatabaseService
    {
        string connectionString = ConfigurationHelper.GetValue<string>("connectionString");
        public Courses GetCourseInformation()
        {
            string query = Queries.queryForSelectCourseWithIdCourse;
            var result = SqlHelper.ExecuteQuery<Courses>(connectionString, query);
            return result.FirstOrDefault();
        }
        public Mentees GetMenteeWithHighestAvgScore()
        {
            string query = Queries.queryForSelectMenteeWithHighestScore;
            var result = SqlHelper.ExecuteQuery<Mentees>(connectionString, query);
            return result.FirstOrDefault();
        }
    }
}
