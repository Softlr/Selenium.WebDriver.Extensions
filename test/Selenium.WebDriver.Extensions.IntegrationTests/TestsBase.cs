namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;

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