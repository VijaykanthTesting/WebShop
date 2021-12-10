using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Base;


namespace SeleniumWrapper
{
    public class SeleniumHelper
    {
        IWebDriver _driver = null;
        ReportHelper _report = null;

        public SeleniumHelper(IWebDriver _driverObj, ReportHelper _reporthelper)
        {
            _driver = _driverObj;
            _report = _reporthelper;

        }

        public void ClickButton(IWebElement _ele)
        {
            _ele.Click();
        }

        public void SendKeys(IWebElement _ele, string value)
        {            
            _ele.SendKeys(value);
            _report.WriteSteps(string.Format("Entered {0} Successfully", value));

        }

        public void Click(IWebElement _element)
        {
            _element.Click();
        }

        public void JSClick(IWebElement _element)
        {
            IJavaScriptExecutor javascript = _driver as IJavaScriptExecutor;
            javascript.ExecuteScript("arguments[0].click()", _element);
            _report.WriteSteps(string.Format("Clicked on Element {0} Successfully", _element));
        }

        public void HighLightControl(IWebElement _element)
        {
            IJavaScriptExecutor javascript = _driver as IJavaScriptExecutor;
            javascript.ExecuteScript("arguments[0].style.border='4px solid blue'", _element);
        }
        
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public string Title
        {
            get
            {
                return _driver.Title;
            }

        }
        private string _title;
        public string Url
        {
            get
            {
                return _driver.Url;
            }

        }


        private string _Url;

        /// <summary>
        ///Refresh the page
        ///</summary>
        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }

        public void ManageDriver()
        {
            //_driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(-1));
        }

        public void NavigateToURLInSameBrowser(string URL)
        {
            _driver.Navigate().GoToUrl(URL);
        }
        /// <summary>
        ///Page Back
        ///</summary>
        public void Back()
        {
            _driver.SwitchTo().DefaultContent();
            _driver.Navigate().Back();
        }

        /// <summary>
        ///Closed the driver
        ///</summary>
        public void DisposeDriver()
        {
            _driver.Close();
        }

        /// <summary>
        /// Moves the focus to the element
        /// </summary>
        /// <param name="webelement"></param>
        public void SetFocus(IWebElement webelement)
        {
            ILocatable hoverItem = (ILocatable)webelement;
            new Actions(_driver).MoveToElement(webelement).Perform();
        }

        public void AcceptAlert()
        {
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Alert().Accept();
            System.Threading.Thread.Sleep(2000);
        }

        public IWebElement GetControlFocused()
        {
            return _driver.SwitchTo().ActiveElement();
        }

        public string GetCurrentWindowHandle()
        {
            return _driver.CurrentWindowHandle;
        }

        public void AlertEnter()
        {
            _driver.SwitchTo().Alert().SendKeys("{ENTER}");
        }
        public void DismissAlert()
        {
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Alert().Dismiss();
            System.Threading.Thread.Sleep(2000);
        }

        public bool VerifyAlertMessage(String ExpMsg)
        {
            System.Threading.Thread.Sleep(2000);
            String actualMessage = _driver.SwitchTo().Alert().Text;
            System.Threading.Thread.Sleep(2000);
            if (ExpMsg.Equals(actualMessage))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool VerifyAlertCustomMessage(string msg)
        {
            String actualMessage = _driver.SwitchTo().Alert().Text;
            return actualMessage.Contains(msg);
        }
        public void MoveToElement(IWebElement ele, string propertyValue)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(ele).Build().Perform();
            System.Threading.Thread.Sleep(10000);
        }
        public void ClickToElement(IWebElement ele, string propertyValue)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(ele).Click().Perform();
            System.Threading.Thread.Sleep(10000);
        }
        public void OpenLinkInNewTab(IWebElement ele, string propertyValue, string[] dynamicControlValue = null)
        {
            Actions actions = new Actions(_driver);
            actions.ContextClick(ele).Perform();
            actions.SendKeys("w").Perform();
            System.Threading.Thread.Sleep(10000);
        }

        public bool verifystring(IWebElement _ele, string msg)
        {
            string actualMessage = _ele.Text;
            if (msg.Equals(actualMessage))
            {
                _report.WriteSteps(string.Format("Actual Message : '{0}' and Expected : '{1}' are equal", actualMessage, msg));
                return true;
            }
            else
            {
                _report.WriteSteps(string.Format("Actual Message : '{0}' and Expected : '{1}' are not equal", actualMessage, msg));
                return false;
            }
        }


        public IWebElement GetWebelementByLinkText(string linkText)
        {
            IWebElement ele; ;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            ele = wait.Until(x => x.FindElement(By.LinkText(linkText)));
            return ele;
        }

        /*
        public void TakeScreenshot()
        {
            try
            {
                string folderName = ConfigHelper.ReportsPath + "\\" + _logger.TestName;
                string fileName = folderName + "\\" + _logger.TestName + ".html";
                ITakesScreenshot ssdriver = _driver as ITakesScreenshot;
                Screenshot screenshot = ssdriver.GetScreenshot();
                string rawFileName = _logger.TestName + DateTime.Now.TimeOfDay.ToString().Replace(" ", string.Empty).Replace(":", string.Empty) + ".png";
                string saveLocation = folderName + "\\" + rawFileName;
                screenshot.SaveAsFile(saveLocation, OpenQA.Selenium.ScreenshotImageFormat.Png);
                string imagetag = "<img src='" + rawFileName + "' height='800px' width='1080px'/>";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true))
                {
                    file.WriteLine("<b>" + imagetag + "</b>" + "</br>");
                    file.Close();
                }

            }
            catch (Exception ex)
            {
                _logger.WriteLine("Error occured during snap shot creation" + ex.Message);
            }
        }*/
    }
}
