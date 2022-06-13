using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using FrameworkLib.Configuration;
using System;
using System.IO;

namespace FrameworkLib.Helpers
{
    public class ReportingHelpers
    {

        public static ExtentHtmlReporter htmlReporter;
        public static ExtentReports extent;

        public static ExtentReports getExtentReports()
        {
            if (extent == null)
            {
                string reportPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Desktop\AutomationQATestReport\TestResults\TR" + DateTime.Now.ToString("dd_MM_yyyy");


                if (!Directory.Exists(reportPath))
                {
                    Directory.CreateDirectory(reportPath);
                }
                string reportFullPath = reportPath + "\\report.html";
                htmlReporter = new ExtentHtmlReporter(reportFullPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
                extent.AddSystemInfo("Machine Name", Environment.MachineName);
                extent.AddSystemInfo("User Name", Environment.UserName);
                extent.AddSystemInfo("Host Name", Environment.UserDomainName);
                string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
                String extentPath = projectPath + "extent-config.xml";
                htmlReporter.LoadConfig(extentPath);

            }
            return extent;
        }
    }
}
