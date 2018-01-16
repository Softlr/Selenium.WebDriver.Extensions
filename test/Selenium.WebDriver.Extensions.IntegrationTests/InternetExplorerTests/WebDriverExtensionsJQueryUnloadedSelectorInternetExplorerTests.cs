namespace Selenium.WebDriver.Extensions.IntegrationTests.InternetExplorerTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.IntegrationTests.Tests;
    using Selenium.WebDriver.Extensions.Tests;
    using Xunit;
    using static Extensions.Tests.Trait.Browser;
    using static Extensions.Tests.Trait.Category;
    using static Extensions.Tests.Trait.Name;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, INTERNET_EXPLORER)]
    [ExcludeFromCodeCoverage]
    [Collection(INTEGRATION)]
    public class WebDriverExtensionsJQueryUnloadedSelectorInternetExplorerTests :
        WebDriverExtensionsJQuerySelectorTests, IClassFixture<InternetExplorerFixture>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsJQueryUnloadedSelectorInternetExplorerTests(InternetExplorerFixture fixture)
            : base(fixture.Browser, false)
        {
        }
    }
}