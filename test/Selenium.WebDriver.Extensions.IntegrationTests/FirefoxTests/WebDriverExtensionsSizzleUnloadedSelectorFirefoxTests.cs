namespace Selenium.WebDriver.Extensions.IntegrationTests.FirefoxTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using Xunit;

    [Trait(Trait.Name.CATEGORY, Trait.Category.INTEGRATION)]
    [Trait(Trait.Name.BROWSER, Trait.Browser.FIREFOX)]
    [ExcludeFromCodeCoverage]
    [Collection(Trait.Browser.FIREFOX)]
    public class WebDriverExtensionsSizzleUnloadedSelectorFirefoxTests : SelectorTests<SizzleSelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsSizzleUnloadedSelectorFirefoxTests(FirefoxFixture fixture)
            : base(fixture.Browser, TestCaseModule.SIZZLE_UNLOADED, x => By.SizzleSelector(x))
        {
        }
    }
}