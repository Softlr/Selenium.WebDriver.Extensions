namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using System.Collections;
    using Moq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    using By = Selenium.WebDriver.Extensions.JQuery.By;
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class JQuerySelectorTests
    {
        private static IEnumerable SelectorTestCases
        {
            get
            {
                // basic tests
                yield return new TestCaseData(By.JQuerySelector("div"))
                    .Returns("jQuery('div')").SetName("jQuery('div')");
                yield return new TestCaseData(By.JQuerySelector("div", jQueryVariable: "$"))
                    .Returns("$('div')").SetName("$('div')");
                yield return new TestCaseData(By.JQuerySelector("div", By.JQuerySelector("article")))
                    .Returns("jQuery('div', jQuery('article'))").SetName("jQuery('div', jQuery('article'))");

                // functions tests
                yield return new TestCaseData(By.JQuerySelector("div").Add("span"))
                    .Returns("jQuery('div').add('span')").SetName("jQuery('div').add('span')");
                yield return new TestCaseData(By.JQuerySelector("div").AddBack())
                    .Returns("jQuery('div').addBack()").SetName("jQuery('div').addBack()");
                yield return new TestCaseData(By.JQuerySelector("div").AddBack("span"))
                    .Returns("jQuery('div').addBack('span')").SetName("jQuery('div').addBack('span')");
                yield return new TestCaseData(By.JQuerySelector("div").AndSelf())
                    .Returns("jQuery('div').andSelf()").SetName("jQuery('div').andSelf()");
                yield return new TestCaseData(By.JQuerySelector("div").Children())
                    .Returns("jQuery('div').children()").SetName("jQuery('div').children()");
                yield return new TestCaseData(By.JQuerySelector("div").Children("span"))
                    .Returns("jQuery('div').children('span')").SetName("jQuery('div').children('span')");
                yield return new TestCaseData(By.JQuerySelector("div").Closest("span"))
                    .Returns("jQuery('div').closest('span')").SetName("jQuery('div').closest('span')");
                yield return new TestCaseData(By.JQuerySelector("div").Contents())
                    .Returns("jQuery('div').contents()").SetName("jQuery('div').contents()");
                yield return new TestCaseData(By.JQuerySelector("div").End())
                    .Returns("jQuery('div').end()").SetName("jQuery('div').end()");
                yield return new TestCaseData(By.JQuerySelector("div").Eq(0))
                    .Returns("jQuery('div').eq(0)").SetName("jQuery('div').eq(0)");
                yield return new TestCaseData(By.JQuerySelector("div").Eq(-2))
                    .Returns("jQuery('div').eq(-2)").SetName("jQuery('div').eq(-2)");
                yield return new TestCaseData(By.JQuerySelector("div").Filter(".empty"))
                    .Returns("jQuery('div').filter('.empty')").SetName("jQuery('div').filter('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").Find(".empty"))
                    .Returns("jQuery('div').find('.empty')").SetName("jQuery('div').find('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").First())
                    .Returns("jQuery('div').first()").SetName("jQuery('div').first()");
                yield return new TestCaseData(By.JQuerySelector("div").Has(".empty"))
                    .Returns("jQuery('div').has('.empty')").SetName("jQuery('div').has('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").Is(".empty"))
                    .Returns("jQuery('div').is('.empty')").SetName("jQuery('div').is('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").Last())
                    .Returns("jQuery('div').last()").SetName("jQuery('div').last()");
                yield return new TestCaseData(By.JQuerySelector("div").Next(".empty"))
                    .Returns("jQuery('div').next('.empty')").SetName("jQuery('div').next('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").NextAll(".empty"))
                    .Returns("jQuery('div').nextAll('.empty')").SetName("jQuery('div').nextAll('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").NextUntil(".empty"))
                    .Returns("jQuery('div').nextUntil('.empty')").SetName("jQuery('div').nextUntil('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").NextUntil(".empty", "span"))
                    .Returns("jQuery('div').nextUntil('.empty', 'span')")
                    .SetName("jQuery('div').nextUntil('.empty', 'span')");
                yield return new TestCaseData(By.JQuerySelector("div").Not(".empty"))
                    .Returns("jQuery('div').not('.empty')").SetName("jQuery('div').not('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").OffsetParent())
                    .Returns("jQuery('div').offsetParent()").SetName("jQuery('div').offsetParent()");
                yield return new TestCaseData(By.JQuerySelector("div").Parent(".parent"))
                    .Returns("jQuery('div').parent('.parent')").SetName("jQuery('div').parent('.parent')");
                yield return new TestCaseData(By.JQuerySelector("div").Parents(".parent"))
                    .Returns("jQuery('div').parents('.parent')").SetName("jQuery('div').parents('.parent')");
                yield return new TestCaseData(By.JQuerySelector("div").ParentsUntil(".parent"))
                    .Returns("jQuery('div').parentsUntil('.parent')")
                    .SetName("jQuery('div').parentsUntil('.parent')");
                yield return new TestCaseData(By.JQuerySelector("div").ParentsUntil(".parent", "body"))
                    .Returns("jQuery('div').parentsUntil('.parent', 'body')")
                    .SetName("jQuery('div').parentsUntil('.parent', 'body')");
                yield return new TestCaseData(By.JQuerySelector("div").Prev(".empty"))
                    .Returns("jQuery('div').prev('.empty')").SetName("jQuery('div').prev('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").PrevAll(".empty"))
                    .Returns("jQuery('div').prevAll('.empty')").SetName("jQuery('div').prevAll('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").PrevUntil(".empty"))
                    .Returns("jQuery('div').prevUntil('.empty')").SetName("jQuery('div').prevUntil('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").PrevUntil(".empty", "span"))
                    .Returns("jQuery('div').prevUntil('.empty', 'span')")
                    .SetName("jQuery('div').prevUntil('.empty', 'span')");
                yield return new TestCaseData(By.JQuerySelector("div").Siblings(".empty"))
                    .Returns("jQuery('div').siblings('.empty')").SetName("jQuery('div').siblings('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").Slice(1))
                    .Returns("jQuery('div').slice(1)").SetName("jQuery('div').slice(1)");
                yield return new TestCaseData(By.JQuerySelector("div").Slice(1, 3))
                    .Returns("jQuery('div').slice(1, 3)").SetName("jQuery('div').slice(1, 3)");
                yield return new TestCaseData(By.JQuerySelector("div").Slice(-3, -1))
                    .Returns("jQuery('div').slice(-3, -1)").SetName("jQuery('div').slice(-3, -1)");

                // additional tests
                yield return new TestCaseData(By.JQuerySelector("div").AddBack(string.Empty))
                    .Returns("jQuery('div').addBack()").SetName("empty selector");
                yield return new TestCaseData(By.JQuerySelector("div").AddBack(" span "))
                    .Returns("jQuery('div').addBack('span')").SetName("trim");
                yield return new TestCaseData(By.JQuerySelector("input[type='text']"))
                    .Returns("jQuery('input[type=\"text\"]')").SetName("escape single quotes");
            }
        }

        private static IEnumerable EqualityTestCases
        {
            get
            {
                yield return new TestCaseData(By.JQuerySelector("div"), By.JQuerySelector("div"), true)
                    .SetName("jQuery('div') == jQuery('div')");
                yield return new TestCaseData(
                    By.JQuerySelector("div"),
                    By.JQuerySelector("div", jQueryVariable: "$"),
                    false)
                    .SetName("jQuery('div') != $('div')");
                yield return new TestCaseData(By.JQuerySelector("div"), By.JQuerySelector("span"), false)
                    .SetName("jQuery('div') != jQuery('span')");
                yield return new TestCaseData(By.JQuerySelector("div"), null, false)
                    .SetName("jQuery('div') != null");
                yield return new TestCaseData(null, By.JQuerySelector("div"), false)
                    .SetName("null != jQuery('div')");
                yield return new TestCaseData(
                    By.JQuerySelector("div", By.JQuerySelector("body")), 
                    By.JQuerySelector("div"),
                    false)
                    .SetName("jQuery('div', jQuery('body')) != jQuery('div')");
                yield return new TestCaseData(
                    By.JQuerySelector("div", By.JQuerySelector("body")), 
                    By.JQuerySelector("div", By.JQuerySelector("body")), 
                    true)
                    .SetName("jQuery('div', jQuery('body')) == jQuery('div', jQuery('body'))");
            }
        }

        [TestCaseSource("SelectorTestCases")]
        public string Selector(JQuerySelector selector)
        {
            return selector.Selector;
        }

        [Test]
        public void Context()
        {
            var by = By.JQuerySelector("div", By.JQuerySelector("article"));

            Assert.AreEqual(by.Selector, "jQuery('div', jQuery('article'))");
            Assert.AreEqual(by.Context.Selector, "jQuery('article')");
        }

        [Test]
        public void JQueryVariable()
        {
            var by = By.JQuerySelector("div", jQueryVariable: "$");

            Assert.AreEqual(by.JQueryVariable, "$");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSelector()
        {
            By.JQuerySelector(null);
        }

        [Test]
        public void CallFormatString()
        {
            var formatString = By.JQuerySelector("div").CallFormatString;
            Assert.IsNotNull(formatString);
        }

        [TestCaseSource("EqualityTestCases")]
        public void EqualityOperator(JQuerySelector selector1, JQuerySelector selector2, bool expectedResult)
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
            var selector1 = By.JQuerySelector("div");
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
            var selector = new JQuerySelector("div");
            selector.Create(null);
        }

        [Test]
        public void CreateJQueryElement()
        {
            var rootSelector = new Mock<ISelector>();
            rootSelector.SetupGet(x => x.Selector).Returns("div");
            rootSelector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(rootSelector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var selector = By.JQuerySelector("test").Create(element.Object);
            Assert.IsInstanceOf<JQuerySelector>(selector);

            var jquerySelector = (JQuerySelector)selector;
            Assert.AreEqual("jQuery", jquerySelector.JQueryVariable);
        }
    }
}
