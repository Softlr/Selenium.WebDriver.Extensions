namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using Nancy.Hosting.Self;
    using OpenQA.Selenium;
    using PostSharp.Patterns.Model;

    [Disposable]
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public abstract class TestsBase
    {
        protected TestsBase(IWebDriver browser, string path)
        {
            var config = new HostConfiguration { UrlReservations = { CreateAutomatically = true } };

            const string serverUrl = "http://localhost:54321";
            Host = new NancyHost(config, new Uri(serverUrl));
            Host.Start();

            Browser = browser;
            Browser.Navigate().GoToUrl(new Uri($"{serverUrl}{path}"));
        }

        [Child]
        protected NancyHost Host { get; }

        [Reference]
        protected IWebDriver Browser { get; }
    }
}