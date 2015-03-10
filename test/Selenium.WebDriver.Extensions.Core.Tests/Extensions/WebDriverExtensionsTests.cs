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
        private Mock<IWebDriver> driverMock;

        [SetUp]
        public void SetUp()
        {
            this.driverMock = new Mock<IWebDriver>();
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(true);
        }

        [TearDown]
        public void TearDown()
        {
            this.driverMock = null;
        }

        [Test]
        public void FindElementWithQuerySelector()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            var list = new List<IWebElement> { element.Object };
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return document.querySelectorAll('div');"))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            var result = this.driverMock.Object.FindElement(By.QuerySelector("div"));

            Assert.IsNotNull(result);
            Assert.AreEqual("div", result.TagName);
        }

        [Test]
        public void FindElementWithNestedQuerySelector()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("span");
            var list = new List<IWebElement> { element.Object };
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return document.querySelectorAll('div').length === 0 ? [] : document.querySelectorAll('div')[0].querySelectorAll('span');"))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            var result = this.driverMock.Object.FindElement(By.QuerySelector("span", By.QuerySelector("div")));

            Assert.IsNotNull(result);
            Assert.AreEqual("span", result.TagName);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementWithQuerySelectorArgumentNull()
        {
            this.driverMock.Object.FindElement((QuerySelector)null);
        }

        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithQuerySelectorNoSuchElement()
        {
            this.driverMock.Object.FindElement(By.QuerySelector("div"));
        }

        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithQuerySelectorNoSuchElementEmptyResult()
        {
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return document.querySelectorAll('div');"))
                .Returns(Enumerable.Empty<IWebElement>());

            this.driverMock.Object.FindElement(By.QuerySelector("div"));
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
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return document.querySelectorAll('.test');"))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            var result = this.driverMock.Object.FindElements(By.QuerySelector(".test"));

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
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return document.querySelectorAll('.test');"))
                .Returns(new ReadOnlyCollection<object>(list));
            var result = this.driverMock.Object.FindElements(By.QuerySelector(".test"));

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        [ExpectedException(typeof(QuerySelectorNotSupportedException))]
        public void QuerySelectorNotSupported()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(false);
            mock.Object.QuerySelector().CheckSupport();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckSelectorPrerequisitesWithoutLoader()
        {
            this.driverMock.Object.CheckSelectorPrerequisites(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadExternalLibraryWithoutLoader()
        {
            this.driverMock.Object.LoadExternalLibrary(null, null);
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
            WebDriverExtensions.FindElement(this.driverMock.Object, null);
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
            WebDriverExtensions.FindElements(this.driverMock.Object, null);
        }
    }
}
