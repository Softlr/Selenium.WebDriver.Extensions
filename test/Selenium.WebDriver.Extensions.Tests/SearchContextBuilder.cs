namespace OpenQA.Selenium.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using Moq;
    using OpenQA.Selenium.Internal;

    [ExcludeFromCodeCoverage]
    internal class SearchContextBuilder
    {
        private readonly Mock<ISearchContext> _contextMock;

        public SearchContextBuilder()
        {
            _contextMock = new Mock<ISearchContext>();
        }

        public ISearchContext Build() => _contextMock.Object;

        public SearchContextBuilder WithWrappedDriver(IWebDriver driver)
        {
            _contextMock.As<IWrapsDriver>().SetupGet(x => x.WrappedDriver).Returns(driver);
            return this;
        }

        public SearchContextBuilder ThatIsWebElement()
        {
            _contextMock.As<IWebElement>();
            return this;
        }
    }
}
