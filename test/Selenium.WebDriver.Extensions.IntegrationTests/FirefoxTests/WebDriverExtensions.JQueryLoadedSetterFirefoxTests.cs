namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Xunit;

    [Trait("Category", "Integration Tests")]
    [Trait("Browser", "Firefox")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsJQueryLoadedSetterFirefoxTests : WebDriverExtensionsJQuerySetterTests, 
        IClassFixture<FirefoxFixture>
    {
        public WebDriverExtensionsJQueryLoadedSetterFirefoxTests(FirefoxFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.JQueryLoadedTestsUrl);
        }
    }
}
