namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System.Collections.Generic;
    using Xunit;
    using Xunit.Extensions;

    public class StringExtensionsTests
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
        [PropertyData("IsNullOrWhiteSpaceData")]
        public void ShouldCorrectlyResolveNullOrWhiteSpaceString(string value, bool expectedResult)
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
