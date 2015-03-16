namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.Core.By;

    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class CssSelectorTests
    {
        public static IEnumerable<object[]> EqualityData
        {
            get
            {
                yield return new object[] { By.CssSelector("div"), By.CssSelector("div"), true };
                yield return new object[] { By.CssSelector("test"), By.CssSelector("span"), false };
                yield return new object[] { By.CssSelector("test"), null, false };
                yield return new object[] { null, By.CssSelector("test"), false };
            }
        }

        [Theory]
        [PropertyData("EqualityData")]
        public void ShouldProperlyCompareSelectors(CssSelector selector1, CssSelector selector2, bool expectedResult)
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
            var selector = new CssSelector("test");

            Assert.Equal(typeof(QuerySelectorRunner), selector.RunnerType);
        }
    }
}
