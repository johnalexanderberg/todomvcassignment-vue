using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using System;

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
            input.SendKeys("Crash on a deserted island");
            input.SendKeys(Keys.Enter);

            var listElement = browser.FindElementByCssSelector("h2");

            Assert.AreEqual("Crash on a deserted island", listElement.Text);
        }

        [TestMethod]
        public void noItemsLeftTest()
        {
            browser.Url = "http://192.168.1.182:8080/";
            var input = browser.FindElementByCssSelector("[type='text']");
            input.SendKeys("Try to escape the island");
            input.SendKeys(Keys.Enter);

            var tick1 = browser.FindElementByCssSelector("[id='todo-count']");
            Assert.AreEqual("1 item left", tick1.Text);

            var button = browser.FindElementByCssSelector("[class='completedButton']");
            button.Click();

            var tick2 = browser.FindElementByCssSelector("[id='todo-count']");
            Assert.AreEqual("0 items left", tick2.Text);

        }


        [TestMethod]
        public void countTest()
        {
            browser.Url = "http://192.168.1.182:8080/";
            var input1 = browser.FindElementByCssSelector("[type='text']");
            input1.SendKeys("Find hidden tunnels");
            input1.SendKeys(Keys.Enter);

            var input2 = browser.FindElementByCssSelector("[type='text']");
            input2.SendKeys("Fight a polarbear");
            input2.SendKeys(Keys.Enter);

            var input3 = browser.FindElementByCssSelector("[type='text']");
            input3.SendKeys("Try and fail to save friends");
            input3.SendKeys(Keys.Enter);

            var button = browser.FindElementByCssSelector("[class='completedButton']");
            button.Click();

            var inputCount = browser.FindElementByCssSelector("[id='todo-count']");

            Assert.AreEqual("2 items left", inputCount.Text);

        }
        [TestMethod]
        public void EditingTest()
        {
            browser.Url = "http://192.168.1.182:8080/";
            var input = browser.FindElementByCssSelector("[type='text']");
            input.SendKeys("feel LOST");
            input.SendKeys(Keys.Enter);

            var listItem = browser.FindElementByCssSelector("[class='edit']");

            Assert.AreEqual(listItem.Text, input.Text);

            Actions act = new Actions(browser);

            //Double Click on list item
            var editedText = browser.FindElementByCssSelector("[class='edit']");
          
            act.DoubleClick(editedText).Perform();

            var isEditingText = browser.FindElementByCssSelector("[class='editing']");

            isEditingText.SendKeys("Join a Fight Club");
            isEditingText.SendKeys(Keys.Enter);

            Assert.AreEqual("Join a Fight Club", editedText.Text);
        }
        [TestMethod]
        public void URLHashChangeTest()
        {

        }
        [TestMethod]
        public void localStorageTest()
        {

        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            browser.Quit();
        }
    }
}
