namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using System.Collections;
    using Moq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.QuerySelector;
    using Selenium.WebDriver.Extensions.Shared;
    using By = Selenium.WebDriver.Extensions.Core.By;

    /// <summary>
    /// XPATH selector tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class XPathSelectorTests
    {
        /// <summary>
        /// Gets the equality test cases.
        /// </summary>
        private static IEnumerable EqualityTestCases
        {
            get
            {
                yield return new TestCaseData(By.XPath("html"), By.XPath("html"), true)
                    .SetName("XP('test') == XP('test')");
                yield return new TestCaseData(By.XPath("html"), By.XPath("body"), false)
                    .SetName("XP('test') != XP('test2')");
                yield return new TestCaseData(By.XPath("html"), null, false)
                    .SetName("XP('test') != null");
                yield return new TestCaseData(null, By.XPath("html"), false)
                    .SetName("null != XP('test')");
            }
        }

        /// <summary>
        /// Tests if the proper selector is generated.
        /// </summary>
        [Test]
        public void Selector()
        {
            var selector = By.XPath("html");
            Assert.AreEqual(selector.Selector, selector.ToString());
        }

        /// <summary>
        /// Tests if the null selector is handled properly.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSelector()
        {
            By.XPath(null);
        }

        /// <summary>
        /// Tests if the call format string is handled properly.
        /// </summary>
        [Test]
        public void CallFormatString()
        {
            var formatString = By.XPath("html").CallFormatString;
            Assert.IsNotNull(formatString);
        }

        /// <summary>
        /// Tests the equality operators.
        /// </summary>
        /// <param name="selector1">First selector to compare.</param>
        /// <param name="selector2">Second selector to compare.</param>
        /// <param name="expectedResult">The expected result.</param>
        [TestCaseSource("EqualityTestCases")]
        public void EqualityOperator(XPathSelector selector1, XPathSelector selector2, bool expectedResult)
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
            var selector1 = By.XPath("text");
            var selector2 = new object();

#pragma warning disable 252,253
            Assert.IsFalse(selector1 == selector2);
            Assert.IsTrue(selector1 != selector2);
#pragma warning restore 252,253
        }

        /// <summary>
        /// Tests the runner type.
        /// </summary>
        [Test]
        public void RunnerType()
        {
            var selector = new XPathSelector("/html");

            Assert.AreEqual(typeof(QuerySelectorRunner), selector.RunnerType);
        }

        /// <summary>
        /// Tests invoking functions with null element.
        /// </summary>
        [Test]
        public void Create()
        {
            var rootSelector = new Mock<ISelector>();
            rootSelector.SetupGet(x => x.Selector).Returns("/body");
            rootSelector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("/html[1]/body");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(rootSelector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var selector = By.XPath("/div").Create(element.Object);
            Assert.IsInstanceOf<XPathSelector>(selector);

            var linkTextSelector = (XPathSelector)selector;
            Assert.AreEqual("/html[1]/body/div", linkTextSelector.RawSelector);
        }

        /// <summary>
        /// Tests invoking functions with null element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateNullElement()
        {
            var selector = new XPathSelector("div");
            selector.Create(null);
        }
    }
}
