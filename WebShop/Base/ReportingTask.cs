using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base
{
    public class ReportingTask
    {
        public ExtentReports _extent;
        public ExtentTest _test;

        public ReportingTask(ExtentReports extentInstance)
        {
            _extent = extentInstance;

        }

        public void InitializeTest(TestContext tc)
        {
            _test = _extent.StartTest(tc.TestName);
        }

        public void FinalizeTest(TestContext tc, string _savelocation)
        {
            var status = tc.CurrentTestOutcome.ToString();

            LogStatus logstatus;

            switch (status)
            {
                case "Failed":
                    logstatus = LogStatus.Fail;
                    break;
                case "Error":
                    logstatus = LogStatus.Warning;
                    break;
                case "Inconclusive":
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }
            _test.Log(logstatus, "Test ended with " + logstatus);
            _test.Log(logstatus, _savelocation);
            _extent.EndTest(_test);
            _extent.Flush();
        }

        /// <summary>
        /// Cleans up reporting.
        /// Runs after all the test finishes
        /// </summary>
        public void CleanUpReporting()
        {
            _extent.Close();
        }
    }
}
