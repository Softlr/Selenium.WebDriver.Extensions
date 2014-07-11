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
        /// Gets the find element test cases.
        /// </summary>
        private static IEnumerable FindElementTestCases
        {
            get
            {
                var element = new Mock<IWebElement>();
                element.Setup(x => x.TagName).Returns("div");
                element.Setup(x => x.GetAttribute("class")).Returns("testClass");
                yield return new TestCaseData(element.Object, By.JQuerySelector("div.testClass"))
                    .Returns(element.Object).SetName("Element found");
                yield return new TestCaseData(element.Object, null).Throws(typeof(ArgumentNullException))
                    .SetName("ArgumentNullException");
                yield return new TestCaseData(null, By.JQuerySelector("div.testClass"))
                    .Throws(typeof(NoSuchElementException)).SetName("NoSuchElementException");
            }
        }

        /// <summary>
        /// Gets the find elements test cases.
        /// </summary>
        private static IEnumerable FindElementsTestCases
        {
            get
            {
                var element = new Mock<IWebElement>();
                element.Setup(x => x.TagName).Returns("div");
                element.Setup(x => x.GetAttribute("class")).Returns("testClass");
                var results = new ReadOnlyCollection<IWebElement>(new List<IWebElement> { element.Object });
                yield return new TestCaseData(results, By.JQuerySelector("div.testClass")).Returns(1)
                    .SetName("Elements found");
                yield return new TestCaseData(results, null).Throws(typeof(ArgumentNullException))
                    .SetName("ArgumentNullException");
                yield return new TestCaseData(null, By.JQuerySelector("div.testClass")).Returns(0)
                    .SetName("Elements not found");
            }
        }

        /// <summary>
        /// Gets the find text test cases.
        /// </summary>
        private static IEnumerable FindTextTestCases
        {
            get
            {
                var element = new Mock<IWebElement>();
                element.Setup(x => x.Text).Returns("test");
                yield return new TestCaseData(element.Object.Text, By.JQuerySelector("div.testClass"))
                    .Returns(element.Object.Text).SetName("Element found");
                yield return new TestCaseData(element.Object.Text, null).Throws(typeof(ArgumentNullException))
                    .SetName("ArgumentNullException");
                yield return new TestCaseData(null, By.JQuerySelector("div.testClass")).Returns(null)
                    .SetName("Element not found");
            }
        }

        /// <summary>
        /// Gets the find text test cases.
        /// </summary>
        private static IEnumerable FindHtmlTestCases
        {
            get
            {
                var element = new Mock<IWebElement>();
                element.Setup(x => x.Text).Returns("<p>test</p>");
                yield return new TestCaseData(element.Object.Text, By.JQuerySelector("div.testClass"))
                    .Returns(element.Object.Text).SetName("Element found");
                yield return new TestCaseData(element.Object.Text, null).Throws(typeof(ArgumentNullException))
                    .SetName("ArgumentNullException");
                yield return new TestCaseData(null, By.JQuerySelector("div.testClass")).Returns(null)
                    .SetName("Element not found");
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
        /// <param name="elementMock">A mock for an element that will be returned by DOM search.</param>
        /// <param name="by">A Selenium jQuery selector.</param>
        /// <returns>Search results.</returns>
        [TestCaseSource(typeof(WebDriverExtensionsTests), "FindElementTestCases")]
        public IWebElement FindElement(IWebElement elementMock, JQuerySelector by)
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>())).Returns(true)
                .Returns(elementMock);
            return mock.Object.FindElement(by);
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        /// <param name="resultsMock">A mock for elements that will be returned by DOM search.</param>
        /// <param name="by">A Selenium jQuery selector.</param>
        /// <returns>A results count.</returns>
        [TestCaseSource(typeof(WebDriverExtensionsTests), "FindElementsTestCases")]
        public int FindElements(ReadOnlyCollection<IWebElement> resultsMock, JQuerySelector by)
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>())).Returns(true)
                .Returns(resultsMock);
            return mock.Object.FindElements(by).Count;
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        /// <param name="innerText">A mock for an inner text that will be returned by DOM search.</param>
        /// <param name="by">A Selenium jQuery selector.</param>
        /// <returns>Search results.</returns>
        [TestCaseSource(typeof(WebDriverExtensionsTests), "FindTextTestCases")]
        public string FindText(string innerText, JQuerySelector by)
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>())).Returns(true)
                .Returns(innerText);
            return mock.Object.FindText(by);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        /// <param name="innerText">A mock for an inner text that will be returned by DOM search.</param>
        /// <param name="by">A Selenium jQuery selector.</param>
        /// <returns>Search results.</returns>
        [TestCaseSource(typeof(WebDriverExtensionsTests), "FindHtmlTestCases")]
        public string FindHtml(string innerText, JQuerySelector by)
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>())).Returns(true)
                .Returns(innerText);
            return mock.Object.FindHtml(by);
        }
    }
}
