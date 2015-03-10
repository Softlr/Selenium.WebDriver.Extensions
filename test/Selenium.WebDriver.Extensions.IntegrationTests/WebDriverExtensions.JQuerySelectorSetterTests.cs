namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.IntegrationTests.Utils;
    using Selenium.WebDriver.Extensions.JQuery;
    
    [TestFixture(
        WebBrowser.PhantomJs,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/b4fd6869d59572f5b84ccc4d5a817d0ac0acd6e8/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/JQuery/Loaded.html")]
    [TestFixture(
        WebBrowser.Chrome,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/b4fd6869d59572f5b84ccc4d5a817d0ac0acd6e8/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/JQuery/Loaded.html")]
    [TestFixture(
        WebBrowser.InternetExplorer,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/b4fd6869d59572f5b84ccc4d5a817d0ac0acd6e8/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/JQuery/Loaded.html")]
    [TestFixture(
        WebBrowser.Firefox,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/b4fd6869d59572f5b84ccc4d5a817d0ac0acd6e8/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/JQuery/Loaded.html")]
    [TestFixture(
        WebBrowser.PhantomJs, 
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/642465fff703167db9516f24330f8413916524e5/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/JQuery/Unloaded.html")]
    [TestFixture(
        WebBrowser.Chrome,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/642465fff703167db9516f24330f8413916524e5/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/JQuery/Unloaded.html")]
    [TestFixture(
        WebBrowser.InternetExplorer,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/642465fff703167db9516f24330f8413916524e5/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/JQuery/Unloaded.html")]
    [TestFixture(
        WebBrowser.Firefox,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/642465fff703167db9516f24330f8413916524e5/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/JQuery/Unloaded.html")]
    [Category("Integration Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsJQuerySelectorSetterTests
    {
        public WebDriverExtensionsJQuerySelectorSetterTests(WebBrowser driver, string testCaseUrl)
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
        public void ChangeText()
        {
            var result = this.Browser.JQuery("h1").Text("test").Text();

            Assert.AreEqual("test", result);
        }

        [Test]
        public void ChangeHtml()
        {
            var result = this.Browser.JQuery("h1").Html("<b>test</b>").Html();

            Assert.AreEqual("<b>test</b>", result);
        }

        [Test]
        public void ChangeAttribute()
        {
            var result = this.Browser.JQuery("h1").Attribute("foo", "bar").Attribute("foo");

            Assert.AreEqual("bar", result);
        }

        [Test]
        public void ChangeProperty()
        {
            var result = this.Browser.JQuery("input:checkbox").Property("checked", "checked").Property("checked");

            Assert.IsTrue(result.HasValue);
            Assert.IsTrue(result.Value);
        }

        [Test]
        public void ChangePropertyBool()
        {
            var result = this.Browser.JQuery("input:checkbox").Property("checked", true).Property("checked");

            Assert.IsTrue(result.HasValue);
            Assert.IsTrue(result.Value);
        }

        [Test]
        public void ChangeValue()
        {
            var result = this.Browser.JQuery("input:text").Value("test").Value();

            Assert.AreEqual("test", result);
        }

        [Test]
        public void ChangeCss()
        {
            var result = this.Browser.JQuery("h1").Css("font-family", "Arial").Css("font-family");

            Assert.AreEqual("Arial", result);
        }

        [Test]
        public void ChangeWidth()
        {
            var result = this.Browser.JQuery("div.scroll").Width(50).Width();

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(50, result.Value);
        }

        [Test]
        public void ChangeHeight()
        {
            var result = this.Browser.JQuery("div.scroll").Height(50).Height();

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(50, result.Value);
        }

        [Test]
        public void ChangeInnerWidth()
        {
            var result = this.Browser.JQuery("div.scroll").InnerWidth(50).InnerWidth();

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(50, result.Value);
        }

        [Test]
        public void ChangeInnerHeight()
        {
            var result = this.Browser.JQuery("div.scroll").InnerHeight(50).InnerHeight();

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(50, result.Value);
        }

        [Test]
        public void ChangeOuterWidth()
        {
            var result = this.Browser.JQuery("div.scroll").OuterWidth(50).OuterWidth();

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(50, result.Value);
        }

        [Test]
        public void ChangeOuterHeight()
        {
            var result = this.Browser.JQuery("div.scroll").OuterHeight(50).OuterHeight();

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(50, result.Value);
        }

        [Test]
        public void ChangeScrollLeft()
        {
            var result = this.Browser.JQuery("div.scroll").ScrollLeft(50).ScrollLeft();

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(50, result.Value);
        }

        [Test]
        public void ChangeScrollTop()
        {
            var result = this.Browser.JQuery("div.scroll").ScrollTop(50).ScrollTop();

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(50, result.Value);
        }

        [Test]
        public void ChangeData()
        {
            var result = this.Browser.JQuery("h1").Data("foo", "bar").Data("foo");

            Assert.AreEqual("bar", result);
        }

        [Test]
        public void RemoveData()
        {
            var result = this.Browser.JQuery("h1").Data("foo", "bar").RemoveData("foo").Data("foo");

            Assert.IsNull(result);
        }

        [Test]
        public void AddClass()
        {
            var result = this.Browser.JQuery("h1").AddClass("foo").HasClass("foo");

            Assert.IsTrue(result.HasValue);
            Assert.IsTrue(result.Value);
        }

        [Test]
        public void RemoveClass()
        {
            var result = this.Browser.JQuery("h1").AddClass("foo").RemoveClass("foo").HasClass("foo");

            Assert.IsTrue(result.HasValue);
            Assert.IsFalse(result.Value);
        }

        [Test]
        public void ToggleClass()
        {
            var result = this.Browser.JQuery("h1").AddClass("foo").ToggleClass("foo").HasClass("foo");

            Assert.IsTrue(result.HasValue);
            Assert.IsFalse(result.Value);

            result = this.Browser.JQuery("h1").ToggleClass("foo").HasClass("foo");

            Assert.IsTrue(result.HasValue);
            Assert.IsTrue(result.Value);
        }
    }
}
