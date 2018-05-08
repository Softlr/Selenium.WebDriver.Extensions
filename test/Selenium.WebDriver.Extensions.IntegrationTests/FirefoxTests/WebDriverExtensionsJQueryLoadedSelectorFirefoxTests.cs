namespace Selenium.WebDriver.Extensions.IntegrationTests.FirefoxTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.IntegrationTests.Tests;
    using Xunit;
    using static Extensions.Tests.Shared.Trait.Browser;
    using static Extensions.Tests.Shared.Trait.Category;
    using static Extensions.Tests.Shared.Trait.Name;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, FIREFOX)]
    [ExcludeFromCodeCoverage]
    [Collection(FIREFOX)]
    public class WebDriverExtensionsJQueryLoadedSelectorFirefoxTests : WebDriverExtensionsJQuerySelectorTests
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsJQueryLoadedSelectorFirefoxTests(FirefoxFixture fixture)
            : base(fixture.Browser, true)
        {
        }
    }
}