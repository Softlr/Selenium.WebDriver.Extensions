namespace Selenium.WebDriver.Extensions.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
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
        /// Gets the load jQuery test cases.
        /// </summary>
        private static IEnumerable LoadJQueryTestCases
        {
            get
            {
                yield return new TestCaseData("latest", null, new object[] { true });
                yield return new TestCaseData("1.11.0", null, new object[] { false, true, true });
                yield return new TestCaseData("latest", TimeSpan.FromSeconds(1), new object[] { false })
                    .Throws(typeof(WebDriverTimeoutException));
            }
        }

        /// <summary>
        /// Tests jQuery loading.
        /// </summary>
        /// <param name="version">The version of jQuery to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the jQuery load.</param>
        /// <param name="mockValueSequence">
        /// A mock value sequence for <see cref="IJavaScriptExecutor.ExecuteScript"/> method.
        /// </param>
        [TestCaseSource(typeof(WebDriverExtensionsTests), "LoadJQueryTestCases")]
        public void LoadJQuery(string version, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var mock = new Mock<IWebDriver>();
            var sequence = mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            mock.Object.LoadJQuery(version, timeout);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        public void FindElement()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsIn("return jQuery('div').get(0);")))
                .Returns(element.Object);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('div').get(0);")))
                .Returns(true);

            var result = mock.Object.FindElement(By.JQuerySelector("div"));

            Assert.IsNotNull(result);
            Assert.AreEqual("div", result.TagName);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementArgumentNull()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.FindElement((JQuerySelector)null);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementNoSuchElement()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsIn("return jQuery('div').get(0);")))
                .Returns(null);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('div').get(0);")))
                .Returns(true);

            mock.Object.FindElement(By.JQuerySelector("div"));
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindElements()
        {
            var element1 = new Mock<IWebElement>();
            element1.Setup(x => x.TagName).Returns("div");
            element1.Setup(x => x.GetAttribute("class")).Returns("test");

            var element2 = new Mock<IWebElement>();
            element2.Setup(x => x.TagName).Returns("span");
            element2.Setup(x => x.GetAttribute("class")).Returns("test");

            var list = new List<IWebElement> { element1.Object, element2.Object };

            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsIn("return jQuery('.test').get();")))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('.test').get();")))
                .Returns(true);

            var result = mock.Object.FindElements(By.JQuerySelector(".test"));

            Assert.AreEqual(2, result.Count);

            Assert.AreEqual("div", result[0].TagName);
            Assert.AreEqual("test", result[0].GetAttribute("class"));

            Assert.AreEqual("span", result[1].TagName);
            Assert.AreEqual("test", result[1].GetAttribute("class"));
        }

        /// <summary>
        /// Tests finding an element text.
        /// </summary>
        [Test]
        public void FindText()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsIn("return jQuery('div').text();")))
                .Returns("test");
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('div').text();")))
                .Returns(true);
            var result = mock.Object.FindText(By.JQuerySelector("div"));

            Assert.AreEqual("test", result);
        }

        /// <summary>
        /// Tests finding an element inner HTML.
        /// </summary>
        [Test]
        public void FindHtml()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsIn("return jQuery('div').html();")))
                .Returns("<p>test</p>");
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('div').html();")))
                .Returns(true);
            var result = mock.Object.FindHtml(By.JQuerySelector("div"));

            Assert.AreEqual("<p>test</p>", result);
        }
    }
}
