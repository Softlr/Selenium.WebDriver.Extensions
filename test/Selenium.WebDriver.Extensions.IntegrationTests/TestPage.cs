namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using static Suppress.Category;
    using static Suppress.CodeCracker;

    [PublicAPI]
    [ExcludeFromCodeCoverage]
    internal class TestPage
    {
        private IWebDriver _driver;

        [SuppressMessage(CODE_CRACKER, CC0057)]
        public TestPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(JQuerySelector), Using = "h1")]
        public IWebElement HeadingJQuery { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(SizzleSelector), Using = "h1")]
        public IWebElement HeadingSizzle { get; set; }
    }
}