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
    public class XPathSelectorTests
    {
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

        [Test]
        public void Selector()
        {
            var selector = By.XPath("html");
            Assert.AreEqual(selector.Selector, selector.ToString());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSelector()
        {
            By.XPath(null);
        }

        [Test]
        public void CallFormatString()
        {
            var formatString = By.XPath("html").CallFormatString;
            Assert.IsNotNull(formatString);
        }

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

        [Test]
        public void RunnerType()
        {
            var selector = new XPathSelector("/html");

            Assert.AreEqual(typeof(JavaScriptRunner), selector.RunnerType);
        }

        [Test]
        public void CreateWithLeadingSlash()
        {
            var rootSelector = new Mock<ISelector>();
            rootSelector.SetupGet(x => x.Selector).Returns("/body");
            rootSelector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("/html[1]/body");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(rootSelector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var selector = By.XPath("/div").Create(element.Object);
            Assert.IsInstanceOf<XPathSelector>(selector);

            var linkTextSelector = (XPathSelector)selector;
            Assert.AreEqual("/html[1]/body/div", linkTextSelector.RawSelector);
        }

        [Test]
        public void CreateWithTrailingSlash()
        {
            var rootSelector = new Mock<ISelector>();
            rootSelector.SetupGet(x => x.Selector).Returns("/body");
            rootSelector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("/html[1]/body/");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(rootSelector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var selector = By.XPath("div").Create(element.Object);
            Assert.IsInstanceOf<XPathSelector>(selector);

            var linkTextSelector = (XPathSelector)selector;
            Assert.AreEqual("/html[1]/body/div", linkTextSelector.RawSelector);
        }

        [Test]
        public void CreateWithTrailingAndLeadingSlash()
        {
            var rootSelector = new Mock<ISelector>();
            rootSelector.SetupGet(x => x.Selector).Returns("/body");
            rootSelector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("/html[1]/body/");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(rootSelector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var selector = By.XPath("/div").Create(element.Object);
            Assert.IsInstanceOf<XPathSelector>(selector);

            var linkTextSelector = (XPathSelector)selector;
            Assert.AreEqual("/html[1]/body//div", linkTextSelector.RawSelector);
        }

        [Test]
        public void CreateWithoutTrailingAndLeadingSlash()
        {
            var rootSelector = new Mock<ISelector>();
            rootSelector.SetupGet(x => x.Selector).Returns("/body");
            rootSelector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("/html[1]/body");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(rootSelector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var selector = By.XPath(".").Create(element.Object);
            Assert.IsInstanceOf<XPathSelector>(selector);

            var linkTextSelector = (XPathSelector)selector;
            Assert.AreEqual("/html[1]/body/.", linkTextSelector.RawSelector);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateNullElement()
        {
            var selector = new XPathSelector("div");
            selector.Create(null);
        }
    }
}
