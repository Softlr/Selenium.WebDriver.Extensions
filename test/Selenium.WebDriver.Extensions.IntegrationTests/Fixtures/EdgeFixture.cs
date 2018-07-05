namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using JetBrains.Annotations;
    using OpenQA.Selenium.Edge;

    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class EdgeFixture : FixtureBase
    {
        public EdgeFixture() =>
            Browser = new EdgeDriver(Path.GetDirectoryName(typeof(EdgeFixture).Assembly.Location));
    }
}
