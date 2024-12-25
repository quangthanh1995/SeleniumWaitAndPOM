using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Automation.Core.Helpers
{
    public class ReportHelper
    {
        ExtentReports extent;
        ExtentTest test;

        public ReportHelper()
        {
            extent = new ExtentReports();
            var spark = new ExtentSparkReporter(Path.Combine(Directory.GetCurrentDirectory(), "Reports", "Spark_Report_" + DateTime.Now.ToFileTimeUtc() + ".html"));
            extent.AttachReporter(spark);
        }

        public void CreateTestCase(string testCaseTitle, string testCaseDescription)
        {
            test = extent.CreateTest(testCaseTitle, testCaseDescription);
        }

        public void LogMessage(string status, string detail, string base64 = null)
        {
            switch (status)
            {
                case "Pass":
                    test.Log(Status.Pass, detail); break;
                case "Fail":
                    test.Log(Status.Fail, detail); break;
                case "Info":
                    test.Log(Status.Info, detail); break;
            }

            if (!string.IsNullOrEmpty(base64))
            {
                test.AddScreenCaptureFromBase64String(base64);
            }
        }

        public void ExportReport()
        {
            extent.Flush();
        }
    }
}
