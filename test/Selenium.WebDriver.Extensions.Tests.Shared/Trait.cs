namespace Selenium.WebDriver.Extensions.Tests.Shared
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class Trait
    {
        public static class Name
        {
            public const string CATEGORY = nameof(Category);
            public const string BROWSER = nameof(Browser);
        }

        public static class Category
        {
            public const string UNIT = "Unit";
            public const string INTEGRATION = "Integration";
        }

        public static class Browser
        {
            public const string CHROME = "Chrome";
            public const string FIREFOX = "Firefox";
            public const string INTERNET_EXPLORER = "InternetExplorer";
            public const string EDGE = "Edge";
        }
    }
}
