namespace Selenium.WebDriver.Extensions.Sizzle.Tests
{
    using System;
    using System.Collections;
    using NUnit.Framework;

    /// <summary>
    /// Sizzle selector tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class SizzleSelectorTests
    {
        /// <summary>
        /// Gets the selector test cases.
        /// </summary>
        private static IEnumerable SelectorTestCases
        {
            get
            {
                yield return new TestCaseData(By.SizzleSelector("div"))
                    .Returns("Sizzle('div')").SetName("Sizzle('div')");
                yield return new TestCaseData(By.SizzleSelector("div", By.SizzleSelector("article")))
                    .Returns("Sizzle('div', Sizzle('article')[0])").SetName("Sizzle('div', Sizzle('article')[0])");
                yield return new TestCaseData(By.SizzleSelector("input[type='text']"))
                    .Returns("Sizzle('input[type=\"text\"]')").SetName("escape single quotes");
            }
        }

        /// <summary>
        /// Tests if the proper selector is generated.
        /// </summary>
        /// <param name="selector">The Sizzle selector.</param>
        /// <returns>The generated Sizzle selector.</returns>
        [TestCaseSource("SelectorTestCases")]
        public string Selector(SizzleSelector selector)
        {
            return selector.Selector;
        }

        /// <summary>
        /// Tests if the context property is handled properly.
        /// </summary>
        [Test]
        public void Context()
        {
            var by = By.SizzleSelector("div", By.SizzleSelector("article"));

            Assert.AreEqual(by.Selector, "Sizzle('div', Sizzle('article')[0])");
            Assert.AreEqual(by.Context.Selector, "Sizzle('article')");
        }

        /// <summary>
        /// Tests if the null selector is handled properly.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSelector()
        {
            By.SizzleSelector(null);
        }

        /// <summary>
        /// Tests if the call format string is handled properly.
        /// </summary>
        [Test]
        public void CallFormatString()
        {
            var formatString = By.SizzleSelector("div").CallFormatString;
            Assert.IsNotNull(formatString);
        }
    }
}
