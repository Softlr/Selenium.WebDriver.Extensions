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
        [Test]
        public void SetText()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Text("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHtml()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Html("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetAttribute()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Attribute("test", "test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetPropertyBool()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Property("test", true).Property("test", false);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetPropertyString()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Property("test", "test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetValue()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("input").Value("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetCss()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Css("test", "test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Width((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Width(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Width(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Width((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Width(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Width(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Width(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetWidthDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Width(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Height((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Height(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Height(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Height((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Height(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Height(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Height(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetHeightDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Height(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerWidth((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerWidth(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerWidth(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerWidth((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerWidth(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerWidth(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerWidth(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerWidthDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerWidth(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerHeight((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerHeight(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerHeight(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerHeight((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerHeight(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerHeight(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerHeight(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetInnerHeightDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").InnerHeight(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterWidth((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterWidth(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterWidth(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterWidth((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterWidth(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterWidth(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterWidth(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterWidthDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterWidth(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterHeight((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterHeight(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterHeight(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterHeight((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterHeight(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterHeight(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterHeight(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetOuterHeightDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").OuterHeight(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollLeft((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollLeft(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollLeft(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollLeft((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollLeft(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollLeft(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollLeft(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollLeftDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollLeft(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollTop((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollTop(100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollTop(100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollTop((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollTop(100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollTop(100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollTop(100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetScrollTopDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ScrollTop(100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataString()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Data("test", "test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataBool()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Data("test", true).Data("test", false);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Data("test", (short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Data("test", 100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Data("test", 100L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Data("test", (ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Data("test", 100U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Data("test", 100UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Data("test", 100.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SetDataDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Data("test", 100.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void RemoveData()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").RemoveData("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void AddClass()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").AddClass("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void RemoveClass()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").RemoveClass("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleClass()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ToggleClass("test");

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleClassBool()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").ToggleClass("test", true).ToggleClass("test", false);

            Assert.IsNotNull(result);
        }

        [Test]
        public void Show()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Show();

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShowShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Show((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShowInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Show(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShowLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Show(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShowUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Show((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShowUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Show(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShowUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Show(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void Hide()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Hide();

            Assert.IsNotNull(result);
        }

        [Test]
        public void HideShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Hide((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void HideInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Hide(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void HideLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Hide(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void HideUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Hide((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void HideUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Hide(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void HideUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Hide(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void Toggle()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Toggle();

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Toggle((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Toggle(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Toggle(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Toggle((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Toggle(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToggleUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Toggle(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDown()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideDown();

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDownShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideDown((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDownInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideDown(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDownLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideDown(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDownUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideDown((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDownUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideDown(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideDownUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideDown(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUp()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideUp();

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUpShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideUp((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUpInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideUp(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUpLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideUp(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUpUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideUp((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUpUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideUp(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideUpUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideUp(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggle()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideToggle();

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggleShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideToggle((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggleInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideToggle(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggleLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideToggle(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggleUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideToggle((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggleUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideToggle(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SlideToggleUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").SlideToggle(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeIn()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeIn();

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeInShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeIn((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeInInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeIn(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeInLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeIn(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeInUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeIn((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeInUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeIn(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeInUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeIn(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOut()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeOut();

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOutShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeOut((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOutInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeOut(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOutLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeOut(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOutUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeOut((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOutUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeOut(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeOutUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeOut(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggle()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeToggle();

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggleShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeToggle((short)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggleInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeToggle(500);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggleLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeToggle(500L);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggleUnsignedShort()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeToggle((ushort)100);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggleUnsignedInt()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeToggle(500U);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToggleUnsignedLong()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeToggle(500UL);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToShortFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeTo((short)100, 0.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToShortDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeTo((short)100, 0.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToIntFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeTo(100, 0.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToIntDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeTo(100, 0.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToLongFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeTo(100L, 0.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToLongDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeTo(100L, 0.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToUnsignedShortFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeTo((ushort)100, 0.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToUnsignedShortDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeTo((ushort)100, 0.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToUnsignedIntFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeTo(100U, 0.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToUnsignedIntDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeTo(100U, 0.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToUnsignedLongFloat()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeTo(100UL, 0.5f);

            Assert.IsNotNull(result);
        }

        [Test]
        public void FadeToUnsignedLongDouble()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").FadeTo(100UL, 0.5d);

            Assert.IsNotNull(result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void FadeToNegativeOpacity()
        {
            var mock = MockWebDriver();
            mock.Object.JQuery("div").FadeTo(100UL, -1.0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void FadeToOpacityBiggerThanOne()
        {
            var mock = MockWebDriver();
            mock.Object.JQuery("div").FadeTo(100UL, 2.0);
        }

        [Test]
        public void Blur()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Blur();

            Assert.IsNotNull(result);
        }

        [Test]
        public void Focus()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Focus();

            Assert.IsNotNull(result);
        }

        [Test]
        public void Change()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Change();

            Assert.IsNotNull(result);
        }

        [Test]
        public void Click()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Click();

            Assert.IsNotNull(result);
        }

        [Test]
        public void DoubleClick()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").DoubleClick();

            Assert.IsNotNull(result);
        }

        [Test]
        public void KeyUp()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").KeyUp();

            Assert.IsNotNull(result);
        }

        [Test]
        public void KeyDown()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").KeyDown();

            Assert.IsNotNull(result);
        }

        [Test]
        public void KeyPress()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").KeyPress();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseUp()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").MouseUp();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseDown()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").MouseDown();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseOver()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").MouseOver();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseOut()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").MouseOut();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseMove()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").MouseMove();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseEnter()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").MouseEnter();

            Assert.IsNotNull(result);
        }

        [Test]
        public void MouseLeave()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").MouseLeave();

            Assert.IsNotNull(result);
        }

        [Test]
        public void Resize()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Resize();

            Assert.IsNotNull(result);
        }

        [Test]
        public void Scroll()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").Scroll();

            Assert.IsNotNull(result);
        }

        [Test]
        public void TriggerHandler()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("div").TriggerHandler("click");

            Assert.IsNotNull(result);
        }

        private static Mock<IWebDriver> MockWebDriver(string script = null, object value = null)
        {
            var mock = new Mock<IWebDriver>();
            if (script != null)
            {
                mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(script)).Returns(value);
            }

            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return typeof window.jQuery === 'function';"))
                .Returns(true);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return typeof window.Sizzle === 'function';"))
                .Returns(true);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return typeof document.querySelectorAll === 'function';")).Returns(true);
            return mock;
        }
    }
}
