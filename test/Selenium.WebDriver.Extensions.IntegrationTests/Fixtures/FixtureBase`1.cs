namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;

    public class FixtureBase<TDriverService> : IDisposable
        where TDriverService : DriverService
    {
        private bool _disposed;

        protected FixtureBase()
        {
        }

        ~FixtureBase() => Dispose(false);

        public IWebDriver Browser { get; protected set; }
        protected TDriverService Service { get; set; }

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

            Service?.Dispose();
            Browser?.Quit();
            Browser?.Dispose();
            _disposed = true;
        }
    }
}