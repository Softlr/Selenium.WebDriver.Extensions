namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using Selenium.WebDriver.Extensions.Core;

    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class JQueryLoaderTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadScriptArgumentsNull()
        {
            var loader = new JQueryLoader();
            loader.LoadScript(null);
        }

        [Test]
        [ExpectedException(typeof(LoaderException))]
        public void LoadScriptArgumentsEmpty()
        {
            var loader = new JQueryLoader();
            loader.LoadScript(Enumerable.Empty<string>().ToArray());
        }
    }
}
