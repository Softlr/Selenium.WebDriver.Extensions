namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using static Tests.Shared.Trait;

    [ExcludeFromCodeCoverage]
    [CollectionDefinition(FIREFOX)]
    public class FirefoxCollection : ICollectionFixture<FirefoxFixture>
    {
    }
}