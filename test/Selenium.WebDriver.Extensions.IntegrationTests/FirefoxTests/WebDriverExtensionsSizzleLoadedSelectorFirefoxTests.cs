namespace Selenium.WebDriver.Extensions.IntegrationTests.FirefoxTests
{
    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, FIREFOX)]
    [ExcludeFromCodeCoverage]
    [Collection(FIREFOX)]
    public class WebDriverExtensionsSizzleLoadedSelectorFirefoxTests : SelectorTests<SizzleSelector>
    {
        public WebDriverExtensionsSizzleLoadedSelectorFirefoxTests(FirefoxFixture fixture)
            : base(fixture, SizzleTestPath, x => SizzleSelector(x))
        {
        }
    }
}
