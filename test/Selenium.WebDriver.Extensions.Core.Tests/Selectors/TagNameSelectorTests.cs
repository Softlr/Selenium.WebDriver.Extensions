namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System.Collections;
    using NUnit.Framework;
    using By = Selenium.WebDriver.Extensions.Core.By;
    
    /// <summary>
    /// Tag name selector tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class TagNameSelectorTests
    {
        /// <summary>
        /// Gets the equality test cases.
        /// </summary>
        private static IEnumerable EqualityTestCases
        {
            get
            {
                yield return new TestCaseData(By.TagName("div"), By.TagName("div"), true)
                    .SetName("TN('div') == TN('test')");
                yield return new TestCaseData(By.TagName("div"), By.TagName("span"), false)
                    .SetName("TN('div') != TN('span')");
                yield return new TestCaseData(By.TagName("div"), null, false).SetName("TN('div') != null");
                yield return new TestCaseData(null, By.TagName("div"), false).SetName("null != TN('div')");
            }
        }

        /// <summary>
        /// Tests the equality operators.
        /// </summary>
        /// <param name="selector1">First selector to compare.</param>
        /// <param name="selector2">Second selector to compare.</param>
        /// <param name="expectedResult">The expected result.</param>
        [TestCaseSource("EqualityTestCases")]
        public void EqualityOperator(TagNameSelector selector1, TagNameSelector selector2, bool expectedResult)
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
        /// Tests the runner type.
        /// </summary>
        [Test]
        public void RunnerType()
        {
            var selector = new TagNameSelector("test");

            Assert.AreEqual(typeof(QuerySelectorRunner), selector.RunnerType);
        }
    }
}
