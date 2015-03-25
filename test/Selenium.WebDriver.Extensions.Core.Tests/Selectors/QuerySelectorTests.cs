namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    // ReSharper disable ExceptionNotDocumented
    // ReSharper disable ExceptionNotDocumentedOptional
    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class QuerySelectorTests
    {
        public static IEnumerable<object[]> SelectorData
        {
            get
            {
                yield return new object[] { By.QuerySelector("div"), "document.querySelectorAll('div')" };
                yield return new object[]
                                 {
                                     By.QuerySelector("input[type='text']"), 
                                     "document.querySelectorAll('input[type=\"text\"]')"
                                 };
                yield return new object[]
                                 {
                                     By.QuerySelector("div", "document.body"),
                                     "document.body.querySelectorAll('div')"
                                 };
                yield return new object[]
                                 {
                                     By.QuerySelector("span", By.QuerySelector("div")), 
                                     "document.querySelectorAll('div').length === 0 ? [] : document.querySelectorAll('div')[0].querySelectorAll('span')"
                                 };
            }
        }

        public static IEnumerable<object[]> EqualityData
        {
            get
            {
                yield return new object[] { By.QuerySelector("div"), By.QuerySelector("div"), true };
                yield return new object[] { By.QuerySelector("div"), By.QuerySelector("span"), false };
                yield return new object[] { By.QuerySelector("div"), null, false };
                yield return new object[] { null, By.QuerySelector("div"), false };
                yield return new object[] { By.QuerySelector("div", By.QuerySelector("body")), By.QuerySelector("div"), false };
                yield return new object[] { By.QuerySelector("div", By.QuerySelector("body")), By.QuerySelector("div", By.QuerySelector("body")), true };
                yield return new object[] { By.QuerySelector("div", "body"), By.QuerySelector("div", By.QuerySelector("body")), false };
                yield return new object[] { By.QuerySelector("div", By.QuerySelector("body")), By.QuerySelector("div", "body"), false };
                yield return new object[] { By.QuerySelector("div", By.QuerySelector("body")), By.QuerySelector("div", By.QuerySelector("div")), false };
            }
        }

        [Theory]
        [MemberData("SelectorData")]
        public void ShouldGenerateCorrectSelector(QuerySelector selector, string expectedResult)
        {
            Assert.Equal(selector.Selector, selector.ToString());
            Assert.Equal(expectedResult, selector.Selector);
        }

        [Fact]
        public void ShouldPopulateFormatStringProperty()
        {
            var formatString = By.QuerySelector("div").CallFormatString;
            Assert.NotNull(formatString);
        }

        [Theory]
        [MemberData("EqualityData")]
        public void ShouldProperlyCompareSelectors(
            QuerySelector selector1,
            QuerySelector selector2, 
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
            var selector1 = By.QuerySelector("div");
            var selector2 = new object();

#pragma warning disable 252,253
            Assert.False(selector1 == selector2);
            Assert.True(selector1 != selector2);
#pragma warning restore 252,253
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingNestedSelectorWithNull()
        {
            var selector = new QuerySelector("div");

            var ex = Assert.Throws<ArgumentNullException>(() => selector.Create(null));
            Assert.Equal("root", ex.ParamName);
        }
    }
}
