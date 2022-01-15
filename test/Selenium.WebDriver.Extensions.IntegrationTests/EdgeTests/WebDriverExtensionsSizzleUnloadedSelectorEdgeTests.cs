namespace Selenium.WebDriver.Extensions.IntegrationTests.EdgeTests
{
    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, EDGE)]
    [ExcludeFromCodeCoverage]
    [Collection(EDGE)]
    public class WebDriverExtensionsSizzleUnloadedSelectorEdgeTests : SelectorTests<SizzleSelector>
    {
        public WebDriverExtensionsSizzleUnloadedSelectorEdgeTests(EdgeFixture fixture)
            : base(fixture, UnloadedPath, x => SizzleSelector(x))
        {
        }
    }
}
