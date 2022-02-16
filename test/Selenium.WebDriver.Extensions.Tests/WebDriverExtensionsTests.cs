namespace Selenium.WebDriver.Extensions.Tests
{
    [Trait(CATEGORY, UNIT)]
    [ExcludeFromCodeCoverage]
    [SuppressMessage(SONARQUBE, S109)]
    [SuppressMessage(SONARQUBE, S3900)]
    public class WebDriverExtensionsTests
    {
        private const string DriverParam = "driver";
        private const string ScriptParam = "script";
        private const string UriParam = "uri";
        private const string VersionParam = "version";
        private static readonly Fixture _fixture = new();
        private static readonly IWebDriver _webDriver = new WebDriverBuilder().Build();

        public static TheoryData<Action, string> InvalidParameters =>
            new()
            {
                // ExecuteScript
                { () => WebDriverExtensions.ExecuteScript(null, _fixture.Create<string>()), DriverParam },
                { () => _webDriver.ExecuteScript(null), ScriptParam },
                { () => _webDriver.ExecuteScript(string.Empty), ScriptParam },

                // LoadJQuery
                { () => WebDriverExtensions.LoadJQuery(null), DriverParam },
                { () => _webDriver.LoadJQuery((string)null), VersionParam },
                { () => _webDriver.LoadJQuery(string.Empty), VersionParam },
                { () => _webDriver.LoadJQuery(_fixture.Create<string>()), VersionParam },
                { () => WebDriverExtensions.LoadJQuery(null, _fixture.Create<Uri>()), DriverParam },
                { () => _webDriver.LoadJQuery((Uri)null), UriParam },

                // LoadSizzle
                { () => WebDriverExtensions.LoadSizzle(null), DriverParam },
                { () => _webDriver.LoadSizzle((string)null), VersionParam },
                { () => _webDriver.LoadSizzle(string.Empty), VersionParam },
                { () => _webDriver.LoadSizzle(_fixture.Create<string>()), VersionParam },
                { () => WebDriverExtensions.LoadSizzle(null, _fixture.Create<Uri>()), DriverParam },
                { () => _webDriver.LoadSizzle((Uri)null), UriParam }
            };

        public static TheoryData<Action<IWebDriver>> Loaders =>
            new()
            {
                // LoadJQuery
                { driver => driver.LoadJQuery(_fixture.Create<Uri>(), null) },
                { driver => driver.LoadJQuery(_fixture.Create<Uri>(), _fixture.Create<TimeSpan>()) },
                { driver => driver.LoadJQuery(_fixture.Create<TimeSpan>()) },

                // LoadSizzle
                { driver => driver.LoadSizzle(_fixture.Create<Uri>(), null) },
                { driver => driver.LoadSizzle(_fixture.Create<Uri>(), _fixture.Create<TimeSpan>()) },
                { driver => driver.LoadSizzle(_fixture.Create<TimeSpan>()) },
            };

        [Theory]
        [AutoData]
        public void Executing_script_works(string scriptMethod)
        {
            var script = $"{scriptMethod}();";
            var driver = new WebDriverBuilder().WithTestMethodDefined(scriptMethod).Build();

            driver.ExecuteScript(script);

            ((IJavaScriptExecutor)driver).Received(1).ExecuteScript(script);
        }

        [Theory]
        [MemberData(nameof(InvalidParameters))]
        public void Invalid_parameter_throws_exception(Action action, string parameter) =>
            FluentActions.Invoking(action).Should().Throw<ArgumentException>().And.ParamName.Should().Be(parameter);

        [Theory]
        [MemberData(nameof(Loaders))]
        public void Loading_library_works(Action<IWebDriver> action)
        {
            var driver = new WebDriverBuilder().WithNoExternalLibraryLoaded().Build();

            action.Invoke(driver);

            ((IJavaScriptExecutor)driver).Received(3).ExecuteScript(Arg.Any<string>());
        }
    }
}
