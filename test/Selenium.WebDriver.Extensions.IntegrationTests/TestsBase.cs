namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Nancy.Hosting.Self;
    using OpenQA.Selenium;

    [ExcludeFromCodeCoverage]
    public abstract class TestsBase : IDisposable
    {
        private readonly NancyHost host;

        private bool disposed;

        protected TestsBase()
        {
            var config = new HostConfiguration { UrlReservations = { CreateAutomatically = true } };

            this.ServerUrl = "http://localhost:50502";
            this.host = new NancyHost(config, new Uri(this.ServerUrl));
            this.host.Start();
        }

        ~TestsBase()
        {
            this.Dispose(false);
        }

        protected IWebDriver Browser { get; set; }

        protected string ServerUrl { get; private set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed || !disposing)
            {
                return;
            }

            this.host.Dispose();
            this.disposed = true;
        }
    }
}
