namespace OpenQA.Selenium.Tests
{
    using Moq;

    internal class WebDriverBuilder
    {
        private readonly Mock<IWebDriver> driverMock;

        public WebDriverBuilder()
        {
            this.driverMock = new Mock<IWebDriver>();
        }

        public IWebDriver Build()
        {
            return this.driverMock.Object;
        }

        public WebDriverBuilder ThatDoesNotHaveExternalLibraryLoaded()
        {
            this.driverMock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>()))
                .Returns(false).Returns(null).Returns(true);
            return this;
        }

        public WebDriverBuilder ThatHasTestMethodDefined()
        {
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return myMethod();")).Returns("foo");
            return this;
        }
    }
}
