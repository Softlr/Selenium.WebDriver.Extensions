namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using PostSharp.Patterns.Model;

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