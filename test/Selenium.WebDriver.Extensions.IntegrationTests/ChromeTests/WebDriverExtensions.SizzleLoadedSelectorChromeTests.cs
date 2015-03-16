namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Xunit;

    [Trait("Category", "Integration Tests")]
    [Trait("Browser", "Chrome")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsSizzleLoadedSelectorChromeTests : WebDriverExtensionsSizzleSelectorTests, 
        IClassFixture<ChromeFixture>
    {
        public WebDriverExtensionsSizzleLoadedSelectorChromeTests(ChromeFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.SizzleLoadedTestsUrl);
        }
    }
}
