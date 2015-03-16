namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Moq;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    using Selenium.WebDriver.Extensions.JQuery;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.JQuery.By;

    [Trait("Category", "Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsTests
    {
        public static IEnumerable<object[]> LoadJQueryData
        {
            get
            {
                yield return new object[] { "latest", null, new object[] { true } };
                yield return new object[] { "1.11.0", null, new object[] { false, true, true } };
            }
        }

        public static IEnumerable<object[]> LoadJQueryWithUriData
        {
            get
            {
                yield return new object[] { new Uri("http://my.com/jquery.js"), null, new object[] { true } };
                yield return new object[] { null, null, new object[] { false, true, true } };
            }
        }

        [Theory]
        [PropertyData("LoadJQueryData")]
        public void ShouldLoadJQuery(string version, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var driverMock = new Mock<IWebDriver>();
            var sequence = driverMock.As<IJavaScriptExecutor>()
                .SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            driverMock.Object.JQuery().Load(version, timeout);
        }

        [Theory]
        [PropertyData("LoadJQueryWithUriData")]
        public void ShouldLoadJQueryWithUri(Uri jQueryUri, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var driverMock = new Mock<IWebDriver>();
            var sequence = driverMock.As<IJavaScriptExecutor>()
                .SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            driverMock.Object.JQuery().Load(jQueryUri, timeout);
        }

        [Fact]
        public void ShouldTimeoutWhenSizzleFailesToLoad()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsAny<string>())).Returns(false);
            Assert.Throws<WebDriverTimeoutException>(() =>
                driverMock.Object.JQuery().Load(timeout: TimeSpan.FromMilliseconds(100)));
        }

        [Fact]
        public void ShouldFindElementWithJQuery()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true); 

            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");

            var list = new List<IWebElement> { element.Object };
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('div').get();"))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            var result = driverMock.Object.FindElement(By.JQuerySelector("div"));

            Assert.NotNull(result);
            Assert.Equal("div", result.TagName);
        }

        [Fact]
        public void ShouldThrowExceptionForNullQuerySelector()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true); 
            
            Assert.Throws<ArgumentNullException>(() => driverMock.Object.FindElement((JQuerySelector)null));
        }

        [Fact]
        public void ShouldThrowExceptionWhenJQueryFindsNoElement()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);

            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            
            Assert.Throws<NoSuchElementException>(() => driverMock.Object.FindElement(By.JQuerySelector("div")));
        }

        [Fact]
        public void ShouldFindElementsWithJQuery()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);

            var element1 = new Mock<IWebElement>();
            element1.Setup(x => x.TagName).Returns("div");
            element1.Setup(x => x.GetAttribute("class")).Returns("test");

            var element2 = new Mock<IWebElement>();
            element2.Setup(x => x.TagName).Returns("span");
            element2.Setup(x => x.GetAttribute("class")).Returns("test");

            var list = new List<IWebElement> { element1.Object, element2.Object };
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('.test').get();"))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            var result = driverMock.Object.FindElements(By.JQuerySelector(".test"));

            Assert.Equal(2, result.Count);

            Assert.Equal("div", result[0].TagName);
            Assert.Equal("test", result[0].GetAttribute("class"));
            
            Assert.Equal("span", result[1].TagName);
            Assert.Equal("test", result[1].GetAttribute("class"));
        }

        [Fact]
        public void ShouldReturnEmptyResultsWhenjQueryDoentFindAnyMatches()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            var list = new List<object>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('.test').get();"))
                .Returns(new ReadOnlyCollection<object>(list));
            var result = driverMock.Object.FindElements(By.JQuerySelector(".test"));

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void ShouldFindText()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('div').text();"))
                .Returns("test");
            var result = driverMock.Object.JQuery("div").Text();

            Assert.Equal("test", result);
        }

        [Fact]
        public void ShouldFindHtml()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('div').html();"))
                .Returns("<p>test</p>");
            var result = driverMock.Object.JQuery("div").Html();

            Assert.Equal("<p>test</p>", result);
        }

        [Fact]
        public void ShouldFindAttribute()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('a').attr('href');"))
                .Returns("http://github.com");
            var result = driverMock.Object.JQuery("a").Attribute("href");

            Assert.Equal("http://github.com", result);
        }

        [Fact]
        public void ShouldFindAttributeNotExists()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            var result = driverMock.Object.JQuery("a").Attribute("href");

            Assert.Null(result);
        }

        [Fact]
        public void ShouldFindAttributeInvalidType()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            var result = driverMock.Object.JQuery("a").Attribute("href");
            
            Assert.Null(result);
        }

        [Fact]
        public void ShouldFindPropertyString()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').prop('checked');")).Returns("prop");
            var result = driverMock.Object.JQuery("input").Property<string>("checked");

            Assert.Equal("prop", result);
        }

        [Fact]
        public void ShouldFindPropertyBoolean()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').prop('checked');")).Returns(true);
            var result = driverMock.Object.JQuery("input").Property("checked");

            Assert.NotNull(result);
            Assert.True(result);
        }

        [Fact]
        public void ShouldFindPropertyNotExists()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            var result = driverMock.Object.JQuery("input").Property("checked");

            Assert.Null(result);
        }

        [Fact]
        public void ShouldFindPropertyInvalidType()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            Assert.Throws<TypeArgumentException>(() => driverMock.Object.JQuery("input").Property<int>("checked"));
        }

        [Fact]
        public void ShouldFindValue()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').val();"))
                .Returns("test");
            var result = driverMock.Object.JQuery("input").Value();

            Assert.Equal("test", result);
        }

        [Fact]
        public void ShouldFindCss()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').css('display');")).Returns("hidden");
            var result = driverMock.Object.JQuery("input").Css("display");

            Assert.Equal("hidden", result);
        }

        [Fact]
        public void ShouldFindWidth()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').width();"))
                .Returns(100L);
            var result = driverMock.Object.JQuery("input").Width();

            Assert.Equal(100L, result);
        }

        [Fact]
        public void ShouldFindHeight()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').height();"))
                .Returns(100L);
            var result = driverMock.Object.JQuery("input").Height();

            Assert.Equal(100L, result);
        }

        [Fact]
        public void ShouldFindInnerWidth()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').innerWidth();"))
                .Returns(100L);
            var result = driverMock.Object.JQuery("input").InnerWidth();

            Assert.Equal(100L, result);
        }

        [Fact]
        public void ShouldFindInnerHeight()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').innerHeight();"))
                .Returns(100L);
            var result = driverMock.Object.JQuery("input").InnerHeight();

            Assert.Equal(100L, result);
        }

        [Fact]
        public void ShouldFindOuterWidth()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').outerWidth();"))
                .Returns(100L);
            var result = driverMock.Object.JQuery("input").OuterWidth();

            Assert.Equal(100L, result);
        }

        [Fact]
        public void ShouldFindOuterHeight()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').outerHeight();"))
                .Returns(100L);
            var result = driverMock.Object.JQuery("input").OuterHeight();

            Assert.Equal(100L, result);
        }

        [Fact]
        public void ShouldFindOuterWidthWithMargin()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').outerWidth(true);")).Returns(100L);
            var result = driverMock.Object.JQuery("input").OuterWidth(true);

            Assert.Equal(100L, result);
        }

        [Fact]
        public void ShouldFindOuterHeightWithMargin()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').outerHeight(true);")).Returns(100L);
            var result = driverMock.Object.JQuery("input").OuterHeight(true);

            Assert.Equal(100L, result);
        }

        [Fact]
        public void ShouldFindPosition()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            var dict = new Dictionary<string, object> { { "top", 100 }, { "left", 200 } };
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').position();")).Returns(dict);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').position();"))).Returns(true);
            var position = driverMock.Object.JQuery("input").Position();

            Assert.NotNull(position);

            // ReSharper disable once PossibleInvalidOperationException
            Assert.Equal(dict["top"], position.Value.Top);
            Assert.Equal(dict["left"], position.Value.Left);
        }

        [Fact]
        public void ShouldFindPositionNotExists()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').position();")).Returns(null);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').position();"))).Returns(true);
            var position = driverMock.Object.JQuery("input").Position();

            Assert.Null(position);
        }

        [Fact]
        public void ShouldFindOffset()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            var dict = new Dictionary<string, object> { { "top", 100 }, { "left", 200 } };
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').offset();"))
                .Returns(dict);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').offset();"))).Returns(true);
            var offset = driverMock.Object.JQuery("input").Offset();

            Assert.NotNull(offset);

            // ReSharper disable once PossibleInvalidOperationException
            Assert.Equal(dict["top"], offset.Value.Top);
            Assert.Equal(dict["left"], offset.Value.Left);
        }

        [Fact]
        public void ShouldFindOffsetNotExists()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').offset();"))
                .Returns(null);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').offset();"))).Returns(true);
            var offset = driverMock.Object.JQuery("input").Offset();

            Assert.Null(offset);
        }

        [Fact]
        public void ShouldFindScrollLeft()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').scrollLeft();"))
                .Returns(100L);
            var result = driverMock.Object.JQuery("input").ScrollLeft();

            Assert.Equal(100L, result);
        }

        [Fact]
        public void ShouldFindScrollTop()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').scrollTop();"))
                .Returns(100L);
            var result = driverMock.Object.JQuery("input").ScrollTop();

            Assert.Equal(100L, result);
        }

        [Fact]
        public void ShouldFindData()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').data('test');"))
                .Returns("val");
            var result = driverMock.Object.JQuery("input").Data("test");

            Assert.Equal("val", result);
        }

        [Fact]
        public void ShouldFindDataInvalidType()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            Assert.Throws<TypeArgumentException>(() => driverMock.Object.JQuery("input").Data<int>("test"));
        }

        [Fact]
        public void ShouldFindCount()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').length;"))
                .Returns(2L);
            var result = driverMock.Object.JQuery("input").Count();

            Assert.Equal(2L, result);
        }

        [Fact]
        public void ShouldFindSerialized()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('form').serialize();"))
                .Returns("search=test");
            var result = driverMock.Object.JQuery("form").Serialized();

            Assert.Equal("search=test", result);
        }

        [Fact]
        public void ShouldFindSerializedArray()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return JSON.stringify(jQuery('form').serializeArray());"))
                .Returns("[{\"name\":\"s\",\"value\":\"\"}]");
            var result = driverMock.Object.JQuery("form").SerializedArray();

            Assert.Equal("[{\"name\":\"s\",\"value\":\"\"}]", result);
        }

        [Fact]
        public void ShouldCheckIfElementHasClass()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('form').hasClass('test');")).Returns(true);
            var result = driverMock.Object.JQuery("form").HasClass("test");

            Assert.NotNull(result);
            Assert.True(result);
        }

        [Fact]
        public void ShouldCorrectlyHandleNumberCastingInInternetExplorer()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').width();"))
                .Returns(100d);
            var result = driverMock.Object.JQuery("input").Width();

            Assert.Equal(100, result);
        }

        [Fact]
        public void ShouldThrowExpcetionWhenInitializingHelperWithNullDriver()
        {
            Assert.Throws<ArgumentNullException>(() => WebElementExtensions.JQuery(null, (JQuerySelector)null));
        }
    }
}
