namespace Selenium.WebDriver.Extensions.JQuery.Tests
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
    using By = Selenium.WebDriver.Extensions.JQuery.By;
    
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsTests
    {
        private Mock<IWebDriver> driverMock;

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

        [SetUp]
        public void SetUp()
        {
            this.driverMock = new Mock<IWebDriver>();
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return typeof window.jQuery === 'function';")).Returns(true);
        }

        [TearDown]
        public void TearDown()
        {
            this.driverMock = null;
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

        [Test]
        public void FindElementWithJQuery()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");

            var list = new List<IWebElement> { element.Object };
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('div').get();"))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            var result = this.driverMock.Object.FindElement(By.JQuerySelector("div"));

            Assert.IsNotNull(result);
            Assert.AreEqual("div", result.TagName);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementWithJQueryArgumentNull()
        {
            this.driverMock.Object.FindElement((JQuerySelector)null);
        }

        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementWithJQueryNoSuchElement()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            
            this.driverMock.Object.FindElement(By.JQuerySelector("div"));
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
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('.test').get();"))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            var result = this.driverMock.Object.FindElements(By.JQuerySelector(".test"));

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
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('.test').get();"))
                .Returns(new ReadOnlyCollection<object>(list));
            var result = this.driverMock.Object.FindElements(By.JQuerySelector(".test"));

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void FindText()
        {
            const string Result = "test";
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('div').text();"))
                .Returns(Result);
            var result = this.driverMock.Object.JQuery("div").Text();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindHtml()
        {
            const string Result = "<p>test</p>";
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('div').html();"))
                .Returns(Result);
            var result = this.driverMock.Object.JQuery("div").Html();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindAttribute()
        {
            const string Result = "http://github.com";
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('a').attr('href');"))
                .Returns(Result);
            var result = this.driverMock.Object.JQuery("a").Attribute("href");

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindAttributeNotExists()
        {
            var result = this.driverMock.Object.JQuery("a").Attribute("href");

            Assert.IsNull(result);
        }

        [Test]
        public void FindAttributeInvalidType()
        {
            var result = this.driverMock.Object.JQuery("a").Attribute("href");
            
            Assert.IsNull(result);
        }

        [Test]
        public void FindPropertyString()
        {
            const string Result = "prop";
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').prop('checked');")).Returns(Result);
            var result = this.driverMock.Object.JQuery("input").Property<string>("checked");

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindPropertyBoolean()
        {
            const bool Result = true;
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').prop('checked');")).Returns(Result);
            var result = this.driverMock.Object.JQuery("input").Property("checked");

            Assert.IsNotNull(result);
            Assert.AreEqual(Result, result.Value);
        }

        [Test]
        public void FindPropertyNotExists()
        {
            var result = this.driverMock.Object.JQuery("input").Property("checked");

            Assert.IsNull(result);
        }

        [Test]
        [ExpectedException(typeof(TypeArgumentException))]
        public void FindPropertyInvalidType()
        {
            this.driverMock.Object.JQuery("input").Property<int>("checked");
        }

        [Test]
        public void FindValue()
        {
            const string Result = "test";
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').val();"))
                .Returns(Result);
            var result = this.driverMock.Object.JQuery("input").Value();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindCss()
        {
            const string Result = "hidden";
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').css('display');")).Returns(Result);
            var result = this.driverMock.Object.JQuery("input").Css("display");

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindWidth()
        {
            const long Result = 100;
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').width();"))
                .Returns(Result);
            var result = this.driverMock.Object.JQuery("input").Width();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindHeight()
        {
            const long Result = 100;
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').height();"))
                .Returns(Result);
            var result = this.driverMock.Object.JQuery("input").Height();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindInnerWidth()
        {
            const long Result = 100;
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').innerWidth();")).Returns(Result);
            var result = this.driverMock.Object.JQuery("input").InnerWidth();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindInnerHeight()
        {
            const long Result = 100;
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').innerHeight();")).Returns(Result);
            var result = this.driverMock.Object.JQuery("input").InnerHeight();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindOuterWidth()
        {
            const long Result = 100;
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').outerWidth();")).Returns(Result);
            var result = this.driverMock.Object.JQuery("input").OuterWidth();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindOuterHeight()
        {
            const long Result = 100;
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').outerHeight();")).Returns(Result);
            var result = this.driverMock.Object.JQuery("input").OuterHeight();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindOuterWidthWithMargin()
        {
            const long Result = 100;
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').outerWidth(true);")).Returns(Result);
            var result = this.driverMock.Object.JQuery("input").OuterWidth(true);

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindOuterHeightWithMargin()
        {
            const long Result = 100;
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').outerHeight(true);")).Returns(Result);
            var result = this.driverMock.Object.JQuery("input").OuterHeight(true);

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindPosition()
        {
            var dict = new Dictionary<string, object> { { "top", 100 }, { "left", 200 } };
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').position();")).Returns(dict);
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').position();"))).Returns(true);
            var position = this.driverMock.Object.JQuery("input").Position();

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
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').position();")).Returns(null);
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').position();"))).Returns(true);
            var position = this.driverMock.Object.JQuery("input").Position();

            Assert.IsNull(position);
        }

        [Test]
        public void FindOffset()
        {
            var dict = new Dictionary<string, object> { { "top", 100 }, { "left", 200 } };
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').offset();"))
                .Returns(dict);
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').offset();"))).Returns(true);
            var offset = this.driverMock.Object.JQuery("input").Offset();

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
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').offset();"))
                .Returns(null);
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').offset();"))).Returns(true);
            var offset = this.driverMock.Object.JQuery("input").Offset();

            Assert.IsNull(offset);
        }

        [Test]
        public void FindScrollLeft()
        {
            const long Result = 100;
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').scrollLeft();")).Returns(Result);
            var result = this.driverMock.Object.JQuery("input").ScrollLeft();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindScrollTop()
        {
            const long Result = 100;
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').scrollTop();")).Returns(Result);
            var result = this.driverMock.Object.JQuery("input").ScrollTop();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindData()
        {
            const string Result = "val";
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').data('test');")).Returns(Result);
            var result = this.driverMock.Object.JQuery("input").Data("test");

            Assert.AreEqual(Result, result);
        }

        [Test]
        [ExpectedException(typeof(TypeArgumentException))]
        public void FindDataInvalidType()
        {
            this.driverMock.Object.JQuery("input").Data<int>("test");
        }

        [Test]
        public void FindCount()
        {
            const long Result = 2;
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').length;"))
                .Returns(Result);
            var result = this.driverMock.Object.JQuery("input").Count();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindSerialized()
        {
            const string Result = "search=test";
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('form').serialize();")).Returns(Result);
            var result = this.driverMock.Object.JQuery("form").Serialized();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void FindSerializedArray()
        {
            const string Result = "[{\"name\":\"s\",\"value\":\"\"}]";
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return JSON.stringify(jQuery('form').serializeArray());"))
                .Returns(Result);
            var result = this.driverMock.Object.JQuery("form").SerializedArray();

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void HasClass()
        {
            const bool Result = true;
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('form').hasClass('test');")).Returns(Result);
            var result = this.driverMock.Object.JQuery("form").HasClass("test");

            Assert.AreEqual(Result, result);
        }

        [Test]
        public void NumbersCastingInInternetExplorer()
        {
            const double MockedWidth = 100d;
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').width();"))
                .Returns(MockedWidth);
            var result = this.driverMock.Object.JQuery("input").Width();

            Assert.AreEqual(MockedWidth, result);
            Assert.IsInstanceOf<long?>(result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HelperWithNullDriver()
        {
            WebElementExtensions.JQuery(null, (JQuerySelector)null);
        }
    }
}
