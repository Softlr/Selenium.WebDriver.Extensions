namespace Selenium.WebDriver.Extensions.Sizzle.Tests
{
    using System;
    using System.Collections;
    using NUnit.Framework;
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class SizzleSelectorTests
    {
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

        private static IEnumerable EqualityTestCases
        {
            get
            {
                yield return new TestCaseData(By.SizzleSelector("div"), By.SizzleSelector("div"), true)
                    .SetName("Sizzle('div') == Sizzle('div')");
                yield return new TestCaseData(By.SizzleSelector("div"), By.SizzleSelector("span"), false)
                    .SetName("Sizzle('div') != Sizzle('span')");
                yield return new TestCaseData(By.SizzleSelector("div"), null, false)
                    .SetName("Sizzle('div') != null");
                yield return new TestCaseData(null, By.SizzleSelector("div"), false)
                    .SetName("null != Sizzle('div')");
                yield return new TestCaseData(
                    By.SizzleSelector("div", By.SizzleSelector("body")),
                    By.SizzleSelector("div"),
                    false)
                    .SetName("Sizzle('div', Sizzle('body')) != Sizzle('div')");
                yield return new TestCaseData(
                    By.SizzleSelector("div", By.SizzleSelector("body")),
                    By.SizzleSelector("div", By.SizzleSelector("body")),
                    true)
                    .SetName("Sizzle('div', Sizzle('body')) == Sizzle('div', Sizzle('body'))");
            }
        }

        [TestCaseSource("SelectorTestCases")]
        public string Selector(SizzleSelector selector)
        {
            return selector.Selector;
        }

        [Test]
        public void Context()
        {
            var by = By.SizzleSelector("div", By.SizzleSelector("article"));

            Assert.AreEqual(by.Selector, "Sizzle('div', Sizzle('article')[0])");
            Assert.AreEqual(by.Context.Selector, "Sizzle('article')");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSelector()
        {
            By.SizzleSelector(null);
        }

        [Test]
        public void CallFormatString()
        {
            var formatString = By.SizzleSelector("div").CallFormatString;
            Assert.IsNotNull(formatString);
        }

        [TestCaseSource("EqualityTestCases")]
        public void EqualityOperator(SizzleSelector selector1, SizzleSelector selector2, bool expectedResult)
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
            var selector1 = By.SizzleSelector("div");
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
            var selector = new SizzleSelector("div");
            selector.Create(null);
        }
    }
}
