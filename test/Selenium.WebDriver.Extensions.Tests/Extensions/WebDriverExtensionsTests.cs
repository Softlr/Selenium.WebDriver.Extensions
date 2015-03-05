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
    using Selenium.WebDriver.Extensions.Core;
    using Selenium.WebDriver.Extensions.JQuery;
    using Selenium.WebDriver.Extensions.Sizzle;
    using By = Selenium.WebDriver.Extensions.By;
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsTests
    {
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

        [TestCaseSource("LoadJQueryTestCases")]
        public void LoadJQuery(string version, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var mock = new Mock<IWebDriver>();
            var sequence = mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            mock.Object.JQuery().Load(version, timeout);
        }

        [TestCaseSource("LoadJQueryWithUriTestCases")]
        public void LoadJQueryWithUri(Uri jQueryUri, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var mock = new Mock<IWebDriver>();
            var sequence = mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            mock.Object.JQuery().Load(jQueryUri, timeout);
        }

        [TestCaseSource("LoadSizzleTestCases")]
        public void LoadSizzle(string version, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var mock = new Mock<IWebDriver>();
            var sequence = mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            mock.Object.Sizzle().Load(version, timeout);
        }

        [TestCaseSource("LoadSizzleWithUriTestCases")]
        public void LoadSizzleWithUri(Uri sizzleUri, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var mock = new Mock<IWebDriver>();
            var sequence = mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            mock.Object.Sizzle().Load(sizzleUri, timeout);
        }

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

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementWithJQueryArgumentNull()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.FindElement((JQuerySelector)null);
        }

        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithJQueryNoSuchElement()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            var mock = MockWebDriver();

            mock.Object.FindElement(By.JQuerySelector("div"));
        }

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

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementWithSizzleArgumentNull()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.FindElement((SizzleSelector)null);
        }

        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithSizzleNoSuchElement()
        {
            var mock = MockWebDriver();

            mock.Object.FindElement(By.SizzleSelector("div"));
        }

        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithSizzleNoSuchElementEmptyResult()
        {
            var mock = MockWebDriver("return Sizzle('div');", Enumerable.Empty<IWebElement>());

            mock.Object.FindElement(By.SizzleSelector("div"));
        }

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

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementWithQuerySelectorArgumentNull()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.FindElement((QuerySelector)null);
        }

        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithQuerySelectorNoSuchElement()
        {
            var mock = MockWebDriver();

            mock.Object.FindElement(By.QuerySelector("div"));
        }

        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithQuerySelectorNoSuchElementEmptyResult()
        {
            var mock = MockWebDriver("return document.querySelectorAll('div');", Enumerable.Empty<IWebElement>());
            
            mock.Object.FindElement(By.QuerySelector("div"));
        }

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

        [Test]
        public void FindElementsWithJQueryNotExists()
        {
            var list = new List<object>();
            var mock = MockWebDriver("return jQuery('.test').get();", new ReadOnlyCollection<object>(list));
            var result = mock.Object.FindElements(By.JQuerySelector(".test"));

            Assert.AreEqual(0, result.Count);
        }

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

        [Test]
        public void FindElementsWithSizzleNotExists()
        {
            var list = new List<object>();
            var mock = MockWebDriver("return Sizzle('.test');", new ReadOnlyCollection<object>(list));
            var result = mock.Object.FindElements(By.SizzleSelector(".test"));

            Assert.AreEqual(0, result.Count);
        }

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

        [Test]
        public void FindElementsWithQuerySelectorNotExists()
        {
            var list = new List<object>();
            var mock = MockWebDriver("return document.querySelectorAll('.test');", new ReadOnlyCollection<object>(list));
            var result = mock.Object.FindElements(By.QuerySelector(".test"));

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void FindText()
        {
            const string Result = "test";
            var mock = MockWebDriver("return jQuery('div').text();", Result);
            var result = mock.Object.JQuery("div").Text();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindHtml()
        {
            const string Result = "<p>test</p>";
            var mock = MockWebDriver("return jQuery('div').html();", Result);
            var result = mock.Object.JQuery("div").Html();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindAttribute()
        {
            const string Result = "http://github.com";
            var mock = MockWebDriver("return jQuery('a').attr('href');", Result);
            var result = mock.Object.JQuery("a").Attribute("href");

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindAttributeNotExists()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("a").Attribute("href");

            Assert.IsNull(result);
        }

        [Test]
        public void FindAttributeInvalidType()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("a").Attribute("href");
            
            Assert.IsNull(result);
        }

        [Test]
        public void FindPropertyString()
        {
            const string Result = "prop";
            var mock = MockWebDriver("return jQuery('input').prop('checked');", Result);
            var result = mock.Object.JQuery("input").Property<string>("checked");

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindPropertyBoolean()
        {
            const bool Result = true;
            var mock = MockWebDriver("return jQuery('input').prop('checked');", Result);
            var result = mock.Object.JQuery("input").Property("checked");

            Assert.IsNotNull(result);
            Assert.AreEqual(Result, result.Value);
        }

        [Test]
        public void FindPropertyNotExists()
        {
            var mock = MockWebDriver();
            var result = mock.Object.JQuery("input").Property("checked");

            Assert.IsNull(result);
        }

        [Test]
        [ExpectedException(typeof(TypeArgumentException))]
        public void FindPropertyInvalidType()
        {
            var mock = MockWebDriver();
            mock.Object.JQuery("input").Property<int>("checked");
        }

        [Test]
        public void FindValue()
        {
            const string Result = "test";
            var mock = MockWebDriver("return jQuery('input').val();", Result);
            var result = mock.Object.JQuery("input").Value();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindCss()
        {
            const string Result = "hidden";
            var mock = MockWebDriver("return jQuery('input').css('display');", Result);
            var result = mock.Object.JQuery("input").Css("display");

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindWidth()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').width();", Result);
            var result = mock.Object.JQuery("input").Width();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindHeight()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').height();", Result);
            var result = mock.Object.JQuery("input").Height();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindInnerWidth()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').innerWidth();", Result);
            var result = mock.Object.JQuery("input").InnerWidth();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindInnerHeight()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').innerHeight();", Result);
            var result = mock.Object.JQuery("input").InnerHeight();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindOuterWidth()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').outerWidth();", Result);
            var result = mock.Object.JQuery("input").OuterWidth();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindOuterHeight()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').outerHeight();", Result);
            var result = mock.Object.JQuery("input").OuterHeight();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindOuterWidthWithMargin()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').outerWidth(true);", Result);
            var result = mock.Object.JQuery("input").OuterWidth(true);

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindOuterHeightWithMargin()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').outerHeight(true);", Result);
            var result = mock.Object.JQuery("input").OuterHeight(true);

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindPosition()
        {
            var dict = new Dictionary<string, object> { { "top", 100 }, { "left", 200 } };
            var mock = MockWebDriver();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').position();"))
                .Returns(dict);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').position();"))).Returns(true);
            var position = mock.Object.JQuery("input").Position();

            if (position == null)
            {
                Assert.Fail();
            }

            Assert.AreEqual(dict["top"], position.Value.Top);
            Assert.AreEqual(dict["left"], position.Value.Left);
        }

        [Test]
        public void FindPositionNotExists()
        {
            var mock = MockWebDriver();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').position();"))
                .Returns(null);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').position();"))).Returns(true);
            var position = mock.Object.JQuery("input").Position();

            Assert.IsNull(position);
        }

        [Test]
        public void FindOffset()
        {
            var dict = new Dictionary<string, object> { { "top", 100 }, { "left", 200 } };
            var mock = MockWebDriver();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').offset();"))
                .Returns(dict);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').offset();")))
                .Returns(true);
            var offset = mock.Object.JQuery("input").Offset();

            if (offset == null)
            {
                Assert.Fail();
            }

            Assert.AreEqual(dict["top"], offset.Value.Top);
            Assert.AreEqual(dict["left"], offset.Value.Left);
        }

        [Test]
        public void FindOffsetNotExists()
        {
            var mock = MockWebDriver();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').offset();"))
                .Returns(null);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').offset();")))
                .Returns(true);
            var offset = mock.Object.JQuery("input").Offset();

            Assert.IsNull(offset);
        }

        [Test]
        public void FindScrollLeft()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').scrollLeft();", Result);
            var result = mock.Object.JQuery("input").ScrollLeft();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindScrollTop()
        {
            const long Result = 100;
            var mock = MockWebDriver("return jQuery('input').scrollTop();", Result);
            var result = mock.Object.JQuery("input").ScrollTop();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindData()
        {
            const string Result = "val";
            var mock = MockWebDriver("return jQuery('input').data('test');", Result);
            var result = mock.Object.JQuery("input").Data("test");

            Assert.AreEqual(Result, result);
        }

        [Test]
        [ExpectedException(typeof(TypeArgumentException))]
        public void FindDataInvalidType()
        {
            var mock = MockWebDriver();
            mock.Object.JQuery("input").Data<int>("test");
        }

        [Test]
        public void FindCount()
        {
            const long Result = 2;
            var mock = MockWebDriver("return jQuery('input').length;", Result);
            var result = mock.Object.JQuery("input").Count();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindSerialized()
        {
            const string Result = "search=test";
            var mock = MockWebDriver("return jQuery('form').serialize();", Result);
            var result = mock.Object.JQuery("form").Serialized();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindSerializedArray()
        {
            const string Result = "[{\"name\":\"s\",\"value\":\"\"}]";
            var mock = MockWebDriver("return JSON.stringify(jQuery('form').serializeArray());", Result);
            var result = mock.Object.JQuery("form").SerializedArray();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void HasClass()
        {
            const bool Result = true;
            var mock = MockWebDriver("return jQuery('form').hasClass('test');", Result);
            var result = mock.Object.JQuery("form").HasClass("test");

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void NumbersCastingInInternetExplorer()
        {
            const double MockedWidth = 100d;
            var mock = MockWebDriver("return jQuery('input').width();", MockedWidth);
            var result = mock.Object.JQuery("input").Width();

            Assert.AreEqual(MockedWidth, result);
            Assert.IsInstanceOf<long?>(result);
        }

        [Test]
        [ExpectedException(typeof(QuerySelectorNotSupportedException))]
        public void QuerySelectorNotSupported()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return typeof document.querySelectorAll === 'function';")).Returns(false);
            mock.Object.QuerySelector().CheckSupport();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckSelectorPrerequisitesWithoutLoader()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.CheckSelectorPrerequisites(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadExternalLibraryWithoutLoader()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.LoadExternalLibrary(null, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HelperWithNullDriver()
        {
            WebElementExtensions.JQuery(null, (JQuerySelector)null);
        }

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
