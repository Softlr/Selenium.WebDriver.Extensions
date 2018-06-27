namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using JetBrains.Annotations;
    using OpenQA.Selenium.Edge;

    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class EdgeFixture : FixtureBase
    {
        public EdgeFixture() =>
            Browser = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
    }
}
