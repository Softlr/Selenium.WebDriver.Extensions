namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Properties;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "InternetExplorer")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class WebDriverExtensionsSizzleLoadedSelectorInternetExplorerTests : 
        WebDriverExtensionsSizzleSelectorTests, IClassFixture<InternetExplorerFixture>
    {
        public WebDriverExtensionsSizzleLoadedSelectorInternetExplorerTests(InternetExplorerFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri(Resources.HostUrl + "/SizzleLoaded"));
        }
    }
}
