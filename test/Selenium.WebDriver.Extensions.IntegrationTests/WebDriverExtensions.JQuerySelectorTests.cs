namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.IntegrationTests.Utils;
    using Selenium.WebDriver.Extensions.JQuery;
    using Selenium.WebDriver.Extensions.Shared;
    using By = Selenium.WebDriver.Extensions.By;

    /// <summary>
    /// JQuery selector tests.
    /// </summary>
    /// <remarks>
    /// In order for IE tests to run it must allow local files to use scripts. You can enable that by going to
    /// Tools > Internet Options > Advanced > Security > Allow active content to run in files on My Computer.
    /// </remarks>
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
        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverExtensionsJQuerySelectorTests"/> class.
        /// </summary>
        /// <param name="driver">The name of the driver used to run the tests.</param>
        /// <param name="testCaseUrl">The test case URL.</param>
        public WebDriverExtensionsJQuerySelectorTests(WebBrowser driver, string testCaseUrl)
        {
            this.Driver = driver;
            this.TestCaseUrl = testCaseUrl;
        }

        /// <summary>
        /// Gets or sets the test case URL.
        /// </summary>
        private string TestCaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the driver name.
        /// </summary>
        private WebBrowser Driver { get; set; }

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
            this.Browser = SetupUtil.ConfigureDriver(this.Driver, this.TestCaseUrl);
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
            var element = this.Browser.FindElement(By.JQuerySelector("#id1"));
            Assert.IsNotNull(element);
        }

        /// <summary>
        /// Tests finding element by ID that doesn't exist.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementThatDoesntExist()
        {
            this.Browser.FindElement(By.JQuerySelector("#id-not"));
        }

        /// <summary>
        /// Tests finding element by class.
        /// </summary>
        [Test]
        public void FindElements()
        {
            var elements = this.Browser.FindElements(By.JQuerySelector("div.main"));
            Assert.AreEqual(2, elements.Count);
        }

        /// <summary>
        /// Tests finding element by class that doesn't exist.
        /// </summary>
        [Test]
        public void FindElementsThatDoesntExist()
        {
            var elements = this.Browser.FindElements(By.JQuerySelector("div.mainNot"));
            Assert.AreEqual(0, elements.Count);
        }

        /// <summary>
        /// Tests finding element text.
        /// </summary>
        [Test]
        public void FindText()
        {
            var text = this.Browser.JQuery(By.JQuerySelector("#id1")).Text();
            var trimmedText = text.Replace(Environment.NewLine, string.Empty).Trim();
            StringAssert.StartsWith("jQuery", trimmedText);
            StringAssert.EndsWith("Selenium", trimmedText);
        }

        /// <summary>
        /// Tests finding element HTML.
        /// </summary>
        [Test]
        public void FindHtml()
        {
            var text = this.Browser.JQuery(By.JQuerySelector("#id1")).Html();
            var trimmedText = text.Replace(Environment.NewLine, string.Empty).Trim();
            StringAssert.StartsWith("<span>jQuery</span>", trimmedText);
            StringAssert.EndsWith("<span>Selenium</span>", trimmedText);
        }

        /// <summary>
        /// Tests finding element attribute.
        /// </summary>
        [Test]
        public void FindAttribute()
        {
            var attribute = this.Browser.JQuery(By.JQuerySelector("input:first")).Attribute("type");
            Assert.AreEqual("checkbox", attribute);
        }

        /// <summary>
        /// Tests finding element attribute that doesn't exist.
        /// </summary>
        [Test]
        public void FindAttributeThatDoesntExist()
        {
            var attribute = this.Browser.JQuery(By.JQuerySelector("input:first")).Attribute("typeNot");
            Assert.IsNull(attribute);
        }

        /// <summary>
        /// Tests finding element property.
        /// </summary>
        [Test]
        public void FindProperty()
        {
            var property = this.Browser.JQuery(By.JQuerySelector("input:first")).Property("checked");
            Assert.IsNotNull(property);
            Assert.IsTrue(property.Value);
        }

        /// <summary>
        /// Tests finding element property that doesn't exist.
        /// </summary>
        [Test]
        public void FindPropertyThatDoesntExist()
        {
            var property = this.Browser.JQuery(By.JQuerySelector("input:first")).Property("checkedNot");
            Assert.IsNull(property);
        }

        /// <summary>
        /// Tests finding element value.
        /// </summary>
        [Test]
        public void FindValue()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("input:first")).Value();
            Assert.AreEqual("v1", value);
        }

        /// <summary>
        /// Tests finding element value that doesn't exist.
        /// </summary>
        [Test]
        public void FindValueThatDoesntExist()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("form")).Value();
            Assert.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Tests finding element CSS.
        /// </summary>
        [Test]
        public void FindCss()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("#id1")).Css("background-color");
            Assert.AreEqual("rgb(0, 128, 0)", value);
        }

        /// <summary>
        /// Tests finding element CSS.
        /// </summary>
        [Test]
        public void FindCssThatDoesntExist()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("#id1")).Css("test");
            Assert.IsNull(value);
        }

        /// <summary>
        /// Tests finding element width.
        /// </summary>
        [Test]
        public void FindWidth()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h1")).Width();
            Assert.AreEqual(200, value);
        }

        /// <summary>
        /// Tests finding element height.
        /// </summary>
        [Test]
        public void FindHeight()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h1")).Height();
            Assert.AreEqual(20, value);
        }

        /// <summary>
        /// Tests finding element inner width.
        /// </summary>
        [Test]
        public void FindInnerWidth()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h1")).InnerWidth();
            Assert.AreEqual(220, value);
        }

        /// <summary>
        /// Tests finding element inner height.
        /// </summary>
        [Test]
        public void FindInnerHeight()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h1")).InnerHeight();
            Assert.AreEqual(40, value);
        }

        /// <summary>
        /// Tests finding element outer width.
        /// </summary>
        [Test]
        public void FindOuterWidth()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h1")).OuterWidth();
            Assert.AreEqual(226, value);
        }

        /// <summary>
        /// Tests finding element outer height.
        /// </summary>
        [Test]
        public void FindOuterHeight()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h1")).OuterHeight();
            Assert.AreEqual(46, value);
        }

        /// <summary>
        /// Tests finding element outer width with margin.
        /// </summary>
        [Test]
        public void FindOuterWidthWithMargin()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h1")).OuterWidth(true);
            Assert.AreEqual(236, value);
        }

        /// <summary>
        /// Tests finding element outer height with margin.
        /// </summary>
        [Test]
        public void FindOuterHeightWithMargin()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h1")).OuterHeight(true);
            Assert.AreEqual(56, value);
        }

        /// <summary>
        /// Tests finding element width that doesn't exist.
        /// </summary>
        [Test]
        public void FindWidthThatDoesntExist()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h6")).Width();
            Assert.IsNull(value);
        }

        /// <summary>
        /// Tests finding element height that doesn't exist.
        /// </summary>
        [Test]
        public void FindHeightThatDoesntExist()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h6")).Height();
            Assert.IsNull(value);
        }

        /// <summary>
        /// Tests finding element inner width that doesn't exist.
        /// </summary>
        [Test]
        public void FindInnerWidthThatDoesntExist()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h6")).InnerWidth();
            Assert.IsNull(value);
        }

        /// <summary>
        /// Tests finding element inner height that doesn't exist.
        /// </summary>
        [Test]
        public void FindInnerHeightThatDoesntExist()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h6")).InnerHeight();
            Assert.IsNull(value);
        }

        /// <summary>
        /// Tests finding element outer width that doesn't exist.
        /// </summary>
        [Test]
        public void FindOuterWidthThatDoesntExist()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h6")).OuterWidth();
            Assert.IsNull(value);
        }

        /// <summary>
        /// Tests finding element outer height that doesn't exist.
        /// </summary>
        [Test]
        public void FindOuterHeightThatDoesntExist()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h6")).OuterHeight();
            Assert.IsNull(value);
        }

        /// <summary>
        /// Tests finding element outer width with margin that doesn't exist.
        /// </summary>
        [Test]
        public void FindOuterWidthWithMarginThatDoesntExist()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h6")).OuterWidth(true);
            Assert.IsNull(value);
        }

        /// <summary>
        /// Tests finding element outer height with margin that doesn't exist.
        /// </summary>
        [Test]
        public void FindOuterHeightWithMarginThatDoesntExist()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("h6")).OuterHeight(true);
            Assert.IsNull(value);
        }

        /// <summary>
        /// Tests finding element position.
        /// </summary>
        [Test]
        public void FindPosition()
        {
            var position = this.Browser.JQuery(By.JQuerySelector("h1")).Position();
            Assert.IsNotNull(position);
            Assert.AreEqual(3, position.Value.Top);
            Assert.AreEqual(8, position.Value.Left);
        }

        /// <summary>
        /// Tests finding element position that doesn't exist.
        /// </summary>
        [Test]
        public void FindPositionThatDoesntExist()
        {
            var position = this.Browser.JQuery(By.JQuerySelector("h6")).Position();
            Assert.IsNull(position);
        }

        /// <summary>
        /// Tests finding element offset.
        /// </summary>
        [Test]
        public void FindOffset()
        {
            var position = this.Browser.JQuery(By.JQuerySelector("h1")).Offset();
            Assert.IsNotNull(position);
            Assert.AreEqual(8, position.Value.Top);
            Assert.AreEqual(13, position.Value.Left);
        }

        /// <summary>
        /// Tests finding element offset that doesn't exist.
        /// </summary>
        [Test]
        public void FindOffsetThatDoesntExist()
        {
            var position = this.Browser.JQuery(By.JQuerySelector("h6")).Offset();
            Assert.IsNull(position);
        }

        /// <summary>
        /// Tests finding element string data.
        /// </summary>
        [Test]
        public void FindStringData()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("form")).Data("mystring");
            Assert.AreEqual("str", value);
        }

        /// <summary>
        /// Tests finding element integer data.
        /// </summary>
        [Test]
        public void FindIntegerData()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("form")).Data<long?>("myint");
            Assert.AreEqual(123, value);
        }

        /// <summary>
        /// Tests finding element boolean data.
        /// </summary>
        [Test]
        public void FindBooleanData()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("form")).Data<bool?>("mybool");
            Assert.IsNotNull(value);
            Assert.IsTrue(value.Value);
        }

        /// <summary>
        /// Tests finding element scroll top value.
        /// </summary>
        [Test]
        public void FindScrollTop()
        {
            var scroll = this.Browser.JQuery(By.JQuerySelector("div.scroll")).ScrollTop();
            Assert.IsNotNull(scroll);
            Assert.AreEqual(100, scroll);
        }

        /// <summary>
        /// Tests finding element scroll left value.
        /// </summary>
        [Test]
        public void FindScrollLeft()
        {
            var scroll = this.Browser.JQuery(By.JQuerySelector("div.scroll")).ScrollLeft();
            Assert.IsNotNull(scroll);
            Assert.AreEqual(200, scroll);
        }

        /// <summary>
        /// Tests finding element count.
        /// </summary>
        [Test]
        public void FindCount()
        {
            var count = this.Browser.JQuery(By.JQuerySelector("div.main")).Count();
            Assert.AreEqual(2, count);
        }

        /// <summary>
        /// Tests finding element count that doesn't exist.
        /// </summary>
        [Test]
        public void FindCountThatDoesntExist()
        {
            var count = this.Browser.JQuery(By.JQuerySelector("div.mainNot")).Count();
            Assert.AreEqual(0, count);
        }

        /// <summary>
        /// Tests finding serialized element.
        /// </summary>
        [Test]
        public void FindSerialized()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("form")).Serialized();
            Assert.AreEqual("i1=v1&i3=v3", value);
        }

        /// <summary>
        /// Tests finding serialized element that doesn't exist.
        /// </summary>
        [Test]
        public void FindSerializedThatDoesntExist()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("form.test")).Serialized();
            Assert.IsEmpty(value);
        }

        /// <summary>
        /// Tests finding serialized array element.
        /// </summary>
        [Test]
        public void FindSerializedArray()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("form")).SerializedArray();
            Assert.AreEqual("[{\"name\":\"i1\",\"value\":\"v1\"},{\"name\":\"i3\",\"value\":\"v3\"}]", value);
        }

        /// <summary>
        /// Tests finding serialized array element that doesn't exist.
        /// </summary>
        [Test]
        public void FindSerializedArrayThatDoesntExist()
        {
            var value = this.Browser.JQuery(By.JQuerySelector("form.test")).SerializedArray();
            Assert.AreEqual("[]", value);
        }

        /// <summary>
        /// Tests finding element path.
        /// </summary>
        [Test]
        public void FindElementPath()
        {
            var element = this.Browser.FindElement(By.JQuerySelector("#id1"));
            Assert.AreEqual("body > div#id1", element.Path);
        }

        /// <summary>
        /// Tests finding element.
        /// </summary>
        [Test]
        public void FindInnerElement()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var element = root.FindElement(By.JQuerySelector("span"));
            Assert.IsNotNull(element);
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindInnerElements()
        {
            var root = this.Browser.FindElement(By.JQuerySelector("#id1"));
            var elements = root.FindElements(By.JQuerySelector("span"));
            Assert.AreEqual(2, elements.Count);
        }
    }
}
