namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    using Selenium.WebDriver.Extensions.JQuery;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.By;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public abstract class WebDriverExtensionsJQuerySelectorTests
    {
        protected IWebDriver Browser { get; set; }

        [Fact]
        public void FindElement()
        {
            var element = this.Browser.FindElement(By.JQuerySelector("#id1"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindElementThatDoesntExist()
        {
            Assert.Throws<NoSuchElementException>(() => this.Browser.FindElement(By.JQuerySelector("#id-not")));
        }

        [Fact]
        public void FindElements()
        {
            var elements = this.Browser.FindElements(By.JQuerySelector("div.main"));
            Assert.Equal(2, elements.Count);
        }

        [Fact]
        public void FindElementsThatDoesntExist()
        {
            var elements = this.Browser.FindElements(By.JQuerySelector("div.mainNot"));
            Assert.Equal(0, elements.Count);
        }

        [Fact]
        public void FindText()
        {
            var text = this.Browser.JQuery("#id1").Text();
            var trimmedText = text.Replace(Environment.NewLine, string.Empty).Trim();
            Assert.True(trimmedText.StartsWith("jQuery"));
            Assert.True(trimmedText.EndsWith("Selenium"));
        }

        [Fact]
        public void FindHtml()
        {
            var text = this.Browser.JQuery("#id1").Html();
            var trimmedText = text.Replace(Environment.NewLine, string.Empty).Trim();
            Assert.True(trimmedText.StartsWith("<span>jQuery</span>"));
            Assert.True(trimmedText.EndsWith("<span>Selenium</span>"));
        }

        [Fact]
        public void FindAttribute()
        {
            var attribute = this.Browser.JQuery("input:first").Attribute("type");
            Assert.Equal("checkbox", attribute);
        }

        [Fact]
        public void FindAttributeThatDoesntExist()
        {
            var attribute = this.Browser.JQuery("input:first").Attribute("typeNot");
            Assert.Null(attribute);
        }

        [Fact]
        public void FindProperty()
        {
            var property = this.Browser.JQuery("input:first").Property("checked");
            Assert.NotNull(property);
            Assert.True(property);
        }

        [Fact]
        public void FindPropertyThatDoesntExist()
        {
            var property = this.Browser.JQuery("input:first").Property("checkedNot");
            Assert.Null(property);
        }

        [Fact]
        public void FindValue()
        {
            var value = this.Browser.JQuery("input:first").Value();
            Assert.Equal("v1", value);
        }

        [Fact]
        public void FindValueThatDoesntExist()
        {
            var value = this.Browser.JQuery("form").Value();
            Assert.True(string.IsNullOrEmpty(value));
        }

        [Fact]
        public void FindCss()
        {
            var value = this.Browser.JQuery("#id1").Css("background-color");
            Assert.Equal("rgb(0, 128, 0)", value);
        }

        [Fact]
        public void FindCssThatDoesntExist()
        {
            var value = this.Browser.JQuery("#id1").Css("test");
            Assert.Null(value);
        }

        [Fact]
        public void FindWidth()
        {
            var value = this.Browser.JQuery("h1").Width();
            Assert.Equal(200, value);
        }

        [Fact]
        public void FindHeight()
        {
            var value = this.Browser.JQuery("h1").Height();
            Assert.Equal(20, value);
        }

        [Fact]
        public void FindInnerWidth()
        {
            var value = this.Browser.JQuery("h1").InnerWidth();
            Assert.Equal(220, value);
        }

        [Fact]
        public void FindInnerHeight()
        {
            var value = this.Browser.JQuery("h1").InnerHeight();
            Assert.Equal(40, value);
        }

        [Fact]
        public void FindOuterWidth()
        {
            var value = this.Browser.JQuery("h1").OuterWidth();
            Assert.Equal(226, value);
        }

        [Fact]
        public void FindOuterHeight()
        {
            var value = this.Browser.JQuery("h1").OuterHeight();
            Assert.Equal(46, value);
        }

        [Fact]
        public void FindOuterWidthWithMargin()
        {
            var value = this.Browser.JQuery("h1").OuterWidth(true);
            Assert.Equal(236, value);
        }

        [Fact]
        public void FindOuterHeightWithMargin()
        {
            var value = this.Browser.JQuery("h1").OuterHeight(true);
            Assert.Equal(56, value);
        }

        [Fact]
        public void FindWidthThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").Width();
            Assert.Null(value);
        }

        [Fact]
        public void FindHeightThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").Height();
            Assert.Null(value);
        }

        [Fact]
        public void FindInnerWidthThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").InnerWidth();
            Assert.Null(value);
        }

        [Fact]
        public void FindInnerHeightThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").InnerHeight();
            Assert.Null(value);
        }

        [Fact]
        public void FindOuterWidthThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").OuterWidth();
            Assert.Null(value);
        }

        [Fact]
        public void FindOuterHeightThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").OuterHeight();
            Assert.Null(value);
        }

        [Fact]
        public void FindOuterWidthWithMarginThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").OuterWidth(true);
            Assert.Null(value);
        }

        [Fact]
        public void FindOuterHeightWithMarginThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").OuterHeight(true);
            Assert.Null(value);
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public void FindPosition()
        {
            var position = this.Browser.JQuery("h1").Position();
            Assert.NotNull(position);
            
            Assert.Equal(3, position.Value.Top);
            Assert.Equal(8, position.Value.Left);
        }

        [Fact]
        public void FindPositionThatDoesntExist()
        {
            var position = this.Browser.JQuery("h6").Position();
            Assert.Null(position);
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public void FindOffset()
        {
            var position = this.Browser.JQuery("h1").Offset();
            Assert.NotNull(position);

            Assert.Equal(8, position.Value.Top);
            Assert.Equal(13, position.Value.Left);
        }

        [Fact]
        public void FindOffsetThatDoesntExist()
        {
            var position = this.Browser.JQuery("h6").Offset();
            Assert.Null(position);
        }

        [Fact]
        public void FindStringData()
        {
            var value = this.Browser.JQuery("form").Data("mystring");
            Assert.Equal("str", value);
        }

        [Fact]
        public void FindIntegerData()
        {
            var value = this.Browser.JQuery("form").Data<long?>("myint");
            Assert.Equal(123, value);
        }

        [Fact]
        public void FindBooleanData()
        {
            var value = this.Browser.JQuery("form").Data<bool?>("mybool");
            Assert.NotNull(value);
            Assert.True(value);
        }

        [Fact]
        public void FindScrollTop()
        {
            var scroll = this.Browser.JQuery("div.scroll").ScrollTop();
            Assert.NotNull(scroll);
            Assert.Equal(100, scroll);
        }

        [Fact]
        public void FindScrollLeft()
        {
            var scroll = this.Browser.JQuery("div.scroll").ScrollLeft();
            Assert.NotNull(scroll);
            Assert.Equal(200, scroll);
        }

        [Fact]
        public void FindCount()
        {
            var count = this.Browser.JQuery("div.main").Count();
            Assert.Equal(2, count);
        }

        [Fact]
        public void FindCountThatDoesntExist()
        {
            var count = this.Browser.JQuery("div.mainNot").Count();
            Assert.Equal(0, count);
        }

        [Fact]
        public void FindSerialized()
        {
            var value = this.Browser.JQuery("form").Serialized();
            Assert.Equal("i1=v1&i3=v3", value);
        }

        [Fact]
        public void FindSerializedThatDoesntExist()
        {
            var value = this.Browser.JQuery("form.test").Serialized();
            Assert.Empty(value);
        }

        [Fact]
        public void FindSerializedArray()
        {
            var value = this.Browser.JQuery("form").SerializedArray();
            Assert.Equal("[{\"name\":\"i1\",\"value\":\"v1\"},{\"name\":\"i3\",\"value\":\"v3\"}]", value);
        }

        [Fact]
        public void FindSerializedArrayThatDoesntExist()
        {
            var value = this.Browser.JQuery("form.test").SerializedArray();
            Assert.Equal("[]", value);
        }

        [Fact]
        public void FindElementPath()
        {
            var element = this.Browser.FindElement(By.JQuerySelector("#id1"));
            Assert.Equal("body > div#id1", element.Path);
        }

        [Fact]
        public void FindInnerElement()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var element = root.FindElement(By.JQuerySelector("span"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindInnerElements()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var elements = root.FindElements(By.JQuerySelector("span"));
            Assert.Equal(2, elements.Count);
        }
    }
}
