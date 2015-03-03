namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System.Collections;
    using NUnit.Framework;
    using Selenium.WebDriver.Extensions.QuerySelector;
    using By = Selenium.WebDriver.Extensions.Core.By;
    using QS = Selenium.WebDriver.Extensions.QuerySelector.QuerySelector;

    /// <summary>
    /// Link text selector tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class ClassNameSelectorTests
    {
        /// <summary>
        /// Gets the equality test cases.
        /// </summary>
        private static IEnumerable EqualityTestCases
        {
            get
            {
                yield return new TestCaseData(By.ClassName("test"), By.ClassName("test"), true)
                    .SetName("CN('test') == CN('test')");
                yield return new TestCaseData(By.ClassName("test"), By.ClassName("test2"), false)
                    .SetName("CN('test') != CN('test2')");
                yield return new TestCaseData(By.ClassName("test"), null, false)
                    .SetName("CN('test') != null");
                yield return new TestCaseData(null, By.ClassName("test"), false)
                    .SetName("null != CN('test')");
            }
        }

        /// <summary>
        /// Gets the equality test cases.
        /// </summary>
        private static IEnumerable QuerySelectorEqualityTestCases
        {
            get
            {
                yield return new TestCaseData(
                    By.QuerySelector("div", By.ClassName("div")),
                    By.QuerySelector("div", By.QuerySelector("div")),
                    false)
                    .SetName("QS('div', CN('div')) != QS('div', QS('div'))");
            }
        }

        /// <summary>
        /// Tests the equality operators.
        /// </summary>
        /// <param name="selector1">First selector to compare.</param>
        /// <param name="selector2">Second selector to compare.</param>
        /// <param name="expectedResult">The expected result.</param>
        [TestCaseSource("EqualityTestCases")]
        public void EqualityOperator(ClassNameSelector selector1, ClassNameSelector selector2, bool expectedResult)
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
        /// <param name="selector1">First selector to compare.</param>
        /// <param name="selector2">Second selector to compare.</param>
        /// <param name="expectedResult">The expected result.</param>
        [TestCaseSource("QuerySelectorEqualityTestCases")]
        public void QuerySelectorEqualityOperator(QS selector1, QS selector2, bool expectedResult)
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
            var selector = new ClassNameSelector("test");

            Assert.AreEqual(typeof(QuerySelectorRunner), selector.RunnerType);
        }
    }
}
