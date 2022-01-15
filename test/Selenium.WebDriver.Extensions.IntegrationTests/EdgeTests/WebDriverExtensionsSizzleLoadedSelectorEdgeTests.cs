namespace Selenium.WebDriver.Extensions.IntegrationTests.EdgeTests
{
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
