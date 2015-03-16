namespace Selenium.WebDriver.Extensions.Sizzle.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;
    using Xunit.Extensions;

    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class SizzleSelectorTests
    {
        public static IEnumerable<object[]> SelectorData
        {
            get
            {
                yield return new object[] { By.SizzleSelector("div"), "Sizzle('div')" };
                yield return new object[]
                                 {
                                     By.SizzleSelector("div", By.SizzleSelector("article")), 
                                     "Sizzle('div', Sizzle('article')[0])"
                                 };
                yield return new object[]
                                 {
                                     By.SizzleSelector("input[type='text']"), 
                                     "Sizzle('input[type=\"text\"]')"
                                 };
            }
        }

        public static IEnumerable<object[]> EqualityData
        {
            get
            {
                yield return new object[] { By.SizzleSelector("div"), By.SizzleSelector("div"), true };
                yield return new object[] { By.SizzleSelector("div"), By.SizzleSelector("span"), false };
                yield return new object[] { By.SizzleSelector("div"), null, false };
                yield return new object[] { null, By.SizzleSelector("div"), false };
                yield return new object[]
                                 {
                                     By.SizzleSelector("div", By.SizzleSelector("body")), 
                                     By.SizzleSelector("div"),
                                     false
                                 };
                yield return new object[]
                                 {
                                     By.SizzleSelector("div", By.SizzleSelector("body")),
                                     By.SizzleSelector("div", By.SizzleSelector("body")), 
                                     true
                                 };
            }
        }

        [Theory]
        [PropertyData("SelectorData")]
        public void ShouldGenerateCorrectSelector(SizzleSelector selector, string expectedResult)
        {
            Assert.Equal(expectedResult, selector.Selector);
        }

        [Fact]
        public void ShouldPopulateContextProperty()
        {
            var by = By.SizzleSelector("div", By.SizzleSelector("article"));

            Assert.Equal(by.Selector, "Sizzle('div', Sizzle('article')[0])");
            Assert.Equal(by.Context.Selector, "Sizzle('article')");
        }

        [Fact]
        public void ShowThrowExceptionWhenCreatingSizzleSelectorWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => By.SizzleSelector(null));
        }

        [Fact]
        public void ShouldPopulateFormatStringProperty()
        {
            var formatString = By.SizzleSelector("div").CallFormatString;
            
            Assert.NotNull(formatString);
        }

        [Theory]
        [PropertyData("EqualityData")]
        public void ShouldProperlyCompareSelectors(
            SizzleSelector selector1,
            SizzleSelector selector2,
            bool expectedResult)
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
            var selector1 = By.SizzleSelector("div");
            var selector2 = new object();

#pragma warning disable 252,253
            Assert.False(selector1 == selector2);
            Assert.True(selector1 != selector2);
#pragma warning restore 252,253
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingNestedSelectorWithNull()
        {
            var selector = new SizzleSelector("div");
            
            Assert.Throws<ArgumentNullException>(() => selector.Create(null));
        }
    }
}
