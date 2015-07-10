namespace Selenium.WebDriver.Extensions.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using Moq;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.By;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class WebDriverExtensionsFindElementsTests
    {
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
        public void ShouldFindElementsWithNestedSelector()
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
                .Setup(x => x.ExecuteScript(It.IsRegex("document.querySelectorAll\\('div'\\).length === 0")))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            var result = driverMock.Object.FindElements(By.QuerySelector(".test", By.QuerySelector("div")));

            Assert.Equal(2, result.Count);

            Assert.Equal("div", result[0].TagName);
            Assert.Equal("test", result[0].GetAttribute("class"));

            Assert.Equal("span", result[1].TagName);
            Assert.Equal("test", result[1].GetAttribute("class"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenFindingElementsWithNullSelector()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(true);

            var ex = Assert.Throws<ArgumentNullException>(
                () => driverMock.Object.FindElements((Core.QuerySelector)null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldReturnEmptyResultWhenFindingElementsThatDoesNotExist()
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
        public void ShouldThrowExceptionWhenFindingElementsWithNullDriver()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => WebDriverExtensions.FindElements(null, null));
            Assert.Equal("driver", ex.ParamName);
        }
    }
}
