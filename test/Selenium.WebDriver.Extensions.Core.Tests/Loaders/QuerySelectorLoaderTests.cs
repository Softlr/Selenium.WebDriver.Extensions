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
        public void ShouldReturnNullWhenLoadingQuerySelectorScript()
        {
            var loadScript = new QuerySelectorLoader().LoadScript();
            Assert.Null(loadScript);
        }

        [Fact]
        public void ShouldReturnNullWhenGettingQuerySelectorLibraryUrl()
        {
            var url = new QuerySelectorLoader().LibraryUri;
            Assert.Null(url);
        }
    }
}
