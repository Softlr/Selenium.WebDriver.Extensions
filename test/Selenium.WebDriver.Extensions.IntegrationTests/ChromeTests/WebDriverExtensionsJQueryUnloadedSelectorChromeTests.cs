namespace Selenium.WebDriver.Extensions.IntegrationTests.ChromeTests
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.IntegrationTests.Tests;
    using Selenium.WebDriver.Extensions.Tests;
    using Xunit;
    using static Extensions.Tests.Trait.Browser;
    using static Extensions.Tests.Trait.Category;
    using static Extensions.Tests.Trait.Name;

    [Trait(CATEGORY, INTEGRATION)]
    [Trait(BROWSER, CHROME)]
    [ExcludeFromCodeCoverage]
    [Collection(INTEGRATION)]
    public class WebDriverExtensionsJQueryUnloadedSelectorChromeTests :
        WebDriverExtensionsJQuerySelectorTests, IClassFixture<ChromeFixture>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsJQueryUnloadedSelectorChromeTests(ChromeFixture fixture)
            : base(fixture.Browser, false)
        {
        }
    }
}