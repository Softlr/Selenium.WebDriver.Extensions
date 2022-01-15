namespace Selenium.WebDriver.Extensions.IntegrationTests.ChromeTests
{
    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, CHROME)]
    [ExcludeFromCodeCoverage]
    [Collection(CHROME)]
    public class WebDriverExtensionsSizzleUnloadedSelectorChromeTests : SelectorTests<SizzleSelector>
    {
        public WebDriverExtensionsSizzleUnloadedSelectorChromeTests(ChromeFixture fixture)
            : base(fixture, UnloadedPath, x => SizzleSelector(x))
        {
        }
    }
}
