namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Nancy.Hosting.Self;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.IntegrationTests.Properties;

    [ExcludeFromCodeCoverage]
    public abstract class TestsBase : IDisposable
    {
        private readonly NancyHost host;

        protected TestsBase()
        {
            this.host = new NancyHost(new Uri(Resources.HostUrl));
            this.host.Start();
        }

        protected IWebDriver Browser { get; set; }

        public void Dispose()
        {
            this.host.Dispose();
        }
    }
}
