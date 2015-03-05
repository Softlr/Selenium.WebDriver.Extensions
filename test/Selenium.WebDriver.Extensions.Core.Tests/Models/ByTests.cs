namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using NUnit.Framework;
    using By = Selenium.WebDriver.Extensions.Core.By;

    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class ByTests
    {
        [Test]
        public void ClassName()
        {
            const string ClassName = "test";
            var wrappedBy = By.ClassName(ClassName);

            Assert.AreEqual(".test", wrappedBy.RawSelector);
        }

        [Test]
        public void CssSelector()
        {
            const string CssSelector = "div.test";
            var wrappedBy = By.CssSelector(CssSelector);

            Assert.AreEqual(CssSelector, wrappedBy.RawSelector);
        }

        [Test]
        public void Id()
        {
            const string Id = "test";
            var wrappedBy = By.Id(Id);

            Assert.AreEqual("#test", wrappedBy.RawSelector);
        }

        [Test]
        public void LinkText()
        {
            const string LinkText = "test";
            var wrappedBy = By.LinkText(LinkText);

            Assert.AreEqual("test", wrappedBy.RawSelector);
        }

        [Test]
        public void LinkTextWithBaseElement()
        {
            const string LinkText = "test";
            var wrappedBy = By.LinkText(LinkText, "document");

            Assert.AreEqual("test", wrappedBy.RawSelector);
        }

        [Test]
        public void Name()
        {
            const string Name = "test";
            var wrappedBy = By.Name(Name);

            Assert.AreEqual("[name='test']", wrappedBy.RawSelector);
        }

        [Test]
        public void PartialLinkText()
        {
            const string PartialLinkText = "test";
            var wrappedBy = By.PartialLinkText(PartialLinkText);

            Assert.AreEqual("test", wrappedBy.RawSelector);
        }

        [Test]
        public void PartialLinkTextWithBaseElement()
        {
            const string PartialLinkText = "test";
            var wrappedBy = By.PartialLinkText(PartialLinkText, "document");

            Assert.AreEqual("test", wrappedBy.RawSelector);
        }

        [Test]
        public void TagName()
        {
            const string TagName = "div";
            var wrappedBy = By.TagName(TagName);

            Assert.AreEqual(TagName, wrappedBy.RawSelector);
        }

        [Test]
        public void XPath()
        {
            const string XPath = "/body/div";
            var wrappedBy = By.XPath(XPath);

            Assert.AreEqual(XPath, wrappedBy.RawSelector);
        }
    }
}
