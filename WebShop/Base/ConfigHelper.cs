using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Base
{
    public static class ConfigHelper
    {
        private static string appurl = ConfigurationManager.AppSettings["Url"].ToString();
        private static string driverpath = ConfigurationManager.AppSettings["DriverPath"].ToString();
        private static string reportspath = ConfigurationManager.AppSettings["ReportsPath"].ToString();
        private static string browsertype = ConfigurationManager.AppSettings["BrowserType"].ToString();
        private static string consolidatedreport = ConfigurationManager.AppSettings["ConsolidatedReport"].ToString();
        
        public static string Appurl
        {
            get
            {
                return appurl;
            }

            set
            {
                appurl = value;
            }
        }

        public static string Driverpath
        {
            get
            {
                return driverpath;
            }

            set
            {
                driverpath = value;
            }
        }

        public static string ReportsPath
        {
            get
            {
                return reportspath;
            }

            set
            {
                reportspath = value;
            }
        }

        public static string BrowserType
        {
            get
            {
                return browsertype;
            }

            set
            {
                browsertype = value;
            }
        }

        public static string ConsolidatedReport
        {
            get
            {
                return consolidatedreport;
            }

            set
            {
                consolidatedreport = value;
            }
        }
    }
}
