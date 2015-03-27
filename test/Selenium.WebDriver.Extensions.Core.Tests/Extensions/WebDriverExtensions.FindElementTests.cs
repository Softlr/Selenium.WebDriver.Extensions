namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Moq;
    using OpenQA.Selenium;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.Core.By;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class WebDriverExtensionsFindElementTests
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
                .Setup(x => x.ExecuteScript(It.IsRegex("document.querySelectorAll\\('div'\\).length === 0")))
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

            var ex = Assert.Throws<ArgumentNullException>(() => driverMock.Object.FindElement((QuerySelector)null));
            Assert.Equal("selector", ex.ParamName);
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
        public void ShouldThrowExceptionWhenFindingElementReturnsEmptyResult()
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
        public void ShouldThrowExceptionWhenFindingElementWithNullDriver()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => WebDriverExtensions.FindElement(null, null));
            Assert.Equal("driver", ex.ParamName);
        }
    }
}
