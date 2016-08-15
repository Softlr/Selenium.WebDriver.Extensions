﻿namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class PhantomJsFixture : IDisposable
    {
        private readonly PhantomJSDriverService service;

        private bool disposed;

        public PhantomJsFixture()
        {
            this.service = PhantomJSDriverService.CreateDefaultService();
            this.service.SslProtocol = "any";
            this.Browser = new PhantomJSDriver(this.service);
        }

        ~PhantomJsFixture()
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
            this.service.Dispose();
            this.disposed = true;
        }
    }
}
