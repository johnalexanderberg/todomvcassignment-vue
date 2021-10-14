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
            // Navigate to our site
            browser.Url = "https://johnalexanderberg.github.io/todomvcassignment-vue/";
            //Find where to and input our ToDo in the form
            var input = browser.FindElementByCssSelector("[type='text']");
            input.SendKeys("star in a really bad move with DiCaprio");
            input.SendKeys(Keys.Enter);

            //Find the item in the List
            var listElement = browser.FindElementByCssSelector("h2");

            //Check that item is the same as we sent in our form
            Assert.AreEqual("star in a really bad move with DiCaprio", listElement.Text);
        }

        [TestMethod]
        public void noItemsLeftTest()
        {
            browser.Url = "https://johnalexanderberg.github.io/todomvcassignment-vue/";
            var input = browser.FindElementByCssSelector("[type='text']");
            input.SendKeys("Be FURY us during the war");
            input.SendKeys(Keys.Enter);

            var itemCounter1 = browser.FindElementByCssSelector("[id='todo-count']");
            Assert.AreEqual("1 item left", itemCounter1.Text);

            //Find and click the "Completed button" 
            var button = browser.FindElementByCssSelector("[class='completedButton']");
            button.Click();

            var itemCounter2 = browser.FindElementByCssSelector("[id='todo-count']");
            Assert.AreEqual("0 items left", itemCounter2.Text);

        }


        [TestMethod]
        public void countItemsLeftTest()
        {
            browser.Url = "https://johnalexanderberg.github.io/todomvcassignment-vue/";
            var input1 = browser.FindElementByCssSelector("[type='text']");
            input1.SendKeys("Play an angry Greek guy in TROY");
            input1.SendKeys(Keys.Enter);

            var input2 = browser.FindElementByCssSelector("[type='text']");
            input2.SendKeys("Get all the MONEY from the BALL");
            input2.SendKeys(Keys.Enter);

            var input3 = browser.FindElementByCssSelector("[type='text']");
            input3.SendKeys("Dont forget to have HAPPY FEET");
            input3.SendKeys(Keys.Enter);

            var button = browser.FindElementByCssSelector("[class='completedButton']");
            button.Click();

            var inputCount = browser.FindElementByCssSelector("[id='todo-count']");

            Assert.AreEqual("2 items left", inputCount.Text);

        }
        [TestMethod]
        public void EditingToDoTest()
        {
            browser.Url = "https://johnalexanderberg.github.io/todomvcassignment-vue/";
            var input = browser.FindElementByCssSelector("[type='text']");
            input.SendKeys("Se7en");
            input.SendKeys(Keys.Enter);

            var listItem = browser.FindElementByCssSelector("[class='edit']");

            //Double click to edit
            new Actions(browser).DoubleClick(browser.FindElementByCssSelector("h2")).Perform();
            
            //Double click to mark all text and press backspace to clear input
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
            browser.Url = "https://johnalexanderberg.github.io/todomvcassignment-vue/";
            var input = browser.FindElementByCssSelector("[type='text']");
            input.SendKeys("Being the second cutes guy in a hotel robbery");
            input.SendKeys(Keys.Enter);

            var button = browser.FindElementByCssSelector("[class='completedButton']");
            button.Click();

            var completedButton = browser.FindElementByCssSelector("[id='completed']");
            completedButton.Click();

            var newUrl = browser.Url;

            Assert.AreEqual("https://johnalexanderberg.github.io/todomvcassignment-vue/#completed", newUrl);

        }
        [TestMethod]
        public void localStorageTest()
        {
            browser.Url = "https://johnalexanderberg.github.io/todomvcassignment-vue/";
            var input = browser.FindElementByCssSelector("[type='text']");
            input.SendKeys("Fighting with mrs smith");
            input.SendKeys(Keys.Enter);

            //Navigate to different site
            browser.Navigate().GoToUrl("http://google.com");
            //Navigate back to TodoList
            browser.Navigate().GoToUrl("https://johnalexanderberg.github.io/todomvcassignment-vue/");
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
