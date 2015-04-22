namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Nancy;
    using Selenium.WebDriver.Extensions.IntegrationTests.Properties;

    public class TestCaseModule : NancyModule
    {
        public TestCaseModule()
        {
            this.Get["/Core"] = _ => Resources.CoreTestsHtml;
        }
    }
}
