namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Firefox;

    [ExcludeFromCodeCoverage]
    public class FirefoxFixture : FixtureBase
    {
        private const int TIMEOUT_MINUTES = 3;

        public FirefoxFixture()
        {
            var options = new FirefoxOptions();
            options.AddArguments("--headless");
            Browser = new FirefoxDriver(
                FirefoxDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(TIMEOUT_MINUTES));
        }
    }
}
