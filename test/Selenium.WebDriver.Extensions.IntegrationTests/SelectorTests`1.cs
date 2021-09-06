namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Xunit;
    using static By;
    using static Softlr.Suppress;
    using static Tests.Shared.Trait;
    using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

    [Trait(CATEGORY, INTEGRATION)]
    [ExcludeFromCodeCoverage]
    [SuppressMessage(SONARQUBE, S109)]
    public class SelectorTests<TSelector> : TestsBase
        where TSelector : By
    {
        private readonly Func<string, TSelector> _selectorAccessor;

        protected SelectorTests(FixtureBase fixture, string path, Func<string, TSelector> selectorAccessor)
            : base(fixture, path) => _selectorAccessor = selectorAccessor;

        [Fact]
        public void Driver_doesnt_find_elements_with_invalid_selector()
        {
            var sut = _selectorAccessor.Invoke("div.mainNot");
            var elements = Browser.FindElements(sut);

            elements.Should().NotBeNull().And.HaveCount(0);
        }

        [Fact]
        public void Driver_finds_element_with_selector()
        {
            var sut = _selectorAccessor.Invoke("#id1");
            var element = Browser.FindElement(sut);

            element.Should().NotBeNull();
        }

        [Fact]
        public void Driver_finds_inner_element_with_selector()
        {
            var root = Browser.FindElement(CssSelector("body"));
            var sut = _selectorAccessor.Invoke("div");
            var element = root.FindElement(sut);

            element.Should().NotBeNull();
        }

        [Fact]
        public void Driver_finds_multiple_elements_with_selector()
        {
            var sut = _selectorAccessor.Invoke("div.main");
            var elements = Browser.FindElements(sut);

            elements.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Driver_finds_multiple_inner_elements_with_selector()
        {
            var root = Browser.FindElement(_selectorAccessor.Invoke("body"));
            var sut = _selectorAccessor.Invoke("div");
            var elements = root.FindElements(sut);

            elements.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Driver_throws_exception_finding_element_with_invalid_selector()
        {
            var sut = _selectorAccessor.Invoke("#id-not");

            FluentActions.Invoking(() => Browser.FindElement(sut)).Should().Throw<NoSuchElementException>();
        }

        [Fact]
        public void Driver_waits_until_expected_condition_is_met()
        {
            var condition = ExpectedConditions.ElementIsVisible(
                _selectorAccessor.Invoke("h1"));

            var wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(3));
            wait.Until(condition);

            var element = Browser.FindElement(_selectorAccessor.Invoke("h1"));
            element.Should().NotBeNull();
        }
    }
}
