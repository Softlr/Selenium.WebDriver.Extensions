namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using OpenQA.Selenium.Chrome;

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
