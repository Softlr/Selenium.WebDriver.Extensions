namespace Selenium.WebDriver.Extensions.IntegrationTests.OperaTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Xunit;
    using static By;
    using static Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, OPERA)]
    [ExcludeFromCodeCoverage]
    [Collection(OPERA)]
    public class WebDriverExtensionsSizzleLoadedSelectorOperaTests : SelectorTests<SizzleSelector>
    {
        public WebDriverExtensionsSizzleLoadedSelectorOperaTests(OperaFixture fixture)
            : base(fixture, SizzleTestPath, x => SizzleSelector(x))
        {
        }
    }
}
