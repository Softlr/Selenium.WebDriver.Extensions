namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Moq;
    using OpenQA.Selenium;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.Core.By;
    
    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsTests
    {
        [Fact]
        public void ShouldFindElement()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(true);

            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            var list = new List<IWebElement> { element.Object };
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return document.querySelectorAll('div');"))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            var result = driverMock.Object.FindElement(By.QuerySelector("div"));

            Assert.NotNull(result);
            Assert.Equal("div", result.TagName);
        }

        [Fact]
        public void ShouldFindElementWithNestedSelector()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(true);

            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("span");
            var list = new List<IWebElement> { element.Object };
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("document.querySelectorAll('div').length === 0")))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            var result = driverMock.Object.FindElement(By.QuerySelector("span", By.QuerySelector("div")));

            Assert.NotNull(result);
            Assert.Equal("span", result.TagName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenFindingElementWithNullSelector()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(true);

            var ex = Assert.Throws<ArgumentNullException>(() => driverMock.Object.FindElement(null));
            Assert.Equal("by", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenFindingElementThatDoesntExist()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(true);

            Assert.Throws<NoSuchElementException>(() => driverMock.Object.FindElement(By.QuerySelector("div")));
        }

        [Fact]
        public void ShouldThrowExceptionWherFindingElementReturnsEmptyResult()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return document.querySelectorAll('div');"))
                .Returns(Enumerable.Empty<IWebElement>());

            Assert.Throws<NoSuchElementException>(() => driverMock.Object.FindElement(By.QuerySelector("div")));
        }

        [Fact]
        public void ShouldFindElements()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(true);

            var element1 = new Mock<IWebElement>();
            element1.Setup(x => x.TagName).Returns("div");
            element1.Setup(x => x.GetAttribute("class")).Returns("test");

            var element2 = new Mock<IWebElement>();
            element2.Setup(x => x.TagName).Returns("span");
            element2.Setup(x => x.GetAttribute("class")).Returns("test");

            var list = new List<IWebElement> { element1.Object, element2.Object };
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return document.querySelectorAll('.test');"))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            var result = driverMock.Object.FindElements(By.QuerySelector(".test"));

            Assert.Equal(2, result.Count);

            Assert.Equal("div", result[0].TagName);
            Assert.Equal("test", result[0].GetAttribute("class"));

            Assert.Equal("span", result[1].TagName);
            Assert.Equal("test", result[1].GetAttribute("class"));
        }

        [Fact]
        public void ShouldReturnEmptyResultWhenFindingElementsThatDoesntExist()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(true);

            var list = new List<object>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return document.querySelectorAll('.test');"))
                .Returns(new ReadOnlyCollection<object>(list));
            var result = driverMock.Object.FindElements(By.QuerySelector(".test"));

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void ShouldThrowExceptionWhenQuerySelectorIsNotSupported()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(false);
            Assert.Throws<QuerySelectorNotSupportedException>(() => driverMock.Object.QuerySelector().CheckSupport());
        }

        [Fact]
        public void ShouldThrowExceptionWhenCheckingSelectorPrerequisitesWithoutLoader()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(true);

            var ex = Assert.Throws<ArgumentNullException>(() => driverMock.Object.CheckSelectorPrerequisites(null));
            Assert.Equal("loader", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCheckingSelectorPrerequisitesWithIncorrectResponse()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(null);

            Assert.False(driverMock.Object.CheckSelectorPrerequisites(new QuerySelectorLoader()));
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingExternalLibraryWithoutLoader()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(true);

            var ex = Assert.Throws<ArgumentNullException>(() => driverMock.Object.LoadExternalLibrary(null, null));
            Assert.Equal("loader", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenFindingElementWithNullDriver()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => WebDriverExtensions.FindElement(null, null));
            Assert.Equal("driver", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenFindingElementsWithNullDriver()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => WebDriverExtensions.FindElements(null, null));
            Assert.Equal("driver", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenExuecutingNullScript()
        {
            var driverMock = new Mock<IWebDriver>();
            
            var ex = Assert.Throws<ArgumentNullException>(() => driverMock.Object.ExecuteScript(null));
            Assert.Equal("script", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenExuecutingEmptyScript()
        {
            var driverMock = new Mock<IWebDriver>();

            var ex = Assert.Throws<ArgumentException>(() => driverMock.Object.ExecuteScript(string.Empty));
            Assert.Equal("script", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenExuecutingWhiteSpaceOnlyScript()
        {
            var driverMock = new Mock<IWebDriver>();

            var ex = Assert.Throws<ArgumentException>(() => driverMock.Object.ExecuteScript(" "));
            Assert.Equal("script", ex.ParamName);
        }
    }
}
