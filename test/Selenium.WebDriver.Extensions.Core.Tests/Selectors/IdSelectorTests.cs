namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System.Collections;
    using NUnit.Framework;
    using Selenium.WebDriver.Extensions.QuerySelector;
    using By = Selenium.WebDriver.Extensions.Core.By;
    
    /// <summary>
    /// Id selector tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class IdSelectorTests
    {
        /// <summary>
        /// Gets the equality test cases.
        /// </summary>
        private static IEnumerable EqualityTestCases
        {
            get
            {
                yield return new TestCaseData(By.Id("test"), By.Id("test"), true).SetName("ID('test') == ID('test')");
                yield return new TestCaseData(By.Id("test"), By.Id("test2"), false)
                    .SetName("ID('test') != ID('test2')");
                yield return new TestCaseData(By.Id("test"), null, false).SetName("ID('test') != null");
                yield return new TestCaseData(null, By.Id("test"), false).SetName("null != ID('test')");
            }
        }

        /// <summary>
        /// Tests the equality operators.
        /// </summary>
        /// <param name="selector1">First selector to compare.</param>
        /// <param name="selector2">Second selector to compare.</param>
        /// <param name="expectedResult">The expected result.</param>
        [TestCaseSource("EqualityTestCases")]
        public void EqualityOperator(IdSelector selector1, IdSelector selector2, bool expectedResult)
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
            var selector = new IdSelector("test");

            Assert.AreEqual(typeof(QuerySelectorRunner), selector.RunnerType);
        }
    }
}
