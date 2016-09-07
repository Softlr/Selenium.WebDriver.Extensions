namespace OpenQA.Selenium.Tests.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using global::Selenium.WebDriver.Extensions;
    using OpenQA.Selenium;
    using Xunit;
    using By = global::Selenium.WebDriver.Extensions.By;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsTests
    {
        private const string _scriptMethod = "myMethod";
        private static readonly string _script = $"{_scriptMethod}();";
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
            // Assert
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be(parameter);
        }

        [Fact]
        public void ShouldExecuteScript()
        {
            // Arrange
            var driverMock = new WebDriverBuilder().ThatHasTestMethodDefined(_scriptMethod);
            var driver = driverMock.Build();

            // Act
            driver.ExecuteScript(_script);

            // Assert
            driverMock.VerifyIfTestMethodWasCalled(_scriptMethod);
        }

        [Theory]
        [MemberData(nameof(Loaders))]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void ShouldLoadLibrary(
            Action<IWebDriver, Uri, TimeSpan?> action, Uri uri, TimeSpan? timeSpan)
        {
            // Arrange
            var driverMock = new WebDriverBuilder().ThatDoesNotHaveExternalLibraryLoaded();
            var driver = driverMock.Build();

            // Act
            action.Invoke(driver, uri, timeSpan);

            // Assert
            driverMock.VerifyIfExternalLibraryWasLoaded(); // assert pass
        }
    }
}
