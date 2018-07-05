namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture;
    using AutoFixture.AutoNSubstitute;
    using NSubstitute;
    using OpenQA.Selenium;
    using static Softlr.Suppress;

    [ExcludeFromCodeCoverage]
    [SuppressMessage(SONARQUBE, S4058)]
    internal class WebDriverBuilder
    {
        private readonly IWebDriver _driver;
        private readonly IFixture _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());

        public WebDriverBuilder() => _driver = Substitute.For<IWebDriver, IJavaScriptExecutor>();

        public IWebDriver Build() => _driver;

        public WebDriverBuilder WithElementLocatedByJQuery(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains($"jQuery('{selector}')")), Arg.Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>() });
            return this;
        }

        public WebDriverBuilder WithElementLocatedBySizzle(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains($"Sizzle('{selector}')")), Arg.Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>() });
            return this;
        }

        public WebDriverBuilder WithElementsLocatedByJQuery(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains($"jQuery('{selector}')")), Arg.Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>(), _fixture.Create<IWebElement>() });
            return this;
        }

        public WebDriverBuilder WithElementsLocatedBySizzle(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains($"Sizzle('{selector}')")), Arg.Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>(), _fixture.Create<IWebElement>() });
            return this;
        }

        public WebDriverBuilder WithJQueryLoaded()
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains("window.jQuery")), Arg.Any<object[]>()).Returns(true);
            return this;
        }

        public WebDriverBuilder WithNoElementLocatedByJQuery(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains($"jQuery('{selector}')")), Arg.Any<object[]>())
                .Returns(new List<IWebElement>());
            return this;
        }

        public WebDriverBuilder WithNoElementLocatedBySizzle(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains($"Sizzle('{selector}')")), Arg.Any<object[]>())
                .Returns(new List<IWebElement>());
            return this;
        }

        public WebDriverBuilder WithNoExternalLibraryLoaded()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(Arg.Any<string>()).Returns(false, null, true);
            return this;
        }

        public WebDriverBuilder WithPathToElement(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains("function(element)")), Arg.Any<object[]>())
                .Returns($"body > {selector}");
            return this;
        }

        public WebDriverBuilder WithSizzleLoaded()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(
                    Arg.Is<string>(s => s.Contains("window.Sizzle")), Arg.Any<object[]>())
                .Returns(true);
            return this;
        }

        public WebDriverBuilder WithTestMethodDefined(string methodName)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript($"{methodName}();").Returns("foo");
            return this;
        }
    }
}
