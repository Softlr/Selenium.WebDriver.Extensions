namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Hosting.Server.Features;
    using OpenQA.Selenium;
    using static Softlr.Suppress;

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
                .UseStartup<Startup>()
                .Build();
            _host.Start();
            ServerUrl = _host.ServerFeatures.Get<IServerAddressesFeature>().Addresses.First();
        }

        ~FixtureBase() => Dispose(false);

        public IWebDriver Browser { get; protected set; }

        [SuppressMessage(SONARQUBE, S3996)]
        public string ServerUrl { get; }

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
