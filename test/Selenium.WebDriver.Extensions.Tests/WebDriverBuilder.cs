namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture;
    using AutoFixture.AutoNSubstitute;
    using NSubstitute;
    using OpenQA.Selenium;

    [ExcludeFromCodeCoverage]
    internal class WebDriverBuilder
    {
        private readonly IWebDriver _driver;
        private readonly IFixture _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());

        public WebDriverBuilder() => _driver = Substitute.For<IWebDriver, IJavaScriptExecutor>();

        public IWebDriver Build() => _driver;

        public WebDriverBuilder ThatDoesNotHaveExternalLibraryLoaded()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(Arg.Any<string>()).Returns(false, null, true);
            return this;
        }

        public void VerifyIfExternalLibraryWasLoaded() =>
            ((IJavaScriptExecutor)_driver).Received(3).ExecuteScript(Arg.Any<string>());

        public WebDriverBuilder ThatHasTestMethodDefined(string methodName)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript($"{methodName}();").Returns("foo");
            return this;
        }

        public void VerifyIfTestMethodWasCalled(string methodName) =>
            ((IJavaScriptExecutor)_driver).Received(1).ExecuteScript($"{methodName}();");

        public WebDriverBuilder ThatHasJQueryLoaded()
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains("window.jQuery")), Arg.Any<object[]>()).Returns(true);
            return this;
        }

        public WebDriverBuilder ThatContainsElementLocatedByJQuery(string selector)
        {
            selector = $"jQuery('{selector}')";
            ((IJavaScriptExecutor)_driver).ExecuteScript(Arg.Is<string>(s => s.Contains(selector)), Arg.Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>() });
            return this;
        }

        public WebDriverBuilder ThatContainsElementsLocatedByJQuery(string selector)
        {
            selector = $"jQuery('{selector}')";
            ((IJavaScriptExecutor)_driver).ExecuteScript(Arg.Is<string>(s => s.Contains(selector)), Arg.Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>(), _fixture.Create<IWebElement>() });
            return this;
        }

        public WebDriverBuilder ThatDoesNotContainElementLocatedByJQuery(string selector)
        {
            selector = $"jQuery('{selector}')";
            ((IJavaScriptExecutor)_driver).ExecuteScript(Arg.Is<string>(s => s.Contains(selector)), Arg.Any<object[]>())
                .Returns(new List<IWebElement>());
            return this;
        }

        public WebDriverBuilder ThatCanResolvePathToElement(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains("function(element)")), Arg.Any<object[]>())
                .Returns($"body > {selector}");
            return this;
        }

        public WebDriverBuilder ThatHasSizzleLoaded()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(Arg.Is<string>(s => s.Contains("window.Sizzle")), Arg.Any<object[]>())
                .Returns(true);
            return this;
        }

        public WebDriverBuilder ThatContainsElementLocatedBySizzle(string selector)
        {
            selector = $"Sizzle('{selector}')";
            ((IJavaScriptExecutor)_driver).ExecuteScript(Arg.Is<string>(s => s.Contains(selector)), Arg.Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>() });
            return this;
        }

        public WebDriverBuilder ThatContainsElementsLocatedBySizzle(string selector)
        {
            selector = $"Sizzle('{selector}')";
            ((IJavaScriptExecutor)_driver).ExecuteScript(Arg.Is<string>(s => s.Contains(selector)), Arg.Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>(), _fixture.Create<IWebElement>() });
            return this;
        }

        public WebDriverBuilder ThatDoesNotContainElementLocatedBySizzle(string selector)
        {
            selector = $"Sizzle('{selector}')";
            ((IJavaScriptExecutor)_driver).ExecuteScript(Arg.Is<string>(s => s.Contains(selector)), Arg.Any<object[]>())
                .Returns(new List<IWebElement>());
            return this;
        }
    }
}