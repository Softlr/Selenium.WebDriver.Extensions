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
        private const string _script = "myMethod();";
        private static readonly Uri _url = new Uri("http://example.com");

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static IEnumerable<object[]> InvalidParameters
        {
            get
            {
                var driver = new WebDriverBuilder().Build();
                const string driverParam = "driver";
                const string scriptParam = "script";
                const string versionParam = "version";
                const string uriParam = "uri";

                // ExecuteScript
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.ExecuteScript(null, _script)),  driverParam
                };
                yield return new object[]
                {
                    (Action)(() => driver.ExecuteScript(null)), scriptParam
                };
                yield return new object[]
                {
                    (Action)(() => driver.ExecuteScript(string.Empty)), scriptParam
                };

                // LoadJQuery
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.LoadJQuery(null, _script)), driverParam
                };
                yield return new object[]
                {
                    (Action)(() => driver.LoadJQuery((string)null)), versionParam
                };
                yield return new object[]
                {
                    (Action)(() => driver.LoadJQuery(string.Empty)), versionParam
                };
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.LoadJQuery(null, _url)), driverParam
                };
                yield return new object[]
                {
                    (Action)(() => driver.LoadJQuery((Uri)null)), uriParam
                };

                // LoadSizzle
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.LoadSizzle(null, _script)), driverParam
                };
                yield return new object[]
                {
                    (Action)(() => driver.LoadSizzle((string)null)), versionParam
                };
                yield return new object[]
                {
                    (Action)(() => driver.LoadSizzle(string.Empty)), versionParam
                };
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.LoadSizzle(null, _url)), driverParam
                };
                yield return new object[]
                {
                    (Action)(() => driver.LoadSizzle((Uri)null)), uriParam
                };
            }
        }

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static IEnumerable<object[]> Loaders
        {
            get
            {
                var timeSpan = TimeSpan.FromMilliseconds(100);

                // LoadJQuery
                yield return new object[]
                {
                    (Action<IWebDriver, Uri, TimeSpan?>)WebDriverExtensions.LoadJQuery, _url, null
                };
                yield return new object[]
                {
                    (Action<IWebDriver, Uri, TimeSpan?>)WebDriverExtensions.LoadJQuery, _url, timeSpan
                };

                // LoadSizzle
                yield return new object[]
                {
                    (Action<IWebDriver, Uri, TimeSpan?>)WebDriverExtensions.LoadSizzle, _url, null
                };
                yield return new object[]
                {
                    (Action<IWebDriver, Uri, TimeSpan?>)WebDriverExtensions.LoadSizzle, _url, timeSpan
                };
            }
        }

        [Theory]
        [MemberData(nameof(InvalidParameters))]
        public void ShouldThrowExceptionForInvalidParameters(Action action, string parameter)
        {
            // Given
            // When
            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be(parameter);
        }

        [Fact]
        public void ShouldExecuteScript()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasTestMethodDefined().Build();

            // When
            driver.ExecuteScript(_script);

            // Then
            true.Should().BeTrue(); // assert pass
        }

        [Theory]
        [MemberData(nameof(Loaders))]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void ShouldLoadLibrary(
            Action<IWebDriver, Uri, TimeSpan?> action, Uri uri, TimeSpan? timeSpan)
        {
            // Given
            var driver = new WebDriverBuilder().ThatDoesNotHaveExternalLibraryLoaded().Build();

            // When
            action.Invoke(driver, uri, timeSpan);

            // Then
            true.Should().BeTrue(); // assert pass
        }
    }
}
