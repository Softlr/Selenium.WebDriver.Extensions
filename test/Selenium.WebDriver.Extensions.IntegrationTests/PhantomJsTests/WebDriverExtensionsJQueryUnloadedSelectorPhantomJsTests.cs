namespace Selenium.WebDriver.Extensions.IntegrationTests.PhantomJsTests
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
    [Trait(BROWSER, PHANTOM_JS)]
    [ExcludeFromCodeCoverage]
    [Collection(INTEGRATION)]
    public class WebDriverExtensionsJQueryUnloadedSelectorPhantomJsTests :
        WebDriverExtensionsJQuerySelectorTests, IClassFixture<PhantomJsFixture>
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public WebDriverExtensionsJQueryUnloadedSelectorPhantomJsTests(PhantomJsFixture fixture)
            : base(fixture.Browser, false)
        {
        }
    }
}