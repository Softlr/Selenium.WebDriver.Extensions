namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.IE;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class InternetExplorerFixture : FixtureBase
    {
        public InternetExplorerFixture() => Browser = new InternetExplorerDriver();
    }
}