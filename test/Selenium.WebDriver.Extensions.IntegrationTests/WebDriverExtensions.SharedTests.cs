namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;
    using Selenium.WebDriver.Extensions.JQuery;
    using Selenium.WebDriver.Extensions.QuerySelector;
    using Selenium.WebDriver.Extensions.Sizzle;
    using By = Selenium.WebDriver.Extensions.By;

    /// <summary>
    /// Shared selector tests.
    /// </summary>
    /// <remarks>
    /// In order for IE tests to run it must allow local files to use scripts. You can enable that by going to
    /// Tools > Internet Options > Advanced > Security > Allow active content to run in files on My Computer.
    /// </remarks>
    [TestFixture("https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/cc9834d8c6b17beb3f8e2b70ef96e8317785aa71/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/QuerySelector/TestCase.html")]
    [Category("Integration Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsSharedTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverExtensionsSharedTests"/> class.
        /// </summary>
        /// <param name="testCaseUrl">The test case URL.</param>
        public WebDriverExtensionsSharedTests(string testCaseUrl)
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
        /// Tests finding element.
        /// </summary>
        [Test]
        public void FindMixedJQuerySizzleElement()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var element = root.FindElement(By.SizzleSelector("span"));
            Assert.IsNotNull(element);
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindMixedJQuerySizzleElements()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var elements = root.FindElements(By.SizzleSelector("span"));
            Assert.AreEqual(2, elements.Count);
        }

        /// <summary>
        /// Tests finding element.
        /// </summary>
        [Test]
        public void FindMixedJQueryQuerySelectorElement()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var element = root.FindElement(By.QuerySelector("span"));
            Assert.IsNotNull(element);
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindMixedJQueryQuerySelectorElements()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var elements = root.FindElements(By.QuerySelector("span"));
            Assert.AreEqual(2, elements.Count);
        }

        /// <summary>
        /// Tests finding element.
        /// </summary>
        [Test]
        public void FindMixedSizzleJQuerySelectorElement()
        {
            var root = this.Browser.FindElement(By.SizzleSelector("#id1"));
            var element = root.FindElement(By.JQuerySelector("span"));
            Assert.IsNotNull(element);
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindMixedSizzleQuerySelectorElements()
        {
            var root = this.Browser.FindElement(By.SizzleSelector("#id1"));
            var elements = root.FindElements(By.QuerySelector("span"));
            Assert.AreEqual(2, elements.Count);
        }

        /// <summary>
        /// Tests finding element.
        /// </summary>
        [Test]
        public void FindMixedQuerySelectorJQueryElement()
        {
            var root = this.Browser.FindElement(By.QuerySelector("#id1"));
            var element = root.FindElement(By.JQuerySelector("span"));
            Assert.IsNotNull(element);
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindMixedQuerySelectorSizzleElements()
        {
            var root = this.Browser.FindElement(By.QuerySelector("#id1"));
            var elements = root.FindElements(By.SizzleSelector("span"));
            Assert.AreEqual(2, elements.Count);
        }
    }
}
