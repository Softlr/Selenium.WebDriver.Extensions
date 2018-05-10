namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using Xunit;

    [ExcludeFromCodeCoverage]
    [CollectionDefinition(Trait.Browser.CHROME)]
    public class ChromeCollection : ICollectionFixture<ChromeFixture>
    {
    }
}