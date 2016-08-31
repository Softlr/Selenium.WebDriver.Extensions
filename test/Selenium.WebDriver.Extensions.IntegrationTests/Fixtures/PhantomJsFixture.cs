namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
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

        [Reference]
        public IWebDriver Browser { get; }

        [Reference]
        private PhantomJSDriverService Service { get; }
    }
}
