namespace Selenium.WebDriver.Extensions.IntegrationTests.InternetExplorerTests
{
    using Selenium.WebDriver.Extensions.IntegrationTests;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using static Selenium.WebDriver.Extensions.Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, INTERNET_EXPLORER)]
    [ExcludeFromCodeCoverage]
    [Collection(INTERNET_EXPLORER)]
    public class WebDriverExtensionsSizzleUnloadedSelectorInternetExplorerTests : SelectorTests<SizzleSelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsSizzleUnloadedSelectorInternetExplorerTests(InternetExplorerFixture fixture)
            : base(fixture.Browser, TestCaseModule.UNLOADED, x => By.SizzleSelector(x))
        {
        }
    }
}
