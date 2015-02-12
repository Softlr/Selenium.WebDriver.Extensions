namespace Selenium.WebDriver.Extensions.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using NUnit.Framework;

    /// <summary>
    /// JQuery loader tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
    [ExcludeFromCodeCoverage]
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
        [ExpectedException(typeof(ExternalLibraryLoadException))]
        public void LoadScriptArgumentsEmpty()
        {
            var loader = new JQueryLoader();
            loader.LoadScript(Enumerable.Empty<string>().ToArray());
        }
    }
}
