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
    }
}
