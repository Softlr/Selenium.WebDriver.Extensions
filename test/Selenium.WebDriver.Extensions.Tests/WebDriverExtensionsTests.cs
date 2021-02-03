namespace Selenium.WebDriver.Extensions.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture;
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using JetBrains.Annotations;
    using NSubstitute;
    using OpenQA.Selenium;
    using Xunit;
    using static System.String;
    using static Shared.Trait;
    using static Softlr.Suppress;

    [Trait(CATEGORY, UNIT)]
    [ExcludeFromCodeCoverage]
    [SuppressMessage(SONARQUBE, S3900)]
    public class WebDriverExtensionsTests
    {
        private const string DriverParam = "driver";
        private const string ScriptParam = "script";
        private const string UriParam = "uri";
        private const string VersionParam = "version";
        private static readonly Fixture _fixture = new Fixture();
        private static readonly IWebDriver _webDriver = new WebDriverBuilder().Build();

        [PublicAPI]
        public static TheoryData<Action, string> InvalidParameters =>
            new TheoryData<Action, string>
            {
                // ExecuteScript
                { () => WebDriverExtensions.ExecuteScript(null, _fixture.Create<string>()), DriverParam },
                { () => _webDriver.ExecuteScript(null), ScriptParam },
                { () => _webDriver.ExecuteScript(Empty), ScriptParam },

                // LoadJQuery
                { () => WebDriverExtensions.LoadJQuery(null), DriverParam },
                { () => _webDriver.LoadJQuery((string)null), VersionParam },
                { () => _webDriver.LoadJQuery(Empty), VersionParam },
                { () => _webDriver.LoadJQuery(_fixture.Create<string>()), VersionParam },
                { () => WebDriverExtensions.LoadJQuery(null, _fixture.Create<Uri>()), DriverParam },
                { () => _webDriver.LoadJQuery((Uri)null), UriParam },

                // LoadSizzle
                { () => WebDriverExtensions.LoadSizzle(null), DriverParam },
                { () => _webDriver.LoadSizzle((string)null), VersionParam },
                { () => _webDriver.LoadSizzle(Empty), VersionParam },
                { () => _webDriver.LoadSizzle(_fixture.Create<string>()), VersionParam },
                { () => WebDriverExtensions.LoadSizzle(null, _fixture.Create<Uri>()), DriverParam },
                { () => _webDriver.LoadSizzle((Uri)null), UriParam }
            };

        [PublicAPI]
        public static TheoryData<Action<IWebDriver, Uri, TimeSpan?>, Uri, TimeSpan?> Loaders =>
            new TheoryData<Action<IWebDriver, Uri, TimeSpan?>, Uri, TimeSpan?>
            {
                // LoadJQuery
                { WebDriverExtensions.LoadJQuery, _fixture.Create<Uri>(), null },
                { WebDriverExtensions.LoadJQuery, _fixture.Create<Uri>(), _fixture.Create<TimeSpan>() },

                // LoadSizzle
                { WebDriverExtensions.LoadSizzle, _fixture.Create<Uri>(), null },
                { WebDriverExtensions.LoadSizzle, _fixture.Create<Uri>(), _fixture.Create<TimeSpan>() }
            };

        [Theory]
        [AutoData]
        [SuppressMessage(SONARQUBE, S2699)]
        public void ShouldExecuteScript(string scriptMethod)
        {
            var script = $"{scriptMethod}();";
            var driver = new WebDriverBuilder().WithTestMethodDefined(scriptMethod).Build();

            driver.ExecuteScript(script);

            ((IJavaScriptExecutor)driver).Received(1).ExecuteScript(script);
        }

        [Theory]
        [MemberData(nameof(Loaders))]
        [SuppressMessage(SONARQUBE, S2699)]
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