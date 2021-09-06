namespace Selenium.WebDriver.Extensions.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using OpenQA.Selenium;
    using Xunit;
    using static System.String;
    using static By;
    using static Shared.Trait;

    [Trait(CATEGORY, UNIT)]
    [ExcludeFromCodeCoverage]
    public class SizzleSelectorTests
    {
        [Theory]
        [AutoData]
        public void Context_without_wrapped_driver_throws_exception(string rawSelector)
        {
            var element = new SearchContextBuilder().AsWebElement().Build();
            var sut = SizzleSelector(rawSelector);

            FluentActions.Invoking(() => sut.FindElement(element)).Should().Throw<InvalidCastException>();
        }

        [Theory]
        [AutoData]
        public void Creating_selector_directly_sets_correct_property_values(string rawSelector)
        {
            var sut = new SizzleSelector(rawSelector);

            sut.Should().NotBeNull();
            sut.RawSelector.Should().Be(rawSelector);
        }

        [Theory]
        [AutoData]
        public void Creating_selector_sets_correct_property_values(string rawSelector)
        {
            var sut = SizzleSelector(rawSelector);

            sut.Should().NotBeNull();
            sut.RawSelector.Should().Be(rawSelector);
        }

        [Theory]
        [AutoData]
        public void Creating_selector_with_context_sets_correct_property_values(
            string contextRawSelector, string rawSelector)
        {
            var sut = SizzleSelector(rawSelector, SizzleSelector(contextRawSelector));

            sut.Should().NotBeNull();
            sut.RawSelector.Should().Be(rawSelector);
            sut.Context.RawSelector.Should().Be(contextRawSelector);
        }

        [Fact]
        public void Creating_selector_with_empty_value_is_invalid() =>
            FluentActions.Invoking(() => SizzleSelector(Empty)).Should().Throw<ArgumentException>().And.ParamName
                .Should().Be("selector");

        [Fact]
        public void Creating_selector_with_null_value_is_invalid() =>
            FluentActions.Invoking(() => SizzleSelector(null)).Should().Throw<ArgumentNullException>().And.ParamName
                .Should().Be("selector");

        [Fact]
        public void Creating_selector_with_whitespace_value_is_invalid() =>
            FluentActions.Invoking(() => SizzleSelector(" ")).Should().Throw<ArgumentException>().And.ParamName
                .Should().Be("selector");

        [Theory]
        [AutoData]
        public void Nested_selector_finds_element(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithElementLocatedBySizzle(rawSelector)
                .WithElementLocatedBySizzle($"body > {rawSelector}").WithPathToElement(rawSelector).Build();
            var element = new SearchContextBuilder().AsWebElement().WithWrappedDriver(driver).Build();
            var sut = SizzleSelector(rawSelector);
            var result = sut.FindElement(element);

            result.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void Non_web_element_throws_exception(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithElementLocatedBySizzle(rawSelector)
                .WithElementLocatedBySizzle($"body > {rawSelector}").WithPathToElement(rawSelector).Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).Build();
            var sut = SizzleSelector(rawSelector);

            FluentActions.Invoking(() => sut.FindElement(element)).Should().Throw<NotSupportedException>();
        }

        [Theory]
        [AutoData]
        public void Not_found_element_throws_exception(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithNoElementLocatedBySizzle(rawSelector).Build();
            var sut = SizzleSelector(rawSelector);

            FluentActions.Invoking(() => sut.FindElement(driver)).Should().Throw<NoSuchElementException>();
        }

        [Theory]
        [AutoData]
        public void Selector_does_not_find_non_matching_elements(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithNoElementLocatedBySizzle(rawSelector).Build();
            var sut = SizzleSelector(rawSelector);
            var result = sut.FindElements(driver);

            result.Should().NotBeNull().And.HaveCount(0);
        }

        [Theory]
        [AutoData]
        public void Selector_finds_element(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithElementLocatedBySizzle(rawSelector).Build();
            var selector = SizzleSelector(rawSelector);
            var sut = selector.FindElement(driver);

            sut.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void Selector_finds_elements(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithElementsLocatedBySizzle(rawSelector).Build();
            var selector = SizzleSelector(rawSelector);
            var sut = selector.FindElements(driver);

            sut.Should().NotBeNull().And.HaveCount(2);
        }
    }
}
