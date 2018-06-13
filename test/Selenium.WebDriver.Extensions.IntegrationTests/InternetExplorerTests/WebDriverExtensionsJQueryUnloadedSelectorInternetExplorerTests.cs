namespace Selenium.WebDriver.Extensions.IntegrationTests.InternetExplorerTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using Xunit;

    [Trait(Trait.Name.CATEGORY, Trait.Category.INTEGRATION)]
    [Trait(Trait.Name.BROWSER, Trait.Browser.INTERNET_EXPLORER)]
    [ExcludeFromCodeCoverage]
    [Collection(Trait.Browser.INTERNET_EXPLORER)]
    public class WebDriverExtensionsJQueryUnloadedSelectorInternetExplorerTests : SelectorTests<JQuerySelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsJQueryUnloadedSelectorInternetExplorerTests(InternetExplorerFixture fixture)
            : base(fixture.Browser, TestCaseModule.JQUERY_UNLOADED, x => By.JQuerySelector(x))
        {
        }
    }
}
