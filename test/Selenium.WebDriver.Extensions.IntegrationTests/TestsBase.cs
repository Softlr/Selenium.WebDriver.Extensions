namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public abstract class TestsBase
    {
        protected TestsBase(IWebDriver browser, string path)
        {
            Browser = browser;
            Browser.Navigate().GoToUrl(new Uri($"{Fixture.SERVER_URL}{path}"));
        }

        protected IWebDriver Browser { get; }
    }
}
