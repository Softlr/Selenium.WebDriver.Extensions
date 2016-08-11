namespace OpenQA.Selenium.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Extensions;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class JavaScriptSnippetsTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenLoadingScriptWithNullArgument()
        {
            // Given
            // When
            Action action = () => JavaScriptSnippets.LoadScriptCode(null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("url", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCheckingScriptWithNullArgument()
        {
            // Given
            // When
            Action action = () => JavaScriptSnippets.CheckScriptCode(null);

            // Then
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("variable", ex.ParamName);
        }
    }
}
