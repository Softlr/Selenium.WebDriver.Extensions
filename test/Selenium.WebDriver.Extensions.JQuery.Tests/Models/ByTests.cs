namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using NUnit.Framework;
    using By = Selenium.WebDriver.Extensions.JQuery.By;

    /// <summary>
    /// Web driver extensions tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class ByTests
    {
        /// <summary>
        /// Tests the query selector.
        /// </summary>
        [Test]
        public void QuerySelector()
        {
            const string Selector = "div";
            var wrappedBy = By.QuerySelector(Selector);

            Assert.AreEqual(Selector, wrappedBy.RawSelector);
        }

        /// <summary>
        /// Tests the query selector with base.
        /// </summary>
        [Test]
        public void QuerySelectorWithBase()
        {
            const string Selector = "div";
            var baseSelector = By.QuerySelector("body");
            var wrappedBy = By.QuerySelector(Selector, baseSelector);

            Assert.AreEqual(Selector, wrappedBy.RawSelector);
        }

        /// <summary>
        /// Tests the class name.
        /// </summary>
        [Test]
        public void ClassName()
        {
            const string ClassName = "test";
            var wrappedBy = By.ClassName(ClassName);

            Assert.AreEqual(".test", wrappedBy.RawSelector);
        }

        /// <summary>
        /// Tests the CSS selector.
        /// </summary>
        [Test]
        public void CssSelector()
        {
            const string CssSelector = "div.test";
            var wrappedBy = By.CssSelector(CssSelector);

            Assert.AreEqual(CssSelector, wrappedBy.RawSelector);
        }

        /// <summary>
        /// Tests the ID.
        /// </summary>
        [Test]
        public void Id()
        {
            const string Id = "test";
            var wrappedBy = By.Id(Id);

            Assert.AreEqual("#test", wrappedBy.RawSelector);
        }

        /// <summary>
        /// Tests the link text.
        /// </summary>
        [Test]
        public void LinkText()
        {
            const string LinkText = "test";
            var wrappedBy = By.LinkText(LinkText);

            Assert.AreEqual("test", wrappedBy.RawSelector);
        }

        /// <summary>
        /// Tests the link text.
        /// </summary>
        [Test]
        public void LinkTextWithBaseElement()
        {
            const string LinkText = "test";
            var wrappedBy = By.LinkText(LinkText, "document");

            Assert.AreEqual("test", wrappedBy.RawSelector);
        }

        /// <summary>
        /// Tests the name.
        /// </summary>
        [Test]
        public void Name()
        {
            const string Name = "test";
            var wrappedBy = By.Name(Name);

            Assert.AreEqual("[name='test']", wrappedBy.RawSelector);
        }

        /// <summary>
        /// Tests the partial link text.
        /// </summary>
        [Test]
        public void PartialLinkText()
        {
            const string PartialLinkText = "test";
            var wrappedBy = By.PartialLinkText(PartialLinkText);

            Assert.AreEqual("test", wrappedBy.RawSelector);
        }

        /// <summary>
        /// Tests the partial link text.
        /// </summary>
        [Test]
        public void PartialLinkTextWithBaseElement()
        {
            const string PartialLinkText = "test";
            var wrappedBy = By.PartialLinkText(PartialLinkText, "document");

            Assert.AreEqual("test", wrappedBy.RawSelector);
        }

        /// <summary>
        /// Tests the tag name.
        /// </summary>
        [Test]
        public void TagName()
        {
            const string TagName = "div";
            var wrappedBy = By.TagName(TagName);

            Assert.AreEqual(TagName, wrappedBy.RawSelector);
        }

        /// <summary>
        /// Tests the XPATH.
        /// </summary>
        [Test]
        public void XPath()
        {
            const string XPath = "/body/div";
            var wrappedBy = By.XPath(XPath);

            Assert.AreEqual(XPath, wrappedBy.RawSelector);
        }
    }
}
