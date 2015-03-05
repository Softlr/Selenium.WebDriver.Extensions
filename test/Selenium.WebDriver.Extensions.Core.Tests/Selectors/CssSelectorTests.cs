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
    public class CssSelectorTests
    {
        private static IEnumerable EqualityTestCases
        {
            get
            {
                yield return new TestCaseData(By.CssSelector("div"), By.CssSelector("div"), true)
                    .SetName("CSS('div') == CSS('div')");
                yield return new TestCaseData(By.CssSelector("test"), By.CssSelector("span"), false)
                    .SetName("CSS('div') != CSS('span')");
                yield return new TestCaseData(By.CssSelector("test"), null, false)
                    .SetName("CSS('div') != null");
                yield return new TestCaseData(null, By.CssSelector("test"), false)
                    .SetName("null != CSS('div')");
            }
        }

        [TestCaseSource("EqualityTestCases")]
        public void EqualityOperator(CssSelector selector1, CssSelector selector2, bool expectedResult)
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
            var selector = new CssSelector("test");

            Assert.AreEqual(typeof(QuerySelectorRunner), selector.RunnerType);
        }
    }
}
