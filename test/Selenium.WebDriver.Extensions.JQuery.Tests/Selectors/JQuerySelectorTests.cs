namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.JQuery.By;

    [Trait("Category", "Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class JQuerySelectorTests
    {
        public static IEnumerable<object[]> SelectorData
        {
            get
            {
                // basic tests
                yield return new object[] { By.JQuerySelector("div"), "jQuery('div')" };
                yield return new object[] { By.JQuerySelector("div", jQueryVariable: "$"), "$('div')" };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div", By.JQuerySelector("article")), 
                                     "jQuery('div', jQuery('article'))"
                                 };

                // functions tests
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").Add("span", By.JQuerySelector("body")), 
                                     "jQuery('div').add('span', jQuery('body'))"
                                 };
                yield return new object[] { By.JQuerySelector("div").Add("span"), "jQuery('div').add('span')" };
                yield return new object[] { By.JQuerySelector("div").AddBack(), "jQuery('div').addBack()" };
                yield return new object[] { By.JQuerySelector("div").AddBack("span"), "jQuery('div').addBack('span')" };
                yield return new object[] { By.JQuerySelector("div").AndSelf(), "jQuery('div').andSelf()" };
                yield return new object[] { By.JQuerySelector("div").Children(), "jQuery('div').children()" };
                yield return new object[] { By.JQuerySelector("div").Children("span"), "jQuery('div').children('span')" };
                yield return new object[] { By.JQuerySelector("div").Closest("span"), "jQuery('div').closest('span')" };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").Closest("span", By.JQuerySelector("body")), 
                                     "jQuery('div').closest('span', jQuery('body'))"
                                 };
                yield return new object[] { By.JQuerySelector("div").Contents(), "jQuery('div').contents()" };
                yield return new object[] { By.JQuerySelector("div").End(), "jQuery('div').end()" };
                yield return new object[] { By.JQuerySelector("div").Eq(0), "jQuery('div').eq(0)" };
                yield return new object[] { By.JQuerySelector("div").Eq(-2), "jQuery('div').eq(-2)" };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").Filter(".empty"),
                                     "jQuery('div').filter('.empty')"
                                 };
                yield return new object[] { By.JQuerySelector("div").Find(".empty"), "jQuery('div').find('.empty')" };
                yield return new object[] { By.JQuerySelector("div").First(), "jQuery('div').first()" };
                yield return new object[] { By.JQuerySelector("div").Has(".empty"), "jQuery('div').has('.empty')" };
                yield return new object[] { By.JQuerySelector("div").Is(".empty"), "jQuery('div').is('.empty')" };
                yield return new object[] { By.JQuerySelector("div").Last(), "jQuery('div').last()" };
                yield return new object[] { By.JQuerySelector("div").Next(".empty"), "jQuery('div').next('.empty')" };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").NextAll(".empty"),
                                     "jQuery('div').nextAll('.empty')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").NextUntil(".empty"), 
                                     "jQuery('div').nextUntil('.empty')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").NextUntil(".empty", "span"), 
                                     "jQuery('div').nextUntil('.empty', 'span')"
                                 };
                yield return new object[] { By.JQuerySelector("div").Not(".empty"), "jQuery('div').not('.empty')" };
                yield return new object[] { By.JQuerySelector("div").OffsetParent(), "jQuery('div').offsetParent()" };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").Parent(".parent"), 
                                     "jQuery('div').parent('.parent')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").Parents(".parent"),
                                     "jQuery('div').parents('.parent')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").ParentsUntil(".parent"),
                                     "jQuery('div').parentsUntil('.parent')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").ParentsUntil(".parent", "body"),
                                     "jQuery('div').parentsUntil('.parent', 'body')"
                                 };
                yield return new object[] { By.JQuerySelector("div").Prev(".empty"), "jQuery('div').prev('.empty')" };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").PrevAll(".empty"), 
                                     "jQuery('div').prevAll('.empty')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").PrevUntil(".empty"), 
                                     "jQuery('div').prevUntil('.empty')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").PrevUntil(".empty", "span"), 
                                     "jQuery('div').prevUntil('.empty', 'span')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").Siblings(".empty"), 
                                     "jQuery('div').siblings('.empty')"
                                 };
                yield return new object[] { By.JQuerySelector("div").Slice(1), "jQuery('div').slice(1)" };
                yield return new object[] { By.JQuerySelector("div").Slice(1, 3), "jQuery('div').slice(1, 3)" };
                yield return new object[] { By.JQuerySelector("div").Slice(-3, -1), "jQuery('div').slice(-3, -1)" };

                // additional tests
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").AddBack(string.Empty),
                                     "jQuery('div').addBack()"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").AddBack(" span "),
                                     "jQuery('div').addBack('span')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("input[type='text']"),
                                     "jQuery('input[type=\"text\"]')"
                                 };
            }
        }

        public static IEnumerable<object[]> EqualityData
        {
            get
            {
                yield return new object[] { By.JQuerySelector("div"), By.JQuerySelector("div"), true };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div"), 
                                     By.JQuerySelector("div", jQueryVariable: "$"), 
                                     false
                                 };
                yield return new object[] { By.JQuerySelector("div"), By.JQuerySelector("span"), false };
                yield return new object[] { By.JQuerySelector("div"), null, false };
                yield return new object[] { null, By.JQuerySelector("div"), false };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div", By.JQuerySelector("body")), 
                                     By.JQuerySelector("div"),
                                     false
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div", By.JQuerySelector("body")), 
                                     By.JQuerySelector("div", By.JQuerySelector("body")),
                                     true
                                 };
            }
        }

        [Theory]
        [MemberData("SelectorData")]
        public void ShouldGenerateCorrectSelector(JQuerySelector selector, string expectedResult)
        {
            Assert.Equal(expectedResult, selector.Selector);
        }

        [Fact]
        public void ShouldPopulateContextProperty()
        {
            var by = By.JQuerySelector("div", By.JQuerySelector("article"));

            Assert.Equal(by.Selector, "jQuery('div', jQuery('article'))");
            Assert.Equal(by.Context.Selector, "jQuery('article')");
        }

        [Fact]
        public void ShouldPopulateJQueryVariable()
        {
            var by = By.JQuerySelector("div", jQueryVariable: "$");

            Assert.Equal(by.JQueryVariable, "$");
        }

        [Fact]
        public void ShowThrowExceptionWhenCreatingJQuerySelectorWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => By.JQuerySelector(null));
        }

        [Fact]
        public void ShouldPopulateFormatStringProperty()
        {
            var formatString = By.JQuerySelector("div").CallFormatString;

            Assert.NotNull(formatString);
        }

        [Theory]
        [MemberData("EqualityData")]
        public void EqualityOperator(JQuerySelector selector1, JQuerySelector selector2, bool expectedResult)
        {
            Assert.Equal(expectedResult, selector1 == selector2);
            if (selector1 != null)
            {
                Assert.Equal(expectedResult, selector1.Equals(selector2));
                if (selector2 != null)
                {
                    Assert.Equal(expectedResult, selector1.GetHashCode() == selector2.GetHashCode());
                }
            }

            Assert.NotEqual(expectedResult, selector1 != selector2);
        }

        [Fact]
        public void ShouldNotCompareElementsOfDifferentType()
        {
            var selector1 = By.JQuerySelector("div");
            var selector2 = new object();

#pragma warning disable 252,253
            Assert.False(selector1 == selector2);
            Assert.True(selector1 != selector2);
#pragma warning restore 252,253
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingNestedSelectorWithNull()
        {
            var selector = new JQuerySelector("div");
            Assert.Throws<ArgumentNullException>(() => selector.Create(null));
        }

        [Fact]
        public void ShouldCreateNestedJQueryElement()
        {
            var rootSelector = new Mock<ISelector>();
            rootSelector.SetupGet(x => x.Selector).Returns("div");
            rootSelector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery")))
                .Returns(true); 
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("body > div");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(rootSelector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driverMock.Object);

            var selector = By.JQuerySelector("test").Create(element.Object);
            Assert.IsType<JQuerySelector>(selector);

            var jquerySelector = (JQuerySelector)selector;
            Assert.Equal("jQuery", jquerySelector.JQueryVariable);
        }
    }
}
