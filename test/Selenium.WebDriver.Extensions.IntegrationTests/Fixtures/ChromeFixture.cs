namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    [ExcludeFromCodeCoverage]
    public class ChromeFixture : FixtureBase
    {
        public ChromeFixture()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            Browser = new ChromeDriver(Path.GetDirectoryName(typeof(ChromeFixture).Assembly.Location), options);
        }
    }
}
