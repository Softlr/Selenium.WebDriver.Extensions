namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Xunit;

    [Trait("Category", "Integration Tests")]
    [Trait("Browser", "InternetExplorer")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsJQueryUnloadedSelectorInternetExplorerTests :
        WebDriverExtensionsJQuerySelectorTests, IClassFixture<InternetExplorerFixture>
    {
        public WebDriverExtensionsJQueryUnloadedSelectorInternetExplorerTests(InternetExplorerFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.JQueryUnloadedTestsUrl);
        }
    }
}
