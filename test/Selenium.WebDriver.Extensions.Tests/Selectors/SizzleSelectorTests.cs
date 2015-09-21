namespace OpenQA.Selenium.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Moq;
    using OpenQA.Selenium.Extensions;
    using OpenQA.Selenium.Internal;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class SizzleSelectorTests
    {
        [Fact]
        public void ShouldCreateSizzleSelector()
        {
            // Given
            // When
            var selector = By.SizzleSelector("div");

            // Then
            Assert.NotNull(selector);
            Assert.Equal("div", selector.RawSelector);
        }

        [Fact]
        public void ShouldCreateSizzleSelectorDirectly()
        {
            // Given
            // When
            var selector = new SizzleSelector("div");

            // Then
            Assert.NotNull(selector);
            Assert.Equal("div", selector.RawSelector);
        }

        [Fact]
        public void ShouldCreateSizzleSelectorWithContext()
        {
            // Given
            var context = By.SizzleSelector("body");

            // When
            var selector = By.SizzleSelector("div", context);

            // Then
            Assert.NotNull(selector);
            Assert.Equal("div", selector.RawSelector);
            Assert.Equal("body", selector.Context.RawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithNullValue()
        {
            // Given
            // When
            Action action = () => By.SizzleSelector(null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithEmptyValue()
        {
            // Given
            // When
            Action action = () => By.SizzleSelector(string.Empty);

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithWhiteSpaceOnlyValue()
        {
            // Given
            // When
            Action action = () => By.SizzleSelector(" ");

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldFindElementBySizzleSelector()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });
            var selector = By.SizzleSelector("div");

            // When
            var result = selector.FindElement(driverMock.Object);

            // Then
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFindElementsBySizzleSelector()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object, new Mock<IWebElement>().Object });
            var selector = By.SizzleSelector("div");

            // When
            var result = selector.FindElements(driverMock.Object);

            // Then
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void ShouldThrowExceptionWhenElementIsNotFoundWithSizzleSelector()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement>());
            var selector = By.SizzleSelector("div");

            // When
            Action action = () => selector.FindElement(driverMock.Object);

            // Then
            Assert.Throws<NoSuchElementException>(action);
        }

        [Fact]
        public void ShouldReturnEmptyResultWhenNoElementsAreFoundWithSizzleSelector()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement>());
            var selector = By.SizzleSelector("div");

            // When
            var result = selector.FindElements(driverMock.Object);

            // Then
            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void ShouldFindElementWithNestedSizzleSelector()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("function(element)")), It.IsAny<object[]>()))
                .Returns("body > div");
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("body > div")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });

            var elementMock = new Mock<ISearchContext>();
            elementMock.As<IWrapsDriver>().SetupGet(x => x.WrappedDriver).Returns(driverMock.Object);
            elementMock.As<IWebElement>();

            var selector = By.SizzleSelector("div");

            // When
            var result = selector.FindElement(elementMock.Object);

            // Then
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldThrowExceptionWhenSearchContextIsNotWebElement()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("function(element)")), It.IsAny<object[]>()))
                .Returns("body > div");
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });
            driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('body > div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });

            var elementMock = new Mock<ISearchContext>();
            elementMock.As<IWrapsDriver>().SetupGet(x => x.WrappedDriver).Returns(driverMock.Object);

            var selector = By.SizzleSelector("div");

            // When
            Action action = () => selector.FindElement(elementMock.Object);

            // Then
            Assert.Throws<NotSupportedException>(action);
        }

        [Fact]
        public void ShouldThrowExceptionWhenSearchContextDoesNotWrapDriver()
        {
            // Given
            var elementMock = new Mock<ISearchContext>();
            elementMock.As<IWebElement>();

            var selector = By.SizzleSelector("div");

            // When
            Action action = () => selector.FindElement(elementMock.Object);

            // Then
            Assert.Throws<NotSupportedException>(action);
        }
    }
}
