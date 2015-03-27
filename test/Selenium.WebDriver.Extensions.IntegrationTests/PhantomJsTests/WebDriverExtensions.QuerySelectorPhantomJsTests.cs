namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "PhantomJs")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsQuerySelectorPhantomJsTests : 
        WebDriverExtensionsQuerySelectorTests, IClassFixture<PhantomJsFixture>
    {
        public WebDriverExtensionsQuerySelectorPhantomJsTests(PhantomJsFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri(Properties.Resources.QuerySelectorTestsUrl));
        }
    }
}
