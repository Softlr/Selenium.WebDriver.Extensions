namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;
    
    public class PhantomJsFixture : IDisposable
    {
        public PhantomJsFixture()
        {
            var phantomJsService = PhantomJSDriverService.CreateDefaultService();
            phantomJsService.SslProtocol = "any";
            this.Browser = new PhantomJSDriver(phantomJsService);
        }

        public IWebDriver Browser { get; set; }

        public void Dispose()
        {
            this.Browser.Dispose();
        }
    }
}
