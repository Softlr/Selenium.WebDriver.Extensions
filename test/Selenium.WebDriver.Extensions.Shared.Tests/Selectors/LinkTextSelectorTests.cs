namespace Selenium.WebDriver.Extensions.Shared.Tests
{
    using System;
    using System.Collections;
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
        /// Gets the equality test cases.
        /// </summary>
        private static IEnumerable EqualityTestCases
        {
            get
            {
                yield return new TestCaseData(By.LinkText("test"), By.LinkText("test"), true)
                    .SetName("LT('test') == LT('test')");
                yield return new TestCaseData(By.LinkText("test"), By.LinkText("test2"), false)
                    .SetName("LT('test') != LT('test2')");
                yield return new TestCaseData(By.LinkText("test"), null, false)
                    .SetName("LT('test') != null");
                yield return new TestCaseData(null, By.LinkText("test"), false)
                    .SetName("null != LT('test')");
                yield return new TestCaseData(
                    By.LinkText("test", "body"),
                    By.LinkText("test"),
                    false)
                    .SetName("LT('test', LT('body')) != LT('test')");
                yield return new TestCaseData(
                    By.LinkText("test", "body"),
                    By.LinkText("test", "body"),
                    true)
                    .SetName("LT('test', LT('body')) == LT('test', LT('body'))");
            }
        }

        /// <summary>
        /// Tests if the proper selector is generated.
        /// </summary>
        [Test]
        public void Selector()
        {
            var selector = By.LinkText("test");
            Assert.AreEqual(selector.Selector, selector.ToString());
        }

        /// <summary>
        /// Tests if the null selector is handled properly.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSelector()
        {
            By.LinkText(null);
        }

        /// <summary>
        /// Tests if the null selector is handled properly.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullBaseElementSelector()
        {
            By.LinkText("test", null);
        }

        /// <summary>
        /// Tests if the call format string is handled properly.
        /// </summary>
        [Test]
        public void CallFormatString()
        {
            var formatString = By.LinkText("test").CallFormatString;
            Assert.IsNotNull(formatString);
        }

        /// <summary>
        /// Tests the equality operators.
        /// </summary>
        /// <param name="selector1">First selector to compare.</param>
        /// <param name="selector2">Second selector to compare.</param>
        /// <param name="expectedResult">The expected result.</param>
        [TestCaseSource("EqualityTestCases")]
        public void EqualityOperator(LinkTextSelector selector1, LinkTextSelector selector2, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, selector1 == selector2);
            if (selector1 != null)
            {
                Assert.AreEqual(expectedResult, selector1.Equals(selector2));
                if (selector2 != null)
                {
                    Assert.AreEqual(expectedResult, selector1.GetHashCode() == selector2.GetHashCode());
                }
            }

            Assert.AreNotEqual(expectedResult, selector1 != selector2);
        }

        /// <summary>
        /// Tests the equality operators.
        /// </summary>
        [Test]
        public void EqualityOperatorWrongType()
        {
            var selector1 = By.LinkText("text");
            var selector2 = new object();

#pragma warning disable 252,253
            Assert.IsFalse(selector1 == selector2);
            Assert.IsTrue(selector1 != selector2);
#pragma warning restore 252,253
        }
    }
}
