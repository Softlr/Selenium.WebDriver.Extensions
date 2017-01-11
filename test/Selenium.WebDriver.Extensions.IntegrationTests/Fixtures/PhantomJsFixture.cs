namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;
    using PostSharp.Patterns.Model;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [Disposable]
    public class PhantomJsFixture
    {
        public PhantomJsFixture()
        {
            Service = PhantomJSDriverService.CreateDefaultService();
            Service.SslProtocol = "any";
            Browser = new PhantomJSDriver(Service);
        }

        [Child]
        public IWebDriver Browser { get; }

        [Child]
        private PhantomJSDriverService Service { get; }
    }
}
