namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    using Selenium.WebDriver.Extensions.IntegrationTests.Utils;
    using By = Selenium.WebDriver.Extensions.By;

    [TestFixture(
        WebBrowser.PhantomJs, 
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/cc9834d8c6b17beb3f8e2b70ef96e8317785aa71/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/QuerySelector/TestCase.html")]
    [TestFixture(
        WebBrowser.Chrome,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/cc9834d8c6b17beb3f8e2b70ef96e8317785aa71/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/QuerySelector/TestCase.html")]
    [TestFixture(
        WebBrowser.InternetExplorer,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/cc9834d8c6b17beb3f8e2b70ef96e8317785aa71/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/QuerySelector/TestCase.html")]
    [TestFixture(
        WebBrowser.Firefox,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/cc9834d8c6b17beb3f8e2b70ef96e8317785aa71/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/QuerySelector/TestCase.html")]
    [Category("Integration Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsCoreTests
    {
        public WebDriverExtensionsCoreTests(WebBrowser driver, string testCaseUrl)
        {
            this.Driver = driver;
            this.TestCaseUrl = testCaseUrl;
        }

        private string TestCaseUrl { get; set; }

        private WebBrowser Driver { get; set; }

        private IWebDriver Browser { get; set; }

        [TestFixtureSetUp]
        public void SetUp()
        {
            this.Browser = SetupUtil.ConfigureDriver(this.Driver, this.TestCaseUrl);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            this.Browser.Dispose();
        }

        [Test]
        public void FindMixedJQuerySizzleElement()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var element = root.FindElement(By.SizzleSelector("span"));
            Assert.IsNotNull(element);
        }

        [Test]
        public void FindMixedJQuerySizzleElements()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var elements = root.FindElements(By.SizzleSelector("span"));
            Assert.AreEqual(2, elements.Count);
        }

        [Test]
        public void FindMixedJQueryQuerySelectorElement()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var element = root.FindElement(By.QuerySelector("span"));
            Assert.IsNotNull(element);
        }

        [Test]
        public void FindMixedJQueryQuerySelectorElements()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var elements = root.FindElements(By.QuerySelector("span"));
            Assert.AreEqual(2, elements.Count);
        }

        [Test]
        public void FindMixedSizzleJQuerySelectorElement()
        {
            var root = this.Browser.FindElement(By.SizzleSelector("#id1"));
            var element = root.FindElement(By.JQuerySelector("span"));
            Assert.IsNotNull(element);
        }

        [Test]
        public void FindMixedSizzleQuerySelectorElements()
        {
            var root = this.Browser.FindElement(By.SizzleSelector("#id1"));
            var elements = root.FindElements(By.QuerySelector("span"));
            Assert.AreEqual(2, elements.Count);
        }

        [Test]
        public void FindMixedQuerySelectorJQueryElement()
        {
            var root = this.Browser.FindElement(By.QuerySelector("#id1"));
            var element = root.FindElement(By.JQuerySelector("span"));
            Assert.IsNotNull(element);
        }

        [Test]
        public void FindMixedQuerySelectorSizzleElements()
        {
            var root = this.Browser.FindElement(By.QuerySelector("#id1"));
            var elements = root.FindElements(By.SizzleSelector("span"));
            Assert.AreEqual(2, elements.Count);
        }
    }
}
