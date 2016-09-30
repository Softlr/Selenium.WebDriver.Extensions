namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using OpenQA.Selenium;
    using Ploeh.AutoFixture.Xunit2;
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

        [Theory]
        [AutoData]
        public void ShouldCorrectlyHandleDoubleValue(double rawResult)
        {
            // Arrange
            // Act
            var result = SelectorBase<JQuerySelector>.ParseResult<long>(rawResult);

            // Assert
            result.GetType().Should().Be(typeof(long));
        }

        [Theory]
        [AutoData]
        public void ShouldCorrectlyHandleCollections(ReadOnlyCollection<object> rawResult)
        {
            // Arrange
            // Act
            var result = SelectorBase<JQuerySelector>.ParseResult<IEnumerable<IWebElement>>(rawResult);

            // Assert
            result.Should().NotBeNull();
        }
    }
}