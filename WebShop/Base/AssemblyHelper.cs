using Microsoft.VisualStudio.TestTools.UnitTesting;
using RelevantCodes.ExtentReports;
using System.IO;

namespace Base
{  

    public static class AssemblyHelper
    {
        public static ReportingTask _reportingTask = null;
        public static void WrapExtendReports(TestContext context)
        {
            if (!Directory.Exists(ConfigHelper.ConsolidatedReport))
            {
                Directory.CreateDirectory(ConfigHelper.ConsolidatedReport);
            }
            ExtentReports extentReports = ReportingManager.Instance;
            extentReports.LoadConfig(ReturnCurrentDirectory() + "\\Reports\\extent-config.xml");
            extentReports.AddSystemInfo("Browser", ConfigHelper.BrowserType);
            _reportingTask = new ReportingTask(extentReports);
        }

        public static string ReturnCurrentDirectory()
        {
            string currentPath = Directory.GetCurrentDirectory();
            string final = currentPath.Replace(currentPath.Substring(currentPath.IndexOf("bin")), "");
            return final;
        }

        public static void ClearExtendReport()
        {
            _reportingTask.CleanUpReporting();
        }
    }
}
