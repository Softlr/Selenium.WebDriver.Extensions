namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Firefox;

    [ExcludeFromCodeCoverage]
    public class FirefoxFixture : FixtureBase
    {
        public FirefoxFixture()
        {
            var options = new FirefoxOptions();
            options.AddArguments("--headless");
            Browser = new FirefoxDriver(
                FirefoxDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
        }
    }
}
