namespace Selenium.WebDriver.Extensions.IntegrationTests.ChromeTests
{
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using static By;
    using static TestCaseModule;
    using static Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, CHROME)]
    [ExcludeFromCodeCoverage]
    [Collection(CHROME)]
    public class WebDriverExtensionsJQueryLoadedSelectorChromeTests : SelectorTests<JQuerySelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsJQueryLoadedSelectorChromeTests(ChromeFixture fixture)
            : base(fixture, JQUERY_LOADED, x => JQuerySelector(x))
        {
        }
    }
}
