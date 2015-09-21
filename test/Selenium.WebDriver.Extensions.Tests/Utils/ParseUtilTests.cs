namespace OpenQA.Selenium.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Util")]
    public class ParseUtilTests
    {
        [Fact]
        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        public void ShouldCorrectlyHandleDefaultValue()
        {
            // Given
            object rawResult = null;

            // When
            var result = ParseUtil.ParseResult<bool>(rawResult);

            // Then
            Assert.False(result);
        }

        [Fact]
        public void ShouldCorrectlyHandleDoubleValue()
        {
            // Given
            const double RawResult = 1.23d;

            // When
            var result = ParseUtil.ParseResult<long>(RawResult);

            // Then
            Assert.IsType<long>(result);
        }

        [Fact]
        public void ShouldCorrectlyHandleCollections()
        {
            // Given
            var rawResult = new ReadOnlyCollection<object>(new List<object>());

            // When
            var result = ParseUtil.ParseResult<IEnumerable<IWebElement>>(rawResult);

            // Then
            Assert.NotNull(result);
        }
    }
}
