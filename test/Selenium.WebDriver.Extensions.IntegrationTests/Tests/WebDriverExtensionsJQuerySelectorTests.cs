namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;
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
            // Given
            var selector = By.JQuerySelector("#id1");

            // When
            var element = this.Browser.FindElement(selector);

            // Then
            Assert.NotNull(element);
        }

        [Fact]
        public void FindElementThatDoesNotExist()
        {
            // Given
            var selector = By.JQuerySelector("#id-not");

            // When
            Action action = () => this.Browser.FindElement(selector);

            // Then
            Assert.Throws<NoSuchElementException>(action);
        }

        [Fact]
        public void FindElements()
        {
            // Given
            var selector = By.JQuerySelector("div.main");

            // When
            var elements = this.Browser.FindElements(selector);

            // Then
            Assert.Equal(2, elements.Count);
        }

        [Fact]
        public void FindElementsThatDoesNotExist()
        {
            // Given
            var selector = By.JQuerySelector("div.mainNot");

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
            var selector = By.JQuerySelector("div");

            // When
            var element = root.FindElement(selector);

            // Then
            Assert.NotNull(element);
        }

        [Fact]
        public void FindInnerElements()
        {
            // Given
            var root = this.Browser.FindElement(By.JQuerySelector("body"));
            var selector = By.JQuerySelector("div");

            // When
            var elements = root.FindElements(selector);

            // Then
            Assert.Equal(2, elements.Count);
        }

        [Fact]
        public void ExpectedConditionsSupport()
        {
            // Given
            var condition = ExpectedConditions.ElementIsVisible(By.JQuerySelector("h1"));

            // When
            var wait = new WebDriverWait(this.Browser, TimeSpan.FromSeconds(3));
            wait.Until(condition);

            // Then
            Assert.True(true);
        }

        [Fact]
        public void PageObjectsSupport()
        {
            // Given
            var page = new TestPage(this.Browser);

            // When
            PageFactory.InitElements(this.Browser, page);

            // Then
            Assert.NotNull(page.HeadingJQuery);
            Assert.Equal("H1 Header", page.HeadingJQuery.Text.Trim());
        }
    }
}
