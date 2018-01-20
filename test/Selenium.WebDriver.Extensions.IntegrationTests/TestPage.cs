namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    [PublicAPI]
    [ExcludeFromCodeCoverage]
    internal class TestPage
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public TestPage(IWebDriver driver) => PageFactory.InitElements(driver, this);

        [FindsBy(How = How.Custom, CustomFinderType = typeof(JQuerySelector), Using = "h1")]
        public IWebElement HeadingJQuery { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(SizzleSelector), Using = "h1")]
        public IWebElement HeadingSizzle { get; set; }
    }
}