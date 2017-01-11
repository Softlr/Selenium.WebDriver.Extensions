namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using PostSharp.Patterns.Model;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [Disposable]
    public class FirefoxFixture
    {
        public FirefoxFixture()
        {
            Service = FirefoxDriverService.CreateDefaultService();
            Service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            Browser = new FirefoxDriver(Service);
        }

        [Child]
        public IWebDriver Browser { get; }

        [Child]
        private FirefoxDriverService Service { get; }
    }
}