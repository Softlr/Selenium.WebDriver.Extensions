namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using System.Linq;
    using Selenium.WebDriver.Extensions.Core;
    using Xunit;

    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class JQueryLoaderTests
    {
        [Fact]
        public void ShouldLoadScriptArgumentsNull()
        {
            var loader = new JQueryLoader();

            Assert.Throws<ArgumentNullException>(() => loader.LoadScript(null));
        }

        [Fact]
        public void ShouldLoadScriptArgumentsEmpty()
        {
            var loader = new JQueryLoader();

            Assert.Throws<LoaderException>(() => loader.LoadScript(Enumerable.Empty<string>().ToArray()));
        }
    }
}
