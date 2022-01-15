namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    [ExcludeFromCodeCoverage]
    public class InternetExplorerFixture : FixtureBase
    {
        public InternetExplorerFixture() =>
            Browser = new InternetExplorerDriver(
                Path.GetDirectoryName(typeof(InternetExplorerFixture).Assembly.Location));
    }
}
