namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;

    [ExcludeFromCodeCoverage]
    public class InternetExplorerFixture : IDisposable
    {
        public InternetExplorerFixture()
        {
            this.Browser = new InternetExplorerDriver();
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
