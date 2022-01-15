namespace Selenium.WebDriver.Extensions.Tests
{
    [ExcludeFromCodeCoverage]
    internal class SearchContextBuilder
    {
        private ISearchContext _searchContext;

        internal SearchContextBuilder() => _searchContext = Substitute.For<ISearchContext, IWrapsDriver>();

        internal SearchContextBuilder AsWebElement()
        {
            _searchContext = Substitute.For<ISearchContext, IWrapsDriver, IWebElement>();
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
