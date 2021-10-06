namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Firefox;

    [ExcludeFromCodeCoverage]
    public class FirefoxFixture : FixtureBase
    {
        public FirefoxFixture()
        {
            var service = FirefoxDriverService.CreateDefaultService();
            service.Host = "::1";
            var options = new FirefoxOptions();
            options.AddArguments("--headless");
            Browser = new FirefoxDriver(service, options);
        }
    }
}
