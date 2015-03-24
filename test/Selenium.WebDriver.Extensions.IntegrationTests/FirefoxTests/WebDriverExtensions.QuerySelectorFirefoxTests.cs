namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Firefox")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsQuerySelectorFirefoxTests : 
        WebDriverExtensionsQuerySelectorTests, IClassFixture<FirefoxFixture>
    {
        public WebDriverExtensionsQuerySelectorFirefoxTests(FirefoxFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.QuerySelectorTestsUrl);
        }
    }
}
