namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    [ExcludeFromCodeCoverage]
    public class EdgeFixture : FixtureBase
    {
        public EdgeFixture()
        {
            var options = new EdgeOptions();
            options.AddArgument("headless");
            options.AddArgument("disable-gpu");
            Browser = new EdgeDriver(Path.GetDirectoryName(typeof(EdgeFixture).Assembly.Location), options);
        }
    }
}
