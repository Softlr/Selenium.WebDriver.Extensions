namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Edge")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    [Collection("Integration")]
    public class WebDriverExtensionsSizzleLoadedSelectorEdgeTests :
        WebDriverExtensionsSizzleSelectorTests, IClassFixture<EdgeFixture>
    {
        public WebDriverExtensionsSizzleLoadedSelectorEdgeTests(EdgeFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri($"{this.ServerUrl}/SizzleLoaded"));
        }
    }
}
