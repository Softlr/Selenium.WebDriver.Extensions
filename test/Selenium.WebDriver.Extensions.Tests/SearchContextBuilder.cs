namespace OpenQA.Selenium.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using Moq;
    using OpenQA.Selenium.Internal;

    [ExcludeFromCodeCoverage]
    internal class SearchContextBuilder
    {
        private readonly Mock<ISearchContext> contextMock;

        public SearchContextBuilder()
        {
            this.contextMock = new Mock<ISearchContext>();
        }

        public ISearchContext Build()
        {
            return this.contextMock.Object;
        }

        public SearchContextBuilder WithWrappedDriver(IWebDriver driver)
        {
            this.contextMock.As<IWrapsDriver>().SetupGet(x => x.WrappedDriver).Returns(driver);
            return this;
        }

        public SearchContextBuilder ThatIsWebElement()
        {
            this.contextMock.As<IWebElement>();
            return this;
        }
    }
}
