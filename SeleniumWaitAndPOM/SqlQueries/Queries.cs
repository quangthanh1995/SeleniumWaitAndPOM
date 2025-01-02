namespace SeleniumWaitAndPOM.SqlQueries
{
    public class Queries
    {
        public static string queryForSelectCourseWithIdCourse = "SELECT IdCourse, Name FROM Course WHERE IdCourse = 1";
        public static string queryForSelectMenteeWithHighestScore = "SELECT TOP 1 IdMentee, Fullname, AvgScore FROM Mentee ORDER BY AvgScore DESC";
    }
}
