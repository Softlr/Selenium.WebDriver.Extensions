namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using PostSharp.Patterns.Model;

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [Disposable]
    public class ChromeFixture
    {
        public ChromeFixture()
        {
            Browser = new ChromeDriver();
        }

        [Child]
        public IWebDriver Browser { get; }
    }
}