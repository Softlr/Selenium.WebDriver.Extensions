namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using static Extensions.Tests.Shared.Trait.Browser;

    [ExcludeFromCodeCoverage]
    [CollectionDefinition(EDGE)]
    public class EdgeCollection : ICollectionFixture<EdgeFixture>
    {
    }
}