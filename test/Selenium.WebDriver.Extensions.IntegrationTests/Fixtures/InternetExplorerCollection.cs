namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using Xunit;

    [ExcludeFromCodeCoverage]
    [CollectionDefinition(Trait.Browser.INTERNET_EXPLORER)]
    public class InternetExplorerCollection : ICollectionFixture<InternetExplorerFixture>
    {
    }
}