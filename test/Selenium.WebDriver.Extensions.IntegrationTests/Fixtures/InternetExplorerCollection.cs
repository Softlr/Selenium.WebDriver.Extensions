namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using static Extensions.Tests.Shared.Trait.Browser;

    [ExcludeFromCodeCoverage]
    [CollectionDefinition(INTERNET_EXPLORER)]
    public class InternetExplorerCollection : ICollectionFixture<InternetExplorerFixture>
    {
    }
}