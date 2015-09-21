namespace OpenQA.Selenium.Tests.Extensions
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Extensions;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class StringExtensionsTests
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { null, true };
                yield return new object[] { string.Empty, true };
                yield return new object[] { "\r\n\t", true };
                yield return new object[] { "   a   ", false };
            }
        }

        [Theory]
        [MemberData("TestData")]
        [SuppressMessage("ReSharper", "InvokeAsExtensionMethod")]
        public void ShouldDetectNullsAndWhiteSpaces(string testValue, bool expected)
        {
            // Given
            // When
            var result = StringExtensions.IsNullOrWhiteSpace(testValue);

            // Then
            Assert.Equal(expected, result);
        }
    }
}
