namespace Selenium.WebDriver.Extensions.IntegrationTests.ChromeTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.IntegrationTests.Tests;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Chrome")]
    [ExcludeFromCodeCoverage]
    [Collection("Integration")]
    public class WebDriverExtensionsSizzleUnloadedSelectorChromeTests :
        WebDriverExtensionsSizzleSelectorTests, IClassFixture<ChromeFixture>
    {
        public WebDriverExtensionsSizzleUnloadedSelectorChromeTests(ChromeFixture fixture)
        {
            Browser = fixture.Browser;
            Browser.Navigate().GoToUrl(new Uri($"{ServerUrl}/SizzleLoaded"));
        }
    }
}
