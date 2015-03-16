namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Xunit;

    [Trait("Category", "Integration Tests")]
    [Trait("Browser", "PhantomJs")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsQuerySelectorPhantomJsTests : WebDriverExtensionsQuerySelectorTests, 
        IClassFixture<PhantomJsFixture>
    {
        public WebDriverExtensionsQuerySelectorPhantomJsTests(PhantomJsFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.QuerySelectorTestsUrl);
        }
    }
}
