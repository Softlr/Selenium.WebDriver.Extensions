namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using OpenQA.Selenium.IE;

    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class InternetExplorerFixture : FixtureBase<InternetExplorerDriverService>
    {
        public InternetExplorerFixture() => Browser = new InternetExplorerDriver();
    }
}