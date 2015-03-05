namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using Moq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebElementTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementSelectorNull()
        {
            var webElement = new Mock<IWebElement>();
            var selector = new Mock<ISelector>();
            var element = new WebElement(webElement.Object, selector.Object);
            element.FindElement((ISelector)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementsSelectorNull()
        {
            var webElement = new Mock<IWebElement>();
            var selector = new Mock<ISelector>();
            var element = new WebElement(webElement.Object, selector.Object);
            element.FindElements((ISelector)null);
        }
    }
}
