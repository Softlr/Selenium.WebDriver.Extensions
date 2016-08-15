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
            // Given
            // When
            var selector = By.SizzleSelector("div");

            // Then
            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be("div");
        }

        [Fact]
        public void ShouldCreateSizzleSelectorDirectly()
        {
            // Given
            // When
            var selector = new SizzleSelector("div");

            // Then
            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be("div");
        }

        [Fact]
        public void ShouldCreateSizzleSelectorWithContext()
        {
            // Given
            var context = By.SizzleSelector("body");

            // When
            var selector = By.SizzleSelector("div", context);

            // Then
            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be("div");
            selector.Context.RawSelector.Should().Be("body");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithNullValue()
        {
            // Given
            // When
            Action action = () => By.SizzleSelector(null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithEmptyValue()
        {
            // Given
            // When
            Action action = () => By.SizzleSelector(string.Empty);

            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithWhiteSpaceOnlyValue()
        {
            // Given
            // When
            Action action = () => By.SizzleSelector(" ");

            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldFindElementBySizzleSelector()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementLocatedBySizzle("div")
                .Build();
            var selector = By.SizzleSelector("div");

            // When
            var result = selector.FindElement(driver);

            // Then
            result.Should().NotBeNull();
        }

        [Fact]
        public void ShouldFindElementsBySizzleSelector()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementsLocatedBySizzle("div")
                .Build();
            var selector = By.SizzleSelector("div");

            // When
            var result = selector.FindElements(driver);

            // Then
            result.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void ShouldThrowExceptionWhenElementIsNotFoundWithSizzleSelector()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatDoesNotContainElementLocatedBySizzle("div")
                .Build();
            var selector = By.SizzleSelector("div");

            // When
            Action action = () => selector.FindElement(driver);

            // Then
            action.ShouldThrow<NoSuchElementException>();
        }

        [Fact]
        public void ShouldReturnEmptyResultWhenNoElementsAreFoundWithSizzleSelector()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatDoesNotContainElementLocatedBySizzle("div")
                .Build();
            var selector = By.SizzleSelector("div");

            // When
            var result = selector.FindElements(driver);

            // Then
            result.Should().NotBeNull().And.HaveCount(0);
        }

        [Fact]
        public void ShouldFindElementWithNestedSizzleSelector()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementLocatedBySizzle("div")
                .ThatContainsElementLocatedBySizzle("body > div").ThatCanResolvePathToElement("div")
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).ThatIsWebElement().Build();

            var selector = By.SizzleSelector("div");

            // When
            var result = selector.FindElement(element);

            // Then
            result.Should().NotBeNull();
        }

        [Fact]
        public void ShouldThrowExceptionWhenSearchContextIsNotWebElement()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasSizzleLoaded().ThatContainsElementLocatedBySizzle("div")
                .ThatContainsElementLocatedBySizzle("body > div").ThatCanResolvePathToElement("div")
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).Build();

            var selector = By.SizzleSelector("div");

            // When
            Action action = () => selector.FindElement(element);

            // Then
            action.ShouldThrow<NotSupportedException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenSearchContextDoesNotWrapDriver()
        {
            // Given
            var element = new SearchContextBuilder().ThatIsWebElement().Build();

            var selector = By.SizzleSelector("div");

            // When
            Action action = () => selector.FindElement(element);

            // Then
            action.ShouldThrow<NotSupportedException>();
        }

        [Fact]
        public void ShouldGetLibraryUri()
        {
            // Given
            var loader = SizzleSelector.Empty;

            // When
            var uri = loader.LibraryUri;

            // Then
            uri.Should().NotBeNull();
        }
    }
}
