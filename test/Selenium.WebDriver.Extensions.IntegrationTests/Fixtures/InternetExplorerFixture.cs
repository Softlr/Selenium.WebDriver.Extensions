namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    using PostSharp.Patterns.Model;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [Disposable]
    public class InternetExplorerFixture
    {
        public InternetExplorerFixture()
        {
            Browser = new InternetExplorerDriver();
        }

        [Reference]
        public IWebDriver Browser { get; }
    }
}
