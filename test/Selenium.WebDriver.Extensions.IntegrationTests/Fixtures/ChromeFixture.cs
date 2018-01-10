namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using OpenQA.Selenium.Chrome;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class ChromeFixture : FixtureBase
    {
        public ChromeFixture() => Browser = new ChromeDriver();
    }
}