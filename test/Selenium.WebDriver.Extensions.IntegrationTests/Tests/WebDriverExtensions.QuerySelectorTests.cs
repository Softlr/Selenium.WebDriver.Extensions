namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.By;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]   
    public abstract class WebDriverExtensionsQuerySelectorTests
    {
        protected IWebDriver Browser { get; set; }

        [Fact]
        public void FindElement()
        {
            var element = this.Browser.FindElement(By.QuerySelector("#id1"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindElementThatDoesntExist()
        {
            Assert.Throws<NoSuchElementException>(() => this.Browser.FindElement(By.QuerySelector("#id-not")));
        }

        [Fact]
        public void FindElements()
        {
            var elements = this.Browser.FindElements(By.QuerySelector("div.main"));
            Assert.Equal(2, elements.Count);
        }

        [Fact]
        public void FindElementsThatDoesntExist()
        {
            var elements = this.Browser.FindElements(By.QuerySelector("div.mainNot"));
            Assert.Equal(0, elements.Count);
        }

        [Fact]
        public void FindElementPath()
        {
            var element = this.Browser.FindElement(By.QuerySelector("#id1"));
            Assert.Equal("body > div#id1", element.Path);
        }

        [Fact]
        public void FindInnerElement()
        {
            var root = this.Browser.FindElement(By.QuerySelector("#id1"));
            var element = root.FindElement(By.QuerySelector("span"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindInnerElements()
        {
            var root = this.Browser.FindElement(By.QuerySelector("#id1"));
            var elements = root.FindElements(By.QuerySelector("span"));
            Assert.Equal(2, elements.Count);
        }
    }
}
