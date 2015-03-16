namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Firefox")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsQuerySelectorFirefoxTests : 
        WebDriverExtensionsQuerySelectorTests, IUseFixture<FirefoxFixture>
    {
        public void SetFixture(FirefoxFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.QuerySelectorTestsUrl);
        }
    }
}
