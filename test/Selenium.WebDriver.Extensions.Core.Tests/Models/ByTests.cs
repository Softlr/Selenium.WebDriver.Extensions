namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.Core.By;

    // ReSharper disable ExceptionNotDocumented
    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class ByTests
    {
        [Fact]
        public void ShouldCreateQuerySelector()
        {
            var selector = By.QuerySelector("div");

            Assert.NotNull(selector);
            Assert.Equal("div", selector.RawSelector);
            Assert.Equal("document", selector.BaseElement);
        }

        [Fact]
        public void ShouldCreateQuerySelectorWithBaseElement()
        {
            var selector = By.QuerySelector("div", "document.getElementById('id1')");

            Assert.NotNull(selector);
            Assert.Equal("div", selector.RawSelector);
            Assert.Equal("document.getElementById('id1')", selector.BaseElement);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingQuerySelectorWithNullValue()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.QuerySelector(null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingQuerySelectorWithEmptyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.QuerySelector(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingQuerySelectorWithWhiteSpaceOnlyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.QuerySelector(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingQuerySelectorWithNullBaseElement()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.QuerySelector("div", (string)null));
            Assert.Equal("baseElement", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingQuerySelectorWithNullBaseSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.QuerySelector("div", (ISelector)null));
            Assert.Equal("baseSelector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingQuerySelectorWithEmptyBaseElement()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.QuerySelector("div", string.Empty));
            Assert.Equal("baseElement", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingQuerySelectorWithWhiteSpaceOnlyBaseElement()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.QuerySelector("div", " "));
            Assert.Equal("baseElement", ex.ParamName);
        }

        [Fact]
        public void ShouldCreateQuerySelectorWithBaseSelector()
        {
            var selector = By.QuerySelector("div", By.QuerySelector("body"));

            Assert.NotNull(selector);
            Assert.Equal("div", selector.RawSelector);

            Assert.NotNull(selector.BaseSelector);
            Assert.Equal("body", selector.BaseSelector.RawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingQuerySelectorWithNullValueAndBaseSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.QuerySelector(null, By.QuerySelector("div")));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingQuerySelectorWithEmptyValueAndBaseSelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.QuerySelector(string.Empty, By.QuerySelector("div")));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingQuerySelectorWithWhiteSpaceOnlyValueAndBaseSelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.QuerySelector(" ", By.QuerySelector("div")));
            Assert.Equal("selector", ex.ParamName);
        }

        public void ShouldThrowexceptionWhenCreatingQuerySelectorWithNullBaseSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.QuerySelector("div", (ISelector)null));
            Assert.Equal("baseSelector", ex.ParamName);
        }

        [Fact]
        public void ShouldCreateClassNameSelector()
        {
            var selector = By.ClassName("test");

            Assert.NotNull(selector);
            Assert.Equal(".test", selector.RawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingClassNameSelectorWithNullValue()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.ClassName(null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingClassNameSelectorWithEmptyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.ClassName(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingClassNameSelectorWithWhiteSpaceOnlyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.ClassName(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldCreateCssSelector()
        {
            var selector = By.CssSelector("div.test");

            Assert.NotNull(selector);
            Assert.Equal("div.test", selector.RawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingCssSelectorWithNullValue()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.CssSelector(null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingCssSelectorWithEmptyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.CssSelector(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingCssSelectorWithWhiteSpaceOnlyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.CssSelector(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldCreateIdSelector()
        {
            var selector = By.Id("test");

            Assert.NotNull(selector);
            Assert.Equal("#test", selector.RawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingIdSelectorWithNullValue()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.Id(null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingIdSelectorWithEmptyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.Id(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingIdSelectorWithWhiteSpaceOnlyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.Id(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldCreateLinkTextSelector()
        {
            var selector = By.LinkText("test");

            Assert.NotNull(selector);
            Assert.Equal("test", selector.RawSelector);
            Assert.Equal("document", selector.BaseElement);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingLinkTextSelectorWithNullValue()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.LinkText(null));
            Assert.Equal("text", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingLinkTextSelectorWithEmptyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.LinkText(string.Empty));
            Assert.Equal("text", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingLinkTextSelectorWithWhiteSpaceOnlyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.LinkText(" "));
            Assert.Equal("text", ex.ParamName);
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
        public void ShouldThrowExceptionWhenCreatingLinkTextSelectorWithNullBaseElement()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.LinkText("test", null));
            Assert.Equal("baseElement", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingLinkTextSelectorWithEmptyBaseElement()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.LinkText("test", string.Empty));
            Assert.Equal("baseElement", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingLinkTextSelectorWithWhiteSpaceOnlyBaseElement()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.LinkText("test", " "));
            Assert.Equal("baseElement", ex.ParamName);
        }

        [Fact]
        public void ShouldCreateNameSelector()
        {
            var selector = By.Name("test");

            Assert.NotNull(selector);
            Assert.Equal("[name='test']", selector.RawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingNameSelectorWithNullValue()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.Name(null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingNameSelectorWithEmptyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.Name(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingNameSelectorWithWhiteSpaceOnlyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.Name(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldCreatePartialLinkTextSelector()
        {
            var selector = By.PartialLinkText("test");

            Assert.NotNull(selector);
            Assert.Equal("test", selector.RawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingPartialLinkTextSelectorWithNullValue()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.PartialLinkText(null));
            Assert.Equal("text", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingPartialLinkTextSelectorWithEmptyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.PartialLinkText(string.Empty));
            Assert.Equal("text", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingPartialLinkTextSelectorWithWhiteSpaceOnlyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.PartialLinkText(" "));
            Assert.Equal("text", ex.ParamName);
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
        public void ShouldThrowExceptionWhenCreatingPartialLinkTextSelectorWithNullBaseElement()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.PartialLinkText("test", null));
            Assert.Equal("baseElement", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingPartialLinkTextSelectorWithEmptyBaseElement()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.PartialLinkText("test", string.Empty));
            Assert.Equal("baseElement", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingPartialLinkTextSelectorWithWhiteSpaceOnlyBaseElement()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.PartialLinkText("test", " "));
            Assert.Equal("baseElement", ex.ParamName);
        }

        [Fact]
        public void ShouldCreateTagNameSelector()
        {
            var selector = By.TagName("div");

            Assert.NotNull(selector);
            Assert.Equal("div", selector.RawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingTagNameSelectorWithNullValue()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.TagName(null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingTagNameSelectorWithEmptyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.TagName(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingTagNameSelectorWithWhiteSpaceOnlyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.TagName(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldCreateXPathSelector()
        {
            var selector = By.XPath("/body/div");

            Assert.NotNull(selector);
            Assert.Equal("/body/div", selector.RawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingXPathSelectorWithNullValue()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.XPath(null));
            Assert.Equal("xpath", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingXPathSelectorWithEmptyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.XPath(string.Empty));
            Assert.Equal("xpath", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingXPathSelectorWithWhiteSpaceOnlyValue()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.XPath(" "));
            Assert.Equal("xpath", ex.ParamName);
        }
    }
}
