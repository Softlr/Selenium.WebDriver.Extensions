namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.By;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public abstract class WebDriverExtensionsCoreTests : TestsBase
    {
        [Fact]
        public void FindMixedJQuerySizzleElement()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var element = root.FindElement(By.SizzleSelector("span"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindMixedJQuerySizzleElements()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var elements = root.FindElements(By.SizzleSelector("span"));
            Assert.Equal(2, elements.Count);
        }

        [Fact]
        public void FindMixedJQueryQuerySelectorElement()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var element = root.FindElement(By.QuerySelector("span"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindMixedJQueryQuerySelectorElements()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var elements = root.FindElements(By.QuerySelector("span"));
            Assert.Equal(2, elements.Count);
        }

        [Fact]
        public void FindMixedSizzleJQuerySelectorElement()
        {
            var root = this.Browser.FindElement(By.SizzleSelector("#id1"));
            var element = root.FindElement(By.JQuerySelector("span"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindMixedSizzleQuerySelectorElements()
        {
            var root = this.Browser.FindElement(By.SizzleSelector("#id1"));
            var elements = root.FindElements(By.QuerySelector("span"));
            Assert.Equal(2, elements.Count);
        }

        [Fact]
        public void FindMixedQuerySelectorJQueryElement()
        {
            var root = this.Browser.FindElement(By.QuerySelector("#id1"));
            var element = root.FindElement(By.JQuerySelector("span"));
            Assert.NotNull(element);
        }

        [Fact]
        public void FindMixedQuerySelectorSizzleElements()
        {
            var root = this.Browser.FindElement(By.QuerySelector("#id1"));
            var elements = root.FindElements(By.SizzleSelector("span"));
            Assert.Equal(2, elements.Count);
        }
    }
}
