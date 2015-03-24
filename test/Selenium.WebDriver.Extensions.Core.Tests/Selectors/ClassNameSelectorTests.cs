namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System.Collections.Generic;
    using Selenium.WebDriver.Extensions.Core;
    using Xunit;
    using Xunit.Extensions;
    using By = Selenium.WebDriver.Extensions.Core.By;

    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class ClassNameSelectorTests
    {
        public static IEnumerable<object[]> EqualityData
        {
            get
            {
                yield return new object[] { By.ClassName("test"), By.ClassName("test"), true };
                yield return new object[] { By.ClassName("test"), By.ClassName("test2"), false };
                yield return new object[] { By.ClassName("test"), null, false };
                yield return new object[] { null, By.ClassName("test"), false };
            }
        }

        public static IEnumerable<object[]> QuerySelectorEqualityData
        {
            get
            {
                yield return new object[]
                                 {
                                     By.QuerySelector("div", By.ClassName("div")), 
                                     By.QuerySelector("div", By.QuerySelector("div")),
                                     false
                                 };
            }
        }

        [Theory]
        [MemberData("EqualityData")]
        public void ShouldProperlyCompareSelectors(
            ClassNameSelector selector1, 
            ClassNameSelector selector2, 
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

        [Theory]
        [MemberData("QuerySelectorEqualityData")]
        public void ShouldProperlyCompareQuerySelectors(
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
        public void ShouldHaveProperRunnerType()
        {
            var selector = new ClassNameSelector("test");

            Assert.Equal(typeof(QuerySelectorRunner), selector.RunnerType);
        }
    }
}
