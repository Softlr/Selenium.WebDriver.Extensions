namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using OpenQA.Selenium;
    using Xunit;
    using static Shared.Trait;

    [Trait(CATEGORY, UNIT)]
    [ExcludeFromCodeCoverage]
    public class SelectorBaseTests
    {
        [Theory]
        [AutoData]
        public void Selector_handled_collection_results(ReadOnlyCollection<object> rawResult)
        {
            var sut = SelectorBase<JQuerySelector>.ParseResult<IEnumerable<IWebElement>>(rawResult);

            sut.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void Selector_handles_double_result(double rawResult)
        {
            var sut = SelectorBase<JQuerySelector>.ParseResult<long>(rawResult);

            sut.GetType().Should().Be(typeof(long));
        }

        [Fact]
        public void Selector_parses_default_value()
        {
            const object rawResult = null;
            var sut = SelectorBase<JQuerySelector>.ParseResult<bool>(rawResult);

            sut.Should().BeFalse();
        }
    }
}
