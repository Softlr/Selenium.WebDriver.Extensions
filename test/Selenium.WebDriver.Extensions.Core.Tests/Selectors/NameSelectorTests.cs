namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System.Collections.Generic;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.Core.By;

    [Trait("Category", "Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class NameSelectorTests
    {
        public static IEnumerable<object[]> EqualityData
        {
            get
            {
                yield return new object[] { By.Name("test"), By.Name("test"), true };
                yield return new object[] { By.Name("test"), By.Name("test2"), false };
                yield return new object[] { By.Name("test"), null, false };
                yield return new object[] { null, By.Name("test"), false };
            }
        }

        [Theory]
        [PropertyData("EqualityData")]
        public void ShouldProperlyCompareSelectors(NameSelector selector1, NameSelector selector2, bool expectedResult)
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
            var selector = new NameSelector("test");

            Assert.Equal(typeof(QuerySelectorRunner), selector.RunnerType);
        }
    }
}
