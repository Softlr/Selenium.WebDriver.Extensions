namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    using Selenium.WebDriver.Extensions.IntegrationTests.Utils;
    using Selenium.WebDriver.Extensions.JQuery;
    using By = Selenium.WebDriver.Extensions.By;
    [TestFixture(
        WebBrowser.PhantomJs,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/63d90edf0560889e753b5fa464f7bf825ee39168/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/JQuery/Loaded.html")]
    [TestFixture(
        WebBrowser.Chrome,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/63d90edf0560889e753b5fa464f7bf825ee39168/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/JQuery/Loaded.html")]
    [TestFixture(
        WebBrowser.InternetExplorer,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/63d90edf0560889e753b5fa464f7bf825ee39168/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/JQuery/Loaded.html")]
    [TestFixture(
        WebBrowser.Firefox,
        "https://cdn.rawgit.com/RaYell/selenium-webdriver-extensions/63d90edf0560889e753b5fa464f7bf825ee39168/test/Selenium.WebDriver.Extensions.IntegrationTests/TestCases/JQuery/Loaded.html")]
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
    public class WebDriverExtensionsJQuerySelectorTests
    {
        public WebDriverExtensionsJQuerySelectorTests(WebBrowser driver, string testCaseUrl)
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
            var element = this.Browser.FindElement(By.JQuerySelector("#id1"));
            Assert.IsNotNull(element);
        }

        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementThatDoesntExist()
        {
            this.Browser.FindElement(By.JQuerySelector("#id-not"));
        }

        [Test]
        public void FindElements()
        {
            var elements = this.Browser.FindElements(By.JQuerySelector("div.main"));
            Assert.AreEqual(2, elements.Count);
        }

        [Test]
        public void FindElementsThatDoesntExist()
        {
            var elements = this.Browser.FindElements(By.JQuerySelector("div.mainNot"));
            Assert.AreEqual(0, elements.Count);
        }

        [Test]
        public void FindText()
        {
            var text = this.Browser.JQuery("#id1").Text();
            var trimmedText = text.Replace(Environment.NewLine, string.Empty).Trim();
            StringAssert.StartsWith("jQuery", trimmedText);
            StringAssert.EndsWith("Selenium", trimmedText);
        }

        [Test]
        public void FindHtml()
        {
            var text = this.Browser.JQuery("#id1").Html();
            var trimmedText = text.Replace(Environment.NewLine, string.Empty).Trim();
            StringAssert.StartsWith("<span>jQuery</span>", trimmedText);
            StringAssert.EndsWith("<span>Selenium</span>", trimmedText);
        }

        [Test]
        public void FindAttribute()
        {
            var attribute = this.Browser.JQuery("input:first").Attribute("type");
            Assert.AreEqual("checkbox", attribute);
        }

        [Test]
        public void FindAttributeThatDoesntExist()
        {
            var attribute = this.Browser.JQuery("input:first").Attribute("typeNot");
            Assert.IsNull(attribute);
        }

        [Test]
        public void FindProperty()
        {
            var property = this.Browser.JQuery("input:first").Property("checked");
            Assert.IsNotNull(property);
            Assert.IsTrue(property.Value);
        }

        [Test]
        public void FindPropertyThatDoesntExist()
        {
            var property = this.Browser.JQuery("input:first").Property("checkedNot");
            Assert.IsNull(property);
        }

        [Test]
        public void FindValue()
        {
            var value = this.Browser.JQuery("input:first").Value();
            Assert.AreEqual("v1", value);
        }

        [Test]
        public void FindValueThatDoesntExist()
        {
            var value = this.Browser.JQuery("form").Value();
            Assert.IsNullOrEmpty(value);
        }

        [Test]
        public void FindCss()
        {
            var value = this.Browser.JQuery("#id1").Css("background-color");
            Assert.AreEqual("rgb(0, 128, 0)", value);
        }

        [Test]
        public void FindCssThatDoesntExist()
        {
            var value = this.Browser.JQuery("#id1").Css("test");
            Assert.IsNull(value);
        }

        [Test]
        public void FindWidth()
        {
            var value = this.Browser.JQuery("h1").Width();
            Assert.AreEqual(200, value);
        }

        [Test]
        public void FindHeight()
        {
            var value = this.Browser.JQuery("h1").Height();
            Assert.AreEqual(20, value);
        }

        [Test]
        public void FindInnerWidth()
        {
            var value = this.Browser.JQuery("h1").InnerWidth();
            Assert.AreEqual(220, value);
        }

        [Test]
        public void FindInnerHeight()
        {
            var value = this.Browser.JQuery("h1").InnerHeight();
            Assert.AreEqual(40, value);
        }

        [Test]
        public void FindOuterWidth()
        {
            var value = this.Browser.JQuery("h1").OuterWidth();
            Assert.AreEqual(226, value);
        }

        [Test]
        public void FindOuterHeight()
        {
            var value = this.Browser.JQuery("h1").OuterHeight();
            Assert.AreEqual(46, value);
        }

        [Test]
        public void FindOuterWidthWithMargin()
        {
            var value = this.Browser.JQuery("h1").OuterWidth(true);
            Assert.AreEqual(236, value);
        }

        [Test]
        public void FindOuterHeightWithMargin()
        {
            var value = this.Browser.JQuery("h1").OuterHeight(true);
            Assert.AreEqual(56, value);
        }

        [Test]
        public void FindWidthThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").Width();
            Assert.IsNull(value);
        }

        [Test]
        public void FindHeightThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").Height();
            Assert.IsNull(value);
        }

        [Test]
        public void FindInnerWidthThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").InnerWidth();
            Assert.IsNull(value);
        }

        [Test]
        public void FindInnerHeightThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").InnerHeight();
            Assert.IsNull(value);
        }

        [Test]
        public void FindOuterWidthThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").OuterWidth();
            Assert.IsNull(value);
        }

        [Test]
        public void FindOuterHeightThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").OuterHeight();
            Assert.IsNull(value);
        }

        [Test]
        public void FindOuterWidthWithMarginThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").OuterWidth(true);
            Assert.IsNull(value);
        }

        [Test]
        public void FindOuterHeightWithMarginThatDoesntExist()
        {
            var value = this.Browser.JQuery("h6").OuterHeight(true);
            Assert.IsNull(value);
        }

        [Test]
        public void FindPosition()
        {
            var position = this.Browser.JQuery("h1").Position();
            Assert.IsNotNull(position);
            Assert.AreEqual(3, position.Value.Top);
            Assert.AreEqual(8, position.Value.Left);
        }

        [Test]
        public void FindPositionThatDoesntExist()
        {
            var position = this.Browser.JQuery("h6").Position();
            Assert.IsNull(position);
        }

        [Test]
        public void FindOffset()
        {
            var position = this.Browser.JQuery("h1").Offset();
            Assert.IsNotNull(position);
            Assert.AreEqual(8, position.Value.Top);
            Assert.AreEqual(13, position.Value.Left);
        }

        [Test]
        public void FindOffsetThatDoesntExist()
        {
            var position = this.Browser.JQuery("h6").Offset();
            Assert.IsNull(position);
        }

        [Test]
        public void FindStringData()
        {
            var value = this.Browser.JQuery("form").Data("mystring");
            Assert.AreEqual("str", value);
        }

        [Test]
        public void FindIntegerData()
        {
            var value = this.Browser.JQuery("form").Data<long?>("myint");
            Assert.AreEqual(123, value);
        }

        [Test]
        public void FindBooleanData()
        {
            var value = this.Browser.JQuery("form").Data<bool?>("mybool");
            Assert.IsNotNull(value);
            Assert.IsTrue(value.Value);
        }

        [Test]
        public void FindScrollTop()
        {
            var scroll = this.Browser.JQuery("div.scroll").ScrollTop();
            Assert.IsNotNull(scroll);
            Assert.AreEqual(100, scroll);
        }

        [Test]
        public void FindScrollLeft()
        {
            var scroll = this.Browser.JQuery("div.scroll").ScrollLeft();
            Assert.IsNotNull(scroll);
            Assert.AreEqual(200, scroll);
        }

        [Test]
        public void FindCount()
        {
            var count = this.Browser.JQuery("div.main").Count();
            Assert.AreEqual(2, count);
        }

        [Test]
        public void FindCountThatDoesntExist()
        {
            var count = this.Browser.JQuery("div.mainNot").Count();
            Assert.AreEqual(0, count);
        }

        [Test]
        public void FindSerialized()
        {
            var value = this.Browser.JQuery("form").Serialized();
            Assert.AreEqual("i1=v1&i3=v3", value);
        }

        [Test]
        public void FindSerializedThatDoesntExist()
        {
            var value = this.Browser.JQuery("form.test").Serialized();
            Assert.IsEmpty(value);
        }

        [Test]
        public void FindSerializedArray()
        {
            var value = this.Browser.JQuery("form").SerializedArray();
            Assert.AreEqual("[{\"name\":\"i1\",\"value\":\"v1\"},{\"name\":\"i3\",\"value\":\"v3\"}]", value);
        }

        [Test]
        public void FindSerializedArrayThatDoesntExist()
        {
            var value = this.Browser.JQuery("form.test").SerializedArray();
            Assert.AreEqual("[]", value);
        }

        [Test]
        public void FindElementPath()
        {
            var element = this.Browser.FindElement(By.JQuerySelector("#id1"));
            Assert.AreEqual("body > div#id1", element.Path);
        }

        [Test]
        public void FindInnerElement()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var element = root.FindElement(By.JQuerySelector("span"));
            Assert.IsNotNull(element);
        }

        [Test]
        public void FindInnerElements()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var elements = root.FindElements(By.JQuerySelector("span"));
            Assert.AreEqual(2, elements.Count);
        }
    }
}
