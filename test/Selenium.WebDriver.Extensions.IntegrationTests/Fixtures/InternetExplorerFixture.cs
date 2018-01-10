namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using OpenQA.Selenium.IE;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class InternetExplorerFixture : FixtureBase
    {
        public InternetExplorerFixture() => Browser = new InternetExplorerDriver();
    }
}