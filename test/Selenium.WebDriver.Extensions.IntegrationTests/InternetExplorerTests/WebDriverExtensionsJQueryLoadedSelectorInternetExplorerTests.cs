namespace Selenium.WebDriver.Extensions.IntegrationTests.InternetExplorerTests
{
    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, INTERNET_EXPLORER)]
    [ExcludeFromCodeCoverage]
    [Collection(INTERNET_EXPLORER)]
    public class WebDriverExtensionsJQueryLoadedSelectorInternetExplorerTests : SelectorTests<JQuerySelector>
    {
        public WebDriverExtensionsJQueryLoadedSelectorInternetExplorerTests(InternetExplorerFixture fixture)
            : base(fixture, JQueryTestPath, x => JQuerySelector(x))
        {
        }
    }
}
