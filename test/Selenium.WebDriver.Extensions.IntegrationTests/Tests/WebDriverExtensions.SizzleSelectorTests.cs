namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.By;

#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public abstract class WebDriverExtensionsSizzleSelectorTests
    {
        protected IWebDriver Browser { get; set; }

        [Fact]
        public void FindElement()
        {
            var element = this.Browser.FindElement(By.SizzleSelector("#id1"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindElementThatDoesntExist()
        {
            Assert.Throws<NoSuchElementException>(() => this.Browser.FindElement(By.SizzleSelector("#id-not")));
        }

        [Fact]
        public void FindElements()
        {
            var elements = this.Browser.FindElements(By.SizzleSelector("div.main"));
            Assert.Equal(2, elements.Count);
        }

        [Fact]
        public void FindElementsThatDoesntExist()
        {
            var elements = this.Browser.FindElements(By.SizzleSelector("div.mainNot"));
            Assert.Equal(0, elements.Count);
        }

        [Fact]
        public void FindElementPath()
        {
            var element = this.Browser.FindElement(By.SizzleSelector("#id1"));
            Assert.Equal("body > div#id1", element.Path);
        }

        [Fact]
        public void FindInnerElement()
        {
            var root = this.Browser.FindElement(By.SizzleSelector("#id1"));
            var element = root.FindElement(By.SizzleSelector("span"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindInnerElements()
        {
            var root = this.Browser.FindElement(By.SizzleSelector("#id1"));
            var elements = root.FindElements(By.SizzleSelector("span"));
            Assert.Equal(2, elements.Count);
        }
    }
}
