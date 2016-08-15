namespace OpenQA.Selenium.Tests.Extensions
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using OpenQA.Selenium.Extensions;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class StringExtensionsTests
    {
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
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
        [MemberData(nameof(TestData))]
        [SuppressMessage("ReSharper", "InvokeAsExtensionMethod")]
        public void ShouldDetectNullsAndWhiteSpaces(string testValue, bool expected)
        {
            // Given
            // When
            var result = StringExtensions.IsNullOrWhiteSpace(testValue);

            // Then
            result.Should().Be(expected);
        }
    }
}
