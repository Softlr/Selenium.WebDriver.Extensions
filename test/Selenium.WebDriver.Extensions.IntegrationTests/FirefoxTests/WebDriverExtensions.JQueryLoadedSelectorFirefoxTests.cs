namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Xunit;

    [Trait("Category", "Integration Tests")]
    [Trait("Browser", "Firefox")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsJQueryLoadedSelectorFirefoxTests : WebDriverExtensionsJQuerySelectorTests, 
        IClassFixture<FirefoxFixture>
    {
        public WebDriverExtensionsJQueryLoadedSelectorFirefoxTests(FirefoxFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.JQueryLoadedTestsUrl);
        }
    }
}
