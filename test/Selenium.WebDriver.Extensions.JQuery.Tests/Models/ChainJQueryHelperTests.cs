namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using Moq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class ChainJQueryHelperTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return typeof window.jQuery === 'function';"))
                .Returns(true);
            this.driver = mock.Object;
        }

        [TearDown]
        public void TearDown()
        {
            this.driver = null;
        }

        [Test]
        public void SetText()
        {
            var result = this.driver.JQuery("div").Text("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHtml()
        {
            var result = this.driver.JQuery("div").Html("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetAttribute()
        {
            var result = this.driver.JQuery("div").Attribute("test", "test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetPropertyBool()
        {
            var result = this.driver.JQuery("div").Property("test", true).Property("test", false);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetPropertyString()
        {
            var result = this.driver.JQuery("div").Property("test", "test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetValue()
        {
            var result = this.driver.JQuery("input").Value("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetCss()
        {
            var result = this.driver.JQuery("div").Css("test", "test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthShort()
        {
            var result = this.driver.JQuery("div").Width((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthInt()
        {
            var result = this.driver.JQuery("div").Width(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthLong()
        {
            var result = this.driver.JQuery("div").Width(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthUnsignedShort()
        {
            var result = this.driver.JQuery("div").Width((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthUnsignedInt()
        {
            var result = this.driver.JQuery("div").Width(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthUnsignedLong()
        {
            var result = this.driver.JQuery("div").Width(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthFloat()
        {
            var result = this.driver.JQuery("div").Width(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthDouble()
        {
            var result = this.driver.JQuery("div").Width(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightShort()
        {
            var result = this.driver.JQuery("div").Height((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightInt()
        {
            var result = this.driver.JQuery("div").Height(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightLong()
        {
            var result = this.driver.JQuery("div").Height(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightUnsignedShort()
        {
            var result = this.driver.JQuery("div").Height((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightUnsignedInt()
        {
            var result = this.driver.JQuery("div").Height(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightUnsignedLong()
        {
            var result = this.driver.JQuery("div").Height(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightFloat()
        {
            var result = this.driver.JQuery("div").Height(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightDouble()
        {
            var result = this.driver.JQuery("div").Height(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthShort()
        {
            var result = this.driver.JQuery("div").InnerWidth((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthInt()
        {
            var result = this.driver.JQuery("div").InnerWidth(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthLong()
        {
            var result = this.driver.JQuery("div").InnerWidth(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthUnsignedShort()
        {
            var result = this.driver.JQuery("div").InnerWidth((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthUnsignedInt()
        {
            var result = this.driver.JQuery("div").InnerWidth(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthUnsignedLong()
        {
            var result = this.driver.JQuery("div").InnerWidth(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthFloat()
        {
            var result = this.driver.JQuery("div").InnerWidth(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthDouble()
        {
            var result = this.driver.JQuery("div").InnerWidth(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightShort()
        {
            var result = this.driver.JQuery("div").InnerHeight((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightInt()
        {
            var result = this.driver.JQuery("div").InnerHeight(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightLong()
        {
            var result = this.driver.JQuery("div").InnerHeight(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightUnsignedShort()
        {
            var result = this.driver.JQuery("div").InnerHeight((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightUnsignedInt()
        {
            var result = this.driver.JQuery("div").InnerHeight(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightUnsignedLong()
        {
            var result = this.driver.JQuery("div").InnerHeight(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightFloat()
        {
            var result = this.driver.JQuery("div").InnerHeight(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightDouble()
        {
            var result = this.driver.JQuery("div").InnerHeight(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthShort()
        {
            var result = this.driver.JQuery("div").OuterWidth((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthInt()
        {
            var result = this.driver.JQuery("div").OuterWidth(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthLong()
        {
            var result = this.driver.JQuery("div").OuterWidth(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthUnsignedShort()
        {
            var result = this.driver.JQuery("div").OuterWidth((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthUnsignedInt()
        {
            var result = this.driver.JQuery("div").OuterWidth(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthUnsignedLong()
        {
            var result = this.driver.JQuery("div").OuterWidth(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthFloat()
        {
            var result = this.driver.JQuery("div").OuterWidth(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthDouble()
        {
            var result = this.driver.JQuery("div").OuterWidth(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightShort()
        {
            var result = this.driver.JQuery("div").OuterHeight((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightInt()
        {
            var result = this.driver.JQuery("div").OuterHeight(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightLong()
        {
            var result = this.driver.JQuery("div").OuterHeight(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightUnsignedShort()
        {
            var result = this.driver.JQuery("div").OuterHeight((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightUnsignedInt()
        {
            var result = this.driver.JQuery("div").OuterHeight(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightUnsignedLong()
        {
            var result = this.driver.JQuery("div").OuterHeight(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightFloat()
        {
            var result = this.driver.JQuery("div").OuterHeight(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightDouble()
        {
            var result = this.driver.JQuery("div").OuterHeight(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftShort()
        {
            var result = this.driver.JQuery("div").ScrollLeft((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftInt()
        {
            var result = this.driver.JQuery("div").ScrollLeft(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftLong()
        {
            var result = this.driver.JQuery("div").ScrollLeft(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftUnsignedShort()
        {
            var result = this.driver.JQuery("div").ScrollLeft((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftUnsignedInt()
        {
            var result = this.driver.JQuery("div").ScrollLeft(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftUnsignedLong()
        {
            var result = this.driver.JQuery("div").ScrollLeft(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftFloat()
        {
            var result = this.driver.JQuery("div").ScrollLeft(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftDouble()
        {
            var result = this.driver.JQuery("div").ScrollLeft(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopShort()
        {
            var result = this.driver.JQuery("div").ScrollTop((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopInt()
        {
            var result = this.driver.JQuery("div").ScrollTop(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopLong()
        {
            var result = this.driver.JQuery("div").ScrollTop(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopUnsignedShort()
        {
            var result = this.driver.JQuery("div").ScrollTop((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopUnsignedInt()
        {
            var result = this.driver.JQuery("div").ScrollTop(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopUnsignedLong()
        {
            var result = this.driver.JQuery("div").ScrollTop(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopFloat()
        {
            var result = this.driver.JQuery("div").ScrollTop(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopDouble()
        {
            var result = this.driver.JQuery("div").ScrollTop(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataString()
        {
            var result = this.driver.JQuery("div").Data("test", "test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataBool()
        {
            var result = this.driver.JQuery("div").Data("test", true).Data("test", false);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataShort()
        {
            var result = this.driver.JQuery("div").Data("test", (short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataInt()
        {
            var result = this.driver.JQuery("div").Data("test", 100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataLong()
        {
            var result = this.driver.JQuery("div").Data("test", 100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataUnsignedShort()
        {
            var result = this.driver.JQuery("div").Data("test", (ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataUnsignedInt()
        {
            var result = this.driver.JQuery("div").Data("test", 100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataUnsignedLong()
        {
            var result = this.driver.JQuery("div").Data("test", 100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataFloat()
        {
            var result = this.driver.JQuery("div").Data("test", 100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataDouble()
        {
            var result = this.driver.JQuery("div").Data("test", 100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void RemoveData()
        {
            var result = this.driver.JQuery("div").RemoveData("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void AddClass()
        {
            var result = this.driver.JQuery("div").AddClass("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void RemoveClass()
        {
            var result = this.driver.JQuery("div").RemoveClass("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleClass()
        {
            var result = this.driver.JQuery("div").ToggleClass("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleClassBool()
        {
            var result = this.driver.JQuery("div").ToggleClass("test", true).ToggleClass("test", false);

            Assert.IsNotNull(result);
        }

        [Test]
        public void Show()
        {
            var result = this.driver.JQuery("div").Show();

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShowShort()
        {
            var result = this.driver.JQuery("div").Show((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShowInt()
        {
            var result = this.driver.JQuery("div").Show(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShowLong()
        {
            var result = this.driver.JQuery("div").Show(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShowUnsignedShort()
        {
            var result = this.driver.JQuery("div").Show((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShowUnsignedInt()
        {
            var result = this.driver.JQuery("div").Show(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShowUnsignedLong()
        {
            var result = this.driver.JQuery("div").Show(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void Hide()
        {
            var result = this.driver.JQuery("div").Hide();

            Assert.IsNotNull(result);
        }

        [Test]
        public void HideShort()
        {
            var result = this.driver.JQuery("div").Hide((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void HideInt()
        {
            var result = this.driver.JQuery("div").Hide(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void HideLong()
        {
            var result = this.driver.JQuery("div").Hide(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void HideUnsignedShort()
        {
            var result = this.driver.JQuery("div").Hide((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void HideUnsignedInt()
        {
            var result = this.driver.JQuery("div").Hide(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void HideUnsignedLong()
        {
            var result = this.driver.JQuery("div").Hide(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void Toggle()
        {
            var result = this.driver.JQuery("div").Toggle();

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleShort()
        {
            var result = this.driver.JQuery("div").Toggle((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleInt()
        {
            var result = this.driver.JQuery("div").Toggle(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleLong()
        {
            var result = this.driver.JQuery("div").Toggle(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleUnsignedShort()
        {
            var result = this.driver.JQuery("div").Toggle((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleUnsignedInt()
        {
            var result = this.driver.JQuery("div").Toggle(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleUnsignedLong()
        {
            var result = this.driver.JQuery("div").Toggle(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDown()
        {
            var result = this.driver.JQuery("div").SlideDown();

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDownShort()
        {
            var result = this.driver.JQuery("div").SlideDown((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDownInt()
        {
            var result = this.driver.JQuery("div").SlideDown(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDownLong()
        {
            var result = this.driver.JQuery("div").SlideDown(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDownUnsignedShort()
        {
            var result = this.driver.JQuery("div").SlideDown((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDownUnsignedInt()
        {
            var result = this.driver.JQuery("div").SlideDown(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDownUnsignedLong()
        {
            var result = this.driver.JQuery("div").SlideDown(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUp()
        {
            var result = this.driver.JQuery("div").SlideUp();

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUpShort()
        {
            var result = this.driver.JQuery("div").SlideUp((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUpInt()
        {
            var result = this.driver.JQuery("div").SlideUp(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUpLong()
        {
            var result = this.driver.JQuery("div").SlideUp(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUpUnsignedShort()
        {
            var result = this.driver.JQuery("div").SlideUp((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUpUnsignedInt()
        {
            var result = this.driver.JQuery("div").SlideUp(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUpUnsignedLong()
        {
            var result = this.driver.JQuery("div").SlideUp(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggle()
        {
            var result = this.driver.JQuery("div").SlideToggle();

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggleShort()
        {
            var result = this.driver.JQuery("div").SlideToggle((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggleInt()
        {
            var result = this.driver.JQuery("div").SlideToggle(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggleLong()
        {
            var result = this.driver.JQuery("div").SlideToggle(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggleUnsignedShort()
        {
            var result = this.driver.JQuery("div").SlideToggle((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggleUnsignedInt()
        {
            var result = this.driver.JQuery("div").SlideToggle(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggleUnsignedLong()
        {
            var result = this.driver.JQuery("div").SlideToggle(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeIn()
        {
            var result = this.driver.JQuery("div").FadeIn();

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeInShort()
        {
            var result = this.driver.JQuery("div").FadeIn((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeInInt()
        {
            var result = this.driver.JQuery("div").FadeIn(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeInLong()
        {
            var result = this.driver.JQuery("div").FadeIn(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeInUnsignedShort()
        {
            var result = this.driver.JQuery("div").FadeIn((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeInUnsignedInt()
        {
            var result = this.driver.JQuery("div").FadeIn(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeInUnsignedLong()
        {
            var result = this.driver.JQuery("div").FadeIn(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOut()
        {
            var result = this.driver.JQuery("div").FadeOut();

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOutShort()
        {
            var result = this.driver.JQuery("div").FadeOut((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOutInt()
        {
            var result = this.driver.JQuery("div").FadeOut(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOutLong()
        {
            var result = this.driver.JQuery("div").FadeOut(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOutUnsignedShort()
        {
            var result = this.driver.JQuery("div").FadeOut((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOutUnsignedInt()
        {
            var result = this.driver.JQuery("div").FadeOut(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOutUnsignedLong()
        {
            var result = this.driver.JQuery("div").FadeOut(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggle()
        {
            var result = this.driver.JQuery("div").FadeToggle();

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggleShort()
        {
            var result = this.driver.JQuery("div").FadeToggle((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggleInt()
        {
            var result = this.driver.JQuery("div").FadeToggle(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggleLong()
        {
            var result = this.driver.JQuery("div").FadeToggle(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggleUnsignedShort()
        {
            var result = this.driver.JQuery("div").FadeToggle((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggleUnsignedInt()
        {
            var result = this.driver.JQuery("div").FadeToggle(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggleUnsignedLong()
        {
            var result = this.driver.JQuery("div").FadeToggle(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToShortFloat()
        {
            var result = this.driver.JQuery("div").FadeTo((short)100, 0.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToShortDouble()
        {
            var result = this.driver.JQuery("div").FadeTo((short)100, 0.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToIntFloat()
        {
            var result = this.driver.JQuery("div").FadeTo(100, 0.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToIntDouble()
        {
            var result = this.driver.JQuery("div").FadeTo(100, 0.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToLongFloat()
        {
            var result = this.driver.JQuery("div").FadeTo(100L, 0.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToLongDouble()
        {
            var result = this.driver.JQuery("div").FadeTo(100L, 0.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToUnsignedShortFloat()
        {
            var result = this.driver.JQuery("div").FadeTo((ushort)100, 0.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToUnsignedShortDouble()
        {
            var result = this.driver.JQuery("div").FadeTo((ushort)100, 0.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToUnsignedIntFloat()
        {
            var result = this.driver.JQuery("div").FadeTo(100U, 0.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToUnsignedIntDouble()
        {
            var result = this.driver.JQuery("div").FadeTo(100U, 0.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToUnsignedLongFloat()
        {
            var result = this.driver.JQuery("div").FadeTo(100UL, 0.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToUnsignedLongDouble()
        {
            var result = this.driver.JQuery("div").FadeTo(100UL, 0.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void FadeToNegativeOpacity()
        {
            this.driver.JQuery("div").FadeTo(100UL, -1.0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void FadeToOpacityBiggerThanOne()
        {
            this.driver.JQuery("div").FadeTo(100UL, 2.0);
        }

        [Test]
        public void Blur()
        {
            var result = this.driver.JQuery("div").Blur();

            Assert.IsNotNull(result);
        }

        [Test]
        public void Focus()
        {
            var result = this.driver.JQuery("div").Focus();

            Assert.IsNotNull(result);
        }

        [Test]
        public void Change()
        {
            var result = this.driver.JQuery("div").Change();

            Assert.IsNotNull(result);
        }

        [Test]
        public void Click()
        {
            var result = this.driver.JQuery("div").Click();

            Assert.IsNotNull(result);
        }

        [Test]
        public void DoubleClick()
        {
            var result = this.driver.JQuery("div").DoubleClick();

            Assert.IsNotNull(result);
        }

        [Test]
        public void KeyUp()
        {
            var result = this.driver.JQuery("div").KeyUp();

            Assert.IsNotNull(result);
        }

        [Test]
        public void KeyDown()
        {
            var result = this.driver.JQuery("div").KeyDown();

            Assert.IsNotNull(result);
        }

        [Test]
        public void KeyPress()
        {
            var result = this.driver.JQuery("div").KeyPress();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseUp()
        {
            var result = this.driver.JQuery("div").MouseUp();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseDown()
        {
            var result = this.driver.JQuery("div").MouseDown();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseOver()
        {
            var result = this.driver.JQuery("div").MouseOver();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseOut()
        {
            var result = this.driver.JQuery("div").MouseOut();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseMove()
        {
            var result = this.driver.JQuery("div").MouseMove();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseEnter()
        {
            var result = this.driver.JQuery("div").MouseEnter();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseLeave()
        {
            var result = this.driver.JQuery("div").MouseLeave();

            Assert.IsNotNull(result);
        }

        [Test]
        public void Resize()
        {
            var result = this.driver.JQuery("div").Resize();

            Assert.IsNotNull(result);
        }

        [Test]
        public void Scroll()
        {
            var result = this.driver.JQuery("div").Scroll();

            Assert.IsNotNull(result);
        }

        [Test]
        public void TriggerHandler()
        {
            var result = this.driver.JQuery("div").TriggerHandler("click");

            Assert.IsNotNull(result);
        }
    }
}
