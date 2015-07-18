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
            var ex = Assert.Throws<ArgumentNullException>(() => By.SizzleSelector(null));

            // Then
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithEmptyValue()
        {
            // Given
            // When
            var ex = Assert.Throws<ArgumentException>(() => By.SizzleSelector(string.Empty));

            // Then
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingSizzleSelectorWithWhiteSpaceOnlyValue()
        {
            // Given
            // When
            var ex = Assert.Throws<ArgumentException>(() => By.SizzleSelector(" "));

            // Then
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldFindElementBySizzleSelector()
        {
            // Given
            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });
            var selector = By.SizzleSelector("div");

            // When
            var result = selector.FindElement(driver.Object);

            // Then
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldFindElementsBySizzleSelector()
        {
            // Given
            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object, new Mock<IWebElement>().Object });
            var selector = By.SizzleSelector("div");

            // When
            var result = selector.FindElements(driver.Object);

            // Then
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void ShouldThrowExceptionWhenElementIsNotFoundWithSizzleSelector()
        {
            // Given
            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement>());
            var selector = By.SizzleSelector("div");

            // When
            Assert.Throws<NoSuchElementException>(() => selector.FindElement(driver.Object));

            // Then
        }

        [Fact]
        public void ShouldReturnEmptyResultWhenNoElementsAreFoundWithSizzleSelector()
        {
            // Given
            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement>());
            var selector = By.SizzleSelector("div");

            // When
            var result = selector.FindElements(driver.Object);

            // Then
            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void ShouldFindElementWithNestedSizzleSelector()
        {
            // Given
            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("function(element)")), It.IsAny<object[]>()))
                .Returns("body > div");
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('body > div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });

            var element = new Mock<ISearchContext>();
            element.As<IWrapsDriver>().SetupGet(x => x.WrappedDriver).Returns(driver.Object);
            element.As<IWebElement>();

            var selector = By.SizzleSelector("div");

            // When
            var result = selector.FindElement(element.Object);

            // Then
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldThrowExceptionWhenSearchContextIsNotWebElement()
        {
            // Given
            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("window.Sizzle")), It.IsAny<object[]>()))
                .Returns(true);
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("function(element)")), It.IsAny<object[]>()))
                .Returns("body > div");
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.Is<string>(s => s.Contains("Sizzle('body > div')")), It.IsAny<object[]>()))
                .Returns(new List<IWebElement> { new Mock<IWebElement>().Object });

            var element = new Mock<ISearchContext>();
            element.As<IWrapsDriver>().SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var selector = By.SizzleSelector("div");

            // When
            // Then
            Assert.Throws<NotSupportedException>(() => selector.FindElement(element.Object));
        }

        [Fact]
        public void ShouldThrowExceptionWhenSearchContextDoesNotWrapDriver()
        {
            // Given
            var element = new Mock<ISearchContext>();
            element.As<IWebElement>();

            var selector = By.SizzleSelector("div");

            // When
            // Then
            Assert.Throws<NotSupportedException>(() => selector.FindElement(element.Object));
        }
    }
}
