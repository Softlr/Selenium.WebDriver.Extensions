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
    public class WebDriverExtensionsQuerySelectorTests
    {
        public WebDriverExtensionsQuerySelectorTests(WebBrowser driver, string testCaseUrl)
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
        public void FindElement()
        {
            var element = this.Browser.FindElement(By.QuerySelector("#id1"));
            Assert.IsNotNull(element);
        }

        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementThatDoesntExist()
        {
            this.Browser.FindElement(By.QuerySelector("#id-not"));
        }

        [Test]
        public void FindElements()
        {
            var elements = this.Browser.FindElements(By.QuerySelector("div.main"));
            Assert.AreEqual(2, elements.Count);
        }

        [Test]
        public void FindElementsThatDoesntExist()
        {
            var elements = this.Browser.FindElements(By.QuerySelector("div.mainNot"));
            Assert.AreEqual(0, elements.Count);
        }

        [Test]
        public void FindElementPath()
        {
            var element = this.Browser.FindElement(By.QuerySelector("#id1"));
            Assert.AreEqual("body > div#id1", element.Path);
        }

        [Test]
        public void FindInnerElement()
        {
            var root = this.Browser.FindElement(By.QuerySelector("#id1"));
            var element = root.FindElement(By.QuerySelector("span"));
            Assert.IsNotNull(element);
        }

        [Test]
        public void FindInnerElements()
        {
            var root = this.Browser.FindElement(By.QuerySelector("#id1"));
            var elements = root.FindElements(By.QuerySelector("span"));
            Assert.AreEqual(2, elements.Count);
        }
    }
}
