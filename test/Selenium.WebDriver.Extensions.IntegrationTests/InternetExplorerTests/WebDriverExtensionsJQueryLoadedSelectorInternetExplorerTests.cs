namespace Selenium.WebDriver.Extensions.IntegrationTests.InternetExplorerTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.IntegrationTests.Tests;
    using Xunit;
    using static Extensions.Tests.Shared.Trait.Browser;
    using static Extensions.Tests.Shared.Trait.Category;
    using static Extensions.Tests.Shared.Trait.Name;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, INTERNET_EXPLORER)]
    [ExcludeFromCodeCoverage]
    [Collection(INTERNET_EXPLORER)]
    public class WebDriverExtensionsJQueryLoadedSelectorInternetExplorerTests : WebDriverExtensionsJQuerySelectorTests
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsJQueryLoadedSelectorInternetExplorerTests(InternetExplorerFixture fixture)
            : base(fixture.Browser, true)
        {
        }
    }
}