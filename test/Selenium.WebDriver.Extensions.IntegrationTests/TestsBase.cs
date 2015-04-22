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
            var config = new HostConfiguration { UrlReservations = { CreateAutomatically = true } };

            this.host = new NancyHost(config, new Uri(Resources.HostUrl));
            this.host.Start();
        }

        protected IWebDriver Browser { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
        public void Dispose()
        {
            this.host.Dispose();
        }
    }
}
