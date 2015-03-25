namespace Selenium.WebDriver.Extensions.Sizzle.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Moq;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    using Selenium.WebDriver.Extensions.Sizzle;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.Sizzle.By;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class WebDriverExtensionsTests
    {
        public static IEnumerable<object[]> LoadSizzleData
        {
            get
            {
                yield return new object[] { "master", null, new object[] { true } };
                yield return new object[] { "1.11.1", null, new object[] { false, true, true } };
            }
        }

        public static IEnumerable<object[]> LoadSizzleWithUriData
        {
            get
            {
                yield return new object[] { new Uri("http://my.com/sizzle.js"), null, new object[] { true } };
                yield return new object[] { null, null, new object[] { false, true, true } };
            }
        }

        [Theory]
        [MemberData("LoadSizzleData")]
        public void ShouldLoadSizzle(string version, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var driverMock = new Mock<IWebDriver>();
            var sequence = driverMock.As<IJavaScriptExecutor>()
                .SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            driverMock.Object.Sizzle().Load(version, timeout);
        }

        [Theory]
        [MemberData("LoadSizzleWithUriData")]
        public void ShouldLoadSizzleWithUri(Uri sizzleUri, TimeSpan? timeout, IEnumerable<object> mockValueSequence)
        {
            var driverMock = new Mock<IWebDriver>();
            var sequence = driverMock.As<IJavaScriptExecutor>()
                .SetupSequence(x => x.ExecuteScript(It.IsAny<string>()));
            mockValueSequence.Aggregate(sequence, (current, mockValue) => current.Returns(mockValue));
            driverMock.Object.Sizzle().Load(sizzleUri, timeout);
        }

        [Fact]
        public void ShouldTimeoutWhenSizzleFailesToLoad()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsAny<string>())).Returns(false);
            Assert.Throws<WebDriverTimeoutException>(() =>
                driverMock.Object.Sizzle().Load(timeout: TimeSpan.FromMilliseconds(100)));
        }

        [Fact]
        public void ShouldFindElementWithSizzle()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("window.Sizzle")))
                .Returns(true);

            var element = new Mock<IWebElement>();
            element.Setup(x => x.TagName).Returns("div");

            var list = new List<IWebElement> { element.Object };

            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return Sizzle('div');"))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            var result = driverMock.Object.FindElement(By.SizzleSelector("div"));

            Assert.NotNull(result);
            Assert.Equal("div", result.TagName);
        }

        [Fact]
        public void ShouldThrowExceptionForNullSizzleSelector()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("window.Sizzle")))
                .Returns(true);

            var ex = Assert.Throws<ArgumentNullException>(() => driverMock.Object.FindElement((SizzleSelector)null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenSizzleFindsNoElement()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("window.Sizzle")))
                .Returns(true);

            Assert.Throws<NoSuchElementException>(() =>
                driverMock.Object.FindElement(By.SizzleSelector("div")));
        }

        [Fact]
        public void ShouldThrowExceptionWhenSizzleFindsEmptyResult()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("window.Sizzle")))
                .Returns(true);
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return Sizzle('div');"))
                .Returns(Enumerable.Empty<IWebElement>());

            Assert.Throws<NoSuchElementException>(() =>
                driverMock.Object.FindElement(By.SizzleSelector("div")));
        }

        [Fact]
        public void ShouldFindElementsWithSizzle()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("window.Sizzle")))
                .Returns(true);

            var element1 = new Mock<IWebElement>();
            element1.Setup(x => x.TagName).Returns("div");
            element1.Setup(x => x.GetAttribute("class")).Returns("test");

            var element2 = new Mock<IWebElement>();
            element2.Setup(x => x.TagName).Returns("span");
            element2.Setup(x => x.GetAttribute("class")).Returns("test");

            var list = new List<IWebElement> { element1.Object, element2.Object };
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return Sizzle('.test');"))
                .Returns(new ReadOnlyCollection<IWebElement>(list));
            var result = driverMock.Object.FindElements(By.SizzleSelector(".test"));

            Assert.Equal(2, result.Count);

            Assert.Equal("div", result[0].TagName);
            Assert.Equal("test", result[0].GetAttribute("class"));

            Assert.Equal("span", result[1].TagName);
            Assert.Equal("test", result[1].GetAttribute("class"));
        }

        [Fact]
        public void ShouldReturnEmptyResultsWhenSizzleDoentFindAnyMatches()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("window.Sizzle")))
                .Returns(true);

            var list = new List<object>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return Sizzle('.test');"))
                .Returns(new ReadOnlyCollection<object>(list));
            var result = driverMock.Object.FindElements(By.SizzleSelector(".test"));

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void ShouldThrowExceptionWhenGettingSizzleHelperWithNullDriver()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Sizzle.WebDriverExtensions.Sizzle(null));
            Assert.Equal("driver", ex.ParamName);
        }
    }
}
