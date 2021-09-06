namespace Selenium.WebDriver.Extensions.IntegrationTests.ChromeTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Xunit;
    using static By;
    using static Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, CHROME)]
    [ExcludeFromCodeCoverage]
    [Collection(CHROME)]
    public class WebDriverExtensionsJQueryUnloadedSelectorChromeTests : SelectorTests<JQuerySelector>
    {
        public WebDriverExtensionsJQueryUnloadedSelectorChromeTests(ChromeFixture fixture)
            : base(fixture, UnloadedPath, x => JQuerySelector(x))
        {
        }
    }
}
