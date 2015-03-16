namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Xunit;

    [Trait("Category", "Integration Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsCoreFirefoxTests : WebDriverExtensionsCoreTests, IUseFixture<FirefoxFixture>
    {
        public void SetFixture(FirefoxFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.CoreTestsUrl);
        }
    }
}
