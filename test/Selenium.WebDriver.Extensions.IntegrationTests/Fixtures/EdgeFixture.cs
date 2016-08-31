namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Edge;
    using PostSharp.Patterns.Model;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [Disposable]
    public class EdgeFixture
    {
        public EdgeFixture()
        {
            Browser = new EdgeDriver();
        }

        [Reference]
        public IWebDriver Browser { get; }
    }
}
