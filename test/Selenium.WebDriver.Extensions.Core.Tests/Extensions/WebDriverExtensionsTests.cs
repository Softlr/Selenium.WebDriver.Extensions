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
            Shared.WebDriverExtensions.FindElement(null, null);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementSelectorNull()
        {
            var driver = new Mock<IWebDriver>();
            Shared.WebDriverExtensions.FindElement(driver.Object, null);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementsDriverNull()
        {
            Shared.WebDriverExtensions.FindElements(null, null);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementsSelectorNull()
        {
            var driver = new Mock<IWebDriver>();
            Shared.WebDriverExtensions.FindElements(driver.Object, null);
        }
    }
}
