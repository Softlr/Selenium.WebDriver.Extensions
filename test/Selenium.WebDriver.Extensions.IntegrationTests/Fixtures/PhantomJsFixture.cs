namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;

#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class PhantomJsFixture : IDisposable
    {
        public PhantomJsFixture()
        {
            var phantomJsService = PhantomJSDriverService.CreateDefaultService();
            phantomJsService.SslProtocol = "any";
            this.Browser = new PhantomJSDriver(phantomJsService);
        }

        public IWebDriver Browser { get; set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Browser.Dispose();
            }
        }
    }
}
