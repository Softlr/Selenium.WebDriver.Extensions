namespace OpenQA.Selenium.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Moq;

    [ExcludeFromCodeCoverage]
    internal class WebDriverBuilder
    {
        private readonly Mock<IWebDriver> driverMock;

        public WebDriverBuilder()
        {
            this.driverMock = new Mock<IWebDriver>();
        }

        public IWebDriver Build()
        {
            return this.driverMock.Object;
        }

        public WebDriverBuilder ThatDoesNotHaveExternalLibraryLoaded()
        {
            this.driverMock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>()))
                .Returns(false).Returns(null).Returns(true);
            return this;
        }

        public WebDriverBuilder ThatHasTestMethodDefined()
        {
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return myMethod();")).Returns("foo");
            return this;
        }

        public WebDriverBuilder ThatHasJQueryLoaded()
        {
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.jQuery")), It.IsAny<object[]>()))
                .Returns(true);
            return this;
        }

        public WebDriverBuilder ThatContainsElementLocatedByJQuery(string selector)
        {
            selector = $"jQuery('{selector}')";
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains(selector)), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });
            return this;
        }

        public WebDriverBuilder ThatContainsElementsLocatedByJQuery(string selector)
        {
            selector = $"jQuery('{selector}')";
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains(selector)), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object, new Mock<IWebElement>().Object });
            return this;
        }

        public WebDriverBuilder ThatDoesNotContainElementLocatedByJQuery(string selector)
        {
            selector = $"jQuery('{selector}')";
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains(selector)), It.IsAny<object[]>()))
                .Returns(new List<IWebElement>());
            return this;
        }

        public WebDriverBuilder ThatCanResolvePathToElement(string selector)
        {
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("function(element)")), It.IsAny<object[]>()))
                .Returns($"body > {selector}");
            return this;
        }

        public WebDriverBuilder ThatHasSizzleLoaded()
        {
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            return this;
        }

        public WebDriverBuilder ThatContainsElementLocatedBySizzle(string selector)
        {
            selector = $"Sizzle('{selector}')";
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains(selector)), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });
            return this;
        }

        public WebDriverBuilder ThatContainsElementsLocatedBySizzle(string selector)
        {
            selector = $"Sizzle('{selector}')";
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains(selector)), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object, new Mock<IWebElement>().Object });
            return this;
        }

        public WebDriverBuilder ThatDoesNotContainElementLocatedBySizzle(string selector)
        {
            selector = $"Sizzle('{selector}')";
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains(selector)), It.IsAny<object[]>()))
                .Returns(new List<IWebElement>());
            return this;
        }
    }
}
