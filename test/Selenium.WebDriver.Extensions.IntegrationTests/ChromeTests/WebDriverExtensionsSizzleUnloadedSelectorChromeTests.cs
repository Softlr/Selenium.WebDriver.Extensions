namespace Selenium.WebDriver.Extensions.IntegrationTests.ChromeTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using Xunit;

    [Trait(Trait.Name.CATEGORY, Trait.Category.INTEGRATION)]
    [Trait(Trait.Name.BROWSER, Trait.Browser.CHROME)]
    [ExcludeFromCodeCoverage]
    [Collection(Trait.Browser.CHROME)]
    public class WebDriverExtensionsSizzleUnloadedSelectorChromeTests : SelectorTests<SizzleSelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsSizzleUnloadedSelectorChromeTests(ChromeFixture fixture)
            : base(fixture.Browser, TestCaseModule.SIZZLE_UNLOADED, x => By.SizzleSelector(x))
        {
        }
    }
}
