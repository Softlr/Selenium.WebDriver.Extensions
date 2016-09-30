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
            // Arrange
            // Act
            var selector = By.SizzleSelector(rawSelector);

            // Assert
            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be(rawSelector);
        }

        [Theory]
        [AutoData]
        public void ShouldCreateSizzleSelectorDirectly(string rawSelector)
        {
            // Arrange
            // Act
            var selector = new SizzleSelector(rawSelector);

            // Assert
            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be(rawSelector);
        }

        [Theory]
        [AutoData]
        public void ShouldCreateSizzleSelectorWithContext(string contextRawSelector, string rawSelector)
        {
            // Arrange
            var context = By.SizzleSelector(contextRawSelector);

            // Act
            var selector = By.SizzleSelector(rawSelector, context);

            // Assert
            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be(rawSelector);
            selector.Context.RawSelector.Should().Be(contextRawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithNullValue()
        {
            // Arrange
            // Act
            Action action = () => By.SizzleSelector(null);

            // Assert
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithEmptyValue()
        {
            // Arrange
            // Act
            Action action = () => By.SizzleSelector(string.Empty);

            // Assert
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithWhiteSpaceOnlyValue()
        {
            // Arrange
            // Act
            Action action = () => By.SizzleSelector(" ");

            // Assert
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("selector");
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementBySizzleSelector(string rawSelector)
        {
            // Arrange
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementLocatedBySizzle(rawSelector)
                .Build();
            var selector = By.SizzleSelector(rawSelector);

            // Act
            var result = selector.FindElement(driver);

            // Assert
            result.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementsBySizzleSelector(string rawSelector)
        {
            // Arrange
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementsLocatedBySizzle(rawSelector)
                .Build();
            var selector = By.SizzleSelector(rawSelector);

            // Act
            var result = selector.FindElements(driver);

            // Assert
            result.Should().NotBeNull().And.HaveCount(2);
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenElementIsNotFoundWithSizzleSelector(string rawSelector)
        {
            // Arrange
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatDoesNotContainElementLocatedBySizzle(rawSelector)
                .Build();
            var selector = By.SizzleSelector(rawSelector);

            // Act
            Action action = () => selector.FindElement(driver);

            // Assert
            action.ShouldThrow<NoSuchElementException>();
        }

        [Theory]
        [AutoData]
        public void ShouldReturnEmptyResultWhenNoElementsAreFoundWithSizzleSelector(string rawSelector)
        {
            // Arrange
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatDoesNotContainElementLocatedBySizzle(rawSelector)
                .Build();
            var selector = By.SizzleSelector(rawSelector);

            // Act
            var result = selector.FindElements(driver);

            // Assert
            result.Should().NotBeNull().And.HaveCount(0);
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementWithNestedSizzleSelector(string rawSelector)
        {
            // Arrange
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementLocatedBySizzle(rawSelector)
                .ThatContainsElementLocatedBySizzle($"body > {rawSelector}").ThatCanResolvePathToElement(rawSelector)
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).ThatIsWebElement().Build();

            var selector = By.SizzleSelector(rawSelector);

            // Act
            var result = selector.FindElement(element);

            // Assert
            result.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenSearchContextIsNotWebElement(string rawSelector)
        {
            // Arrange
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementLocatedBySizzle(rawSelector)
                .ThatContainsElementLocatedBySizzle($"body > {rawSelector}").ThatCanResolvePathToElement(rawSelector)
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).Build();

            var selector = By.SizzleSelector(rawSelector);

            // Act
            Action action = () => selector.FindElement(element);

            // Assert
            action.ShouldThrow<NotSupportedException>();
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenSearchContextDoesNotWrapDriver(string rawSelector)
        {
            // Arrange
            var element = new SearchContextBuilder().ThatIsWebElement().Build();

            var selector = By.SizzleSelector(rawSelector);

            // Act
            Action action = () => selector.FindElement(element);

            // Assert
            action.ShouldThrow<NotSupportedException>();
        }
    }
}
