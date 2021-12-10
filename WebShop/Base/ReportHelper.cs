using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Base
{
    public class ReportHelper
    {
        internal string FileName;
        internal TestContext _logger;
        internal IWebDriver _driver;
        internal string testFolder;
        public ReportHelper(IWebDriver driver, TestContext logger)
        {
            _logger = logger;
            _driver = driver;
            this.CheckDirectory();
        }

        public bool CheckDirectory()
        {
            try
            {
                if (!Directory.Exists(ConfigHelper.ReportsPath))
                {
                    Directory.CreateDirectory(ConfigHelper.ReportsPath);
                    _logger.WriteLine("Directory Created");
                }

                this.CreateTestCaseFolder();
                return true;
            }
            catch (Exception exe)
            {
                _logger.WriteLine("Directory Creation failed {0}", exe.ToString());
                return false;
            }
        }

        public bool CreateTestCaseFolder()
        {
            try
            {
                string randomFile = DateTime.Now.TimeOfDay.ToString().Replace(" ", string.Empty).Replace(":", string.Empty).Replace(".", string.Empty);
                testFolder = ConfigHelper.ReportsPath + "\\" + _logger.TestName + randomFile;
                FileName = testFolder + "\\" + _logger.TestName + ".html";
                if (!Directory.Exists(testFolder))
                {
                    Directory.CreateDirectory(testFolder);
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(FileName, true))
                    {
                        file.WriteLine("<p><b>Logger for Test Method : {0} <b></p>", _logger.TestName);
                        file.Close();
                    }
                    _logger.WriteLine("Test Method Directory Created");
                }
                return true;
            }
            catch (Exception exe)
            {
                _logger.WriteLine("Directory Creation failed {0}", exe.ToString());
                return false;
            }
        }

        public void WriteSteps(string log)
        {
            try
            {
                if (!File.Exists(FileName))
                {
                    this.CreateTestCaseFolder();
                }

                this.TakeScreenshot();
                using (StreamWriter file = new StreamWriter(FileName, true))
                {
                    file.WriteLine("<p><b>" + log + "<b></p>");
                    file.Close();
                    _logger.WriteLine(log);
                }


            }
            catch (Exception exe)
            {
                _logger.WriteLine("Directory Creation failed {0}", exe.ToString());
            }
        }

        public string TakeScreenshot()
        {
            string saveLocation = null;
            try
            {
                ITakesScreenshot ssdriver = _driver as ITakesScreenshot;
                Screenshot screenshot = ssdriver.GetScreenshot();
                string randomFile = DateTime.Now.TimeOfDay.ToString().Replace(" ", string.Empty).Replace(":", string.Empty).Replace(".", string.Empty);
                string rawFileName = _logger.TestName + randomFile + ".png";
                saveLocation = testFolder + "\\" + rawFileName;
                screenshot.SaveAsFile(saveLocation, OpenQA.Selenium.ScreenshotImageFormat.Png);
                string imagetag = "<img src='" + saveLocation + "' height='600px' width='800px'/>";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(FileName, true))
                {
                    file.WriteLine("<b>" + imagetag + "</b>" + "</br>");
                    file.Close();
                }

            }
            catch (Exception ex)
            {
                _logger.WriteLine("Error occured during snap shot creation" + ex.Message);
            }

            return saveLocation;
        }
    }
}
