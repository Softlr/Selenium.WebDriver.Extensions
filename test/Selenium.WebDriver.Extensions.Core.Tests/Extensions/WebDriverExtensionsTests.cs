namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using Moq;
    using NUnit.Framework;
    using OpenQA.Selenium;

    /// <summary>
    /// Web driver extensions tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsTests
    {
        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementDriverNull()
        {
            WebDriverExtensions.FindElement(null, null);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementSelectorNull()
        {
            var driver = new Mock<IWebDriver>();
            WebDriverExtensions.FindElement(driver.Object, null);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementsDriverNull()
        {
            WebDriverExtensions.FindElements(null, null);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementsSelectorNull()
        {
            var driver = new Mock<IWebDriver>();
            WebDriverExtensions.FindElements(driver.Object, null);
        }
    }
}
