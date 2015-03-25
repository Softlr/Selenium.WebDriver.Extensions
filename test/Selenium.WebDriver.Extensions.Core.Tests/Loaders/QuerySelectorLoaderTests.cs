namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
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
