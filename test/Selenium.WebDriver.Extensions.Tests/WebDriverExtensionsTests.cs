namespace Selenium.WebDriver.Extensions.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using By = Selenium.WebDriver.Extensions.By;

    /// <summary>
    /// Web driver extensions tests.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
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
        /// Tests jQuery loading.
        /// </summary>
        /// <param name="version">The version of jQuery to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the jQuery load.</param>
        /// <param name="mockValueSequence">
        /// A mock value sequence for <see cref="IJavaScriptExecutor.ExecuteScript"/> method.
        /// </param>
        [TestCaseSource(typeof(WebDriverExtensionsTests), "LoadJQueryTestCases")]
        public void LoadJQuery(string version, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var mock = new Mock<IWebDriver>();
            var sequence = mock.As<IJavaScriptExecutor>().SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            mock.Object.LoadJQuery(version, timeout);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        public void FindElement()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('div').get(0);"))
                .Returns(element.Object);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('div').get(0);")))
                .Returns(true);

            var result = mock.Object.FindElement(By.JQuerySelector("div"));

            Assert.IsNotNull(result);
            Assert.AreEqual("div", result.TagName);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElementArgumentNull()
        {
            var mock = new Mock<IWebDriver>();
            mock.Object.FindElement((JQuerySelector)null);
        }

        /// <summary>
        /// Tests finding an element.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindElementNoSuchElement()
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('div').get(0);"))
                .Returns(null);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('div').get(0);")))
                .Returns(true);

            mock.Object.FindElement(By.JQuerySelector("div"));
        }

        /// <summary>
        /// Tests finding elements.
        /// </summary>
        [Test]
        public void FindElements()
        {
            var element1 = new Mock<IWebElement>();
            element1.Setup(x => x.TagName).Returns("div");
            element1.Setup(x => x.GetAttribute("class")).Returns("test");

            var element2 = new Mock<IWebElement>();
            element2.Setup(x => x.TagName).Returns("span");
            element2.Setup(x => x.GetAttribute("class")).Returns("test");

            var list = new List<IWebElement> { element1.Object, element2.Object };

            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('.test').get();"))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('.test').get();")))
                .Returns(true);

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
        public void FindElementsNotExists()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('.test').get();"))
                .Returns(null);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('.test').get();")))
                .Returns(true);

            var result = mock.Object.FindElements(By.JQuerySelector(".test"));

            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// Tests finding an element text.
        /// </summary>
        [Test]
        public void FindText()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('div').text();"))
                .Returns("test");
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('div').text();")))
                .Returns(true);
            var result = mock.Object.FindText(By.JQuerySelector("div"));

            Assert.AreEqual("test", result);
        }

        /// <summary>
        /// Tests finding an element inner HTML.
        /// </summary>
        [Test]
        public void FindHtml()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('div').html();"))
                .Returns("<p>test</p>");
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('div').html();")))
                .Returns(true);
            var result = mock.Object.FindHtml(By.JQuerySelector("div"));

            Assert.AreEqual("<p>test</p>", result);
        }

        /// <summary>
        /// Tests finding an element attribute.
        /// </summary>
        [Test]
        public void FindAttribute()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('a').attr('href');"))
                .Returns("http://github.com");
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('a').attr('href');")))
                .Returns(true);
            var result = mock.Object.FindAttribute(By.JQuerySelector("a"), "href");

            Assert.AreEqual("http://github.com", result);
        }

        /// <summary>
        /// Tests finding an element attribute that doesn't exist.
        /// </summary>
        [Test]
        public void FindAttributeNotExists()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('a').attr('href');"))
                .Returns(null);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('a').attr('href');")))
                .Returns(true);
            var result = mock.Object.FindAttribute(By.JQuerySelector("a"), "href");

            Assert.IsNull(result);
        }

        /// <summary>
        /// Tests finding an element property.
        /// </summary>
        [Test]
        public void FindProperty()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').prop('checked');"))
                .Returns("true");
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').prop('checked');"))).Returns(true);
            var result = mock.Object.FindProperty(By.JQuerySelector("input"), "checked");

            Assert.AreEqual("true", result);
        }

        /// <summary>
        /// Tests finding an element property that doesn't exist.
        /// </summary>
        [Test]
        public void FindPropertyNotExists()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').prop('checked');"))).Returns(true);
            var result = mock.Object.FindProperty(By.JQuerySelector("input"), "checked");

            Assert.IsNull(result);
        }

        /// <summary>
        /// Tests finding an element value.
        /// </summary>
        [Test]
        public void FindValue()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').val();"))
                .Returns("test");
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').val();"))).Returns(true);
            var result = mock.Object.FindValue(By.JQuerySelector("input"));

            Assert.AreEqual("test", result);
        }

        /// <summary>
        /// Tests finding an element CSS property.
        /// </summary>
        [Test]
        public void FindCssString()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').css('display');"))
                .Returns("hidden");
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').css('display');"))).Returns(true);
            var result = mock.Object.FindCss(By.JQuerySelector("input"), "display");

            Assert.AreEqual("hidden", result);
        }

        /// <summary>
        /// Tests finding an element CSS property.
        /// </summary>
        [Test]
        public void FindCssInt()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return jQuery('input').css('z-index');"))
                .Returns(1);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').css('z-index');"))).Returns(true);
            var result = mock.Object.FindCss<int>(By.JQuerySelector("input"), "z-index");

            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Tests finding an element CSS property that doesn't exist.
        /// </summary>
        [Test]
        public void FindCssNotExists()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').css('display');"))
                .Returns(null);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').css('display');"))).Returns(true);
            var result = mock.Object.FindCss<string>(By.JQuerySelector("input"), "display");

            Assert.IsNull(result);
        }

        /// <summary>
        /// Tests finding an element width.
        /// </summary>
        [Test]
        public void FindWidth()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').width();"))
                .Returns(100);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').width();"))).Returns(true);
            var result = mock.Object.FindWidth(By.JQuerySelector("input"));

            Assert.AreEqual(100, result);
        }

        /// <summary>
        /// Tests finding an element height.
        /// </summary>
        [Test]
        public void FindHeight()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').height();"))
                .Returns(100);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').height();"))).Returns(true);
            var result = mock.Object.FindHeight(By.JQuerySelector("input"));

            Assert.AreEqual(100, result);
        }

        /// <summary>
        /// Tests finding an element inner width.
        /// </summary>
        [Test]
        public void FindInnerWidth()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').innerWidth();"))
                .Returns(100);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').innerWidth();"))).Returns(true);
            var result = mock.Object.FindInnerWidth(By.JQuerySelector("input"));

            Assert.AreEqual(100, result);
        }

        /// <summary>
        /// Tests finding an element inner height.
        /// </summary>
        [Test]
        public void FindInnerHeight()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').innerHeight();"))
                .Returns(100);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').innerHeight();"))).Returns(true);
            var result = mock.Object.FindInnerHeight(By.JQuerySelector("input"));

            Assert.AreEqual(100, result);
        }

        /// <summary>
        /// Tests finding an element outer width.
        /// </summary>
        [Test]
        public void FindOuterWidth()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').outerWidth();"))
                .Returns(100);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').outerWidth();"))).Returns(true);
            var result = mock.Object.FindOuterWidth(By.JQuerySelector("input"));

            Assert.AreEqual(100, result);
        }

        /// <summary>
        /// Tests finding an element outer height.
        /// </summary>
        [Test]
        public void FindOuterHeight()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').outerHeight();"))
                .Returns(100);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').outerHeight();"))).Returns(true);
            var result = mock.Object.FindOuterHeight(By.JQuerySelector("input"));

            Assert.AreEqual(100, result);
        }

        /// <summary>
        /// Tests finding an element outer width with margin.
        /// </summary>
        [Test]
        public void FindOuterWidthWithMargin()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').outerWidth(true);"))
                .Returns(100);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').outerWidth(true);"))).Returns(true);
            var result = mock.Object.FindOuterWidth(By.JQuerySelector("input"), true);

            Assert.AreEqual(100, result);
        }

        /// <summary>
        /// Tests finding an element outer height with margin.
        /// </summary>
        [Test]
        public void FindOuterHeightWithMargin()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').outerHeight(true);"))
                .Returns(100);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').outerHeight(true);"))).Returns(true);
            var result = mock.Object.FindOuterHeight(By.JQuerySelector("input"), true);

            Assert.AreEqual(100, result);
        }

        /// <summary>
        /// Tests finding an element position.
        /// </summary>
        [Test]
        public void FindPosition()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').position().left;"))
                .Returns(100);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').position().top;"))
                .Returns(200);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn(
                    "return jQuery('input').position().left;", 
                    "return jQuery('input').position().top;")))
                .Returns(true);
            var position = mock.Object.FindPosition(By.JQuerySelector("input"));

            Assert.AreEqual(200, position.Top);
            Assert.AreEqual(100, position.Left);
        }

        /// <summary>
        /// Tests finding an element offset.
        /// </summary>
        [Test]
        public void FindOffset()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').offset().left;"))
                .Returns(100);
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').offset().top;"))
                .Returns(200);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn(
                    "return jQuery('input').offset().left;", 
                    "return jQuery('input').offset().top;")))
                .Returns(true);
            var offset = mock.Object.FindOffset(By.JQuerySelector("input"));

            Assert.AreEqual(200, offset.Top);
            Assert.AreEqual(100, offset.Left);
        }

        /// <summary>
        /// Tests finding an element scroll left.
        /// </summary>
        [Test]
        public void FindScrollLeft()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').scrollLeft();"))
                .Returns(100);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').scrollLeft();"))).Returns(true);
            var result = mock.Object.FindScrollLeft(By.JQuerySelector("input"));

            Assert.AreEqual(100, result);
        }

        /// <summary>
        /// Tests finding an element scroll top.
        /// </summary>
        [Test]
        public void FindScrollTop()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').scrollTop();"))
                .Returns(100);
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').scrollTop();"))).Returns(true);
            var result = mock.Object.FindScrollTop(By.JQuerySelector("input"));

            Assert.AreEqual(100, result);
        }

        /// <summary>
        /// Tests finding an element scroll left.
        /// </summary>
        [Test]
        public void FindData()
        {
            var mock = new Mock<IWebDriver>();
            mock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return jQuery('input').data('test');"))
                .Returns("val");
            mock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsNotIn("return jQuery('input').data('test');"))).Returns(true);
            var result = mock.Object.FindData(By.JQuerySelector("input"), "test");

            Assert.AreEqual("val", result);
        }
    }
}
