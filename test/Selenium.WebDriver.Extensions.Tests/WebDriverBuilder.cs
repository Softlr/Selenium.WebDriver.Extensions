namespace Selenium.WebDriver.Extensions.Tests
{
    [ExcludeFromCodeCoverage]
    [SuppressMessage(SONARQUBE, S4058)]
    internal class WebDriverBuilder
    {
        private readonly IWebDriver _driver;
        private readonly IFixture _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());

        internal WebDriverBuilder() => _driver = Substitute.For<IWebDriver, IJavaScriptExecutor>();

        internal IWebDriver Build() => _driver;

        internal WebDriverBuilder WithElementLocatedByJQuery(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains($"jQuery('{selector}')")), Arg.Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>() });
            return this;
        }

        internal WebDriverBuilder WithElementLocatedBySizzle(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains($"Sizzle('{selector}')")), Arg.Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>() });
            return this;
        }

        internal WebDriverBuilder WithElementsLocatedByJQuery(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains($"jQuery('{selector}')")), Arg.Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>(), _fixture.Create<IWebElement>() });
            return this;
        }

        internal WebDriverBuilder WithElementsLocatedBySizzle(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains($"Sizzle('{selector}')")), Arg.Any<object[]>())
                .Returns(new List<IWebElement> { _fixture.Create<IWebElement>(), _fixture.Create<IWebElement>() });
            return this;
        }

        internal WebDriverBuilder WithJQueryLoaded()
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains("window.jQuery")), Arg.Any<object[]>()).Returns(true);
            return this;
        }

        internal WebDriverBuilder WithNoElementLocatedByJQuery(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains($"jQuery('{selector}')")), Arg.Any<object[]>())
                .Returns(new List<IWebElement>());
            return this;
        }

        internal WebDriverBuilder WithNoElementLocatedBySizzle(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains($"Sizzle('{selector}')")), Arg.Any<object[]>())
                .Returns(new List<IWebElement>());
            return this;
        }

        internal WebDriverBuilder WithNoExternalLibraryLoaded()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(Arg.Any<string>()).Returns(false, null, true);
            return this;
        }

        internal WebDriverBuilder WithPathToElement(string selector)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains("function(element)")), Arg.Any<object[]>())
                .Returns($"body > {selector}");
            return this;
        }

        internal WebDriverBuilder WithSizzleLoaded()
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript(Arg.Is<string>(s => s.Contains("window.Sizzle")), Arg.Any<object[]>())
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
