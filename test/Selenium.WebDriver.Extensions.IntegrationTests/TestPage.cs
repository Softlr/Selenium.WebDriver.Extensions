namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    [PublicAPI]
    [ExcludeFromCodeCoverage]
    internal class TestPage
    {
        private IWebDriver _driver;

        [SuppressMessage(Suppress.Category.CODE_CRACKER, Suppress.CodeCracker.CC0057)]
        public TestPage(IWebDriver driver) => _driver = driver;

        [FindsBy(How = How.Custom, CustomFinderType = typeof(JQuerySelector), Using = "h1")]
        public IWebElement HeadingJQuery { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(SizzleSelector), Using = "h1")]
        public IWebElement HeadingSizzle { get; set; }
    }
}