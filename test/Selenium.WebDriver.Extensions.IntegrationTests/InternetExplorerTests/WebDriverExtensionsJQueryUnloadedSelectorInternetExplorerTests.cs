namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "InternetExplorer")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    [Collection("Integration")]
    public class WebDriverExtensionsJQueryUnloadedSelectorInternetExplorerTests :
        WebDriverExtensionsJQuerySelectorTests, IClassFixture<InternetExplorerFixture>
    {
        public WebDriverExtensionsJQueryUnloadedSelectorInternetExplorerTests(InternetExplorerFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri($"{this.ServerUrl}/JQueryUnloaded"));
        }
    }
}
