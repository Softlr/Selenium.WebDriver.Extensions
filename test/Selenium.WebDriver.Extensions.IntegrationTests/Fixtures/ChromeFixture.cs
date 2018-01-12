namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using OpenQA.Selenium.Chrome;

    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class ChromeFixture : FixtureBase
    {
        public ChromeFixture() => Browser = new ChromeDriver();
    }
}