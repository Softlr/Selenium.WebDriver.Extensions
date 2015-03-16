namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using Xunit;
    
    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class QuerySelectorLoaderTests
    {
        [Fact]
        public void ShouldLoadScript()
        {
            var loadScript = new QuerySelectorLoader().LoadScript();
            Assert.Null(loadScript);
        }

        [Fact]
        public void ShouldGetDefaultLibraryUrl()
        {
            var url = new QuerySelectorLoader().LibraryUri;
            Assert.Null(url);
        }
    }
}
