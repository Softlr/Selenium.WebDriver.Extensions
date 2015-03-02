namespace Selenium.WebDriver.Extensions.Shared.Tests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Link text selector tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class LinkTextSelectorTests
    {
        /// <summary>
        /// Tests if the null selector is handled properly.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullBaseElementSelector()
        {
            By.LinkText("test", null);
        }
    }
}
