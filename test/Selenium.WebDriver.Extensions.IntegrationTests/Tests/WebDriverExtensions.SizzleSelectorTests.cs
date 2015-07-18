namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Xunit;
    using By = OpenQA.Selenium.Extensions.By;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public abstract class WebDriverExtensionsSizzleSelectorTests : TestsBase
    {
        [Fact]
        public void FindElement()
        {
            var element = this.Browser.FindElement(By.SizzleSelector("#id1"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindElementThatDoesNotExist()
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
        public void FindElementsThatDoesNotExist()
        {
            var elements = this.Browser.FindElements(By.SizzleSelector("div.mainNot"));
            Assert.Equal(0, elements.Count);
        }

        [Fact]
        public void FindInnerElement()
        {
            var root = this.Browser.FindElement(By.CssSelector("body"));
            var element = root.FindElement(By.SizzleSelector("div"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindInnerElements()
        {
            var root = this.Browser.FindElement(By.SizzleSelector("body"));
            var elements = root.FindElements(By.SizzleSelector("h1"));
            Assert.Equal(1, elements.Count);
        }

        [Fact]
        public void ExpectedConditionsSupport()
        {
            var wait = new WebDriverWait(this.Browser, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.SizzleSelector("h1")));

            Assert.True(true);
        }
    }
}
