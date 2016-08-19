namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Edge")]
    [ExcludeFromCodeCoverage]
    [Collection("Integration")]
    public class WebDriverExtensionsSizzleLoadedSelectorEdgeTests :
        WebDriverExtensionsSizzleSelectorTests, IClassFixture<EdgeFixture>
    {
        public WebDriverExtensionsSizzleLoadedSelectorEdgeTests(EdgeFixture fixture)
        {
            Browser = fixture.Browser;
            Browser.Navigate().GoToUrl(new Uri($"{ServerUrl}/SizzleLoaded"));
        }
    }
}
