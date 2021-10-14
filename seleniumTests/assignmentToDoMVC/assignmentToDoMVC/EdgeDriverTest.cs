using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;

namespace assignmentToDoMVC
{
    [TestClass]
    public class EdgeDriverTest
    {

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
            input.SendKeys("LOST");
            input.SendKeys(Keys.Enter);

            var listItem = browser.FindElementByCssSelector("[class='edit']");

            new Actions(browser).DoubleClick(browser.FindElementByCssSelector("h2")).Perform();
            new Actions(browser).DoubleClick(browser.FindElementByCssSelector("[class='editing']")).Perform();
            
            var isEditingText = browser.FindElementByCssSelector("[class='edit']");

            isEditingText.SendKeys(Keys.Backspace);
            isEditingText.SendKeys("Join a Fight Club");
            isEditingText.SendKeys(Keys.Enter);

            Assert.AreEqual(isEditingText.Text, listItem.Text);
        }
        [TestMethod]
        public void URLHashChangeTest()
        {
            browser.Url = "http://192.168.1.182:8080/";
            var input = browser.FindElementByCssSelector("[type='text']");
            input.SendKeys("Being the second cutes guy in a hotel robbery");
            input.SendKeys(Keys.Enter);

            var button = browser.FindElementByCssSelector("[class='completedButton']");
            button.Click();

            var completedButton = browser.FindElementByCssSelector("[id='completed']");
            completedButton.Click();

            var newUrl = browser.Url;

            Assert.AreEqual("http://192.168.1.182:8080/#completed", newUrl);

        }
        [TestMethod]
        public void localStorageTest()
        {
            browser.Url = "http://192.168.1.182:8080/";
            var input = browser.FindElementByCssSelector("[type='text']");
            input.SendKeys("Fighting with mrs smith");
            input.SendKeys(Keys.Enter);

            //Navigate to different site
            browser.Navigate().GoToUrl("http://google.com");
            //Navigate back to TodoList
            browser.Navigate().GoToUrl("http://192.168.1.182:8080/");
            //Find item in List
            var reload = browser.FindElementByCssSelector("h2");
            //Check that it's still the same as before
            Assert.AreEqual("Fighting with mrs smith", reload.Text);

        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            browser.Quit();
        }
    }
}
