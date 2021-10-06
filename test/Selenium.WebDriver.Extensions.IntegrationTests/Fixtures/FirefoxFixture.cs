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
            Browser = new FirefoxDriver(service);
        }
    }
}
