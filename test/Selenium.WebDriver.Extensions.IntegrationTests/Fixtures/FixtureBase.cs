namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Nancy.Hosting.Self;
    using OpenQA.Selenium;

    [ExcludeFromCodeCoverage]
    public class FixtureBase : IDisposable
    {
        private readonly NancyHost _host;
        private bool _disposed;

        protected FixtureBase()
        {
            var config = new HostConfiguration { UrlReservations = { CreateAutomatically = true } };

            _host = new NancyHost(config, new Uri(Fixture.SERVER_URL));
            _host.Start();
        }

        ~FixtureBase() => Dispose(false);

        public IWebDriver Browser { get; protected set; }

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

            Browser?.Quit();
            Browser?.Dispose();
            _host.Dispose();
            _disposed = true;
        }
    }
}