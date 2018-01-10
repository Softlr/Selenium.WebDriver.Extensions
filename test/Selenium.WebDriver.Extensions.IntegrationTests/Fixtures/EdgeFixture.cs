namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Edge;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class EdgeFixture : FixtureBase
    {
        public EdgeFixture() => Browser = new EdgeDriver();
    }
}