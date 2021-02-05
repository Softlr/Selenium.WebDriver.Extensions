namespace Selenium.WebDriver.Extensions.Tests.Shared
{
    using System.Diagnostics.CodeAnalysis;
    using static Softlr.Suppress;

    [ExcludeFromCodeCoverage]
    [SuppressMessage(SONARQUBE, S2339)]
    public static partial class Trait
    {
        public const string CHROME = "Chrome";
        public const string EDGE = "Edge";
        public const string FIREFOX = "Firefox";
        public const string INTERNET_EXPLORER = "InternetExplorer";
    }
}
