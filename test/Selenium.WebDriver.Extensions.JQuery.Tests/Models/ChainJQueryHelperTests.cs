namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using Moq;
    using OpenQA.Selenium;
    using Xunit;

    [Trait("Category", "Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
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
        public void ShouldSetWidthShort()
        {
            var result = this.driver.JQuery("div").Width((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetWidthInt()
        {
            var result = this.driver.JQuery("div").Width(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetWidthLong()
        {
            var result = this.driver.JQuery("div").Width(100L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetWidthUnsignedShort()
        {
            var result = this.driver.JQuery("div").Width((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetWidthUnsignedInt()
        {
            var result = this.driver.JQuery("div").Width(100U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetWidthUnsignedLong()
        {
            var result = this.driver.JQuery("div").Width(100UL);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetWidthFloat()
        {
            var result = this.driver.JQuery("div").Width(100.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetWidthDouble()
        {
            var result = this.driver.JQuery("div").Width(100.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetHeightShort()
        {
            var result = this.driver.JQuery("div").Height((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetHeightInt()
        {
            var result = this.driver.JQuery("div").Height(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetHeightLong()
        {
            var result = this.driver.JQuery("div").Height(100L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetHeightUnsignedShort()
        {
            var result = this.driver.JQuery("div").Height((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetHeightUnsignedInt()
        {
            var result = this.driver.JQuery("div").Height(100U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetHeightUnsignedLong()
        {
            var result = this.driver.JQuery("div").Height(100UL);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetHeightFloat()
        {
            var result = this.driver.JQuery("div").Height(100.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetHeightDouble()
        {
            var result = this.driver.JQuery("div").Height(100.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerWidthShort()
        {
            var result = this.driver.JQuery("div").InnerWidth((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerWidthInt()
        {
            var result = this.driver.JQuery("div").InnerWidth(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerWidthLong()
        {
            var result = this.driver.JQuery("div").InnerWidth(100L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerWidthUnsignedShort()
        {
            var result = this.driver.JQuery("div").InnerWidth((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerWidthUnsignedInt()
        {
            var result = this.driver.JQuery("div").InnerWidth(100U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerWidthUnsignedLong()
        {
            var result = this.driver.JQuery("div").InnerWidth(100UL);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerWidthFloat()
        {
            var result = this.driver.JQuery("div").InnerWidth(100.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerWidthDouble()
        {
            var result = this.driver.JQuery("div").InnerWidth(100.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerHeightShort()
        {
            var result = this.driver.JQuery("div").InnerHeight((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerHeightInt()
        {
            var result = this.driver.JQuery("div").InnerHeight(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerHeightLong()
        {
            var result = this.driver.JQuery("div").InnerHeight(100L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerHeightUnsignedShort()
        {
            var result = this.driver.JQuery("div").InnerHeight((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerHeightUnsignedInt()
        {
            var result = this.driver.JQuery("div").InnerHeight(100U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerHeightUnsignedLong()
        {
            var result = this.driver.JQuery("div").InnerHeight(100UL);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerHeightFloat()
        {
            var result = this.driver.JQuery("div").InnerHeight(100.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetInnerHeightDouble()
        {
            var result = this.driver.JQuery("div").InnerHeight(100.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterWidthShort()
        {
            var result = this.driver.JQuery("div").OuterWidth((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterWidthInt()
        {
            var result = this.driver.JQuery("div").OuterWidth(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterWidthLong()
        {
            var result = this.driver.JQuery("div").OuterWidth(100L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterWidthUnsignedShort()
        {
            var result = this.driver.JQuery("div").OuterWidth((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterWidthUnsignedInt()
        {
            var result = this.driver.JQuery("div").OuterWidth(100U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterWidthUnsignedLong()
        {
            var result = this.driver.JQuery("div").OuterWidth(100UL);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterWidthFloat()
        {
            var result = this.driver.JQuery("div").OuterWidth(100.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterWidthDouble()
        {
            var result = this.driver.JQuery("div").OuterWidth(100.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterHeightShort()
        {
            var result = this.driver.JQuery("div").OuterHeight((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterHeightInt()
        {
            var result = this.driver.JQuery("div").OuterHeight(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterHeightLong()
        {
            var result = this.driver.JQuery("div").OuterHeight(100L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterHeightUnsignedShort()
        {
            var result = this.driver.JQuery("div").OuterHeight((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterHeightUnsignedInt()
        {
            var result = this.driver.JQuery("div").OuterHeight(100U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterHeightUnsignedLong()
        {
            var result = this.driver.JQuery("div").OuterHeight(100UL);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterHeightFloat()
        {
            var result = this.driver.JQuery("div").OuterHeight(100.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetOuterHeightDouble()
        {
            var result = this.driver.JQuery("div").OuterHeight(100.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollLeftShort()
        {
            var result = this.driver.JQuery("div").ScrollLeft((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollLeftInt()
        {
            var result = this.driver.JQuery("div").ScrollLeft(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollLeftLong()
        {
            var result = this.driver.JQuery("div").ScrollLeft(100L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollLeftUnsignedShort()
        {
            var result = this.driver.JQuery("div").ScrollLeft((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollLeftUnsignedInt()
        {
            var result = this.driver.JQuery("div").ScrollLeft(100U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollLeftUnsignedLong()
        {
            var result = this.driver.JQuery("div").ScrollLeft(100UL);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollLeftFloat()
        {
            var result = this.driver.JQuery("div").ScrollLeft(100.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollLeftDouble()
        {
            var result = this.driver.JQuery("div").ScrollLeft(100.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollTopShort()
        {
            var result = this.driver.JQuery("div").ScrollTop((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollTopInt()
        {
            var result = this.driver.JQuery("div").ScrollTop(100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollTopLong()
        {
            var result = this.driver.JQuery("div").ScrollTop(100L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollTopUnsignedShort()
        {
            var result = this.driver.JQuery("div").ScrollTop((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollTopUnsignedInt()
        {
            var result = this.driver.JQuery("div").ScrollTop(100U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollTopUnsignedLong()
        {
            var result = this.driver.JQuery("div").ScrollTop(100UL);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollTopFloat()
        {
            var result = this.driver.JQuery("div").ScrollTop(100.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetScrollTopDouble()
        {
            var result = this.driver.JQuery("div").ScrollTop(100.5d);

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
        public void ShouldSetDataShort()
        {
            var result = this.driver.JQuery("div").Data("test", (short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetDataInt()
        {
            var result = this.driver.JQuery("div").Data("test", 100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetDataLong()
        {
            var result = this.driver.JQuery("div").Data("test", 100L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetDataUnsignedShort()
        {
            var result = this.driver.JQuery("div").Data("test", (ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetDataUnsignedInt()
        {
            var result = this.driver.JQuery("div").Data("test", 100U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetDataUnsignedLong()
        {
            var result = this.driver.JQuery("div").Data("test", 100UL);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetDataFloat()
        {
            var result = this.driver.JQuery("div").Data("test", 100.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSetDataDouble()
        {
            var result = this.driver.JQuery("div").Data("test", 100.5d);

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
        public void ShouldShowShort()
        {
            var result = this.driver.JQuery("div").Show((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldShowInt()
        {
            var result = this.driver.JQuery("div").Show(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldShowLong()
        {
            var result = this.driver.JQuery("div").Show(500L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldShowUnsignedShort()
        {
            var result = this.driver.JQuery("div").Show((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldShowUnsignedInt()
        {
            var result = this.driver.JQuery("div").Show(500U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldShowUnsignedLong()
        {
            var result = this.driver.JQuery("div").Show(500UL);

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
        public void ShouldHideShort()
        {
            var result = this.driver.JQuery("div").Hide((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldHideInt()
        {
            var result = this.driver.JQuery("div").Hide(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldHideLong()
        {
            var result = this.driver.JQuery("div").Hide(500L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldHideUnsignedShort()
        {
            var result = this.driver.JQuery("div").Hide((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldHideUnsignedInt()
        {
            var result = this.driver.JQuery("div").Hide(500U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldHideUnsignedLong()
        {
            var result = this.driver.JQuery("div").Hide(500UL);

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
        public void ShouldToggleShort()
        {
            var result = this.driver.JQuery("div").Toggle((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldToggleInt()
        {
            var result = this.driver.JQuery("div").Toggle(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldToggleLong()
        {
            var result = this.driver.JQuery("div").Toggle(500L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldToggleUnsignedShort()
        {
            var result = this.driver.JQuery("div").Toggle((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldToggleUnsignedInt()
        {
            var result = this.driver.JQuery("div").Toggle(500U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldToggleUnsignedLong()
        {
            var result = this.driver.JQuery("div").Toggle(500UL);

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
        public void ShouldSlideDownShort()
        {
            var result = this.driver.JQuery("div").SlideDown((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideDownInt()
        {
            var result = this.driver.JQuery("div").SlideDown(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideDownLong()
        {
            var result = this.driver.JQuery("div").SlideDown(500L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideDownUnsignedShort()
        {
            var result = this.driver.JQuery("div").SlideDown((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideDownUnsignedInt()
        {
            var result = this.driver.JQuery("div").SlideDown(500U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideDownUnsignedLong()
        {
            var result = this.driver.JQuery("div").SlideDown(500UL);

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
        public void ShouldSlideUpShort()
        {
            var result = this.driver.JQuery("div").SlideUp((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideUpInt()
        {
            var result = this.driver.JQuery("div").SlideUp(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideUpLong()
        {
            var result = this.driver.JQuery("div").SlideUp(500L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideUpUnsignedShort()
        {
            var result = this.driver.JQuery("div").SlideUp((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideUpUnsignedInt()
        {
            var result = this.driver.JQuery("div").SlideUp(500U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideUpUnsignedLong()
        {
            var result = this.driver.JQuery("div").SlideUp(500UL);

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
        public void ShouldSlideToggleShort()
        {
            var result = this.driver.JQuery("div").SlideToggle((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideToggleInt()
        {
            var result = this.driver.JQuery("div").SlideToggle(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideToggleLong()
        {
            var result = this.driver.JQuery("div").SlideToggle(500L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideToggleUnsignedShort()
        {
            var result = this.driver.JQuery("div").SlideToggle((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideToggleUnsignedInt()
        {
            var result = this.driver.JQuery("div").SlideToggle(500U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldSlideToggleUnsignedLong()
        {
            var result = this.driver.JQuery("div").SlideToggle(500UL);

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
        public void ShouldFadeInShort()
        {
            var result = this.driver.JQuery("div").FadeIn((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeInInt()
        {
            var result = this.driver.JQuery("div").FadeIn(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeInLong()
        {
            var result = this.driver.JQuery("div").FadeIn(500L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeInUnsignedShort()
        {
            var result = this.driver.JQuery("div").FadeIn((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeInUnsignedInt()
        {
            var result = this.driver.JQuery("div").FadeIn(500U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeInUnsignedLong()
        {
            var result = this.driver.JQuery("div").FadeIn(500UL);

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
        public void ShouldFadeOutShort()
        {
            var result = this.driver.JQuery("div").FadeOut((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeOutInt()
        {
            var result = this.driver.JQuery("div").FadeOut(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeOutLong()
        {
            var result = this.driver.JQuery("div").FadeOut(500L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeOutUnsignedShort()
        {
            var result = this.driver.JQuery("div").FadeOut((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeOutUnsignedInt()
        {
            var result = this.driver.JQuery("div").FadeOut(500U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeOutUnsignedLong()
        {
            var result = this.driver.JQuery("div").FadeOut(500UL);

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
        public void ShouldFadeToggleShort()
        {
            var result = this.driver.JQuery("div").FadeToggle((short)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToggleInt()
        {
            var result = this.driver.JQuery("div").FadeToggle(500);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToggleLong()
        {
            var result = this.driver.JQuery("div").FadeToggle(500L);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToggleUnsignedShort()
        {
            var result = this.driver.JQuery("div").FadeToggle((ushort)100);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToggleUnsignedInt()
        {
            var result = this.driver.JQuery("div").FadeToggle(500U);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToggleUnsignedLong()
        {
            var result = this.driver.JQuery("div").FadeToggle(500UL);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToEnumFloat()
        {
            var result = this.driver.JQuery("div").FadeTo(Duration.Fast, 0.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToEnumDouble()
        {
            var result = this.driver.JQuery("div").FadeTo(Duration.Fast, 0.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToShortFloat()
        {
            var result = this.driver.JQuery("div").FadeTo((short)100, 0.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToShortDouble()
        {
            var result = this.driver.JQuery("div").FadeTo((short)100, 0.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToIntFloat()
        {
            var result = this.driver.JQuery("div").FadeTo(100, 0.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToIntDouble()
        {
            var result = this.driver.JQuery("div").FadeTo(100, 0.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToLongFloat()
        {
            var result = this.driver.JQuery("div").FadeTo(100L, 0.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToLongDouble()
        {
            var result = this.driver.JQuery("div").FadeTo(100L, 0.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToUnsignedShortFloat()
        {
            var result = this.driver.JQuery("div").FadeTo((ushort)100, 0.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToUnsignedShortDouble()
        {
            var result = this.driver.JQuery("div").FadeTo((ushort)100, 0.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToUnsignedIntFloat()
        {
            var result = this.driver.JQuery("div").FadeTo(100U, 0.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToUnsignedIntDouble()
        {
            var result = this.driver.JQuery("div").FadeTo(100U, 0.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToUnsignedLongFloat()
        {
            var result = this.driver.JQuery("div").FadeTo(100UL, 0.5f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToUnsignedLongDouble()
        {
            var result = this.driver.JQuery("div").FadeTo(100UL, 0.5d);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFadeToNegativeOpacity()
        {
            Assert.Throws<ArgumentException>(() => this.driver.JQuery("div").FadeTo(100UL, -1.0));
        }

        [Fact]
        public void ShouldFadeToOpacityBiggerThanOne()
        {
            Assert.Throws<ArgumentException>(() => this.driver.JQuery("div").FadeTo(100UL, 2.0));
        }

        [Fact]
        public void ShouldFadeToEnumNegativeOpacity()
        {
            Assert.Throws<ArgumentException>(() => this.driver.JQuery("div").FadeTo(Duration.Slow, -1.0));
        }

        [Fact]
        public void ShouldFadeToEnumOpacityBiggerThanOne()
        {
            Assert.Throws<ArgumentException>(() => this.driver.JQuery("div").FadeTo(Duration.Slow, 2.0));
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
