namespace Selenium.WebDriver.Extensions.IntegrationTests.EdgeTests
{
    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, EDGE)]
    [ExcludeFromCodeCoverage]
    [Collection(EDGE)]
    public class WebDriverExtensionsJQueryLoadedSelectorEdgeTests : SelectorTests<JQuerySelector>
    {
        public WebDriverExtensionsJQueryLoadedSelectorEdgeTests(EdgeFixture fixture)
            : base(fixture, JQueryTestPath, x => JQuerySelector(x))
        {
        }
    }
}
