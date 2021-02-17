namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using OpenQA.Selenium.IE;

    [ExcludeFromCodeCoverage]
    public class InternetExplorerFixture : FixtureBase
    {
        public InternetExplorerFixture() =>
            Browser = new InternetExplorerDriver(
                Path.GetDirectoryName(typeof(InternetExplorerFixture).Assembly.Location));
    }
}
