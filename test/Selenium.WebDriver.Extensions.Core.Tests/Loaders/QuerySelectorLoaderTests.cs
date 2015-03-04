namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using NUnit.Framework;
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class QuerySelectorLoaderTests
    {
        [Test]
        public void LoadScript()
        {
            var loadScript = new QuerySelectorLoader().LoadScript();
            Assert.IsNull(loadScript);
        }

        [Test]
        public void DefaultLibraryUrl()
        {
            var url = new QuerySelectorLoader().LibraryUri;
            Assert.IsNull(url);
        }
    }
}
