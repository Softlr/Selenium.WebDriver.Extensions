namespace Selenium.WebDriver.Extensions.IntegrationTests.InternetExplorerTests
{
    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, INTERNET_EXPLORER)]
    [ExcludeFromCodeCoverage]
    [Collection(INTERNET_EXPLORER)]
    public class WebDriverExtensionsSizzleUnloadedSelectorInternetExplorerTests : SelectorTests<SizzleSelector>
    {
        public WebDriverExtensionsSizzleUnloadedSelectorInternetExplorerTests(InternetExplorerFixture fixture)
            : base(fixture, UnloadedPath, x => SizzleSelector(x))
        {
        }
    }
}
