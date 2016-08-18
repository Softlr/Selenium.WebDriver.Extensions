namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using Nancy;

    [ExcludeFromCodeCoverage]
    public class TestCaseModule : NancyModule
    {
        public TestCaseModule()
        {
            const string Prefix = "Selenium.WebDriver.Extensions.IntegrationTests.TestCases.";
            Get["/jQueryLoaded"] = _ => GetHtml($"{Prefix}JQuery.Loaded.html");
            Get["/jQueryUnloaded"] = _ => GetHtml($"{Prefix}JQuery.Unloaded.html");
            Get["/SizzleLoaded"] = _ => GetHtml($"{Prefix}Sizzle.Loaded.html");
            Get["/SizzleUnloaded"] = _ => GetHtml($"{Prefix}Sizzle.Unloaded.html");
        }

        private static string GetHtml(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Stream stream = null;
            try
            {
                stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                {
                    return null;
                }

                using (var reader = new StreamReader(stream))
                {
                    stream = null;
                    return reader.ReadToEnd();
                }
            }
            finally
            {
                stream?.Dispose();
            }
        }
    }
}
