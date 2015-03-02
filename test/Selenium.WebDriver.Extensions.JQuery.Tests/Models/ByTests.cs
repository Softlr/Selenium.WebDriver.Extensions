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
            var selector = OpenQA.Selenium.By.ClassName(ClassName);
            var wrappedBy = By.ClassName(ClassName);

            Assert.AreEqual(selector, wrappedBy);
        }

        /// <summary>
        /// Tests the CSS selector.
        /// </summary>
        [Test]
        public void CssSelector()
        {
            const string CssSelector = "div.test";
            var selector = OpenQA.Selenium.By.CssSelector(CssSelector);
            var wrappedBy = By.CssSelector(CssSelector);

            Assert.AreEqual(selector, wrappedBy);
        }

        /// <summary>
        /// Tests the ID.
        /// </summary>
        [Test]
        public void Id()
        {
            const string Id = "test";
            var selector = OpenQA.Selenium.By.Id(Id);
            var wrappedBy = By.Id(Id);

            Assert.AreEqual(selector, wrappedBy);
        }

        /// <summary>
        /// Tests the link text.
        /// </summary>
        [Test]
        public void LinkText()
        {
            const string LinkText = "test";
            var selector = OpenQA.Selenium.By.LinkText(LinkText);
            var wrappedBy = By.LinkText(LinkText);

            Assert.AreEqual(selector, wrappedBy);
        }

        /// <summary>
        /// Tests the name.
        /// </summary>
        [Test]
        public void Name()
        {
            const string Name = "test";
            var selector = OpenQA.Selenium.By.Name(Name);
            var wrappedBy = By.Name(Name);

            Assert.AreEqual(selector, wrappedBy);
        }

        /// <summary>
        /// Tests the partial link text.
        /// </summary>
        [Test]
        public void PartialLinkText()
        {
            const string PartialLinkText = "test";
            var selector = OpenQA.Selenium.By.PartialLinkText(PartialLinkText);
            var wrappedBy = By.PartialLinkText(PartialLinkText);

            Assert.AreEqual(selector, wrappedBy);
        }

        /// <summary>
        /// Tests the tag name.
        /// </summary>
        [Test]
        public void TagName()
        {
            const string TagName = "div";
            var selector = OpenQA.Selenium.By.TagName(TagName);
            var wrappedBy = By.TagName(TagName);

            Assert.AreEqual(selector, wrappedBy);
        }

        /// <summary>
        /// Tests the XPATH.
        /// </summary>
        [Test]
        public void XPath()
        {
            const string XPath = "/body/div";
            var selector = OpenQA.Selenium.By.XPath(XPath);
            var wrappedBy = By.XPath(XPath);

            Assert.AreEqual(selector, wrappedBy);
        }
    }
}
