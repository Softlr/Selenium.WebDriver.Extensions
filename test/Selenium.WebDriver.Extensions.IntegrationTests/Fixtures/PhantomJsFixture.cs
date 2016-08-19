namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class PhantomJsFixture : IDisposable
    {
        private readonly PhantomJSDriverService _service;
        private bool _disposed;

        public PhantomJsFixture()
        {
            _service = PhantomJSDriverService.CreateDefaultService();
            _service.SslProtocol = "any";
            Browser = new PhantomJSDriver(_service);
        }

        ~PhantomJsFixture()
        {
            Dispose(false);
        }

        public IWebDriver Browser { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [SuppressMessage(
            "Microsoft.Usage",
            "CA2213:DisposableFieldsShouldBeDisposed",
            MessageId = "<Browser>k__BackingField")]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed || !disposing)
            {
                return;
            }

            Browser.Dispose();
            _service.Dispose();
            _disposed = true;
        }
    }
}
