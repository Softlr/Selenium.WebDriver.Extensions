namespace Selenium.WebDriver.Extensions.IntegrationTests.EdgeTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Xunit;
    using static By;
    using static Tests.Shared.Trait;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, EDGE)]
    [ExcludeFromCodeCoverage]
    [Collection(EDGE)]
    public class WebDriverExtensionsJQueryUnloadedSelectorEdgeTests : SelectorTests<JQuerySelector>
    {
        public WebDriverExtensionsJQueryUnloadedSelectorEdgeTests(EdgeFixture fixture)
            : base(fixture, UnloadedPath, x => JQuerySelector(x))
        {
        }
    }
}
