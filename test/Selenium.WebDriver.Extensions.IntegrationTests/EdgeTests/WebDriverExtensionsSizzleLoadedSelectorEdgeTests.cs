namespace Selenium.WebDriver.Extensions.IntegrationTests.EdgeTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Xunit;
    using static By;
    using static Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, EDGE)]
    [ExcludeFromCodeCoverage]
    [Collection(EDGE)]
    public class WebDriverExtensionsSizzleLoadedSelectorEdgeTests : SelectorTests<SizzleSelector>
    {
        public WebDriverExtensionsSizzleLoadedSelectorEdgeTests(EdgeFixture fixture)
            : base(fixture, SizzleTestPath, x => SizzleSelector(x))
        {
        }
    }
}
