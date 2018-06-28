namespace Selenium.WebDriver.Extensions.Tests.Shared
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class Trait
    {
        public static class Browser
        {
            public const string CHROME = "Chrome";
            public const string EDGE = "Edge";
            public const string FIREFOX = "Firefox";
            public const string INTERNET_EXPLORER = "InternetExplorer";
        }

        public static class Category
        {
            public const string INTEGRATION = "Integration";
            public const string UNIT = "Unit";
        }

        public static class Name
        {
            public const string BROWSER = nameof(Browser);
            public const string CATEGORY = nameof(Category);
        }
    }
}
