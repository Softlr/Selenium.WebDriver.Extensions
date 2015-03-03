namespace Selenium.WebDriver.Extensions.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.JQuery;
    using Selenium.WebDriver.Extensions.QuerySelector;
    using Selenium.WebDriver.Extensions.Shared;
    using Selenium.WebDriver.Extensions.Sizzle;
    using By = Selenium.WebDriver.Extensions.By;
    
    /// <summary>
    /// Web driver extensions tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsTests
    {
        /// <summary>
        /// Gets the load jQuery test cases.
        /// </summary>
        private static IEnumerable LoadJQueryTestCases
        {
            get
            {
                yield return new TestCaseData("latest", null, new object[] { true });
                yield return new TestCaseData("1.11.0", null, new object[] { false, true, true });
                yield return new TestCaseData("latest", TimeSpan.FromSeconds(1), new object[] { false })
                    .Throws(typeof(WebDriverTimeoutException));
            }
        }

        /// <summary>
        /// Gets the load jQuery test cases.
        /// </summary>
        private static IEnumerable LoadJQueryWithUriTestCases
        {
            get
            {
                yield return new TestCaseData(new Uri("http://my.com/jquery.js"), null, new object[] { true });
                yield return new TestCaseData(null, null, new object[] { false, true, true });
                yield return new TestCaseData(
                    new Uri("http://my.com/jquery.js"), 
                    TimeSpan.FromSeconds(1), 
                    new object[] { false }).Throws(typeof(WebDriverTimeoutException));
            }
        }

        /// <summary>
        /// Gets the load Sizzle test cases.
        /// </summary>
        private static IEnumerable LoadSizzleTestCases
        {
            get
            {
                yield return new TestCaseData("master", null, new object[] { true });
                yield return new TestCaseData("1.11.1", null, new object[] { false, true, true });
                yield return new TestCaseData("master", TimeSpan.FromSeconds(1), new object[] { false })
                    .Throws(typeof(WebDriverTimeoutException));
            }
        }

        /// <summary>
        /// Gets the load Sizzle test cases.
        /// </summary>
        private static IEnumerable LoadSizzleWithUriTestCases
        {
            get
            {
                yield return new TestCaseData(new Uri("http://my.com/sizzle.js"), null, new object[] { true });
                yield return new TestCaseData(null, null, new object[] { false, true, true });
                yield return new TestCaseData(
                    new Uri("http://my.com/sizzle.js"),
                    TimeSpan.FromSeconds(1),
                    new object[] { false }).Throws(typeof(WebDriverTimeoutException));
            }
        }

        /// <summary>
        /// Tests jQuery loading.
        /// </summary>
        /// <param name="version">The version of jQuery to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the jQuery load.</param>
        /// <param name="mockValueSequence">
        /// A mock value sequence for <see cref="IJavaScriptExecutor.ExecuteScript"/> method.
        /// </param>
        [TestCaseSource("LoadJQueryTestCases")]
        public void LoadJQuery(string version, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var mock = new Mock<IWebDriver>();
            var sequence = mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            mock.Object.JQuery().Load(version, timeout);
        }

        /// <summary>
        /// Tests jQuery loading.
        /// </summary>
        /// <param name="jQueryUri">The URI of jQuery to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the jQuery load.</param>
        /// <param name="mockValueSequence">
        /// A mock value sequence for <see cref="IJavaScriptExecutor.ExecuteScript"/> method.
        /// </param>
        [TestCaseSource("LoadJQueryWithUriTestCases")]
        public void LoadJQueryWithUri(Uri jQueryUri, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var mock = new Mock<IWebDriver>();
            var sequence = mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            mock.Object.JQuery().Load(jQueryUri, timeout);
        }

        /// <summary>
        /// Tests Sizzle loading.
        /// </summary>
        /// <param name="version">The version of Sizzle to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the Sizzle load.</param>
        /// <param name="mockValueSequence">
        /// A mock value sequence for <see cref="IJavaScriptExecutor.ExecuteScript"/> method.
        /// </param>
        [TestCaseSource("LoadSizzleTestCases")]
        public void LoadSizzle(string version, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var mock = new Mock<IWebDriver>();
            var sequence = mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            mock.Object.Sizzle().Load(version, timeout);
        }

        /// <summary>
        /// Tests Sizzle loading.
        /// </summary>
        /// <param name="sizzleUri">The URI of Sizzle to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the Sizzle load.</param>
        /// <param name="mockValueSequence">
        /// A mock value sequence for <see cref="IJavaScriptExecutor.ExecuteScript"/> method.
        /// </param>
        [TestCaseSource("LoadSizzleWithUriTestCases")]
        public void LoadSizzleWithUri(Uri sizzleUri, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var mock = new Mock<IWebDriver>();
            var sequence = mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            mock.Object.Sizzle().Load(sizzleUri, timeout);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        public void FindElementWithJQuery()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");

            var list = new List<IWebElement> { element.Object };
            var mock = MockWebDriver("return jQuery('div').get();", new ReadOnlyCollection<IWebElement>(list));
            var result = mock.Object.FindElement(By.JQuerySelector("div"));

            Assert.IsNotNull(result);
            Assert.AreEqual("div", result.TagName);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementWithJQueryArgumentNull()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.FindElement((JQuerySelector)null);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithJQueryNoSuchElement()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            var mock = MockWebDriver();

            mock.Object.FindElement(By.JQuerySelector("div"));
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        public void FindElementWithSizzle()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            var list = new List<IWebElement> { element.Object };
            var mock = MockWebDriver("return Sizzle('div');", new ReadOnlyCollection<IWebElement>(list));
            var result = mock.Object.FindElement(By.SizzleSelector("div"));

            Assert.IsNotNull(result);
            Assert.AreEqual("div", result.TagName);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementWithSizzleArgumentNull()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.FindElement((SizzleSelector)null);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithSizzleNoSuchElement()
        {
            var mock = MockWebDriver();

            mock.Object.FindElement(By.SizzleSelector("div"));
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithSizzleNoSuchElementEmptyResult()
        {
            var mock = MockWebDriver("return Sizzle('div');", Enumerable.Empty<IWebElement>());

            mock.Object.FindElement(By.SizzleSelector("div"));
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        public void FindElementWithQuerySelector()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            var list = new List<IWebElement> { element.Object };
            var mock = MockWebDriver("return document.querySelectorAll('div');", new ReadOnlyCollection<IWebElement>(list));
            var result = mock.Object.FindElement(By.QuerySelector("div"));

            Assert.IsNotNull(result);
            Assert.AreEqual("div", result.TagName);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        public void FindElementWithNestedQuerySelector()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("span");
            var list = new List<IWebElement> { element.Object };
            var mock = MockWebDriver(
                "return document.querySelectorAll('div').length === 0 ? [] : document.querySelectorAll('div')[0].querySelectorAll('span');", 
                new ReadOnlyCollection<IWebElement>(list));
            var result = mock.Object.FindElement(By.QuerySelector("span", By.QuerySelector("div")));

            Assert.IsNotNull(result);
            Assert.AreEqual("span", result.TagName);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementWithQuerySelectorArgumentNull()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.FindElement((QuerySelector)null);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithQuerySelectorNoSuchElement()
        {
            var mock = MockWebDriver();

            mock.Object.FindElement(By.QuerySelector("div"));
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithQuerySelectorNoSuchElementEmptyResult()
        {
            var mock = MockWebDriver("return document.querySelectorAll('div');", Enumerable.Empty<IWebElement>());
            
            mock.Object.FindElement(By.QuerySelector("div"));
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindElementsWithJQuery()
        {
            var element1 = new Mock<IWebElement>();
            element1.Setup(x => x.TagName).Returns("div");
            element1.Setup(x => x.GetAttribute("class")).Returns("test");

            var element2 = new Mock<IWebElement>();
            element2.Setup(x => x.TagName).Returns("span");
            element2.Setup(x => x.GetAttribute("class")).Returns("test");

            var list = new List<IWebElement> { element1.Object, element2.Object };
            var mock = MockWebDriver("return jQuery('.test').get();", new ReadOnlyCollection<IWebElement>(list));
            var result = mock.Object.FindElements(By.JQuerySelector(".test"));

            Assert.AreEqual(2, result.Count);

            Assert.AreEqual("div", result[0].TagName);
            Assert.AreEqual("test", result[0].GetAttribute("class"));

            Assert.AreEqual("span", result[1].TagName);
            Assert.AreEqual("test", result[1].GetAttribute("class"));
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindElementsWithJQueryNotExists()
        {
            var list = new List<object>();
            var mock = MockWebDriver("return jQuery('.test').get();", new ReadOnlyCollection<object>(list));
            var result = mock.Object.FindElements(By.JQuerySelector(".test"));

            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindElementsWithSizzle()
        {
            var element1 = new Mock<IWebElement>();
            element1.Setup(x => x.TagName).Returns("div");
            element1.Setup(x => x.GetAttribute("class")).Returns("test");

            var element2 = new Mock<IWebElement>();
            element2.Setup(x => x.TagName).Returns("span");
            element2.Setup(x => x.GetAttribute("class")).Returns("test");

            var list = new List<IWebElement> { element1.Object, element2.Object };
            var mock = MockWebDriver("return Sizzle('.test');", new ReadOnlyCollection<IWebElement>(list));
            var result = mock.Object.FindElements(By.SizzleSelector(".test"));

            Assert.AreEqual(2, result.Count);

            Assert.AreEqual("div", result[0].TagName);
            Assert.AreEqual("test", result[0].GetAttribute("class"));

            Assert.AreEqual("span", result[1].TagName);
            Assert.AreEqual("test", result[1].GetAttribute("class"));
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindElementsWithSizzleNotExists()
        {
            var list = new List<object>();
            var mock = MockWebDriver("return Sizzle('.test');", new ReadOnlyCollection<object>(list));
            var result = mock.Object.FindElements(By.SizzleSelector(".test"));

            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindElementsWithQuerySelector()
        {
            var element1 = new Mock<IWebElement>();
            element1.Setup(x => x.TagName).Returns("div");
            element1.Setup(x => x.GetAttribute("class")).Returns("test");

            var element2 = new Mock<IWebElement>();
            element2.Setup(x => x.TagName).Returns("span");
            element2.Setup(x => x.GetAttribute("class")).Returns("test");

            var list = new List<IWebElement> { element1.Object, element2.Object };
            var mock = MockWebDriver("return document.querySelectorAll('.test');", new ReadOnlyCollection<IWebElement>(list));
            var result = mock.Object.FindElements(By.QuerySelector(".test"));

            Assert.AreEqual(2, result.Count);

            Assert.AreEqual("div", result[0].TagName);
            Assert.AreEqual("test", result[0].GetAttribute("class"));

            Assert.AreEqual("span", result[1].TagName);
            Assert.AreEqual("test", result[1].GetAttribute("class"));
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindElementsWithQuerySelectorNotExists()
        {
            var list = new List<object>();
            var mock = MockWebDriver("return document.querySelectorAll('.test');", new ReadOnlyCollection<object>(list));
            var result = mock.Object.FindElements(By.QuerySelector(".test"));

            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// Tests finding an element text.
        /// </summary>
        [Test]
        public void FindText()
        {
            const string Result = "test";
            var mock = MockWebDriver("return jQuery('div').text();", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("div")).Text();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element inner HTML.
        /// </summary>
        [Test]
        public void FindHtml()
        {
            const string Result = "<p>test</p>";
            var mock = MockWebDriver("return jQuery('div').html();", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("div")).Html();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element string attribute.
        /// </summary>
        [Test]
        public void FindAttribute()
        {
            const string Result = "http://github.com";
            var mock = MockWebDriver("return jQuery('a').attr('href');", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("a")).Attribute("href");

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element attribute that doesn't exist.
        /// </summary>
        [Test]
        public void FindAttributeNotExists()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery(By.JQuerySelector("a")).Attribute("href");

            Assert.IsNull(result);
        }

        /// <summary>
        /// Tests finding an element attribute with invalid type parameter.
        /// </summary>
        [Test]
        public void FindAttributeInvalidType()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery(By.JQuerySelector("a")).Attribute("href");
            
            Assert.IsNull(result);
        }

        /// <summary>
        /// Tests finding an element string property.
        /// </summary>
        [Test]
        public void FindPropertyString()
        {
            const string Result = "prop";
            var mock = MockWebDriver("return jQuery('input').prop('checked');", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).Property<string>("checked");

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element boolean property.
        /// </summary>
        [Test]
        public void FindPropertyBoolean()
        {
            const bool Result = true;
            var mock = MockWebDriver("return jQuery('input').prop('checked');", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).Property("checked");

            Assert.IsNotNull(result);
            Assert.AreEqual(Result, result.Value);
        }

        /// <summary>
        /// Tests finding an element property that doesn't exist.
        /// </summary>
        [Test]
        public void FindPropertyNotExists()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery(By.JQuerySelector("input")).Property("checked");

            Assert.IsNull(result);
        }

        /// <summary>
        /// Tests finding an element property with invalid type parameter.
        /// </summary>
        [Test]
        [ExpectedException(typeof(TypeArgumentException))]
        public void FindPropertyInvalidType()
        {
            var mock = MockWebDriver();
            mock.Object.JQuery(By.JQuerySelector("input")).Property<int>("checked");
        }

        /// <summary>
        /// Tests finding an element value.
        /// </summary>
        [Test]
        public void FindValue()
        {
            const string Result = "test";
            var mock = MockWebDriver("return jQuery('input').val();", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).Value();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element CSS property.
        /// </summary>
        [Test]
        public void FindCss()
        {
            const string Result = "hidden";
            var mock = MockWebDriver("return jQuery('input').css('display');", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).Css("display");

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element width.
        /// </summary>
        [Test]
        public void FindWidth()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').width();", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).Width();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element height.
        /// </summary>
        [Test]
        public void FindHeight()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').height();", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).Height();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element inner width.
        /// </summary>
        [Test]
        public void FindInnerWidth()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').innerWidth();", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).InnerWidth();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element inner height.
        /// </summary>
        [Test]
        public void FindInnerHeight()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').innerHeight();", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).InnerHeight();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element outer width.
        /// </summary>
        [Test]
        public void FindOuterWidth()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').outerWidth();", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).OuterWidth();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element outer height.
        /// </summary>
        [Test]
        public void FindOuterHeight()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').outerHeight();", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).OuterHeight();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element outer width with margin.
        /// </summary>
        [Test]
        public void FindOuterWidthWithMargin()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').outerWidth(true);", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).OuterWidth(true);

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element outer height with margin.
        /// </summary>
        [Test]
        public void FindOuterHeightWithMargin()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').outerHeight(true);", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).OuterHeight(true);

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element position.
        /// </summary>
        [Test]
        public void FindPosition()
        {
            var dict = new Dictionary<string, object> { { "top", 100 }, { "left", 200 } };
            var mock = MockWebDriver();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').position();"))
                .Returns(dict);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').position();"))).Returns(true);
            var position = mock.Object.JQuery(By.JQuerySelector("input")).Position();

            if (position == null)
            {
                Assert.Fail();
            }

            Assert.AreEqual(dict["top"], position.Value.Top);
            Assert.AreEqual(dict["left"], position.Value.Left);
        }

        /// <summary>
        /// Tests finding an element position that does not exist.
        /// </summary>
        [Test]
        public void FindPositionNotExists()
        {
            var mock = MockWebDriver();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').position();"))
                .Returns(null);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').position();"))).Returns(true);
            var position = mock.Object.JQuery(By.JQuerySelector("input")).Position();

            Assert.IsNull(position);
        }

        /// <summary>
        /// Tests finding an element offset.
        /// </summary>
        [Test]
        public void FindOffset()
        {
            var dict = new Dictionary<string, object> { { "top", 100 }, { "left", 200 } };
            var mock = MockWebDriver();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').offset();"))
                .Returns(dict);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').offset();")))
                .Returns(true);
            var offset = mock.Object.JQuery(By.JQuerySelector("input")).Offset();

            if (offset == null)
            {
                Assert.Fail();
            }

            Assert.AreEqual(dict["top"], offset.Value.Top);
            Assert.AreEqual(dict["left"], offset.Value.Left);
        }

        /// <summary>
        /// Tests finding an element offset that does not exist.
        /// </summary>
        [Test]
        public void FindOffsetNotExists()
        {
            var mock = MockWebDriver();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').offset();"))
                .Returns(null);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').offset();")))
                .Returns(true);
            var offset = mock.Object.JQuery(By.JQuerySelector("input")).Offset();

            Assert.IsNull(offset);
        }

        /// <summary>
        /// Tests finding an element scroll left.
        /// </summary>
        [Test]
        public void FindScrollLeft()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').scrollLeft();", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).ScrollLeft();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element scroll top.
        /// </summary>
        [Test]
        public void FindScrollTop()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').scrollTop();", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).ScrollTop();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element scroll left.
        /// </summary>
        [Test]
        public void FindData()
        {
            const string Result = "val";
            var mock = MockWebDriver("return jQuery('input').data('test');", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).Data("test");

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding an element scroll left.
        /// </summary>
        [Test]
        [ExpectedException(typeof(TypeArgumentException))]
        public void FindDataInvalidType()
        {
            var mock = MockWebDriver();
            mock.Object.JQuery(By.JQuerySelector("input")).Data<int>("test");
        }

        /// <summary>
        /// Tests finding an element count.
        /// </summary>
        [Test]
        public void FindCount()
        {
            const long Result = 2;
            var mock = MockWebDriver("return jQuery('input').length;", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).Count();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding a serialized element.
        /// </summary>
        [Test]
        public void FindSerialized()
        {
            const string Result = "search=test";
            var mock = MockWebDriver("return jQuery('form').serialize();", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("form")).Serialized();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding a serialized element array.
        /// </summary>
        [Test]
        public void FindSerializedArray()
        {
            const string Result = "[{\"name\":\"s\",\"value\":\"\"}]";
            var mock = MockWebDriver("return JSON.stringify(jQuery('form').serializeArray());", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("form")).SerializedArray();

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests finding if elements contain a class.
        /// </summary>
        [Test]
        public void HasClass()
        {
            const bool Result = true;
            var mock = MockWebDriver("return jQuery('form').hasClass('test');", Result);
            var result = mock.Object.JQuery(By.JQuerySelector("form")).HasClass("test");

            Assert.AreEqual(Result, result);
        }

        /// <summary>
        /// Tests numbers casting in IE.
        /// </summary>
        [Test]
        public void NumbersCastingInInternetExplorer()
        {
            const double MockedWidth = 100d;
            var mock = MockWebDriver("return jQuery('input').width();", MockedWidth);
            var result = mock.Object.JQuery(By.JQuerySelector("input")).Width();

            Assert.AreEqual(MockedWidth, result);
            Assert.IsInstanceOf<long?>(result);
        }

        /// <summary>
        /// Tests query selector support check.
        /// </summary>
        [Test]
        [ExpectedException(typeof(QuerySelectorNotSupportedException))]
        public void QuerySelectorNotSupported()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return typeof document.querySelectorAll === 'function';")).Returns(false);
            mock.Object.QuerySelector().CheckSupport();
        }

        /// <summary>
        /// Tests checking selector prerequisites.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckSelectorPrerequisitesWithoutLoader()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.CheckSelectorPrerequisites(null);
        }

        /// <summary>
        /// Tests loading external libraries.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadExternalLibraryWithoutLoader()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.LoadExternalLibrary(null, null);
        }

        /// <summary>
        /// Tests loading external libraries.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HelperWithNullDriver()
        {
            WebElementExtensions.JQuery(null);
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
