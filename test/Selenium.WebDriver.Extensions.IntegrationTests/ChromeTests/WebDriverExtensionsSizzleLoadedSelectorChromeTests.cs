namespace Selenium.WebDriver.Extensions.IntegrationTests.ChromeTests
{
    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, CHROME)]
    [ExcludeFromCodeCoverage]
    [Collection(CHROME)]
    public class WebDriverExtensionsSizzleLoadedSelectorChromeTests : SelectorTests<SizzleSelector>
    {
        public WebDriverExtensionsSizzleLoadedSelectorChromeTests(ChromeFixture fixture)
            : base(fixture, SizzleTestPath, x => SizzleSelector(x))
        {
        }
    }
}
