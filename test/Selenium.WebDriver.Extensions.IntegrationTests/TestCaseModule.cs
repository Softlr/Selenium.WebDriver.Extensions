namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.IO;
    using System.Reflection;
    using Nancy;
    
    public class TestCaseModule : NancyModule
    {
        public TestCaseModule()
        {
            const string Prefix = "Selenium.WebDriver.Extensions.IntegrationTests.TestCases.";
            this.Get["/QuerySelector"] = _ => GetHtml(Prefix + "QuerySelector.TestCase.html");
            this.Get["/jQueryLoaded"] = _ => GetHtml(Prefix + "JQuery.Loaded.html");
            this.Get["/jQueryUnloaded"] = _ => GetHtml(Prefix + "JQuery.Unloaded.html");
            this.Get["/SizzleLoaded"] = _ => GetHtml(Prefix + "Sizzle.Loaded.html");
            this.Get["/SizzleUnloaded"] = _ => GetHtml(Prefix + "Sizzle.Unloaded.html");
        }

        private static string GetHtml(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    return null;
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
