namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using OpenQA.Selenium.Chrome;

    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class ChromeFixture : FixtureBase<ChromeDriverService>
    {
        public ChromeFixture()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            Browser = new ChromeDriver(options);
        }
    }
}