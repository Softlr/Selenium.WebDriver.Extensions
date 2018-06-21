namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using NSubstitute;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;

    [ExcludeFromCodeCoverage]
    internal class SearchContextBuilder
    {
        private ISearchContext _searchContext;

        public SearchContextBuilder() => _searchContext = Substitute.For<ISearchContext, IWrapsDriver>();

        public ISearchContext Build() => _searchContext;

        public SearchContextBuilder WithWrappedDriver(IWebDriver driver)
        {
            ((IWrapsDriver)_searchContext).WrappedDriver.Returns(driver);
            return this;
        }

        public SearchContextBuilder AsWebElement()
        {
            _searchContext = Substitute.For<ISearchContext, IWrapsDriver, IWebElement>();
            return this;
        }
    }
}
