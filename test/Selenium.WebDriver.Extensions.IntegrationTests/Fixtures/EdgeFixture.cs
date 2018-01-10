namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using OpenQA.Selenium.Edge;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class EdgeFixture : FixtureBase
    {
        public EdgeFixture() => Browser = new EdgeDriver();
    }
}