namespace Selenium.WebDriver.Extensions.IntegrationTests.Tests
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
            var selector = By.SizzleSelector("#id1");

            var element = Browser.FindElement(selector);

            element.Should().NotBeNull();
        }

        [Fact]
        public void FindElementThatDoesNotExist()
        {
            var selector = By.SizzleSelector("#id-not");

            Action action = () => Browser.FindElement(selector);

            action.ShouldThrow<NoSuchElementException>();
        }

        [Fact]
        public void FindElements()
        {
            var selector = By.SizzleSelector("div.main");

            var elements = Browser.FindElements(selector);

            elements.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void FindElementsThatDoesNotExist()
        {
            var selector = By.SizzleSelector("div.mainNot");

            var elements = Browser.FindElements(selector);

            elements.Should().NotBeNull().And.HaveCount(0);
        }

        [Fact]
        public void FindInnerElement()
        {
            var root = Browser.FindElement(By.CssSelector("body"));
            var selector = By.SizzleSelector("div");

            var element = root.FindElement(selector);

            element.Should().NotBeNull();
        }

        [Fact]
        public void FindInnerElements()
        {
            var root = Browser.FindElement(By.SizzleSelector("body"));
            var selector = By.SizzleSelector("h1");

            var elements = root.FindElements(selector);

            elements.Should().NotBeNull().And.HaveCount(1);
        }

        [Fact]
        public void ExpectedConditionsSupport()
        {
            var condition = ExpectedConditions.ElementIsVisible(By.SizzleSelector("h1"));

            var wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(3));
            wait.Until(condition);

            true.Should().BeTrue(); // assert pass
        }

        [Fact]
        public void PageObjectsSupport()
        {
            var page = new TestPage(Browser);

            PageFactory.InitElements(Browser, page);

            page.HeadingJQuery.Should().NotBeNull();
            page.HeadingJQuery.Text.Trim().Should().Be("H1 Header");
        }
    }
}