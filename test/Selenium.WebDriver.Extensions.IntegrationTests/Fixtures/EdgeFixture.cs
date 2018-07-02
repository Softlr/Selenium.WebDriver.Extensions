namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using JetBrains.Annotations;
    using OpenQA.Selenium.Edge;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;

    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class EdgeFixture : FixtureBase
    {
        public EdgeFixture() =>
            Browser = new EdgeDriver(Path.GetDirectoryName(typeof(EdgeFixture).Assembly.Location));
    }
}
