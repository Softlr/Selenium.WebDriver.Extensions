namespace Selenium.WebDriver.Extensions.Sizzle.Tests
{
    using Xunit;
    using By = Selenium.WebDriver.Extensions.Sizzle.By;

    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class ByTests
    {
        [Fact]
        public void ShouldCreateSizzleSelector()
        {
            var selector = By.SizzleSelector("div");

            Assert.NotNull(selector);
            Assert.Equal("div", selector.RawSelector);
        }

        [Fact]
        public void ShouldCreateQuerySelector()
        {
            var selector = By.QuerySelector("div");

            Assert.NotNull(selector);
            Assert.Equal("div", selector.RawSelector);
        }

        [Fact]
        public void ShouldCreateQuerySelectorWithBase()
        {
            var selector = By.QuerySelector("div", By.QuerySelector("body"));

            Assert.NotNull(selector);
            Assert.Equal("div", selector.RawSelector);

            Assert.NotNull(selector.BaseSelector);
            Assert.Equal("body", selector.BaseSelector.RawSelector);
        }

        [Fact]
        public void ShouldCreateClassNameSelector()
        {
            var selector = By.ClassName("test");

            Assert.NotNull(selector);
            Assert.Equal(".test", selector.RawSelector);
        }

        [Fact]
        public void ShouldCreateCssSelector()
        {
            var selector = By.CssSelector("div.test");

            Assert.NotNull(selector);
            Assert.Equal("div.test", selector.RawSelector);
        }

        [Fact]
        public void ShouldCreateIdSelector()
        {
            var selector = By.Id("test");

            Assert.NotNull(selector);
            Assert.Equal("#test", selector.RawSelector);
        }

        [Fact]
        public void ShouldCreateLinkTextSelector()
        {
            var selector = By.LinkText("test");

            Assert.NotNull(selector);
            Assert.Equal("test", selector.RawSelector);
        }

        [Fact]
        public void ShouldCreateLinkTextWithBaseElement()
        {
            var selector = By.LinkText("test", "document.getElementById('a')");

            Assert.NotNull(selector);
            Assert.Equal("test", selector.RawSelector);
            Assert.Equal("document.getElementById('a')", selector.BaseElement);
        }

        [Fact]
        public void ShouldCreateNameSelector()
        {
            var selector = By.Name("test");

            Assert.NotNull(selector);
            Assert.Equal("[name='test']", selector.RawSelector);
        }

        [Fact]
        public void ShouldCreatePartialLinkTextSelector()
        {
            var selector = By.PartialLinkText("test");

            Assert.NotNull(selector);
            Assert.Equal("test", selector.RawSelector);
        }

        [Fact]
        public void ShouldCreatePartialLinkTextWithBaseElement()
        {
            var selector = By.PartialLinkText("test", "document.getElementById('a')");

            Assert.NotNull(selector);
            Assert.Equal("test", selector.RawSelector);
            Assert.Equal("document.getElementById('a')", selector.BaseElement);
        }

        [Fact]
        public void ShouldCreateTagName()
        {
            var selector = By.TagName("div");

            Assert.NotNull(selector);
            Assert.Equal("div", selector.RawSelector);
        }

        [Fact]
        public void ShouldCreateXPathSelector()
        {
            var selector = By.XPath("/body/div");

            Assert.NotNull(selector);
            Assert.Equal("/body/div", selector.RawSelector);
        }
    }
}
