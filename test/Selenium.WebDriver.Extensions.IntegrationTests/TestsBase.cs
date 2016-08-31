namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Nancy.Hosting.Self;
    using OpenQA.Selenium;
    using PostSharp.Patterns.Model;

    [ExcludeFromCodeCoverage]
    [Disposable]
    public abstract class TestsBase
    {
        protected TestsBase()
        {
            var config = new HostConfiguration { UrlReservations = { CreateAutomatically = true } };

            ServerUrl = "http://localhost:50502";
            Host = new NancyHost(config, new Uri(ServerUrl));
            Host.Start();
        }

        [Reference]
        protected IWebDriver Browser { get; set; }

        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        protected string ServerUrl { get; }

        [Reference]
        private NancyHost Host { get; }
    }
}
