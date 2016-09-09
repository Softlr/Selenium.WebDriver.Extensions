namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class SelectorBaseTests
    {
        [Fact]
        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        public void ShouldCorrectlyHandleDefaultValue()
        {
            // Arrange
            object rawResult = null;

            // Act
            var result = SelectorBase<JQuerySelector>.ParseResult<bool>(rawResult);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldCorrectlyHandleDoubleValue()
        {
            // Arrange
            const double rawResult = 1.23d;

            // Act
            var result = SelectorBase<JQuerySelector>.ParseResult<long>(rawResult);

            // Assert
            result.GetType().Should().Be(typeof(long));
        }

        [Fact]
        public void ShouldCorrectlyHandleCollections()
        {
            // Arrange
            var rawResult = new ReadOnlyCollection<object>(new List<object>());

            // Act
            var result = SelectorBase<JQuerySelector>.ParseResult<IEnumerable<IWebElement>>(rawResult);

            // Assert
            result.Should().NotBeNull();
        }
    }
}