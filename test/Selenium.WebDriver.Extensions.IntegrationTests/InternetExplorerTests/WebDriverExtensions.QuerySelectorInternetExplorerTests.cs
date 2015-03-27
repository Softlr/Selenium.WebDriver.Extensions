namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "InternetExplorer")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsQuerySelectorInternetExplorerTests : 
        WebDriverExtensionsQuerySelectorTests, IClassFixture<InternetExplorerFixture>
    {
        public WebDriverExtensionsQuerySelectorInternetExplorerTests(InternetExplorerFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri(Properties.Resources.QuerySelectorTestsUrl));
        }
    }
}
