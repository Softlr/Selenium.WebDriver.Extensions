namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class PhantomJsFixture : IDisposable
    {
        public PhantomJsFixture()
        {
            Service = PhantomJSDriverService.CreateDefaultService();
            Service.SslProtocol = "any";
            Browser = new PhantomJSDriver(Service);
        }

        public IWebDriver Browser { get; }

        private PhantomJSDriverService Service { get; }

        public void Dispose()
        {
            Browser?.Quit();
            Browser?.Dispose();
            Service?.Dispose();
        }
    }
}
