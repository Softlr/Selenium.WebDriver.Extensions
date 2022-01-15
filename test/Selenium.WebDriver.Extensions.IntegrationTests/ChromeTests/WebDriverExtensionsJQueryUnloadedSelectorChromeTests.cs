namespace Selenium.WebDriver.Extensions.IntegrationTests.ChromeTests
{
    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, CHROME)]
    [ExcludeFromCodeCoverage]
    [Collection(CHROME)]
    public class WebDriverExtensionsJQueryUnloadedSelectorChromeTests : SelectorTests<JQuerySelector>
    {
        public WebDriverExtensionsJQueryUnloadedSelectorChromeTests(ChromeFixture fixture)
            : base(fixture, UnloadedPath, x => JQuerySelector(x))
        {
        }
    }
}
