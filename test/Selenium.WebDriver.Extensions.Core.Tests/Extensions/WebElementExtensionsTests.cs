namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Moq;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.Core.By;

    [Trait("Category", "Unit")]
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebElementExtensionsTests
    {
        private Mock<IWebDriver> driverMock;

        public WebElementExtensionsTests()
        {
            this.driverMock = new Mock<IWebDriver>();
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(true);
        }

        public void Dispose()
        {
            this.driverMock = null;
        }

        [Fact]
        public void ShouldGetPath()
        {
            var selector = new Mock<ISelector>();
            selector.SetupGet(x => x.Selector).Returns("div");
            selector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)"))).Returns("body > div");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(selector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(this.driverMock.Object);
            
            Assert.Equal("body > div", element.Object.Path);
        }

        [Fact]
        public void ShouldGetXPath()
        {
            var selector = new Mock<ISelector>();
            selector.SetupGet(x => x.Selector).Returns("div");
            selector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)"))).Returns("html[1]/body");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(selector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(this.driverMock.Object);

            Assert.Equal("html[1]/body", element.Object.XPath);
        }

        [Fact]
        public void ShouldFindElementWithXPath()
        {
            var element = new Mock<IWebElement>();
            element.SetupGet(x => x.TagName).Returns("body");

            var list = new List<IWebElement> { element.Object };
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("/html/body");
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("document\\.evaluate")))
                .Returns(new ReadOnlyCollection<IWebElement>(list));

            var result = this.driverMock.Object.FindElement(By.XPath("/html/body"));

            Assert.NotNull(result);
            Assert.Equal("body", result.TagName);
        }

        [Fact]
        public void ShouldFindElementWithQuerySelector()
        {
            var selector = By.QuerySelector("div");

            var rootElement = new Mock<IWebElement>();
            rootElement.SetupGet(x => x.TagName).Returns("div");

            var element = new Mock<IWebElement>();
            element.SetupGet(x => x.TagName).Returns("span");

            var rootList = new List<IWebElement> { rootElement.Object };
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return document.querySelectorAll('div');"))
                .Returns(new ReadOnlyCollection<IWebElement>(rootList));
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("body > div");
            var elementList = new List<IWebElement> { element.Object };
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(
                    "return document.querySelectorAll('body > div').length === 0 ? [] : document.querySelectorAll('body > div')[0].querySelectorAll('span');"))
                .Returns(new ReadOnlyCollection<IWebElement>(elementList));

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(this.driverMock.Object);

            var result = webElement.Object.FindElement(By.QuerySelector("span"));

            Assert.NotNull(result);
            Assert.Equal("span", result.TagName);
        }

        [Fact]
        public void ShouldFindElementsWithQuerySelector()
        {
            var selector = By.QuerySelector("div");

            var rootElement = new Mock<IWebElement>();
            rootElement.SetupGet(x => x.TagName).Returns("div");

            var element1 = new Mock<IWebElement>();
            element1.Setup(x => x.TagName).Returns("span");
            element1.Setup(x => x.GetAttribute("class")).Returns("test1");

            var element2 = new Mock<IWebElement>();
            element2.Setup(x => x.TagName).Returns("span");
            element2.Setup(x => x.GetAttribute("class")).Returns("test2");

            var rootList = new List<IWebElement> { rootElement.Object };
            var elementList = new List<IWebElement> { element1.Object, element2.Object };
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return document.querySelectorAll('div');"))
                .Returns(new ReadOnlyCollection<IWebElement>(rootList));
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("body > div");
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(
                    "return document.querySelectorAll('body > div').length === 0 ? [] : document.querySelectorAll('body > div')[0].querySelectorAll('span');"))
                .Returns(new ReadOnlyCollection<IWebElement>(elementList));

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(this.driverMock.Object);

            var result = webElement.Object.FindElements(By.QuerySelector("span"));

            Assert.Equal(2, result.Count);

            Assert.Equal("span", result[0].TagName);
            Assert.Equal("test1", result[0].GetAttribute("class"));
            
            Assert.Equal("span", result[1].TagName);
            Assert.Equal("test2", result[1].GetAttribute("class"));
        }
    }
}
