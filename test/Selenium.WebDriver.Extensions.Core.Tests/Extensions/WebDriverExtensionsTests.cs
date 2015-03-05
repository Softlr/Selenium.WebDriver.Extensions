namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using By = Selenium.WebDriver.Extensions.Core.By;

    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsTests
    {
        [Test]
        public void FindElementWithQuerySelector()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            var list = new List<IWebElement> { element.Object };
            var mock = MockWebDriver("return document.querySelectorAll('div');", new ReadOnlyCollection<IWebElement>(list));
            var result = mock.Object.FindElement(By.QuerySelector("div"));

            Assert.IsNotNull(result);
            Assert.AreEqual("div", result.TagName);
        }

        [Test]
        public void FindElementWithNestedQuerySelector()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("span");
            var list = new List<IWebElement> { element.Object };
            var mock = MockWebDriver(
                "return document.querySelectorAll('div').length === 0 ? [] : document.querySelectorAll('div')[0].querySelectorAll('span');",
                new ReadOnlyCollection<IWebElement>(list));
            var result = mock.Object.FindElement(By.QuerySelector("span", By.QuerySelector("div")));

            Assert.IsNotNull(result);
            Assert.AreEqual("span", result.TagName);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementWithQuerySelectorArgumentNull()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.FindElement((QuerySelector)null);
        }

        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithQuerySelectorNoSuchElement()
        {
            var mock = MockWebDriver();

            mock.Object.FindElement(By.QuerySelector("div"));
        }

        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithQuerySelectorNoSuchElementEmptyResult()
        {
            var mock = MockWebDriver("return document.querySelectorAll('div');", Enumerable.Empty<IWebElement>());

            mock.Object.FindElement(By.QuerySelector("div"));
        }

        [Test]
        public void FindElementsWithQuerySelector()
        {
            var element1 = new Mock<IWebElement>();
            element1.Setup(x => x.TagName).Returns("div");
            element1.Setup(x => x.GetAttribute("class")).Returns("test");

            var element2 = new Mock<IWebElement>();
            element2.Setup(x => x.TagName).Returns("span");
            element2.Setup(x => x.GetAttribute("class")).Returns("test");

            var list = new List<IWebElement> { element1.Object, element2.Object };
            var mock = MockWebDriver("return document.querySelectorAll('.test');", new ReadOnlyCollection<IWebElement>(list));
            var result = mock.Object.FindElements(By.QuerySelector(".test"));

            Assert.AreEqual(2, result.Count);

            Assert.AreEqual("div", result[0].TagName);
            Assert.AreEqual("test", result[0].GetAttribute("class"));

            Assert.AreEqual("span", result[1].TagName);
            Assert.AreEqual("test", result[1].GetAttribute("class"));
        }

        [Test]
        public void FindElementsWithQuerySelectorNotExists()
        {
            var list = new List<object>();
            var mock = MockWebDriver("return document.querySelectorAll('.test');", new ReadOnlyCollection<object>(list));
            var result = mock.Object.FindElements(By.QuerySelector(".test"));

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        [ExpectedException(typeof(QuerySelectorNotSupportedException))]
        public void QuerySelectorNotSupported()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return typeof document.querySelectorAll === 'function';")).Returns(false);
            mock.Object.QuerySelector().CheckSupport();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckSelectorPrerequisitesWithoutLoader()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.CheckSelectorPrerequisites(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadExternalLibraryWithoutLoader()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.LoadExternalLibrary(null, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementDriverNull()
        {
            WebDriverExtensions.FindElement(null, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementSelectorNull()
        {
            var driver = new Mock<IWebDriver>();
            WebDriverExtensions.FindElement(driver.Object, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementsDriverNull()
        {
            WebDriverExtensions.FindElements(null, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementsSelectorNull()
        {
            var driver = new Mock<IWebDriver>();
            WebDriverExtensions.FindElements(driver.Object, null);
        }

        private static Mock<IWebDriver> MockWebDriver(string script = null, object value = null)
        {
            var mock = new Mock<IWebDriver>();
            if (script != null)
            {
                mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(script)).Returns(value);
            }

            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return typeof document.querySelectorAll === 'function';")).Returns(true);
            return mock;
        }
    }
}
