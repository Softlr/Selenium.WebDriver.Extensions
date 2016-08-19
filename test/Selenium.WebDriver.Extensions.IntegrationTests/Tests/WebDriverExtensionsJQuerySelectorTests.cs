namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;
    using Xunit;
    using By = OpenQA.Selenium.Extensions.By;

    [ExcludeFromCodeCoverage]
    public abstract class WebDriverExtensionsJQuerySelectorTests : TestsBase
    {
        [Fact]
        public void FindElement()
        {
            // Given
            var selector = By.JQuerySelector("#id1");

            // When
            var element = Browser.FindElement(selector);

            // Then
            element.Should().NotBeNull();
        }

        [Fact]
        public void FindElementThatDoesNotExist()
        {
            // Given
            var selector = By.JQuerySelector("#id-not");

            // When
            Action action = () => Browser.FindElement(selector);

            // Then
            action.ShouldThrow<NoSuchElementException>();
        }

        [Fact]
        public void FindElements()
        {
            // Given
            var selector = By.JQuerySelector("div.main");

            // When
            var elements = Browser.FindElements(selector);

            // Then
            elements.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void FindElementsThatDoesNotExist()
        {
            // Given
            var selector = By.JQuerySelector("div.mainNot");

            // When
            var elements = Browser.FindElements(selector);

            // Then
            elements.Should().NotBeNull().And.HaveCount(0);
        }

        [Fact]
        public void FindInnerElement()
        {
            // Given
            var root = Browser.FindElement(By.CssSelector("body"));
            var selector = By.JQuerySelector("div");

            // When
            var element = root.FindElement(selector);

            // Then
            element.Should().NotBeNull();
        }

        [Fact]
        public void FindInnerElements()
        {
            // Given
            var root = Browser.FindElement(By.JQuerySelector("body"));
            var selector = By.JQuerySelector("div");

            // When
            var elements = root.FindElements(selector);

            // Then
            elements.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void ExpectedConditionsSupport()
        {
            // Given
            var condition = ExpectedConditions.ElementIsVisible(By.JQuerySelector("h1"));

            // When
            var wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(3));
            wait.Until(condition);

            // Then
            true.Should().BeTrue(); // assert pass
        }

        [Fact]
        public void PageObjectsSupport()
        {
            // Given
            var page = new TestPage(Browser);

            // When
            PageFactory.InitElements(Browser, page);

            // Then
            page.HeadingJQuery.Should().NotBeNull();
            page.HeadingJQuery.Text.Trim().Should().Be("H1 Header");
        }
    }
}
