namespace Selenium.WebDriver.Extensions.IntegrationTests.InternetExplorerTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using Xunit;
    using static Selenium.WebDriver.Extensions.By;
    using static Selenium.WebDriver.Extensions.IntegrationTests.TestCaseModule;
    using static Selenium.WebDriver.Extensions.Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, INTERNET_EXPLORER)]
    [ExcludeFromCodeCoverage]
    [Collection(INTERNET_EXPLORER)]
    public class WebDriverExtensionsJQueryUnloadedSelectorInternetExplorerTests : SelectorTests<JQuerySelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsJQueryUnloadedSelectorInternetExplorerTests(InternetExplorerFixture fixture)
            : base(fixture, UNLOADED, x => JQuerySelector(x))
        {
        }
    }
}
