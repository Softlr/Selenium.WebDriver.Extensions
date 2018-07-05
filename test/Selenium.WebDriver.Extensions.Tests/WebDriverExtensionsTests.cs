namespace Selenium.WebDriver.Extensions.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture;
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using JetBrains.Annotations;
    using NSubstitute;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions;
    using Selenium.WebDriver.Extensions.Tests.Shared;
    using Xunit;
    using static Selenium.WebDriver.Extensions.Tests.Shared.Trait;
    using static Softlr.Suppress;
    using static System.String;

    [Trait(CATEGORY, UNIT)]
    [ExcludeFromCodeCoverage]
    [SuppressMessage(SONARQUBE, S3900)]
    public class WebDriverExtensionsTests
    {
        private static readonly Fixture _fixture = new Fixture();

        [PublicAPI]
        public static IEnumerable<object[]> InvalidParameters
        {
            get
            {
                var webDriver = new WebDriverBuilder().Build();
                const string driverParam = "driver";
                const string scriptParam = "script";
                const string versionParam = "version";
                const string uriParam = "uri";

                // ExecuteScript
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.ExecuteScript(null, _fixture.Create<string>())),  driverParam
                };
                yield return new object[] { (Action)(() => webDriver.ExecuteScript(null)), scriptParam };
                yield return new object[] { (Action)(() => webDriver.ExecuteScript(Empty)), scriptParam };

                // LoadJQuery
                yield return new object[] { (Action)(() => WebDriverExtensions.LoadJQuery(null)), driverParam };
                yield return new object[] { (Action)(() => webDriver.LoadJQuery((string)null)), versionParam };
                yield return new object[] { (Action)(() => webDriver.LoadJQuery(Empty)), versionParam };
                yield return new object[]
                {
                    (Action)(() => webDriver.LoadJQuery(_fixture.Create<string>())), versionParam
                };
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.LoadJQuery(null, _fixture.Create<Uri>())), driverParam
                };
                yield return new object[] { (Action)(() => webDriver.LoadJQuery((Uri)null)), uriParam };

                // LoadSizzle
                yield return new object[] { (Action)(() => WebDriverExtensions.LoadSizzle(null)), driverParam };
                yield return new object[] { (Action)(() => webDriver.LoadSizzle((string)null)), versionParam };
                yield return new object[] { (Action)(() => webDriver.LoadSizzle(Empty)), versionParam };
                yield return new object[]
                {
                    (Action)(() => webDriver.LoadSizzle(_fixture.Create<string>())), versionParam
                };
                yield return new object[]
                {
                    (Action)(() => WebDriverExtensions.LoadSizzle(null, _fixture.Create<Uri>())), driverParam
                };
                yield return new object[] { (Action)(() => webDriver.LoadSizzle((Uri)null)), uriParam };
            }
        }

        [PublicAPI]
        public static IEnumerable<object[]> Loaders
        {
            get
            {
                var timeSpan = _fixture.Create<TimeSpan>();

                // LoadJQuery
                yield return new object[]
                {
                    (Action<IWebDriver, Uri, TimeSpan?>)WebDriverExtensions.LoadJQuery, _fixture.Create<Uri>(),
                    null
                };
                yield return new object[]
                {
                    (Action<IWebDriver, Uri, TimeSpan?>)WebDriverExtensions.LoadJQuery, _fixture.Create<Uri>(),
                    timeSpan
                };

                // LoadSizzle
                yield return new object[]
                {
                    (Action<IWebDriver, Uri, TimeSpan?>)WebDriverExtensions.LoadSizzle, _fixture.Create<Uri>(),
                    null
                };
                yield return new object[]
                {
                    (Action<IWebDriver, Uri, TimeSpan?>)WebDriverExtensions.LoadSizzle, _fixture.Create<Uri>(),
                    timeSpan
                };
            }
        }

        [Theory]
        [AutoData]
        public void ShouldExecuteScript(string scriptMethod)
        {
            var script = $"{scriptMethod}();";
            var driver = new WebDriverBuilder().WithTestMethodDefined(scriptMethod).Build();

            driver.ExecuteScript(script);

            ((IJavaScriptExecutor)driver).Received(1).ExecuteScript(script);
        }

        [Theory]
        [MemberData(nameof(Loaders))]
        public void ShouldLoadLibrary(Action<IWebDriver, Uri, TimeSpan?> action, Uri uri, TimeSpan? timeSpan)
        {
            var driver = new WebDriverBuilder().WithNoExternalLibraryLoaded().Build();

            action.Invoke(driver, uri, timeSpan);

            ((IJavaScriptExecutor)driver).Received(3).ExecuteScript(Arg.Any<string>());
        }

        [Theory]
        [MemberData(nameof(InvalidParameters))]
        public void ShouldThrowExceptionForInvalidParameters(Action action, string parameter) =>
            action.Should().Throw<ArgumentException>().And.ParamName.Should().Be(parameter);
    }
}
