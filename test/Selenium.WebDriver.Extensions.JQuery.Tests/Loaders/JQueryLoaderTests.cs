namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using Selenium.WebDriver.Extensions.Core;

    /// <summary>
    /// JQuery loader tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class JQueryLoaderTests
    {
        /// <summary>
        /// Script loading test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadScriptArgumentsNull()
        {
            var loader = new JQueryLoader();
            loader.LoadScript(null);
        }

        /// <summary>
        /// Script loading test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(LoaderException))]
        public void LoadScriptArgumentsEmpty()
        {
            var loader = new JQueryLoader();
            loader.LoadScript(Enumerable.Empty<string>().ToArray());
        }
    }
}
