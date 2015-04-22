namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Nancy;
    using Selenium.WebDriver.Extensions.IntegrationTests.Properties;

    public class TestCaseModule : NancyModule
    {
        public TestCaseModule()
        {
            this.Get["/Core"] = _ => Resources.CoreTestsHtml;
            this.Get["/QuerySelector"] = _ => Resources.QuerySelectorHtml;
            this.Get["/jQueryLoaded"] = _ => Resources.jQueryLoadedHtml;
            this.Get["/jQueryUnloaded"] = _ => Resources.jQueryUnloadedHtml;
            this.Get["/SizzleLoaded"] = _ => Resources.SizzleLoadedHtml;
            this.Get["/SizzleUnloaded"] = _ => Resources.SizzleUnloadedHtml;
        }
    }
}
