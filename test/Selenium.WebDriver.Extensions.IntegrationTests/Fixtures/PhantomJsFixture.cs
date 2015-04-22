namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class PhantomJsFixture : IDisposable
    {
        private bool disposed;

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public PhantomJsFixture()
        {
            var phantomJsService = PhantomJSDriverService.CreateDefaultService();
            phantomJsService.SslProtocol = "any";
            this.Browser = new PhantomJSDriver(phantomJsService);
        }

        ~PhantomJsFixture()
        {
            this.Dispose(false);
        }

        public IWebDriver Browser { get; private set; }

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

            this.Browser.Dispose();
            this.disposed = true;
        }
    }
}
