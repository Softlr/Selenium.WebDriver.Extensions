namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System.Collections;
    using NUnit.Framework;
    using By = Selenium.WebDriver.Extensions.Core.By;

    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class NameSelectorTests
    {
        private static IEnumerable EqualityTestCases
        {
            get
            {
                yield return new TestCaseData(By.Name("test"), By.Name("test"), true)
                    .SetName("N('test') == N('test')");
                yield return new TestCaseData(By.Name("test"), By.Name("test2"), false)
                    .SetName("N('test') != N('test2')");
                yield return new TestCaseData(By.Name("test"), null, false).SetName("N('test') != null");
                yield return new TestCaseData(null, By.Name("test"), false).SetName("null != N('test')");
            }
        }

        [TestCaseSource("EqualityTestCases")]
        public void EqualityOperator(NameSelector selector1, NameSelector selector2, bool expectedResult)
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

        [Test]
        public void RunnerType()
        {
            var selector = new NameSelector("test");

            Assert.AreEqual(typeof(QuerySelectorRunner), selector.RunnerType);
        }
    }
}
