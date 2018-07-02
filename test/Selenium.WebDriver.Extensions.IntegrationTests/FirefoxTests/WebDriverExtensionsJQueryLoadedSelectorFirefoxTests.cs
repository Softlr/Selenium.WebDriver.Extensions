namespace Selenium.WebDriver.Extensions.IntegrationTests.FirefoxTests
{
    using Selenium.WebDriver.Extensions.IntegrationTests;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using static Selenium.WebDriver.Extensions.Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, FIREFOX)]
    [ExcludeFromCodeCoverage]
    [Collection(FIREFOX)]
    public class WebDriverExtensionsJQueryLoadedSelectorFirefoxTests : SelectorTests<JQuerySelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsJQueryLoadedSelectorFirefoxTests(FirefoxFixture fixture)
            : base(fixture.Browser, TestCaseModule.JQUERY_LOADED, x => By.JQuerySelector(x))
        {
        }
    }
}
