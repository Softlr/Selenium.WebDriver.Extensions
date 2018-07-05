namespace Selenium.WebDriver.Extensions.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using Xunit;
    using static Selenium.WebDriver.Extensions.Tests.Shared.Trait;
    using static System.String;
    using By = Selenium.WebDriver.Extensions.By;

    [Trait(CATEGORY, UNIT)]
    [ExcludeFromCodeCoverage]
    public class SizzleSelectorTests
    {
        [Theory]
        [AutoData]
        public void ShouldCreateSizzleSelector(string rawSelector)
        {
            var sut = By.SizzleSelector(rawSelector);

            sut.Should().NotBeNull();
            sut.RawSelector.Should().Be(rawSelector);
        }

        [Theory]
        [AutoData]
        public void ShouldCreateSizzleSelectorDirectly(string rawSelector)
        {
            var sut = new SizzleSelector(rawSelector);

            sut.Should().NotBeNull();
            sut.RawSelector.Should().Be(rawSelector);
        }

        [Theory]
        [AutoData]
        public void ShouldCreateSizzleSelectorWithContext(string contextRawSelector, string rawSelector)
        {
            var sut = By.SizzleSelector(rawSelector, By.SizzleSelector(contextRawSelector));

            sut.Should().NotBeNull();
            sut.RawSelector.Should().Be(rawSelector);
            sut.Context.RawSelector.Should().Be(contextRawSelector);
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementBySizzleSelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithElementLocatedBySizzle(rawSelector)
                .Build();
            var selector = By.SizzleSelector(rawSelector);
            var sut = selector.FindElement(driver);

            sut.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementsBySizzleSelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithElementsLocatedBySizzle(rawSelector)
                .Build();
            var selector = By.SizzleSelector(rawSelector);
            var sut = selector.FindElements(driver);

            sut.Should().NotBeNull().And.HaveCount(2);
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementWithNestedSizzleSelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithElementLocatedBySizzle(rawSelector)
                .WithElementLocatedBySizzle($"body > {rawSelector}").WithPathToElement(rawSelector)
                .Build();
            var element = new SearchContextBuilder().AsWebElement().WithWrappedDriver(driver).Build();
            var sut = By.SizzleSelector(rawSelector);
            var result = sut.FindElement(element);

            result.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void ShouldReturnEmptyResultWhenNoElementsAreFoundWithSizzleSelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithNoElementLocatedBySizzle(rawSelector)
                .Build();
            var sut = By.SizzleSelector(rawSelector);
            var result = sut.FindElements(driver);

            result.Should().NotBeNull().And.HaveCount(0);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithEmptyValue() =>
            ((Action)(() => By.SizzleSelector(Empty))).Should().Throw<ArgumentException>()
            .And.ParamName.Should().Be("selector");

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithNullValue() =>
            ((Action)(() => By.SizzleSelector(null))).Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("selector");

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithWhiteSpaceOnlyValue() =>
            ((Action)(() => By.SizzleSelector(" "))).Should().Throw<ArgumentException>()
            .And.ParamName.Should().Be("selector");

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenElementIsNotFoundWithSizzleSelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithNoElementLocatedBySizzle(rawSelector)
                .Build();
            var sut = By.SizzleSelector(rawSelector);

            ((Action)(() => sut.FindElement(driver))).Should().Throw<NoSuchElementException>();
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenSearchContextDoesNotWrapDriver(string rawSelector)
        {
            var element = new SearchContextBuilder().AsWebElement().Build();
            var sut = By.SizzleSelector(rawSelector);

            ((Action)(() => sut.FindElement(element))).Should().Throw<InvalidCastException>();
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenSearchContextIsNotWebElement(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithElementLocatedBySizzle(rawSelector)
                .WithElementLocatedBySizzle($"body > {rawSelector}").WithPathToElement(rawSelector)
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).Build();
            var sut = By.SizzleSelector(rawSelector);

            ((Action)(() => sut.FindElement(element))).Should().Throw<NotSupportedException>();
        }
    }
}
