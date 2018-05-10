namespace Selenium.WebDriver.Extensions.IntegrationTests.EdgeTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.IntegrationTests.Tests;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using Xunit;

    [Trait(Trait.Name.CATEGORY, Trait.Category.INTEGRATION)]
    [Trait(Trait.Name.BROWSER, Trait.Browser.EDGE)]
    [ExcludeFromCodeCoverage]
    [Collection(Trait.Browser.EDGE)]
    public class WebDriverExtensionsSizzleUnloadedSelectorEdgeTests : SelectorTests<SizzleSelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsSizzleUnloadedSelectorEdgeTests(EdgeFixture fixture)
            : base(fixture.Browser, TestCaseModule.SIZZLE_UNLOADED, x => By.SizzleSelector(x))
        {
        }
    }
}