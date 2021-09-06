namespace Selenium.WebDriver.Extensions.IntegrationTests.FirefoxTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Xunit;
    using static By;
    using static Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, FIREFOX)]
    [ExcludeFromCodeCoverage]
    [Collection(FIREFOX)]
    public class WebDriverExtensionsSizzleUnloadedSelectorFirefoxTests : SelectorTests<SizzleSelector>
    {
        public WebDriverExtensionsSizzleUnloadedSelectorFirefoxTests(FirefoxFixture fixture)
            : base(fixture, UnloadedPath, x => SizzleSelector(x))
        {
        }
    }
}
