namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using Microsoft.AspNetCore.Hosting;
    using OpenQA.Selenium;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    [ExcludeFromCodeCoverage]
    public class FixtureBase : IDisposable
    {
        private readonly IWebHost _host;
        private bool _disposed;

        protected FixtureBase()
        {
            _host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseUrls(Fixture.SERVER_URL)
                .UseStartup<Startup>()
                .Build();
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
