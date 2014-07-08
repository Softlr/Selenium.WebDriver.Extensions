namespace Selenium.WebDriver.Extensions.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using Moq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using By = Selenium.WebDriver.Extensions.By;

    /// <summary>
    /// Web driver extensions tests.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsTests
    {
        /// <summary>
        /// Tests jQuery loading in already-loaded scenario.
        /// </summary>
        [Test]
        public void LoadExistingJQuery()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsAny<string>())).Returns(true);
            mock.Object.LoadJQuery();
        }

        /// <summary>
        /// Tests jQuery loading in not-already-loaded scenario.
        /// </summary>
        [Test]
        public void LoadJQuery()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>())).Returns(false)
                .Returns(true).Returns(true);
            mock.Object.LoadJQuery("1.11.0");
        }

        /// <summary>
        /// Tests jQuery loading timeout.
        /// </summary>
        [Test]
        [ExpectedException(typeof(WebDriverTimeoutException))]
        public void LoadJQueryWithTimeout()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>())).Returns(false);
            mock.Object.LoadJQuery("latest", TimeSpan.FromSeconds(1));
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        public void FindElement()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            element.Setup(x => x.GetAttribute("class")).Returns("testClass");
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>())).Returns(true)
                .Returns(element.Object);
            var item = mock.Object.FindElement(By.JQuerySelector("div.testClass"));

            Assert.IsNotNull(item);
        }

        /// <summary>
        /// Tests finding an element with null selector.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementNullSelector()
        {
            var mock = new Mock<IWebDriver>();
            WebDriverExtensions.FindElement(mock.Object, null);
        }

        /// <summary>
        /// Tests finding an element which doesn't match given selector.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindNonExistingElement()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>())).Returns(true);
            mock.Object.FindElement(By.JQuerySelector("div.testClass"));
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindElements()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            element.Setup(x => x.GetAttribute("class")).Returns("testClass");
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>())).Returns(true)
                .Returns(new ReadOnlyCollection<IWebElement>(new List<IWebElement> { element.Object }));
            var item = mock.Object.FindElements(By.JQuerySelector("div.testClass"));

            Assert.IsNotNull(item);
            Assert.AreEqual(1, item.Count);
        }

        /// <summary>
        /// Tests finding elements with null selector.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementsNullSelector()
        {
            var mock = new Mock<IWebDriver>();
            WebDriverExtensions.FindElements(mock.Object, null);
        }

        /// <summary>
        /// Tests finding elements which doesn't match given selector.
        /// </summary>
        [Test]
        public void FindNonExistingElements()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>())).Returns(true);
            var item = mock.Object.FindElements(By.JQuerySelector("div.testClass"));

            Assert.IsNotNull(item);
            Assert.AreEqual(0, item.Count);
        }
    }
}
