using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base
{
    public class BaseDriver
    {
        public static IWebDriver _driver;

        //private Objects objects = null;

        private TestContext _testContext;

        protected static ReportHelper _reporthelper;

        private string saveLocation = null;

        [TestInitialize()]
        public void TestInitialize()
        {
            _testContext = TestContext;
            InitializeDriver();            
            _reporthelper = new ReportHelper(_driver, TestContext);
            AssemblyHelper._reportingTask.InitializeTest(TestContext);
        }

        public TestContext TestContext { get; set; }

        [TestCleanup()]
        public void TestCleanUp()
        {
            saveLocation = _reporthelper.TakeScreenshot();
            string imagetag = "<a href='" + saveLocation + "' Target='_blank' ><img src='" + saveLocation + "' height='240px' width='440px' Title='Click on Image'/></a>";
            AssemblyHelper._reportingTask.FinalizeTest(TestContext, imagetag);
            DisposeDriver();
        }    

        public IWebDriver InitializeDriver()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(ConfigHelper.Appurl);
            _driver.Manage().Window.Maximize();
            //this.Objects = new Objects();
            return _driver;
        }

        public void DisposeDriver()
        {
            _driver.Quit();
        }        
    }
}
