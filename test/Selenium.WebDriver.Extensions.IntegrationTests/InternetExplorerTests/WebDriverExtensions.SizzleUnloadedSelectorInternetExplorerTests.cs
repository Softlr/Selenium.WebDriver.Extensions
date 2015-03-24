namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "InternetExplorer")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsSizzleUnloadedSelectorInternetExplorerTests :
        WebDriverExtensionsSizzleSelectorTests, IClassFixture<InternetExplorerFixture>
    {
        public WebDriverExtensionsSizzleUnloadedSelectorInternetExplorerTests(InternetExplorerFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.SizzleUnloadedTestsUrl);
        }
    }
}
