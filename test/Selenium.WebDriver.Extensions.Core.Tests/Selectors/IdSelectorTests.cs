namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using Xunit.Extensions;
    using By = Selenium.WebDriver.Extensions.Core.By;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class IdSelectorTests
    {
        public static IEnumerable<object[]> EqualityData
        {
            get
            {
                yield return new object[] { By.Id("test"), By.Id("test"), true };
                yield return new object[] { By.Id("test"), By.Id("test2"), false };
                yield return new object[] { By.Id("test"), null, false };
                yield return new object[] { null, By.Id("test"), false };
            }
        }

        [Theory]
        [MemberData("EqualityData")]
        public void EqualityOperator(IdSelector selector1, IdSelector selector2, bool expectedResult)
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
            var selector = new IdSelector("test");

            Assert.Equal(typeof(QuerySelectorRunner), selector.RunnerType);
        }
    }
}
