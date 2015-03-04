namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using System.Collections;
    using Moq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using By = Selenium.WebDriver.Extensions.Core.By;
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class PartialLinkTextSelectorTests
    {
        private static IEnumerable EqualityTestCases
        {
            get
            {
                yield return new TestCaseData(By.PartialLinkText("test"), By.PartialLinkText("test"), true)
                    .SetName("PLT('test') == PLT('test')");
                yield return new TestCaseData(By.PartialLinkText("test"), By.PartialLinkText("test2"), false)
                    .SetName("PLT('test') != PLT('test2')");
                yield return new TestCaseData(By.PartialLinkText("test"), null, false)
                    .SetName("PLT('test') != null");
                yield return new TestCaseData(null, By.PartialLinkText("test"), false)
                    .SetName("null != PLT('test')");
                yield return new TestCaseData(
                    By.PartialLinkText("test", "body"),
                    By.PartialLinkText("test"),
                    false)
                    .SetName("PLT('test', PLT('body')) != PLT('test')");
                yield return new TestCaseData(
                    By.PartialLinkText("test", "body"),
                    By.PartialLinkText("test", "body"),
                    true)
                    .SetName("PLT('test', PLT('body')) == PLT('test', PLT('body'))");
            }
        }

        [Test]
        public void Selector()
        {
            var selector = By.PartialLinkText("test");
            Assert.AreEqual(selector.Selector, selector.ToString());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSelector()
        {
            By.PartialLinkText(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullBaseElementSelector()
        {
            By.PartialLinkText("test", null);
        }

        [Test]
        public void CallFormatString()
        {
            var formatString = By.PartialLinkText("test").CallFormatString;
            Assert.IsNotNull(formatString);
        }

        [TestCaseSource("EqualityTestCases")]
        public void EqualityOperator(
            PartialLinkTextSelector selector1,
            PartialLinkTextSelector selector2,
            bool expectedResult)
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
            var selector1 = By.PartialLinkText("text");
            var selector2 = new object();

#pragma warning disable 252,253
            Assert.IsFalse(selector1 == selector2);
            Assert.IsTrue(selector1 != selector2);
#pragma warning restore 252,253
        }

        [Test]
        public void RunnerType()
        {
            var selector = new LinkTextSelector("test");

            Assert.AreEqual(typeof(QuerySelectorRunner), selector.RunnerType);
        }

        [Test]
        public void Create()
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

            var selector = By.PartialLinkText("test").Create(element.Object);
            Assert.IsInstanceOf<PartialLinkTextSelector>(selector);

            var linkTextSelector = (PartialLinkTextSelector)selector;
            Assert.AreEqual("test", linkTextSelector.RawSelector);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateNullElement()
        {
            var selector = new PartialLinkTextSelector("div");
            selector.Create(null);
        }
    }
}
