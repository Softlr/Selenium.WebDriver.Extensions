namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Moq;
    using OpenQA.Selenium;

    [ExcludeFromCodeCoverage]
    internal class WebDriverBuilder
    {
        private readonly Mock<IWebDriver> _driverMock;

        public WebDriverBuilder()
        {
            _driverMock = new Mock<IWebDriver>();
        }

        public IWebDriver Build() => _driverMock.Object;

        public WebDriverBuilder ThatDoesNotHaveExternalLibraryLoaded()
        {
            _driverMock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>()))
                .Returns(false).Returns(null).Returns(true);
            return this;
        }

        public void VerifyIfExternalLibraryWasLoaded() =>
            _driverMock.As<IJavaScriptExecutor>().Verify(x => x.ExecuteScript(It.IsAny<string>()), Times.Exactly(3));

        public WebDriverBuilder ThatHasTestMethodDefined(string methodName)
        {
            _driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript($"{methodName}();"))
                .Returns("foo");
            return this;
        }

        public void VerifyIfTestMethodWasCalled(string methodName) =>
            _driverMock.As<IJavaScriptExecutor>().Verify(x => x.ExecuteScript($"{methodName}();"), Times.Once);

        public WebDriverBuilder ThatHasJQueryLoaded()
        {
            _driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.jQuery")), It.IsAny<object[]>()))
                .Returns(true);
            return this;
        }

        public WebDriverBuilder ThatContainsElementLocatedByJQuery(string selector)
        {
            selector = $"jQuery('{selector}')";
            _driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains(selector)), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });
            return this;
        }

        public WebDriverBuilder ThatContainsElementsLocatedByJQuery(string selector)
        {
            selector = $"jQuery('{selector}')";
            _driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains(selector)), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object, new Mock<IWebElement>().Object });
            return this;
        }

        public WebDriverBuilder ThatDoesNotContainElementLocatedByJQuery(string selector)
        {
            selector = $"jQuery('{selector}')";
            _driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains(selector)), It.IsAny<object[]>()))
                .Returns(new List<IWebElement>());
            return this;
        }

        public WebDriverBuilder ThatCanResolvePathToElement(string selector)
        {
            _driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("function(element)")), It.IsAny<object[]>()))
                .Returns($"body > {selector}");
            return this;
        }

        public WebDriverBuilder ThatHasSizzleLoaded()
        {
            _driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            return this;
        }

        public WebDriverBuilder ThatContainsElementLocatedBySizzle(string selector)
        {
            selector = $"Sizzle('{selector}')";
            _driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains(selector)), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });
            return this;
        }

        public WebDriverBuilder ThatContainsElementsLocatedBySizzle(string selector)
        {
            selector = $"Sizzle('{selector}')";
            _driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains(selector)), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object, new Mock<IWebElement>().Object });
            return this;
        }

        public WebDriverBuilder ThatDoesNotContainElementLocatedBySizzle(string selector)
        {
            selector = $"Sizzle('{selector}')";
            _driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains(selector)), It.IsAny<object[]>()))
                .Returns(new List<IWebElement>());
            return this;
        }
    }
}