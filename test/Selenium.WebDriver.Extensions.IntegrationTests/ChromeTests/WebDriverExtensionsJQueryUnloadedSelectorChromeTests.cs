namespace Selenium.WebDriver.Extensions.IntegrationTests.ChromeTests
{
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using static By;
    using static Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, CHROME)]
    [ExcludeFromCodeCoverage]
    [Collection(CHROME)]
    public class WebDriverExtensionsJQueryUnloadedSelectorChromeTests : SelectorTests<JQuerySelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsJQueryUnloadedSelectorChromeTests(ChromeFixture fixture)
            : base(fixture, "/Unloaded", x => JQuerySelector(x))
        {
        }
    }
}
