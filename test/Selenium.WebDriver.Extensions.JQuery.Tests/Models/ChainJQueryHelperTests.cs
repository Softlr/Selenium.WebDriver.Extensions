namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Moq;
    using OpenQA.Selenium;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class ChainJQueryHelperTests : IDisposable
    {
        private readonly IWebDriver driver;

        public ChainJQueryHelperTests()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery"))).Returns(true);
            this.driver = mock.Object;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void ShouldThrowExceptionWhenGettingHelperWithNullSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => this.driver.JQuery((JQuerySelector)null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenGettingHelperWithNullStringSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => this.driver.JQuery((string)null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldSetText()
        {
            var result = this.driver.JQuery("div").Text("test");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetHtml()
        {
            var result = this.driver.JQuery("div").Html("test");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetAttribute()
        {
            var result = this.driver.JQuery("div").Attribute("test", "test");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetPropertyBool()
        {
            var result = this.driver.JQuery("div").Property("test", true).Property("test", false);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetPropertyString()
        {
            var result = this.driver.JQuery("div").Property("test", "test");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetValue()
        {
            var result = this.driver.JQuery("input").Value("test");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetCss()
        {
            var result = this.driver.JQuery("div").Css("test", "test");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetWidth()
        {
            var result = this.driver.JQuery("div").Width(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetHeight()
        {
            var result = this.driver.JQuery("div").Height(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerWidth()
        {
            var result = this.driver.JQuery("div").InnerWidth(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerHeight()
        {
            var result = this.driver.JQuery("div").InnerHeight(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterWidth()
        {
            var result = this.driver.JQuery("div").OuterWidth(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterHeight()
        {
            var result = this.driver.JQuery("div").OuterHeight(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollLeft()
        {
            var result = this.driver.JQuery("div").ScrollLeft(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollTop()
        {
            var result = this.driver.JQuery("div").ScrollTop(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetDataString()
        {
            var result = this.driver.JQuery("div").Data("test", "test");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetDataBool()
        {
            var result = this.driver.JQuery("div").Data("test", true).Data("test", false);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetDataNumber()
        {
            var result = this.driver.JQuery("div").Data("test", 100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldRemoveData()
        {
            var result = this.driver.JQuery("div").RemoveData("test");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldAddClass()
        {
            var result = this.driver.JQuery("div").AddClass("test");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldRemoveClass()
        {
            var result = this.driver.JQuery("div").RemoveClass("test");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldToggleClass()
        {
            var result = this.driver.JQuery("div").ToggleClass("test");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldToggleClassBool()
        {
            var result = this.driver.JQuery("div").ToggleClass("test", true).ToggleClass("test", false);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldRemove()
        {
            var result = this.driver.JQuery("div").Remove();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldRemoveWithSelector()
        {
            var result = this.driver.JQuery("div").Remove(".test");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldEmpty()
        {
            var result = this.driver.JQuery("div").Empty();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldShow()
        {
            var result = this.driver.JQuery("div").Show();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldShowEnum()
        {
            var result = this.driver.JQuery("div").Show(Duration.Fast);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldShowNumber()
        {
            var result = this.driver.JQuery("div").Show(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldHide()
        {
            var result = this.driver.JQuery("div").Hide();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldHideEnum()
        {
            var result = this.driver.JQuery("div").Hide(Duration.Slow);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldHideNumber()
        {
            var result = this.driver.JQuery("div").Hide(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldToggle()
        {
            var result = this.driver.JQuery("div").Toggle();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldToggleEnum()
        {
            var result = this.driver.JQuery("div").Toggle(Duration.Fast);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldToggleNumber()
        {
            var result = this.driver.JQuery("div").Toggle(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideDown()
        {
            var result = this.driver.JQuery("div").SlideDown();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideDownEnum()
        {
            var result = this.driver.JQuery("div").SlideDown(Duration.Fast);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideDownNumber()
        {
            var result = this.driver.JQuery("div").SlideDown(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideUp()
        {
            var result = this.driver.JQuery("div").SlideUp();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideUpEnum()
        {
            var result = this.driver.JQuery("div").SlideUp(Duration.Fast);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideUpNumbel()
        {
            var result = this.driver.JQuery("div").SlideUp(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideToggle()
        {
            var result = this.driver.JQuery("div").SlideToggle();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideToggleEnum()
        {
            var result = this.driver.JQuery("div").SlideToggle(Duration.Slow);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideToggleNumber()
        {
            var result = this.driver.JQuery("div").SlideToggle(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeIn()
        {
            var result = this.driver.JQuery("div").FadeIn();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeInEnum()
        {
            var result = this.driver.JQuery("div").FadeIn(Duration.Slow);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeInNumber()
        {
            var result = this.driver.JQuery("div").FadeIn(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeOut()
        {
            var result = this.driver.JQuery("div").FadeOut();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeOutEnum()
        {
            var result = this.driver.JQuery("div").FadeOut(Duration.Slow);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeOutNumber()
        {
            var result = this.driver.JQuery("div").FadeOut(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToggle()
        {
            var result = this.driver.JQuery("div").FadeToggle();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToggleEnum()
        {
            var result = this.driver.JQuery("div").FadeToggle(Duration.Slow);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToggleNumber()
        {
            var result = this.driver.JQuery("div").FadeToggle(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToNumber()
        {
            var result = this.driver.JQuery("div").FadeTo(100, 0.5m);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToGivenValue()
        {
            var result = this.driver.JQuery("div").FadeTo(100, 0.5m);
            
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToGivenDuration()
        {
            var result = this.driver.JQuery("div").FadeTo(Duration.Slow, 0.5m);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToNegativeOpacity()
        {
            var ex = Assert.Throws<ArgumentException>(() => this.driver.JQuery("div").FadeTo(100, -1m));
            Assert.Equal("opacity", ex.ParamName);
        }

        [Fact]
        public void ShouldFadeToOpacityBiggerThanOne()
        {
            var ex = Assert.Throws<ArgumentException>(() => this.driver.JQuery("div").FadeTo(100, 2m));
            Assert.Equal("opacity", ex.ParamName);
        }

        [Fact]
        public void ShouldFadeToEnumNegativeOpacity()
        {
            var ex = Assert.Throws<ArgumentException>(() => this.driver.JQuery("div").FadeTo(Duration.Slow, -1m));
            Assert.Equal("opacity", ex.ParamName);
        }

        [Fact]
        public void ShouldFadeToEnumOpacityBiggerThanOne()
        {
            var ex = Assert.Throws<ArgumentException>(() => this.driver.JQuery("div").FadeTo(Duration.Slow, 2m));
            Assert.Equal("opacity", ex.ParamName);
        }

        [Fact]
        public void ShouldBlur()
        {
            var result = this.driver.JQuery("div").Blur();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFocus()
        {
            var result = this.driver.JQuery("div").Focus();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldChange()
        {
            var result = this.driver.JQuery("div").Change();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldClick()
        {
            var result = this.driver.JQuery("div").Click();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldDoubleClick()
        {
            var result = this.driver.JQuery("div").DoubleClick();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldKeyUp()
        {
            var result = this.driver.JQuery("div").KeyUp();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldKeyDown()
        {
            var result = this.driver.JQuery("div").KeyDown();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldKeyPress()
        {
            var result = this.driver.JQuery("div").KeyPress();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldMouseUp()
        {
            var result = this.driver.JQuery("div").MouseUp();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldMouseDown()
        {
            var result = this.driver.JQuery("div").MouseDown();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldMouseOver()
        {
            var result = this.driver.JQuery("div").MouseOver();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldMouseOut()
        {
            var result = this.driver.JQuery("div").MouseOut();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldMouseMove()
        {
            var result = this.driver.JQuery("div").MouseMove();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldMouseEnter()
        {
            var result = this.driver.JQuery("div").MouseEnter();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldMouseLeave()
        {
            var result = this.driver.JQuery("div").MouseLeave();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldResize()
        {
            var result = this.driver.JQuery("div").Resize();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldScroll()
        {
            var result = this.driver.JQuery("div").Scroll();

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldTriggerEvent()
        {
            var result = this.driver.JQuery("div").Trigger("click");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldTriggerHandler()
        {
            var result = this.driver.JQuery("div").TriggerHandler("click");

            Assert.NotNull(result);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.driver.Dispose();
            }
        }
    }
}
