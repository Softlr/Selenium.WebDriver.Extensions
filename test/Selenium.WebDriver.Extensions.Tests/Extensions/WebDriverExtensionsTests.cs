namespace OpenQA.Selenium.Tests.Extensions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
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
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.CheckSelectorPrerequisites(null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("loader", ex.ParamName);
        }

        [Fact]
        public void ShouldLoadExternalLibrary()
        {
            // Given
            var driver = new WebDriverBuilder().ThatDoesNotHaveExternalLibraryLoaded().Build();

            // When
            driver.LoadExternalLibrary(
                new JQueryLoader(),
                new Uri("http://example.com"),
                TimeSpan.FromMilliseconds(100));

            // Then
            Assert.True(true);
        }

        [Fact]
        public void ShouldLoadExternalLibraryWithLoaderDefaultUri()
        {
            // Given
            var driver = new WebDriverBuilder().ThatDoesNotHaveExternalLibraryLoaded().Build();

            // When
            driver.LoadExternalLibrary(
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
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadExternalLibrary(null, null);

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
            var driver = new WebDriverBuilder().ThatHasTestMethodDefined().Build();

            // When
            driver.ExecuteScript("myMethod();");

            // Then
            Assert.True(true);
        }

        [Fact]
        public void ShouldThrowExceptionWhenExecutingNullScript()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.ExecuteScript(null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("script", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenExecutingEmptyScript()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.ExecuteScript(string.Empty);

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("script", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenExecutingWhiteSpaceOnlyScript()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.ExecuteScript(" ");

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("script", ex.ParamName);
        }

        [Fact]
        public void ShouldLoadJQuery()
        {
            // Given
            var driver = new WebDriverBuilder().ThatDoesNotHaveExternalLibraryLoaded().Build();

            // When
            driver.LoadJQuery(
                new Uri("http://example.com"),
                TimeSpan.FromMilliseconds(100));

            // Then
            Assert.True(true);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingJQueryWithNullVersion()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadJQuery((string)null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingJQueryWithEmptyVersion()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadJQuery(string.Empty);

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingJQueryWithWhiteSpaceOnlyVersion()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadJQuery("\t");

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldLoadSizzle()
        {
            // Given
            var driver = new WebDriverBuilder().ThatDoesNotHaveExternalLibraryLoaded().Build();

            // When
            driver.LoadSizzle(
                new Uri("http://example.com"),
                TimeSpan.FromMilliseconds(100));

            // Then
            Assert.True(true);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleWithNullVersion()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadSizzle((string)null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleWithEmptyVersion()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadSizzle(string.Empty);

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleWithWhiteSpaceOnlyVersion()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadSizzle("\t");

            // Then
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("version", ex.ParamName);
        }
    }
}
