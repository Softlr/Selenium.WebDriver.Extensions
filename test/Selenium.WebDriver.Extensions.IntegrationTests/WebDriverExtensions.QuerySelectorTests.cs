namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;
    using Selenium.WebDriver.Extensions.QuerySelector;
    using By = Selenium.WebDriver.Extensions.By;

    /// <summary>
    /// Query selector tests.
    /// </summary>
    /// <remarks>
    /// In order for IE tests to run it must allow local files to use scripts. You can enable that by going to
    /// Tools > Internet Options > Advanced > Security > Allow active content to run in files on My Computer.
    /// </remarks>
    [TestFixture("https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/642465fff703167db9516f24330f8413916524e5/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/QuerySelector/TestCase.html")]
    [Category("Integration Tests")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsQuerySelectorTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverExtensionsQuerySelectorTests"/> class.
        /// </summary>
        /// <param name="testCaseUrl">The test case URL.</param>
        public WebDriverExtensionsQuerySelectorTests(string testCaseUrl)
        {
            this.TestCaseUrl = testCaseUrl;
        }

        /// <summary>
        /// Gets or sets the test case URL.
        /// </summary>
        private string TestCaseUrl { get; set; }

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
            this.Browser = new PhantomJSDriver();
            this.Browser.Navigate().GoToUrl(this.TestCaseUrl);
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
        public void FindElement()
        {
            var element = this.Browser.FindElement(By.QuerySelector("#id1"));
            Assert.IsNotNull(element);
        }

        /// <summary>
        /// Tests finding element by ID that doesn't exist.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementThatDoesntExist()
        {
            this.Browser.FindElement(By.QuerySelector("#id-not"));
        }

        /// <summary>
        /// Tests finding element by class.
        /// </summary>
        [Test]
        public void FindElements()
        {
            var elements = this.Browser.FindElements(By.QuerySelector("div.main"));
            Assert.AreEqual(2, elements.Count);
        }

        /// <summary>
        /// Tests finding element by class that doesn't exist.
        /// </summary>
        [Test]
        public void FindElementsThatDoesntExist()
        {
            var elements = this.Browser.FindElements(By.QuerySelector("div.mainNot"));
            Assert.AreEqual(0, elements.Count);
        }
    }
}
