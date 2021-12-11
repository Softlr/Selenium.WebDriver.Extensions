namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture;
    using AutoFixture.AutoNSubstitute;
    using NSubstitute;
    using OpenQA.Selenium;
    using static NSubstitute.Arg;
    using static NSubstitute.Substitute;
    using static Softlr.Suppress;

    [ExcludeFromCodeCoverage]
    [SuppressMessage(SONARQUBE, S4058)]
    internal class WebDriverBuilder
    {
        private readonly IWebDriver _driver;
        private readonly IFixture _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());

        internal WebDriverBuilder() => _driver = For<IWebDriver, IJavaScriptExecutor>();

        internal IWebDriver Build() => _driver;

        internal WebDriverBuilder WithElementLocatedByJQuery(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Is<string>(s => s.Contains($"jQuery('{selector}')")), Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>() });
            return this;
        }

        internal WebDriverBuilder WithElementLocatedBySizzle(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Is<string>(s => s.Contains($"Sizzle('{selector}')")), Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>() });
            return this;
        }

        internal WebDriverBuilder WithElementsLocatedByJQuery(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Is<string>(s => s.Contains($"jQuery('{selector}')")), Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>(), _fixture.Create<IWebElement>() });
            return this;
        }

        internal WebDriverBuilder WithElementsLocatedBySizzle(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Is<string>(s => s.Contains($"Sizzle('{selector}')")), Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>(), _fixture.Create<IWebElement>() });
            return this;
        }

        internal WebDriverBuilder WithJQueryLoaded()
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Is<string>(s => s.Contains("window.jQuery")), Any<object[]>()).Returns(true);
            return this;
        }

        internal WebDriverBuilder WithNoElementLocatedByJQuery(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Is<string>(s => s.Contains($"jQuery('{selector}')")), Any<object[]>())
                .Returns(new List<IWebElement>());
            return this;
        }

        internal WebDriverBuilder WithNoElementLocatedBySizzle(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Is<string>(s => s.Contains($"Sizzle('{selector}')")), Any<object[]>())
                .Returns(new List<IWebElement>());
            return this;
        }

        internal WebDriverBuilder WithNoExternalLibraryLoaded()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(Any<string>()).Returns(false, null, true);
            return this;
        }

        internal WebDriverBuilder WithPathToElement(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Is<string>(s => s.Contains("function(element)")), Any<object[]>())
                .Returns($"body > {selector}");
            return this;
        }

        internal WebDriverBuilder WithSizzleLoaded()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(Is<string>(s => s.Contains("window.Sizzle")), Any<object[]>())
                .Returns(true);
            return this;
        }

        internal WebDriverBuilder WithTestMethodDefined(string methodName)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript($"{methodName}();").Returns("foo");
            return this;
        }
    }
}
