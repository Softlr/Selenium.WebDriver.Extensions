namespace OpenQA.Selenium.Tests.Extensions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Moq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Extensions;
    using OpenQA.Selenium.Loaders;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class WebDriverExtensionsTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenCheckingSelectorPrerequisitesWithNullDriver()
        {
            // Given
            // When
            Action action = () => WebDriverExtensions.CheckSelectorPrerequisites(null, null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("driver", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCheckingSelectorPrerequisitesWithoutLoader()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();

            // When
            Action action = () => driverMock.Object.CheckSelectorPrerequisites(null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("loader", ex.ParamName);
        }

        [Fact]
        public void ShouldLoadExternalLibrary()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsAny<string>())).Returns(true);

            // When
            driverMock.Object.LoadExternalLibrary(
                new JQueryLoader(),
                new Uri("http://example.com"),
                TimeSpan.FromMilliseconds(100));

            // Then
            Assert.True(true);
        }

        [Fact]
        public void ShouldLoadExternalLibraryWithLoaderDetaultUri()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsAny<string>())).Returns(true);

            // When
            driverMock.Object.LoadExternalLibrary(
                new JQueryLoader(),
                null,
                TimeSpan.FromMilliseconds(100));

            // Then
            Assert.True(true);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingExternalLibraryWithNullDriver()
        {
            // Given
            // When
            Action action = () => WebDriverExtensions.LoadExternalLibrary(null, null, null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("driver", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingExternalLibraryWithoutLoader()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();

            // When
            Action action = () => driverMock.Object.LoadExternalLibrary(null, null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("loader", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenExecutingScriptWithNullDriver()
        {
            // Given
            // When
            Action action = () => WebDriverExtensions.ExecuteScript(null, null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("driver", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenExecutingScriptThatExpectsValueWithNullDriver()
        {
            // Given
            // When
            Action action = () => WebDriverExtensions.ExecuteScript<object>(null, null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("driver", ex.ParamName);
        }

        [Fact]
        public void ShouldExecuteScript()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsAny<string>())).Returns("foo");

            // When
            driverMock.Object.ExecuteScript("myMethod();");

            // Then
            Assert.True(true);
        }

        [Fact]
        public void ShouldExecuteScriptThatReturnsValue()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsAny<string>())).Returns("foo");

            // When
            var result = driverMock.Object.ExecuteScript<string>("return 'foo';");

            // Then
            Assert.Equal("foo", result);
        }

        [Fact]
        public void ShouldThrowExceptionWhenExecutingNullScript()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();

            // When
            Action action = () => driverMock.Object.ExecuteScript(null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("script", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenExecutingEmptyScript()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();

            // When
            Action action = () => driverMock.Object.ExecuteScript(string.Empty);

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("script", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenExecutingWhiteSpaceOnlyScript()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();

            //When
            Action action = () => driverMock.Object.ExecuteScript(" ");

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("script", ex.ParamName);
        }

        [Fact]
        public void ShouldLoadJQuery()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsAny<string>())).Returns(true);

            // When
            driverMock.Object.LoadJQuery(
                new Uri("http://example.com"),
                TimeSpan.FromMilliseconds(100));

            // Then
            Assert.True(true);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingJQueryWithNullVersion()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();

            // When
            Action action = () => driverMock.Object.LoadJQuery((string)null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingJQueryWithEmptyVersion()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();

            // When
            Action action = () => driverMock.Object.LoadJQuery(string.Empty);

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingJQueryWithWhiteSpaceOnlyVersion()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();

            // When
            Action action = () => driverMock.Object.LoadJQuery("\t");

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldLoadSizzle()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsAny<string>())).Returns(true);

            // When
            driverMock.Object.LoadSizzle(
                new Uri("http://example.com"),
                TimeSpan.FromMilliseconds(100));

            // Then
            Assert.True(true);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleWithNullVersion()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();

            // When
            Action action = () => driverMock.Object.LoadSizzle((string)null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleWithEmptyVersion()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();

            // When
            Action action = () => driverMock.Object.LoadSizzle(string.Empty);

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleWithWhiteSpaceOnlyVersion()
        {
            // Given
            var driverMock = new Mock<IWebDriver>();

            // When
            Action action = () => driverMock.Object.LoadSizzle("\t");

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("version", ex.ParamName);
        }
    }
}
