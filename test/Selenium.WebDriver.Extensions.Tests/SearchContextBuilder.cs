namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using NSubstitute;
    using OpenQA.Selenium;
    using static NSubstitute.Substitute;

    [ExcludeFromCodeCoverage]
    internal class SearchContextBuilder
    {
        private ISearchContext _searchContext;

        internal SearchContextBuilder() => _searchContext = For<ISearchContext, IWrapsDriver>();

        internal SearchContextBuilder AsWebElement()
        {
            _searchContext = For<ISearchContext, IWrapsDriver, IWebElement>();
            return this;
        }

        internal ISearchContext Build() => _searchContext;

        internal SearchContextBuilder WithWrappedDriver(IWebDriver driver)
        {
            ((IWrapsDriver)_searchContext).WrappedDriver.Returns(driver);
            return this;
        }
    }
}
