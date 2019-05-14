namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using static Softlr.Suppress;

    [ExcludeFromCodeCoverage]
    public abstract class TestsBase
    {
        [SuppressMessage(SONARQUBE, S3900)]
        protected TestsBase(FixtureBase fixture, string path)
        {
            Browser = fixture.Browser;
            Browser.Navigate().GoToUrl(new Uri($"{fixture.ServerUrl}{path}"));
        }

        protected IWebDriver Browser { get; }
    }
}
