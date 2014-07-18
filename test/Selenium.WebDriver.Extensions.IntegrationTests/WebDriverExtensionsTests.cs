namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using By = Selenium.WebDriver.Extensions.By;

    /// <summary>
    /// JQuery selector tests.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsTests
    {
        /// <summary>
        /// Gets or sets the selenium web driver.
        /// </summary>
        private IWebDriver Browser { get; set; }
        
        /// <summary>
        /// Sets up the test fixture.
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            this.Browser = new FirefoxDriver();
            
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo == null)
            {
                return;
            }

            var uri = new Uri(directoryInfo.FullName + Path.DirectorySeparatorChar + "TestCase.html");
            this.Browser.Navigate().GoToUrl(uri.AbsoluteUri);
        }

        /// <summary>
        /// Tears down the test fixture.
        /// </summary>
        [TestFixtureTearDown]
        public void TearDown()
        {
            this.Browser.Dispose();
        }

        /// <summary>
        /// Tests finding element by ID.
        /// </summary>
        [Test]
        public void FindDivById()
        {
            var element = this.Browser.FindElement(By.JQuerySelector("#id1"));
            Assert.IsNotNull(element);
        }

        /// <summary>
        /// Tests finding element by ID that doesn't exist.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindDivByIdThatDoesntExist()
        {
            this.Browser.FindElement(By.JQuerySelector("#id2"));
        }

        /// <summary>
        /// Tests finding element by class.
        /// </summary>
        [Test]
        public void FindDivByClass()
        {
            var elements = this.Browser.FindElements(By.JQuerySelector("div.main"));
            Assert.AreEqual(2, elements.Count);
        }

        /// <summary>
        /// Tests finding element by class that doesn't exist.
        /// </summary>
        [Test]
        public void FindDivByClassThatDoesntExist()
        {
            var elements = this.Browser.FindElements(By.JQuerySelector("div.main1"));
            Assert.AreEqual(0, elements.Count);
        }
    }
}
