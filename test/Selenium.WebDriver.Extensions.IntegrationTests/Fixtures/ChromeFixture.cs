namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Chrome;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class ChromeFixture : FixtureBase
    {
        public ChromeFixture() => Browser = new ChromeDriver();
    }
}