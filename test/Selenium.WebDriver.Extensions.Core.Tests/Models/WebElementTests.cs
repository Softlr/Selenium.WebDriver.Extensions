namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using Moq;
    using OpenQA.Selenium;
    using Xunit;

    [Trait("Category", "Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebElementTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenFindingElementWithNullSelector()
        {
            var webElement = new Mock<IWebElement>();
            var selector = new Mock<ISelector>();
            var element = new WebElement(webElement.Object, selector.Object);
            Assert.Throws<ArgumentNullException>(() => element.FindElement((ISelector)null));
        }

        [Fact]
        public void ShouldThrowExceptionWhenFindingElementsWithNullSelector()
        {
            var webElement = new Mock<IWebElement>();
            var selector = new Mock<ISelector>();
            var element = new WebElement(webElement.Object, selector.Object);
            Assert.Throws<ArgumentNullException>(() => element.FindElements((ISelector)null));
        }
    }
}
