namespace Selenium.WebDriver.Extensions.IntegrationTests.InternetExplorerTests
{
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using static By;
    using static Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, INTERNET_EXPLORER)]
    [ExcludeFromCodeCoverage]
    [Collection(INTERNET_EXPLORER)]
    public class WebDriverExtensionsJQueryLoadedSelectorInternetExplorerTests : SelectorTests<JQuerySelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsJQueryLoadedSelectorInternetExplorerTests(InternetExplorerFixture fixture)
            : base(fixture, "/jQueryLoaded", x => JQuerySelector(x))
        {
        }
    }
}
