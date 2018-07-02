namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using JetBrains.Annotations;
    using OpenQA.Selenium.IE;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;

    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class InternetExplorerFixture : FixtureBase
    {
        public InternetExplorerFixture() =>
            Browser = new InternetExplorerDriver(
                Path.GetDirectoryName(typeof(InternetExplorerFixture).Assembly.Location));
    }
}
