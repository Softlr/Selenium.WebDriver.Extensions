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
            driver.LoadJQuery(new Uri("http://example.com"), TimeSpan.FromMilliseconds(100));

            // Then
            true.Should().BeTrue(); // assert pass
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingJQueryWithNullDriver()
        {
            // Given
            // When
            Action action = () => WebDriverExtensions.LoadJQuery(null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("driver");
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
        public void ShouldThrowExceptionWhenLoadingJQueryWithNullDriverAndUrl()
        {
            // Given
            var url = new Uri("http://example.com");

            // When
            Action action = () => WebDriverExtensions.LoadJQuery(null, url);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("driver");
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
            driver.LoadSizzle(new Uri("http://example.com"), TimeSpan.FromMilliseconds(100));

            // Then
            true.Should().BeTrue(); // assert pass
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleWithNullDriver()
        {
            // Given
            // When
            Action action = () => WebDriverExtensions.LoadSizzle(null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("driver");
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleWithNullDriverAndUrl()
        {
            // Given
            var url = new Uri("http://example.com");

            // When
            Action action = () => WebDriverExtensions.LoadSizzle(null, url);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("driver");
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
