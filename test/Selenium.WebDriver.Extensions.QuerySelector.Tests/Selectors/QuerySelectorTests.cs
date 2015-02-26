namespace Selenium.WebDriver.Extensions.QuerySelector.Tests
{
    using System;
    using System.Collections;
    using NUnit.Framework;
    
    /// <summary>
    /// Query selector tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class QuerySelectorTests
    {
        /// <summary>
        /// Gets the selector test cases.
        /// </summary>
        private static IEnumerable SelectorTestCases
        {
            get
            {
                yield return new TestCaseData(By.QuerySelector("div"))
                    .Returns("document.querySelectorAll('div')").SetName("document.querySelectorAll('div')");
                yield return new TestCaseData(By.QuerySelector("input[type='text']"))
                    .Returns("document.querySelectorAll('input[type=\"text\"]')").SetName("escape single quotes");
                yield return new TestCaseData(By.QuerySelector("div", "document.body"))
                    .Returns("document.body.querySelectorAll('div')")
                    .SetName("document.body.querySelectorAll('div')");
                yield return new TestCaseData(By.QuerySelector("span", By.QuerySelector("div")))
                    .Returns("document.querySelectorAll('div').length === 0 ? [] : document.querySelectorAll('div')[0].querySelectorAll('span')")
                    .SetName("document.querySelectorAll('div')[0].querySelectorAll('span')");
            }
        }

        /// <summary>
        /// Tests if the proper selector is generated.
        /// </summary>
        /// <param name="selector">The query selector.</param>
        /// <returns>The generated query selector.</returns>
        [TestCaseSource("SelectorTestCases")]
        public string Selector(QuerySelector selector)
        {
            Assert.AreEqual(selector.Selector, selector.ToString());
            return selector.Selector;
        }

        /// <summary>
        /// Tests if the null selector is handled properly.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSelector()
        {
            By.QuerySelector(null);
        }

        /// <summary>
        /// Tests if the null selector is handled properly.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullBaseElementSelector()
        {
            By.QuerySelector("div", (string)null);
        }

        /// <summary>
        /// Tests if the null selector is handled properly.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSelectorWithBaseSelector()
        {
            By.QuerySelector(null, By.QuerySelector("div"));
        }

        /// <summary>
        /// Tests if the null selector is handled properly.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullBaseSelector()
        {
            By.QuerySelector("div", (QuerySelector)null);
        }

        /// <summary>
        /// Tests if the call format string is handled properly.
        /// </summary>
        [Test]
        public void CallFormatString()
        {
            var formatString = By.QuerySelector("div").CallFormatString;
            Assert.IsNotNull(formatString);
        }
    }
}
