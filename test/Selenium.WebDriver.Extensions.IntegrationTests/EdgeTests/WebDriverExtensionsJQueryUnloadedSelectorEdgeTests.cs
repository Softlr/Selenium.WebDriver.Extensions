namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Edge")]
    [ExcludeFromCodeCoverage]
    [Collection("Integration")]
    public class WebDriverExtensionsJQueryUnloadedSelectorEdgeTests :
        WebDriverExtensionsJQuerySelectorTests, IClassFixture<EdgeFixture>
    {
        public WebDriverExtensionsJQueryUnloadedSelectorEdgeTests(EdgeFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri($"{this.ServerUrl}/JQueryUnloaded"));
        }
    }
}
