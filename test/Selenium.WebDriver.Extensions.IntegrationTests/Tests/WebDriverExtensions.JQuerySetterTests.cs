namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.JQuery;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public abstract class WebDriverExtensionsJQuerySetterTests
    {
        protected IWebDriver Browser { get; set; }

        [Fact]
        public void ChangeText()
        {
            var result = this.Browser.JQuery("h1").Text("test").Text();

            Assert.Equal("test", result);
        }

        [Fact]
        public void ChangeHtml()
        {
            var result = this.Browser.JQuery("h1").Html("<b>test</b>").Html();

            Assert.Equal("<b>test</b>", result);
        }

        [Fact]
        public void ChangeAttribute()
        {
            var result = this.Browser.JQuery("h1").Attribute("foo", "bar").Attribute("foo");

            Assert.Equal("bar", result);
        }

        [Fact]
        public void ChangeProperty()
        {
            var result = this.Browser.JQuery("input:checkbox").Property("checked", "checked").Property("checked");

            Assert.NotNull(result);
            Assert.True(result.Value);
        }

        [Fact]
        public void ChangePropertyBool()
        {
            var result = this.Browser.JQuery("input:checkbox").Property("checked", true).Property("checked");

            Assert.NotNull(result);
            Assert.True(result.Value);
        }

        [Fact]
        public void ChangeValue()
        {
            var result = this.Browser.JQuery("input:text").Value("test").Value();

            Assert.Equal("test", result);
        }

        [Fact]
        public void ChangeCss()
        {
            var result = this.Browser.JQuery("h1").Css("font-family", "Arial").Css("font-family");

            Assert.Equal("Arial", result);
        }

        [Fact]
        public void ChangeWidth()
        {
            var result = this.Browser.JQuery("div.scroll").Width(50).Width();

            Assert.Equal(50, result);
        }

        [Fact]
        public void ChangeHeight()
        {
            var result = this.Browser.JQuery("div.scroll").Height(50).Height();

            Assert.Equal(50, result);
        }

        [Fact]
        public void ChangeInnerWidth()
        {
            var result = this.Browser.JQuery("div.scroll").InnerWidth(50).InnerWidth();

            Assert.True(result.HasValue);
            Assert.Equal(50, result);
        }

        [Fact]
        public void ChangeInnerHeight()
        {
            var result = this.Browser.JQuery("div.scroll").InnerHeight(50).InnerHeight();

            Assert.True(result.HasValue);
            Assert.Equal(50, result);
        }

        [Fact]
        public void ChangeOuterWidth()
        {
            var result = this.Browser.JQuery("div.scroll").OuterWidth(50).OuterWidth();

            Assert.True(result.HasValue);
            Assert.Equal(50, result);
        }

        [Fact]
        public void ChangeOuterHeight()
        {
            var result = this.Browser.JQuery("div.scroll").OuterHeight(50).OuterHeight();

            Assert.True(result.HasValue);
            Assert.Equal(50, result);
        }

        [Fact]
        public void ChangeScrollLeft()
        {
            var result = this.Browser.JQuery("div.scroll").ScrollLeft(50).ScrollLeft();

            Assert.True(result.HasValue);
            Assert.Equal(50, result);
        }

        [Fact]
        public void ChangeScrollTop()
        {
            var result = this.Browser.JQuery("div.scroll").ScrollTop(50).ScrollTop();

            Assert.True(result.HasValue);
            Assert.Equal(50, result);
        }

        [Fact]
        public void ChangeData()
        {
            var result = this.Browser.JQuery("h1").Data("foo", "bar").Data("foo");

            Assert.Equal("bar", result);
        }

        [Fact]
        public void RemoveData()
        {
            var result = this.Browser.JQuery("h1").Data("foo", "bar").RemoveData("foo").Data("foo");

            Assert.Null(result);
        }

        [Fact]
        public void AddClass()
        {
            var result = this.Browser.JQuery("h1").AddClass("foo").HasClass("foo");

            Assert.NotNull(result);
            Assert.True(result.Value);
        }

        [Fact]
        public void RemoveClass()
        {
            var result = this.Browser.JQuery("h1").AddClass("foo").RemoveClass("foo").HasClass("foo");

            Assert.NotNull(result);
            Assert.False(result.Value);
        }

        [Fact]
        public void ToggleClass()
        {
            var result = this.Browser.JQuery("h1").AddClass("foo").ToggleClass("foo").HasClass("foo");

            Assert.NotNull(result);
            Assert.False(result.Value);

            result = this.Browser.JQuery("h1").ToggleClass("foo").HasClass("foo");

            Assert.NotNull(result);
            Assert.True(result.Value);
        }
    }
}
