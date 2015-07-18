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
            // Given
            var selector = By.SizzleSelector("#id1");

            // When
            var element = this.Browser.FindElement(selector);

            // Then
            Assert.NotNull(element);
        }

        [Fact]
        public void FindElementThatDoesNotExist()
        {
            // Given
            var selector = By.SizzleSelector("#id-not");

            // When
            Action action = () => this.Browser.FindElement(selector);

            // Then
            Assert.Throws<NoSuchElementException>(action);
        }

        [Fact]
        public void FindElements()
        {
            // Given
            var selector = By.SizzleSelector("div.main");

            // When
            var elements = this.Browser.FindElements(selector);

            // Then
            Assert.Equal(2, elements.Count);
        }

        [Fact]
        public void FindElementsThatDoesNotExist()
        {
            // Given
            var selector = By.SizzleSelector("div.mainNot");

            // When
            var elements = this.Browser.FindElements(selector);

            // Then
            Assert.Equal(0, elements.Count);
        }

        [Fact]
        public void FindInnerElement()
        {
            // Given
            var root = this.Browser.FindElement(By.CssSelector("body"));
            var selector = By.SizzleSelector("div");

            // When
            var element = root.FindElement(selector);

            // Then
            Assert.NotNull(element);
        }

        [Fact]
        public void FindInnerElements()
        {
            // Given
            var root = this.Browser.FindElement(By.SizzleSelector("body"));
            var selector = By.SizzleSelector("h1");

            // When
            var elements = root.FindElements(selector);
            Assert.Equal(1, elements.Count);
        }

        [Fact]
        public void ExpectedConditionsSupport()
        {
            //Given
            var condition = ExpectedConditions.ElementIsVisible(By.SizzleSelector("h1"));

            // When
            var wait = new WebDriverWait(this.Browser, TimeSpan.FromSeconds(3));
            wait.Until(condition);

            // Then
            Assert.True(true);
        }
    }
}
