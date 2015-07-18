namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    internal class TestPage
    {
        [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        [SuppressMessage("ReSharper", "NotAccessedField.Local")]
        private IWebDriver driver;

        public TestPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(JQuerySelector), Using = "h1")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
        public IWebElement HeadingJQuery { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(SizzleSelector), Using = "h1")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
        public IWebElement HeadingSizzle { get; set; }
    }
}
