namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    
    public class ChromeFixture : IDisposable
    {
        public ChromeFixture()
        {
            this.Browser = new ChromeDriver();
        }

        public IWebDriver Browser { get; set; }

        public void Dispose()
        {
            this.Browser.Dispose();
        }
    }
}
