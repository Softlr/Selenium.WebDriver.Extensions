namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "InternetExplorer")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsCoreInternetExplorerTests : WebDriverExtensionsCoreTests, 
        IClassFixture<InternetExplorerFixture>
    {
        public WebDriverExtensionsCoreInternetExplorerTests(InternetExplorerFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri(Properties.Resources.CoreTestsUrl));
        }
    }
}
