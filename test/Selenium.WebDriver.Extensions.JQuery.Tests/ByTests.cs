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
        /// Tests the class name.
        /// </summary>
        [Test]
        public void ClassName()
        {
            const string ClassName = "test";
            var originalBy = OpenQA.Selenium.By.ClassName(ClassName);
            var wrappedBy = By.ClassName(ClassName);

            Assert.AreEqual(originalBy, wrappedBy);
        }

        /// <summary>
        /// Tests the CSS selector.
        /// </summary>
        [Test]
        public void CssSelector()
        {
            const string CssSelector = "div.test";
            var originalBy = OpenQA.Selenium.By.CssSelector(CssSelector);
            var wrappedBy = By.CssSelector(CssSelector);

            Assert.AreEqual(originalBy, wrappedBy);
        }

        /// <summary>
        /// Tests the ID.
        /// </summary>
        [Test]
        public void Id()
        {
            const string Id = "test";
            var originalBy = OpenQA.Selenium.By.Id(Id);
            var wrappedBy = By.Id(Id);

            Assert.AreEqual(originalBy, wrappedBy);
        }

        /// <summary>
        /// Tests the link text.
        /// </summary>
        [Test]
        public void LinkText()
        {
            const string LinkText = "div.test";
            var originalBy = OpenQA.Selenium.By.LinkText(LinkText);
            var wrappedBy = By.LinkText(LinkText);

            Assert.AreEqual(originalBy, wrappedBy);
        }

        /// <summary>
        /// Tests the name.
        /// </summary>
        [Test]
        public void Name()
        {
            const string Name = "div.test";
            var originalBy = OpenQA.Selenium.By.Name(Name);
            var wrappedBy = By.Name(Name);

            Assert.AreEqual(originalBy, wrappedBy);
        }

        /// <summary>
        /// Tests the partial link text.
        /// </summary>
        [Test]
        public void PartialLinkText()
        {
            const string PartialLinkText = "div.test";
            var originalBy = OpenQA.Selenium.By.PartialLinkText(PartialLinkText);
            var wrappedBy = By.PartialLinkText(PartialLinkText);

            Assert.AreEqual(originalBy, wrappedBy);
        }

        /// <summary>
        /// Tests the tag name.
        /// </summary>
        [Test]
        public void TagName()
        {
            const string TagName = "div.test";
            var originalBy = OpenQA.Selenium.By.TagName(TagName);
            var wrappedBy = By.TagName(TagName);

            Assert.AreEqual(originalBy, wrappedBy);
        }

        /// <summary>
        /// Tests the XPATH.
        /// </summary>
        [Test]
        public void XPath()
        {
            const string XPath = "div.test";
            var originalBy = OpenQA.Selenium.By.XPath(XPath);
            var wrappedBy = By.XPath(XPath);

            Assert.AreEqual(originalBy, wrappedBy);
        }
    }
}
