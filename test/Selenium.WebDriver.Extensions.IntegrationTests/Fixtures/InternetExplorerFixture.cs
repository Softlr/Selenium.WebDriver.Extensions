namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class InternetExplorerFixture : IDisposable
    {
        private bool disposed;

        public InternetExplorerFixture()
        {
            this.Browser = new InternetExplorerDriver();
        }

        ~InternetExplorerFixture()
        {
            this.Dispose(false);
        }

        public IWebDriver Browser { get; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        [SuppressMessage(
            "Microsoft.Usage",
            "CA2213:DisposableFieldsShouldBeDisposed",
            MessageId = "<Browser>k__BackingField")]
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
