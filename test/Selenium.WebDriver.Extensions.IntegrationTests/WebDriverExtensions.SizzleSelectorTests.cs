namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;
    using Selenium.WebDriver.Extensions.Shared;
    using Selenium.WebDriver.Extensions.Sizzle;
    using By = Selenium.WebDriver.Extensions.By;

    /// <summary>
    /// Sizzle selector tests.
    /// </summary>
    /// <remarks>
    /// In order for IE tests to run it must allow local files to use scripts. You can enable that by going to
    /// Tools > Internet Options > Advanced > Security > Allow active content to run in files on My Computer.
    /// </remarks>
    [TestFixture("https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/642465fff703167db9516f24330f8413916524e5/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/Sizzle/Loaded.html")]
    [TestFixture("https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/642465fff703167db9516f24330f8413916524e5/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/Sizzle/Unloaded.html")]
    [Category("Integration Tests")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsSizzleSelectorTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverExtensionsSizzleSelectorTests"/> class.
        /// </summary>
        /// <param name="testCaseUrl">The test case URL.</param>
        public WebDriverExtensionsSizzleSelectorTests(string testCaseUrl)
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
            var phantomJsService = PhantomJSDriverService.CreateDefaultService();
            phantomJsService.SslProtocol = "any";
            this.Browser = new PhantomJSDriver(phantomJsService);
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
            var element = this.Browser.FindElement(By.SizzleSelector("#id1"));
            Assert.IsNotNull(element);
        }

        /// <summary>
        /// Tests finding element by ID.
        /// </summary>
        [Test]
        public void FindElementPath()
        {
            var element = this.Browser.FindElement(By.SizzleSelector("#id1"));
            var path = element.GetPath();
            Assert.AreEqual("body > div#id1", path);
        }

        /// <summary>
        /// Tests finding element by ID that doesn't exist.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementThatDoesntExist()
        {
            this.Browser.FindElement(By.SizzleSelector("#id-not"));
        }

        /// <summary>
        /// Tests finding element by class.
        /// </summary>
        [Test]
        public void FindElements()
        {
            var elements = this.Browser.FindElements(By.SizzleSelector("div.main"));
            Assert.AreEqual(2, elements.Count);
        }

        /// <summary>
        /// Tests finding element by class that doesn't exist.
        /// </summary>
        [Test]
        public void FindElementsThatDoesntExist()
        {
            var elements = this.Browser.FindElements(By.SizzleSelector("div.mainNot"));
            Assert.AreEqual(0, elements.Count);
        }
    }
}
