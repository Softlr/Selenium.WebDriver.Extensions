namespace OpenQA.Selenium.Tests.Extensions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Extensions;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenCheckingSelectorPrerequisitesWithNullDriver()
        {
            // Given
            // When
            Action action = () => WebDriverExtensions.CheckSelectorPrerequisites(null, null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("driver");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCheckingSelectorPrerequisitesWithoutLoader()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.CheckSelectorPrerequisites(null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldLoadExternalLibrary()
        {
            // Given
            var driver = new WebDriverBuilder().ThatDoesNotHaveExternalLibraryLoaded().Build();

            // When
            driver.LoadExternalLibrary(
                JQuerySelector.Empty,
                new Uri("http://example.com"),
                TimeSpan.FromMilliseconds(100));

            // Then
            true.Should().BeTrue(); // assert pass
        }

        [Fact]
        public void ShouldLoadExternalLibraryWithLoaderDefaultUri()
        {
            // Given
            var driver = new WebDriverBuilder().ThatDoesNotHaveExternalLibraryLoaded().Build();

            // When
            driver.LoadExternalLibrary(
                JQuerySelector.Empty,
                null,
                TimeSpan.FromMilliseconds(100));

            // Then
            true.Should().BeTrue(); // assert pass
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingExternalLibraryWithNullDriver()
        {
            // Given
            // When
            Action action = () => WebDriverExtensions.LoadExternalLibrary(null, null, null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("driver");
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingExternalLibraryWithoutLoader()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadExternalLibrary(null, null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenExecutingScriptWithNullDriver()
        {
            // Given
            // When
            Action action = () => WebDriverExtensions.ExecuteScript(null, null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("driver");
        }

        [Fact]
        public void ShouldThrowExceptionWhenExecutingScriptThatExpectsValueWithNullDriver()
        {
            // Given
            // When
            Action action = () => WebDriverExtensions.ExecuteScript<object>(null, null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("driver");
        }

        [Fact]
        public void ShouldExecuteScript()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasTestMethodDefined().Build();

            // When
            driver.ExecuteScript("myMethod();");

            // Then
            true.Should().BeTrue(); // assert pass
        }

        [Fact]
        public void ShouldThrowExceptionWhenExecutingNullScript()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.ExecuteScript(null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("script");
        }

        [Fact]
        public void ShouldThrowExceptionWhenExecutingEmptyScript()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.ExecuteScript(string.Empty);

            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("script");
        }

        [Fact]
        public void ShouldThrowExceptionWhenExecutingWhiteSpaceOnlyScript()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.ExecuteScript(" ");

            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("script");
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
            true.Should().BeTrue(); // assert pass
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingJQueryWithNullVersion()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadJQuery((string)null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("version");
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingJQueryWithEmptyVersion()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadJQuery(string.Empty);

            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("version");
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingJQueryWithWhiteSpaceOnlyVersion()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadJQuery("\t");

            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("version");
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
            true.Should().BeTrue(); // assert pass
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleWithNullVersion()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadSizzle((string)null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("version");
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleWithEmptyVersion()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadSizzle(string.Empty);

            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("version");
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleWithWhiteSpaceOnlyVersion()
        {
            // Given
            var driver = new WebDriverBuilder().Build();

            // When
            Action action = () => driver.LoadSizzle("\t");

            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("version");
        }
    }
}
