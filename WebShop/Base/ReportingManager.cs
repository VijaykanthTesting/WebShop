using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base
{
    public class ReportingManager
    {
        /// <summary>
        /// Create new instance of Extent report
        /// </summary>
        private static readonly ExtentReports _instance = new ExtentReports(ConfigHelper.ConsolidatedReport + @"\\TestReport_"+ DateTime.Now.TimeOfDay.ToString().Replace(" ", string.Empty).Replace(":", string.Empty).Replace(".", string.Empty) + ".html");

        static ReportingManager() { }
        private ReportingManager() { }

        /// <summary>
        /// Property to return the instance of the report.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
