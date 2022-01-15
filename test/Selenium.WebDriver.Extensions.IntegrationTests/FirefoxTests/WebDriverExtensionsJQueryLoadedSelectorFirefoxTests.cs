namespace Selenium.WebDriver.Extensions.IntegrationTests.FirefoxTests
{
    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, FIREFOX)]
    [ExcludeFromCodeCoverage]
    [Collection(FIREFOX)]
    public class WebDriverExtensionsJQueryLoadedSelectorFirefoxTests : SelectorTests<JQuerySelector>
    {
        public WebDriverExtensionsJQueryLoadedSelectorFirefoxTests(FirefoxFixture fixture)
            : base(fixture, JQueryTestPath, x => JQuerySelector(x))
        {
        }
    }
}
