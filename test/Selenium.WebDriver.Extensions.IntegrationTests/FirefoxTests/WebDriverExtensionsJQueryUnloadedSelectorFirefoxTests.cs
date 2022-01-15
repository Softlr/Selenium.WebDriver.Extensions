namespace Selenium.WebDriver.Extensions.IntegrationTests.FirefoxTests
{
    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, FIREFOX)]
    [ExcludeFromCodeCoverage]
    [Collection(FIREFOX)]
    public class WebDriverExtensionsJQueryUnloadedSelectorFirefoxTests : SelectorTests<JQuerySelector>
    {
        public WebDriverExtensionsJQueryUnloadedSelectorFirefoxTests(FirefoxFixture fixture)
            : base(fixture, UnloadedPath, x => JQuerySelector(x))
        {
        }
    }
}
