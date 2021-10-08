using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace assignmentToDoMVC
{
    [TestClass]
    public class EdgeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private const string edgeDriverDirectory = @"D:\FrontEnd\edgedriver_win64";
        private EdgeDriver browser;

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            browser = new EdgeDriver(edgeDriverDirectory);
        }

        [TestMethod]
        public void inputTest()
        {
            // Replace with your own test logic.
            browser.Url = "http://192.168.1.182:8080/";
            var input = browser.FindElementByCssSelector("[type='text']");
            input.SendKeys("Clean");
            input.SendKeys(Keys.Enter);

            var listElement = browser.FindElementByCssSelector("h2");
            
            Assert.AreEqual("Clean", listElement.Text);
        }
        [TestMethod]
        public void countTest()
        {
            browser.Url = "http://192.168.1.182:8080/";
            var input1 = browser.FindElementByCssSelector("[type='text']");
            input1.SendKeys("Buy Cat Food");
            input1.SendKeys(Keys.Enter);

            var input2 = browser.FindElementByCssSelector("[type='text']");
            input2.SendKeys("Go To Work");
            input2.SendKeys(Keys.Enter);

            var input3 = browser.FindElementByCssSelector("[type='text']");
            input3.SendKeys("Buy Christmas Presents");
            input3.SendKeys(Keys.Enter);

            var inputCount = browser.FindElementByCssSelector("h2");

            Assert.AreEqual(3, inputCount);
            
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            browser.Quit();
        }
    }
}
