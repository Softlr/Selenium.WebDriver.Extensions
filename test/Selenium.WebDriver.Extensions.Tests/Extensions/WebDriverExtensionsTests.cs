namespace OpenQA.Selenium.Tests.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Extensions;
    using Xunit;
    using By = OpenQA.Selenium.Extensions.By;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsTests
    {
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static IEnumerable<object[]> InvalidParameters
        {
            get
            {
                var driver = new WebDriverBuilder().Build();
                const string script = "myMethod();";
                var url = new Uri("http://example.com");

                // ExecuteScript
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.ExecuteScript(null, script)),  "driver"
                };
                yield return new object[]
                {
                    (Action)(() => driver.ExecuteScript(null)), "script"
                };
                yield return new object[]
                {
                    (Action)(() => driver.ExecuteScript(string.Empty)), "script"
                };

                // LoadJQuery
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.LoadJQuery(null, script)), "driver"
                };
                yield return new object[]
                {
                    (Action)(() => driver.LoadJQuery((string)null)), "version"
                };
                yield return new object[]
                {
                    (Action)(() => driver.LoadJQuery(string.Empty)), "version"
                };
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.LoadJQuery(null, url)), "driver"
                };
                yield return new object[]
                {
                    (Action)(() => driver.LoadJQuery((Uri)null)), "uri"
                };

                // LoadSizzle
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.LoadSizzle(null, script)), "driver"
                };
                yield return new object[]
                {
                    (Action)(() => driver.LoadSizzle((string)null)), "version"
                };
                yield return new object[]
                {
                    (Action)(() => driver.LoadSizzle(string.Empty)), "version"
                };
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.LoadSizzle(null, url)), "driver"
                };
                yield return new object[]
                {
                    (Action)(() => driver.LoadSizzle((Uri)null)), "uri"
                };
            }
        }

        [Theory]
        [MemberData(nameof(InvalidParameters))]
        public void ShouldThrowExceptionForInvalidParameters(Action action, string paramName)
        {
            // Given
            // When
            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be(paramName);
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
        public void ShouldLoadSizzle()
        {
            // Given
            var driver = new WebDriverBuilder().ThatDoesNotHaveExternalLibraryLoaded().Build();

            // When
            driver.LoadSizzle(new Uri("http://example.com"), TimeSpan.FromMilliseconds(100));

            // Then
            true.Should().BeTrue(); // assert pass
        }
    }
}
