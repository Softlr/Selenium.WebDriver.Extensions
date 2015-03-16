namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    
    public class FirefoxFixture : IDisposable
    {
        public FirefoxFixture()
        {
            this.Browser = new FirefoxDriver();
        }

        public IWebDriver Browser { get; set; }

        public void Dispose()
        {
            this.Browser.Dispose();
        }
    }
}
