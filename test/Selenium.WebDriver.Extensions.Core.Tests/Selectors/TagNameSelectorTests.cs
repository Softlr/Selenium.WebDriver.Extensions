namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System.Collections.Generic;
    using Xunit;
    using Xunit.Extensions;
    using By = Selenium.WebDriver.Extensions.Core.By;

    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class TagNameSelectorTests
    {
        public static IEnumerable<object[]> EqualityData
        {
            get
            {
                yield return new object[] { By.TagName("div"), By.TagName("div"), true };
                yield return new object[] { By.TagName("div"), By.TagName("span"), false };
                yield return new object[] { By.TagName("div"), null, false };
                yield return new object[] { null, By.TagName("div"), false };
            }
        }

        [Theory]
        [PropertyData("EqualityData")]
        public void ShouldProperlyCompareSelectors(
            TagNameSelector selector1,
            TagNameSelector selector2, 
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
        public void ShouldHaveProperRunnerType()
        {
            var selector = new TagNameSelector("test");

            Assert.Equal(typeof(QuerySelectorRunner), selector.RunnerType);
        }
    }
}
