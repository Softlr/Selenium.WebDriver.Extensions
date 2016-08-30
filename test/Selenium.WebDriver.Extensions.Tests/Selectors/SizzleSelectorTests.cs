namespace OpenQA.Selenium.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using Moq;
    using OpenQA.Selenium.Extensions;
    using OpenQA.Selenium.Internal;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class SizzleSelectorTests
    {
        [Fact]
        public void ShouldCreateSizzleSelector()
        {
            // Arrange
            // Act
            var selector = By.SizzleSelector("div");

            // Assert
            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be("div");
        }

        [Fact]
        public void ShouldCreateSizzleSelectorDirectly()
        {
            // Arrange
            // Act
            var selector = new SizzleSelector("div");

            // Assert
            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be("div");
        }

        [Fact]
        public void ShouldCreateSizzleSelectorWithContext()
        {
            // Arrange
            var context = By.SizzleSelector("body");

            // Act
            var selector = By.SizzleSelector("div", context);

            // Assert
            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be("div");
            selector.Context.RawSelector.Should().Be("body");
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

        [Fact]
        public void ShouldFindElementBySizzleSelector()
        {
            // Arrange
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementLocatedBySizzle("div")
                .Build();
            var selector = By.SizzleSelector("div");

            // Act
            var result = selector.FindElement(driver);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void ShouldFindElementsBySizzleSelector()
        {
            // Arrange
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementsLocatedBySizzle("div")
                .Build();
            var selector = By.SizzleSelector("div");

            // Act
            var result = selector.FindElements(driver);

            // Assert
            result.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void ShouldThrowExceptionWhenElementIsNotFoundWithSizzleSelector()
        {
            // Arrange
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatDoesNotContainElementLocatedBySizzle("div")
                .Build();
            var selector = By.SizzleSelector("div");

            // Act
            Action action = () => selector.FindElement(driver);

            // Assert
            action.ShouldThrow<NoSuchElementException>();
        }

        [Fact]
        public void ShouldReturnEmptyResultWhenNoElementsAreFoundWithSizzleSelector()
        {
            // Arrange
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatDoesNotContainElementLocatedBySizzle("div")
                .Build();
            var selector = By.SizzleSelector("div");

            // Act
            var result = selector.FindElements(driver);

            // Assert
            result.Should().NotBeNull().And.HaveCount(0);
        }

        [Fact]
        public void ShouldFindElementWithNestedSizzleSelector()
        {
            // Arrange
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementLocatedBySizzle("div")
                .ThatContainsElementLocatedBySizzle("body > div").ThatCanResolvePathToElement("div")
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).ThatIsWebElement().Build();

            var selector = By.SizzleSelector("div");

            // Act
            var result = selector.FindElement(element);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void ShouldThrowExceptionWhenSearchContextIsNotWebElement()
        {
            // Arrange
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementLocatedBySizzle("div")
                .ThatContainsElementLocatedBySizzle("body > div").ThatCanResolvePathToElement("div")
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).Build();

            var selector = By.SizzleSelector("div");

            // Act
            Action action = () => selector.FindElement(element);

            // Assert
            action.ShouldThrow<NotSupportedException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenSearchContextDoesNotWrapDriver()
        {
            // Arrange
            var element = new SearchContextBuilder().ThatIsWebElement().Build();

            var selector = By.SizzleSelector("div");

            // Act
            Action action = () => selector.FindElement(element);

            // Assert
            action.ShouldThrow<NotSupportedException>();
        }
    }
}
