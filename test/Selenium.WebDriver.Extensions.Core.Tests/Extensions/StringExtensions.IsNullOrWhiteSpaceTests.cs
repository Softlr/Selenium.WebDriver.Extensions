namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    
    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class StringExtensionsIsNullOrWhiteSpaceTests
    {
        public static IEnumerable<object[]> IsNullOrWhiteSpaceData
        {
            get
            {
                yield return new object[] { string.Empty, true };
                yield return new object[] { " \t\r\n", true };
                yield return new object[] { " a", false };
                yield return new object[] { "a ", false };
            }
        }

        [Theory]
        [MemberData("IsNullOrWhiteSpaceData")]
        public void ShouldCorrectlyResolveStrings(string value, bool expectedResult)
        {
            Assert.Equal(expectedResult, value.IsNullOrWhiteSpace());
        }

        [Fact]
        public void ShouldHandleNullValueCorrectly()
        {
            Assert.True(StringExtensions.IsNullOrWhiteSpace(null));
        }
    }
}
