namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using NSubstitute;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;

    [ExcludeFromCodeCoverage]
    internal class SearchContextBuilder
    {
        private readonly ISearchContext _searchContext;

        public SearchContextBuilder() => _searchContext = Substitute.For<ISearchContext, IWrapsDriver, IWebElement>();

        public ISearchContext Build() => _searchContext;

        public SearchContextBuilder WithWrappedDriver(IWebDriver driver)
        {
            ((IWrapsDriver)_searchContext).WrappedDriver.Returns(driver);
            return this;
        }
    }
}