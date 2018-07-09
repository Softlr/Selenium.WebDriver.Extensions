namespace Selenium.WebDriver.Extensions.IntegrationTests.EdgeTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using Xunit;
    using static Selenium.WebDriver.Extensions.By;
    using static Selenium.WebDriver.Extensions.IntegrationTests.TestCaseModule;
    using static Selenium.WebDriver.Extensions.Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, EDGE)]
    [ExcludeFromCodeCoverage]
    [Collection(EDGE)]
    public class WebDriverExtensionsSizzleLoadedSelectorEdgeTests : SelectorTests<SizzleSelector>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsSizzleLoadedSelectorEdgeTests(EdgeFixture fixture)
            : base(fixture, SIZZLE_LOADED, x => SizzleSelector(x))
        {
        }
    }
}
