namespace OpenQA.Selenium.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class SelectorBaseTests
    {
        [Fact]
        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        public void ShouldCorrectlyHandleDefaultValue()
        {
            // Given
            object rawResult = null;

            // When
            var result = SelectorBase<JQuerySelector>.ParseResult<bool>(rawResult);

            // Then
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldCorrectlyHandleDoubleValue()
        {
            // Given
            const double RawResult = 1.23d;

            // When
            var result = SelectorBase<JQuerySelector>.ParseResult<long>(RawResult);

            // Then
            result.GetType().Should().Be(typeof(long));
        }

        [Fact]
        public void ShouldCorrectlyHandleCollections()
        {
            // Given
            var rawResult = new ReadOnlyCollection<object>(new List<object>());

            // When
            var result = SelectorBase<JQuerySelector>.ParseResult<IEnumerable<IWebElement>>(rawResult);

            // Then
            result.Should().NotBeNull();
        }
    }
}