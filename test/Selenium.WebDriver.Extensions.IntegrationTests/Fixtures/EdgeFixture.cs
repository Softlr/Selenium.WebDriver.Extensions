namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using OpenQA.Selenium.Edge;

    [ExcludeFromCodeCoverage]
    public class EdgeFixture : FixtureBase
    {
        public EdgeFixture()
        {
            var options = new EdgeOptions { UseChromium = true };
            options.AddArgument("headless");
            options.AddArgument("disable-gpu");
            Browser = new EdgeDriver(Path.GetDirectoryName(typeof(EdgeFixture).Assembly.Location), options);
        }
    }
}
