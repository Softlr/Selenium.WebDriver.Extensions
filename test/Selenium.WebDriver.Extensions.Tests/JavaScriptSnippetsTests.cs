namespace OpenQA.Selenium.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using OpenQA.Selenium.Extensions;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class JavaScriptSnippetsTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenLoadingScriptWithNullArgument()
        {
            // Given
            // When
            Action action = () => JavaScriptSnippets.LoadScriptCode(null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("url");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCheckingScriptWithNullArgument()
        {
            // Given
            // When
            Action action = () => JavaScriptSnippets.CheckScriptCode(null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("variable");
        }
    }
}
