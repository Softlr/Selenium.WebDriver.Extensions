namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using NUnit.Framework;
    
    /// <summary>
    /// Query selector loader tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class QuerySelectorLoaderTests
    {
        /// <summary>
        /// Tests script loading.
        /// </summary>
        [Test]
        public void LoadScript()
        {
            var loadScript = new QuerySelectorLoader().LoadScript();
            Assert.IsNull(loadScript);
        }

        /// <summary>
        /// Tests default library URL.
        /// </summary>
        [Test]
        public void DefaultLibraryUrl()
        {
            var url = new QuerySelectorLoader().LibraryUri;
            Assert.IsNull(url);
        }
    }
}
