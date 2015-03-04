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
    public class WebDriverExtensionsTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementDriverNull()
        {
            WebDriverExtensions.FindElement(null, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementSelectorNull()
        {
            var driver = new Mock<IWebDriver>();
            WebDriverExtensions.FindElement(driver.Object, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementsDriverNull()
        {
            WebDriverExtensions.FindElements(null, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementsSelectorNull()
        {
            var driver = new Mock<IWebDriver>();
            WebDriverExtensions.FindElements(driver.Object, null);
        }
    }
}
