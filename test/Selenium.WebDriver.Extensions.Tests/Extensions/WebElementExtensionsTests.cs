namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Moq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.JQuery;
    using Selenium.WebDriver.Extensions.Shared;
    using By = Selenium.WebDriver.Extensions.By;
    
    /// <summary>
    /// Web element extensions tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebElementExtensionsTests
    {
        /// <summary>
        /// Tests finding element path.
        /// </summary>
        [Test]
        public void GetPath()
        {
            var selector = new Mock<ISelector>();
            selector.SetupGet(x => x.Selector).Returns("div");
            selector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(selector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driver.Object);
            
            Assert.AreEqual("body > div", element.Object.Path);
        }

        /// <summary>
        /// Tests finding element XPATH.
        /// </summary>
        [Test]
        public void GetXPath()
        {
            var selector = new Mock<ISelector>();
            selector.SetupGet(x => x.Selector).Returns("div");
            selector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("html[1]/body");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(selector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            Assert.AreEqual("html[1]/body", element.Object.XPath);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        public void FindElementWithJQuery()
        {
            var selector = By.JQuerySelector("div");
            
            var rootElement = new Mock<IWebElement>();
            rootElement.SetupGet(x => x.TagName).Returns("div");

            var element = new Mock<IWebElement>();
            element.SetupGet(x => x.TagName).Returns("span");

            var list = new List<IWebElement> { rootElement.Object };
            var driver = MockWebDriver("return jQuery('div').get();", new ReadOnlyCollection<IWebElement>(list));
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");
            var elementList = new List<IWebElement> { element.Object };
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('span', jQuery('body > div')).get();"))
                .Returns(new ReadOnlyCollection<IWebElement>(elementList));
            
            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindElement(By.JQuerySelector("span"));

            Assert.IsNotNull(result);
            Assert.AreEqual("span", result.TagName);
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindElementsWithJQuery()
        {
            var selector = By.JQuerySelector("div");

            var rootElement = new Mock<IWebElement>();
            rootElement.SetupGet(x => x.TagName).Returns("div");

            var element1 = new Mock<IWebElement>();
            element1.Setup(x => x.TagName).Returns("span");
            element1.Setup(x => x.GetAttribute("class")).Returns("test1");

            var element2 = new Mock<IWebElement>();
            element2.Setup(x => x.TagName).Returns("span");
            element2.Setup(x => x.GetAttribute("class")).Returns("test2");

            var list = new List<IWebElement> { rootElement.Object };
            var driver = MockWebDriver("return jQuery('div').get();", new ReadOnlyCollection<IWebElement>(list));
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");
            var elementList = new List<IWebElement> { element1.Object, element2.Object };
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('span', jQuery('body > div')).get();"))
                .Returns(new ReadOnlyCollection<IWebElement>(elementList));

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindElements(By.JQuerySelector("span"));

            Assert.AreEqual(2, result.Count);

            Assert.AreEqual("span", result[0].TagName);
            Assert.AreEqual("test1", result[0].GetAttribute("class"));

            Assert.AreEqual("span", result[1].TagName);
            Assert.AreEqual("test2", result[1].GetAttribute("class"));
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        public void FindElementWithSizzle()
        {
            var selector = By.SizzleSelector("div");

            var rootElement = new Mock<IWebElement>();
            rootElement.SetupGet(x => x.TagName).Returns("div");

            var element = new Mock<IWebElement>();
            element.SetupGet(x => x.TagName).Returns("span");

            var rootList = new List<IWebElement> { rootElement.Object };
            var driver = MockWebDriver("return Sizzle('div');", new ReadOnlyCollection<IWebElement>(rootList));
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");
            var elementList = new List<IWebElement> { element.Object };
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return Sizzle('span', Sizzle('body > div')[0]);"))
                .Returns(new ReadOnlyCollection<IWebElement>(elementList));

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindElement(By.SizzleSelector("span"));

            Assert.IsNotNull(result);
            Assert.AreEqual("span", result.TagName);
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindElementsWithSizzle()
        {
            var selector = By.SizzleSelector("div");

            var rootElement = new Mock<IWebElement>();
            rootElement.SetupGet(x => x.TagName).Returns("div");

            var element1 = new Mock<IWebElement>();
            element1.Setup(x => x.TagName).Returns("span");
            element1.Setup(x => x.GetAttribute("class")).Returns("test1");

            var element2 = new Mock<IWebElement>();
            element2.Setup(x => x.TagName).Returns("span");
            element2.Setup(x => x.GetAttribute("class")).Returns("test2");

            var rootList = new List<IWebElement> { rootElement.Object };
            var elementList = new List<IWebElement> { element1.Object, element2.Object };
            var driver = MockWebDriver("return Sizzle('div');", new ReadOnlyCollection<IWebElement>(rootList));
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return Sizzle('span', Sizzle('body > div')[0]);"))
                .Returns(new ReadOnlyCollection<IWebElement>(elementList));

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindElements(By.SizzleSelector("span"));

            Assert.AreEqual(2, result.Count);

            Assert.AreEqual("span", result[0].TagName);
            Assert.AreEqual("test1", result[0].GetAttribute("class"));

            Assert.AreEqual("span", result[1].TagName);
            Assert.AreEqual("test2", result[1].GetAttribute("class"));
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        public void FindElementWithQuerySelector()
        {
            var selector = By.QuerySelector("div");

            var rootElement = new Mock<IWebElement>();
            rootElement.SetupGet(x => x.TagName).Returns("div");

            var element = new Mock<IWebElement>();
            element.SetupGet(x => x.TagName).Returns("span");

            var rootList = new List<IWebElement> { rootElement.Object };
            var driver = MockWebDriver(
                "return document.querySelectorAll('div');",
                new ReadOnlyCollection<IWebElement>(rootList));
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");
            var elementList = new List<IWebElement> { element.Object };
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(
                    "return document.querySelectorAll('body > div').length === 0 ? [] : document.querySelectorAll('body > div')[0].querySelectorAll('span');"))
                .Returns(new ReadOnlyCollection<IWebElement>(elementList));

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindElement(By.QuerySelector("span"));

            Assert.IsNotNull(result);
            Assert.AreEqual("span", result.TagName);
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindElementsWithQuerySelector()
        {
            var selector = By.QuerySelector("div");

            var rootElement = new Mock<IWebElement>();
            rootElement.SetupGet(x => x.TagName).Returns("div");

            var element1 = new Mock<IWebElement>();
            element1.Setup(x => x.TagName).Returns("span");
            element1.Setup(x => x.GetAttribute("class")).Returns("test1");

            var element2 = new Mock<IWebElement>();
            element2.Setup(x => x.TagName).Returns("span");
            element2.Setup(x => x.GetAttribute("class")).Returns("test2");

            var rootList = new List<IWebElement> { rootElement.Object };
            var elementList = new List<IWebElement> { element1.Object, element2.Object };
            var driver = MockWebDriver(
                "return document.querySelectorAll('div');",
                new ReadOnlyCollection<IWebElement>(rootList));
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");
            driver.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(
                    "return document.querySelectorAll('body > div').length === 0 ? [] : document.querySelectorAll('body > div')[0].querySelectorAll('span');"))
                .Returns(new ReadOnlyCollection<IWebElement>(elementList));

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindElements(By.QuerySelector("span"));

            Assert.AreEqual(2, result.Count);

            Assert.AreEqual("span", result[0].TagName);
            Assert.AreEqual("test1", result[0].GetAttribute("class"));

            Assert.AreEqual("span", result[1].TagName);
            Assert.AreEqual("test2", result[1].GetAttribute("class"));
        }

        /// <summary>
        /// Tests finding an element text.
        /// </summary>
        [Test]
        public void FindText()
        {
            const string Result = "test";

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('span', jQuery('body > div')).text();", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");
            
            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindText(By.JQuerySelector("span"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element inner HTML.
        /// </summary>
        [Test]
        public void FindHtml()
        {
            const string Result = "<p>test</p>";

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('span', jQuery('body > div')).html();", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");
            
            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindHtml(By.JQuerySelector("span"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element string attribute.
        /// </summary>
        [Test]
        public void FindAttribute()
        {
            const string Result = "http://github.com";
            
            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('a', jQuery('body > div')).attr('href');", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");
            
            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindAttribute(By.JQuerySelector("a"), "href");

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element string property.
        /// </summary>
        [Test]
        public void FindPropertyString()
        {
            const string Result = "prop";
            
            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).prop('checked');", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindProperty<string>(By.JQuerySelector("input"), "checked");

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element boolean property.
        /// </summary>
        [Test]
        public void FindPropertyBoolean()
        {
            const bool Result = true;

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).prop('checked');", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindProperty(By.JQuerySelector("input"), "checked");

            Assert.IsNotNull(result);
            Assert.AreEqual(Result, result.Value);
        }

        /// <summary>
        /// Tests finding an element value.
        /// </summary>
        [Test]
        public void FindValue()
        {
            const string Result = "test";

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).val();", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindValue(By.JQuerySelector("input"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element CSS property.
        /// </summary>
        [Test]
        public void FindCss()
        {
            const string Result = "hidden";

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).css('display');", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindCss(By.JQuerySelector("input"), "display");

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element width.
        /// </summary>
        [Test]
        public void FindWidth()
        {
            const long Result = 100;

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).width();", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindWidth(By.JQuerySelector("input"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element height.
        /// </summary>
        [Test]
        public void FindHeight()
        {
            const long Result = 100;

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).height();", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindHeight(By.JQuerySelector("input"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element inner width.
        /// </summary>
        [Test]
        public void FindInnerWidth()
        {
            const long Result = 100;

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).innerWidth();", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindInnerWidth(By.JQuerySelector("input"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element inner height.
        /// </summary>
        [Test]
        public void FindInnerHeight()
        {
            const long Result = 100;

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).innerHeight();", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindInnerHeight(By.JQuerySelector("input"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element outer width.
        /// </summary>
        [Test]
        public void FindOuterWidth()
        {
            const long Result = 100;

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).outerWidth();", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindOuterWidth(By.JQuerySelector("input"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element outer height.
        /// </summary>
        [Test]
        public void FindOuterHeight()
        {
            const long Result = 100;

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).outerHeight();", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindOuterHeight(By.JQuerySelector("input"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element outer width with margin.
        /// </summary>
        [Test]
        public void FindOuterWidthWithMargin()
        {
            const long Result = 100;

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).outerWidth(true);", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindOuterWidth(By.JQuerySelector("input"), true);

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element outer height with margin.
        /// </summary>
        [Test]
        public void FindOuterHeightWithMargin()
        {
            const long Result = 100;

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).outerHeight(true);", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindOuterHeight(By.JQuerySelector("input"), true);

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element position.
        /// </summary>
        [Test]
        public void FindPosition()
        {
            var dict = new Dictionary<string, object> { { "top", 100 }, { "left", 200 } };

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).position();", dict);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var position = webElement.Object.FindPosition(By.JQuerySelector("input"));
            if (position == null)
            {
                Assert.Fail();
            }

            Assert.AreEqual(dict["top"], position.Value.Top);
            Assert.AreEqual(dict["left"], position.Value.Left);
        }

        /// <summary>
        /// Tests finding an element offset.
        /// </summary>
        [Test]
        public void FindOffset()
        {
            var dict = new Dictionary<string, object> { { "top", 100 }, { "left", 200 } };

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).offset();", dict);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var offset = webElement.Object.FindOffset(By.JQuerySelector("input"));
            if (offset == null)
            {
                Assert.Fail();
            }

            Assert.AreEqual(dict["top"], offset.Value.Top);
            Assert.AreEqual(dict["left"], offset.Value.Left);
        }

        /// <summary>
        /// Tests finding an element scroll left.
        /// </summary>
        [Test]
        public void FindScrollLeft()
        {
            const long Result = 100;

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).scrollLeft();", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindScrollLeft(By.JQuerySelector("input"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element scroll top.
        /// </summary>
        [Test]
        public void FindScrollTop()
        {
            const long Result = 100;
            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).scrollTop();", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindScrollTop(By.JQuerySelector("input"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element scroll left.
        /// </summary>
        [Test]
        public void FindData()
        {
            const string Result = "val";

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).data('test');", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindData(By.JQuerySelector("input"), "test");

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element scroll left.
        /// </summary>
        [Test]
        public void FindIntData()
        {
            const bool Result = true;

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).data('test');", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindData<bool?>(By.JQuerySelector("input"), "test");

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element count.
        /// </summary>
        [Test]
        public void FindCount()
        {
            const long Result = 2;

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('input', jQuery('body > div')).length;", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindCount(By.JQuerySelector("input"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding a serialized element.
        /// </summary>
        [Test]
        public void FindSerialized()
        {
            const string Result = "search=test";

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver("return jQuery('form', jQuery('body > div')).serialize();", Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindSerialized(By.JQuerySelector("form"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding a serialized element array.
        /// </summary>
        [Test]
        public void FindSerializedArray()
        {
            const string Result = "[{\"name\":\"s\",\"value\":\"\"}]";

            var selector = By.QuerySelector("div");
            var driver = MockWebDriver(
                "return JSON.stringify(jQuery('form', jQuery('body > div')).serializeArray());",
                Result);
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(el\\)")))
                .Returns("body > div");

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var result = webElement.Object.FindSerializedArray(By.JQuerySelector("form"));

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Mocks the Selenium web driver.
        /// </summary>
        /// <param name="script">Script to mock to return value.</param>
        /// <param name="value">A value to return by the script.</param>
        /// <returns>Mocked Selenium web driver.</returns>
        private static Mock<IWebDriver> MockWebDriver(string script = null, object value = null)
        {
            var mock = new Mock<IWebDriver>();
            if (script != null)
            {
                mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(script)).Returns(value);
            }

            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return typeof window.jQuery === 'function';"))
                .Returns(true);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return typeof window.Sizzle === 'function';"))
                .Returns(true);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return typeof document.querySelectorAll === 'function';")).Returns(true);
            return mock;
        }
    }
}
