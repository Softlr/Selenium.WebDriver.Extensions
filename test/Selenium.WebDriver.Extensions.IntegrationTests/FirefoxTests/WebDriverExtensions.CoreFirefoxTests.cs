namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Xunit;

    [Trait("Category", "Integration Tests")]
    [Trait("Browser", "Firefox")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsCoreFirefoxTests : WebDriverExtensionsCoreTests, IClassFixture<FirefoxFixture>
    {
        public WebDriverExtensionsCoreFirefoxTests(FirefoxFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.CoreTestsUrl);
        }
    }
}
