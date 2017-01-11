namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.By;

    [ExcludeFromCodeCoverage]
    public abstract class WebDriverExtensionsSizzleSelectorTests : TestsBase
    {
        [Fact]
        public void FindElement()
        {
            // Arrange
            var selector = By.SizzleSelector("#id1");

            // Act
            var element = Browser.FindElement(selector);

            // Assert
            element.Should().NotBeNull();
        }

        [Fact]
        public void FindElementThatDoesNotExist()
        {
            // Arrange
            var selector = By.SizzleSelector("#id-not");

            // Act
            Action action = () => Browser.FindElement(selector);

            // Assert
            action.ShouldThrow<NoSuchElementException>();
        }

        [Fact]
        public void FindElements()
        {
            // Arrange
            var selector = By.SizzleSelector("div.main");

            // Act
            var elements = Browser.FindElements(selector);

            // Assert
            elements.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void FindElementsThatDoesNotExist()
        {
            // Arrange
            var selector = By.SizzleSelector("div.mainNot");

            // Act
            var elements = Browser.FindElements(selector);

            // Assert
            elements.Should().NotBeNull().And.HaveCount(0);
        }

        [Fact]
        public void FindInnerElement()
        {
            // Arrange
            var root = Browser.FindElement(By.CssSelector("body"));
            var selector = By.SizzleSelector("div");

            // Act
            var element = root.FindElement(selector);

            // Assert
            element.Should().NotBeNull();
        }

        [Fact]
        public void FindInnerElements()
        {
            // Arrange
            var root = Browser.FindElement(By.SizzleSelector("body"));
            var selector = By.SizzleSelector("h1");

            // Act
            var elements = root.FindElements(selector);

            // Assert
            elements.Should().NotBeNull().And.HaveCount(1);
        }

        [Fact]
        public void ExpectedConditionsSupport()
        {
            // Arrange
            var condition = ExpectedConditions.ElementIsVisible(By.SizzleSelector("h1"));

            // Act
            var wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(3));
            wait.Until(condition);

            // Assert
            true.Should().BeTrue(); // assert pass
        }

        [Fact]
        public void PageObjectsSupport()
        {
            // Arrange
            var page = new TestPage(Browser);

            // Act
            PageFactory.InitElements(Browser, page);

            // Assert
            page.HeadingJQuery.Should().NotBeNull();
            page.HeadingJQuery.Text.Trim().Should().Be("H1 Header");
        }
    }
}