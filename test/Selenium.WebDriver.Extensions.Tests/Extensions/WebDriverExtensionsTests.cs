namespace Selenium.WebDriver.Extensions.Tests.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using OpenQA.Selenium;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Xunit2;
    using Selenium.WebDriver.Extensions;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsTests
    {
        private static readonly Fixture _fixture = new Fixture();

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
                    (Action)(() => WebDriverExtensions.ExecuteScript(null, _fixture.Create<string>())),  driverParam
                };
                yield return new object[] { (Action)(() => driver.ExecuteScript(null)), scriptParam };
                yield return new object[] { (Action)(() => driver.ExecuteScript(string.Empty)), scriptParam };

                // LoadJQuery
                yield return new object[] { (Action)(() => WebDriverExtensions.LoadJQuery(null)), driverParam };
                yield return new object[] { (Action)(() => driver.LoadJQuery((string)null)), versionParam };
                yield return new object[] { (Action)(() => driver.LoadJQuery(string.Empty)), versionParam };
                yield return new object[]
                {
                    (Action)(() => driver.LoadJQuery(_fixture.Create<string>())), versionParam
                };
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.LoadJQuery(null, _fixture.Create<Uri>())), driverParam
                };
                yield return new object[] { (Action)(() => driver.LoadJQuery((Uri)null)), uriParam };

                // LoadSizzle
                yield return new object[] { (Action)(() => WebDriverExtensions.LoadSizzle(null)), driverParam };
                yield return new object[] { (Action)(() => driver.LoadSizzle((string)null)), versionParam };
                yield return new object[] { (Action)(() => driver.LoadSizzle(string.Empty)), versionParam };
                yield return new object[]
                {
                    (Action)(() => driver.LoadSizzle(_fixture.Create<string>())), versionParam
                };
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.LoadSizzle(null, _fixture.Create<Uri>())), driverParam
                };
                yield return new object[] { (Action)(() => driver.LoadSizzle((Uri)null)), uriParam };
            }
        }

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static IEnumerable<object[]> Loaders
        {
            get
            {
                var timeSpan = _fixture.Create<TimeSpan>();

                // LoadJQuery
                yield return new object[]
                {
                    (Action<IWebDriver, Uri, TimeSpan?>)WebDriverExtensions.LoadJQuery, _fixture.Create<Uri>(), null
                };
                yield return new object[]
                {
                    (Action<IWebDriver, Uri, TimeSpan?>)WebDriverExtensions.LoadJQuery, _fixture.Create<Uri>(), timeSpan
                };

                // LoadSizzle
                yield return new object[]
                {
                    (Action<IWebDriver, Uri, TimeSpan?>)WebDriverExtensions.LoadSizzle, _fixture.Create<Uri>(), null
                };
                yield return new object[]
                {
                    (Action<IWebDriver, Uri, TimeSpan?>)WebDriverExtensions.LoadSizzle, _fixture.Create<Uri>(), timeSpan
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

        [Theory]
        [AutoData]
        public void ShouldExecuteScript(string scriptMethod)
        {
            // Arrange
            var script = $"{scriptMethod}();";
            var driverMock = new WebDriverBuilder().ThatHasTestMethodDefined(scriptMethod);
            var driver = driverMock.Build();

            // Act
            driver.ExecuteScript(script);

            // Assert
            driverMock.VerifyIfTestMethodWasCalled(scriptMethod);
        }

        [Theory]
        [MemberData(nameof(Loaders))]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void ShouldLoadLibrary(Action<IWebDriver, Uri, TimeSpan?> action, Uri uri, TimeSpan? timeSpan)
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
