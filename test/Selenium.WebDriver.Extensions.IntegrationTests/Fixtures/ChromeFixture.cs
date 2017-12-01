namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class ChromeFixture : IDisposable
    {
        public ChromeFixture() => Browser = new ChromeDriver();

        public IWebDriver Browser { get; }

        public void Dispose()
        {
            Browser?.Quit();
            Browser?.Dispose();
        }
    }
}
