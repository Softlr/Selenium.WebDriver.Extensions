namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using System.Collections;
    using NUnit.Framework;
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class QuerySelectorTests
    {
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

        private static IEnumerable EqualityTestCases
        {
            get
            {
                yield return new TestCaseData(By.QuerySelector("div"), By.QuerySelector("div"), true)
                    .SetName("QS('div') == QS('div')");
                yield return new TestCaseData(By.QuerySelector("div"), By.QuerySelector("span"), false)
                    .SetName("QS('div') != QS('span')");
                yield return new TestCaseData(By.QuerySelector("div"), null, false)
                    .SetName("QS('div') != null");
                yield return new TestCaseData(null, By.QuerySelector("div"), false)
                    .SetName("null != QS('div')");
                yield return new TestCaseData(
                    By.QuerySelector("div", By.QuerySelector("body")),
                    By.QuerySelector("div"),
                    false)
                    .SetName("QS('div', QS('body')) != QS('div')");
                yield return new TestCaseData(
                    By.QuerySelector("div", By.QuerySelector("body")),
                    By.QuerySelector("div", By.QuerySelector("body")),
                    true)
                    .SetName("QS('div', QS('body')) == QS('div', QS('body'))");
                yield return new TestCaseData(
                    By.QuerySelector("div", "body"),
                    By.QuerySelector("div", By.QuerySelector("body")),
                    false)
                    .SetName("QS('div', null) != QS('div', QS('body'))");
                yield return new TestCaseData(
                    By.QuerySelector("div", By.QuerySelector("body")),
                    By.QuerySelector("div", "body"),
                    false)
                    .SetName("QS('div', QS('body')) != QS('div', null)");
                yield return new TestCaseData(
                    By.QuerySelector("div", By.QuerySelector("body")),
                    By.QuerySelector("div", By.QuerySelector("div")),
                    false)
                    .SetName("QS('div', QS('body')) != QS('div', QS('div'))");
            }
        }

        [TestCaseSource("SelectorTestCases")]
        public string Selector(QuerySelector selector)
        {
            Assert.AreEqual(selector.Selector, selector.ToString());
            return selector.Selector;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSelector()
        {
            By.QuerySelector(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullBaseElementSelector()
        {
            By.QuerySelector("div", (string)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSelectorWithBaseSelector()
        {
            By.QuerySelector(null, By.QuerySelector("div"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullBaseSelector()
        {
            By.QuerySelector("div", (QuerySelector)null);
        }

        [Test]
        public void CallFormatString()
        {
            var formatString = By.QuerySelector("div").CallFormatString;
            Assert.IsNotNull(formatString);
        }

        [TestCaseSource("EqualityTestCases")]
        public void EqualityOperator(QuerySelector selector1, QuerySelector selector2, bool expectedResult)
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
        public void EqualityOperatorWrongType()
        {
            var selector1 = By.QuerySelector("div");
            var selector2 = new object();

#pragma warning disable 252,253
            Assert.IsFalse(selector1 == selector2);
            Assert.IsTrue(selector1 != selector2);
#pragma warning restore 252,253
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateNullElement()
        {
            var selector = new QuerySelector("div");
            selector.Create(null);
        }
    }
}
