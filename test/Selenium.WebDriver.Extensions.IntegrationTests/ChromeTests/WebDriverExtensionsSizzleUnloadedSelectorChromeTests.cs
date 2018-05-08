namespace Selenium.WebDriver.Extensions.IntegrationTests.ChromeTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.IntegrationTests.Tests;
    using Xunit;
    using static Extensions.Tests.Shared.Trait.Browser;
    using static Extensions.Tests.Shared.Trait.Category;
    using static Extensions.Tests.Shared.Trait.Name;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, CHROME)]
    [ExcludeFromCodeCoverage]
    [Collection(CHROME)]
    public class WebDriverExtensionsSizzleUnloadedSelectorChromeTests : WebDriverExtensionsSizzleSelectorTests
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsSizzleUnloadedSelectorChromeTests(ChromeFixture fixture)
            : base(fixture.Browser, false)
        {
        }
    }
}