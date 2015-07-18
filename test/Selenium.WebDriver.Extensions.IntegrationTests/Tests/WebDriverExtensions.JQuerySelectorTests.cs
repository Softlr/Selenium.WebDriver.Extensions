namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using Xunit;
    using By = OpenQA.Selenium.Extensions.By;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public abstract class WebDriverExtensionsJQuerySelectorTests : TestsBase
    {
        [Fact]
        public void FindElement()
        {
            var element = this.Browser.FindElement(By.JQuerySelector("#id1"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindElementThatDoesNotExist()
        {
            Assert.Throws<NoSuchElementException>(() => this.Browser.FindElement(By.JQuerySelector("#id-not")));
        }

        [Fact]
        public void FindElements()
        {
            var elements = this.Browser.FindElements(By.JQuerySelector("div.main"));
            Assert.Equal(2, elements.Count);
        }

        [Fact]
        public void FindElementsThatDoesNotExist()
        {
            var elements = this.Browser.FindElements(By.JQuerySelector("div.mainNot"));
            Assert.Equal(0, elements.Count);
        }

        [Fact]
        public void FindInnerElement()
        {
            var root = this.Browser.FindElement(By.CssSelector("body"));
            var element = root.FindElement(By.JQuerySelector("div"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindInnerElements()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("body"));
            var elements = root.FindElements(By.JQuerySelector("div"));
            Assert.Equal(2, elements.Count);
        }
    }
}
