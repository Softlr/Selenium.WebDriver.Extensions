namespace Selenium.WebDriver.Extensions.IntegrationTests.InternetExplorerTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.IntegrationTests.Tests;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using Xunit;

    [Trait(Trait.Name.CATEGORY, Trait.Category.INTEGRATION)]
    [Trait(Trait.Name.BROWSER, Trait.Browser.INTERNET_EXPLORER)]
    [ExcludeFromCodeCoverage]
    [Collection(Trait.Browser.INTERNET_EXPLORER)]
    public class WebDriverExtensionsJQueryLoadedSelectorInternetExplorerTests : SelectorTests<JQuerySelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsJQueryLoadedSelectorInternetExplorerTests(InternetExplorerFixture fixture)
            : base(fixture.Browser, TestCaseModule.JQUERY_LOADED, x => By.JQuerySelector(x))
        {
        }
    }
}