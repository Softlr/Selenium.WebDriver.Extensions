namespace Selenium.WebDriver.Extensions.IntegrationTests.ChromeTests
{
    using Selenium.WebDriver.Extensions.IntegrationTests;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using static Selenium.WebDriver.Extensions.Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, CHROME)]
    [ExcludeFromCodeCoverage]
    [Collection(CHROME)]
    public class WebDriverExtensionsSizzleLoadedSelectorChromeTests : SelectorTests<SizzleSelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsSizzleLoadedSelectorChromeTests(ChromeFixture fixture)
            : base(fixture.Browser, TestCaseModule.SIZZLE_LOADED, x => By.SizzleSelector(x))
        {
        }
    }
}
