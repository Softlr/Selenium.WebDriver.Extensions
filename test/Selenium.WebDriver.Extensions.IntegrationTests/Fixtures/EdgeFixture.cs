namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Edge;

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class EdgeFixture : IDisposable
    {
        public EdgeFixture() => Browser = new EdgeDriver();

        public IWebDriver Browser { get; }

        public void Dispose()
        {
            Browser?.Quit();
            Browser?.Dispose();
        }
    }
}
