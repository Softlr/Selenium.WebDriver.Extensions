namespace Selenium.WebDriver.Extensions.IntegrationTests.EdgeTests
{
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using static By;
    using static TestCaseModule;
    using static Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, EDGE)]
    [ExcludeFromCodeCoverage]
    [Collection(EDGE)]
    public class WebDriverExtensionsSizzleUnloadedSelectorEdgeTests : SelectorTests<SizzleSelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsSizzleUnloadedSelectorEdgeTests(EdgeFixture fixture)
            : base(fixture, UNLOADED, x => SizzleSelector(x))
        {
        }
    }
}
