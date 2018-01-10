namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class FirefoxFixture : IDisposable
    {
        public FirefoxFixture()
        {
            Service = FirefoxDriverService.CreateDefaultService();
            Service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            Browser = new FirefoxDriver(Service);
        }

        public IWebDriver Browser { get; }

        private FirefoxDriverService Service { get; }

        public void Dispose()
        {
            Browser?.Quit();
            Browser?.Dispose();
            Service?.Dispose();
        }
    }
}
