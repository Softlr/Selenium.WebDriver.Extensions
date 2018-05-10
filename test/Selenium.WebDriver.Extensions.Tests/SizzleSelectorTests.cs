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
    using By = Selenium.WebDriver.Extensions.By;

    [Trait(Trait.Name.CATEGORY, Trait.Category.UNIT)]
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
            var context = By.SizzleSelector(contextRawSelector);
            var sut = By.SizzleSelector(rawSelector, context);

            sut.Should().NotBeNull();
            sut.RawSelector.Should().Be(rawSelector);
            sut.Context.RawSelector.Should().Be(contextRawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithNullValue()
        {
            void Action() => By.SizzleSelector(null);

            ((Action)Action).Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithEmptyValue()
        {
            void Action() => By.SizzleSelector(string.Empty);

            ((Action)Action).Should().Throw<ArgumentException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithWhiteSpaceOnlyValue()
        {
            void Action() => By.SizzleSelector(" ");

            ((Action)Action).Should().Throw<ArgumentException>().And.ParamName.Should().Be("selector");
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
        public void ShouldThrowExceptionWhenElementIsNotFoundWithSizzleSelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithNoElementLocatedBySizzle(rawSelector)
                .Build();
            var sut = By.SizzleSelector(rawSelector);

            void Action() => sut.FindElement(driver);

            ((Action)Action).Should().Throw<NoSuchElementException>();
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
        public void ShouldThrowExceptionWhenSearchContextIsNotWebElement(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithSizzleLoaded().WithElementLocatedBySizzle(rawSelector)
                .WithElementLocatedBySizzle($"body > {rawSelector}").WithPathToElement(rawSelector)
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).Build();
            var sut = By.SizzleSelector(rawSelector);

            void Action() => sut.FindElement(element);

            ((Action)Action).Should().Throw<NotSupportedException>();
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenSearchContextDoesNotWrapDriver(string rawSelector)
        {
            var element = new SearchContextBuilder().AsWebElement().Build();
            var sut = By.SizzleSelector(rawSelector);

            void Action() => sut.FindElement(element);

            ((Action)Action).Should().Throw<InvalidCastException>();
        }
    }
}