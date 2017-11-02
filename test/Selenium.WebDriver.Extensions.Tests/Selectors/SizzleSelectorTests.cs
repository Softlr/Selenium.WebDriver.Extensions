namespace Selenium.WebDriver.Extensions.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using OpenQA.Selenium;
    using Ploeh.AutoFixture.Xunit2;
    using Selenium.WebDriver.Extensions;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.By;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class SizzleSelectorTests
    {
        [Theory]
        [AutoData]
        public void ShouldCreateSizzleSelector(string rawSelector)
        {
            var selector = By.SizzleSelector(rawSelector);

            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be(rawSelector);
        }

        [Theory]
        [AutoData]
        public void ShouldCreateSizzleSelectorDirectly(string rawSelector)
        {
            var selector = new SizzleSelector(rawSelector);

            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be(rawSelector);
        }

        [Theory]
        [AutoData]
        public void ShouldCreateSizzleSelectorWithContext(string contextRawSelector, string rawSelector)
        {
            var context = By.SizzleSelector(contextRawSelector);

            var selector = By.SizzleSelector(rawSelector, context);

            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be(rawSelector);
            selector.Context.RawSelector.Should().Be(contextRawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithNullValue()
        {
            Action action = () => By.SizzleSelector(null);

            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithEmptyValue()
        {
            Action action = () => By.SizzleSelector(string.Empty);

            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithWhiteSpaceOnlyValue()
        {
            Action action = () => By.SizzleSelector(" ");

            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("selector");
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementBySizzleSelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementLocatedBySizzle(rawSelector)
                .Build();
            var selector = By.SizzleSelector(rawSelector);

            var result = selector.FindElement(driver);

            result.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementsBySizzleSelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementsLocatedBySizzle(rawSelector)
                .Build();
            var selector = By.SizzleSelector(rawSelector);

            var result = selector.FindElements(driver);

            result.Should().NotBeNull().And.HaveCount(2);
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenElementIsNotFoundWithSizzleSelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatDoesNotContainElementLocatedBySizzle(rawSelector)
                .Build();
            var selector = By.SizzleSelector(rawSelector);

            Action action = () => selector.FindElement(driver);

            action.ShouldThrow<NoSuchElementException>();
        }

        [Theory]
        [AutoData]
        public void ShouldReturnEmptyResultWhenNoElementsAreFoundWithSizzleSelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatDoesNotContainElementLocatedBySizzle(rawSelector)
                .Build();
            var selector = By.SizzleSelector(rawSelector);

            var result = selector.FindElements(driver);

            result.Should().NotBeNull().And.HaveCount(0);
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementWithNestedSizzleSelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementLocatedBySizzle(rawSelector)
                .ThatContainsElementLocatedBySizzle($"body > {rawSelector}").ThatCanResolvePathToElement(rawSelector)
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).ThatIsWebElement().Build();

            var selector = By.SizzleSelector(rawSelector);

            var result = selector.FindElement(element);

            result.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenSearchContextIsNotWebElement(string rawSelector)
        {
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementLocatedBySizzle(rawSelector)
                .ThatContainsElementLocatedBySizzle($"body > {rawSelector}").ThatCanResolvePathToElement(rawSelector)
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).Build();

            var selector = By.SizzleSelector(rawSelector);

            Action action = () => selector.FindElement(element);

            action.ShouldThrow<NotSupportedException>();
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenSearchContextDoesNotWrapDriver(string rawSelector)
        {
            var element = new SearchContextBuilder().ThatIsWebElement().Build();

            var selector = By.SizzleSelector(rawSelector);

            Action action = () => selector.FindElement(element);

            action.ShouldThrow<NotSupportedException>();
        }
    }
}