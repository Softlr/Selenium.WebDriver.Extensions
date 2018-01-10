namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class SelectorBaseTests
    {
        [Fact]
        public void ShouldCorrectlyHandleDefaultValue()
        {
            const object rawResult = null;

            var result = SelectorBase<JQuerySelector>.ParseResult<bool>(rawResult);

            result.Should().BeFalse();
        }

        [Theory]
        [AutoData]
        public void ShouldCorrectlyHandleDoubleValue(double rawResult)
        {
            var result = SelectorBase<JQuerySelector>.ParseResult<long>(rawResult);

            result.GetType().Should().Be(typeof(long));
        }

        [Theory]
        [AutoData]
        public void ShouldCorrectlyHandleCollections(ReadOnlyCollection<object> rawResult)
        {
            var result = SelectorBase<JQuerySelector>.ParseResult<IEnumerable<IWebElement>>(rawResult);

            result.Should().NotBeNull();
        }
    }
}