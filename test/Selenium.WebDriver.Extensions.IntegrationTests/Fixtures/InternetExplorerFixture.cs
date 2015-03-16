namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;

    public class InternetExplorerFixture : IDisposable
    {
        public InternetExplorerFixture()
        {
            this.Browser = new InternetExplorerDriver();
        }

        public IWebDriver Browser { get; set; }

        public void Dispose()
        {
            this.Browser.Dispose();
        }
    }
}
