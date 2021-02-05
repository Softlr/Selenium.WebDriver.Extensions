namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using NSubstitute;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using static NSubstitute.Substitute;

    [ExcludeFromCodeCoverage]
    internal class SearchContextBuilder
    {
        private ISearchContext _searchContext;

        public SearchContextBuilder() => _searchContext = For<ISearchContext, IWrapsDriver>();

        public SearchContextBuilder AsWebElement()
        {
            _searchContext = For<ISearchContext, IWrapsDriver, IWebElement>();
            return this;
        }

        public ISearchContext Build() => _searchContext;

        public SearchContextBuilder WithWrappedDriver(IWebDriver driver)
        {
            ((IWrapsDriver)_searchContext).WrappedDriver.Returns(driver);
            return this;
        }
    }
}