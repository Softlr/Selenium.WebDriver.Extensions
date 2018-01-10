namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Nancy.Hosting.Self;
    using OpenQA.Selenium;

    [ExcludeFromCodeCoverage]
    public abstract class TestsBase : IDisposable
    {
        private readonly NancyHost _host;
        private bool _disposed;

        protected TestsBase()
        {
            var config = new HostConfiguration { UrlReservations = { CreateAutomatically = true } };

            ServerUrl = "http://localhost:50502";
            _host = new NancyHost(config, new Uri(ServerUrl));
            _host.Start();
        }

        ~TestsBase() => Dispose(false);

        protected IWebDriver Browser { get; set; }

        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        protected string ServerUrl { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global")]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed || !disposing)
            {
                return;
            }

            _host.Dispose();
            _disposed = true;
        }
    }
}