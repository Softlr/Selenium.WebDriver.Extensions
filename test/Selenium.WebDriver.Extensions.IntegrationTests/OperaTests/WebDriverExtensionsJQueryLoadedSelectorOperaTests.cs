namespace Selenium.WebDriver.Extensions.IntegrationTests.OperaTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Xunit;
    using static By;
    using static Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, OPERA)]
    [ExcludeFromCodeCoverage]
    [Collection(OPERA)]
    public class WebDriverExtensionsJQueryLoadedSelectorOperaTests : SelectorTests<JQuerySelector>
    {
        public WebDriverExtensionsJQueryLoadedSelectorOperaTests(OperaFixture fixture)
            : base(fixture, JQueryTestPath, x => JQuerySelector(x))
        {
        }
    }
}
