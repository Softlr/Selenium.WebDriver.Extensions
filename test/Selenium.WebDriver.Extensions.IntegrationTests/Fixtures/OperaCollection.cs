namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using static Tests.Shared.Trait;

    [ExcludeFromCodeCoverage]
    [CollectionDefinition(OPERA)]
    public class OperaCollection : ICollectionFixture<OperaFixture>
    {
    }
}
