namespace Selenium.WebDriver.Extensions.Sizzle.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using Moq;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.Sizzle.By;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class SizzleSelectorTests
    {
        private Mock<IWebDriver> driverMock;

        public SizzleSelectorTests()
        {
            this.driverMock = new Mock<IWebDriver>();
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("window.Sizzle"))).Returns(true);
        }

        public static IEnumerable<object[]> SelectorData
        {
            get
            {
                yield return new object[] { By.SizzleSelector("div"), "Sizzle('div')" };
                yield return new object[]
                                 {
                                     By.SizzleSelector("div", By.SizzleSelector("article")), 
                                     "Sizzle('div', Sizzle('article')[0])"
                                 };
                yield return new object[]
                                 {
                                     By.SizzleSelector("input[type='text']"), 
                                     "Sizzle('input[type=\"text\"]')"
                                 };
            }
        }

        public static IEnumerable<object[]> EqualityData
        {
            get
            {
                yield return new object[] { By.SizzleSelector("div"), By.SizzleSelector("div"), true };
                yield return new object[] { By.SizzleSelector("div"), By.SizzleSelector("span"), false };
                yield return new object[] { By.SizzleSelector("div"), null, false };
                yield return new object[] { null, By.SizzleSelector("div"), false };
                yield return new object[]
                                 {
                                     By.SizzleSelector("div", By.SizzleSelector("body")), 
                                     By.SizzleSelector("div"),
                                     false
                                 };
                yield return new object[]
                                 {
                                     By.SizzleSelector("div", By.SizzleSelector("body")),
                                     By.SizzleSelector("div", By.SizzleSelector("body")), 
                                     true
                                 };
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        [Theory]
        [MemberData("SelectorData")]
        public void ShouldGenerateCorrectSelector(SizzleSelector selector, string expectedResult)
        {
            Assert.Equal(expectedResult, selector.Selector);
        }

        [Fact]
        public void ShouldPopulateContextProperty()
        {
            var by = By.SizzleSelector("div", By.SizzleSelector("article"));

            Assert.Equal(by.Selector, "Sizzle('div', Sizzle('article')[0])");
            Assert.Equal(by.Context.Selector, "Sizzle('article')");
        }

        [Fact]
        public void ShouldPopulateFormatStringProperty()
        {
            var formatString = By.SizzleSelector("div").CallFormatString;
            
            Assert.NotNull(formatString);
        }

        [Theory]
        [MemberData("EqualityData")]
        public void ShouldProperlyCompareSelectors(
            SizzleSelector selector1,
            SizzleSelector selector2,
            bool expectedResult)
        {
            Assert.Equal(expectedResult, selector1 == selector2);
            if (selector1 != null)
            {
                Assert.Equal(expectedResult, selector1.Equals(selector2));
                if (selector2 != null)
                {
                    Assert.Equal(expectedResult, selector1.GetHashCode() == selector2.GetHashCode());
                }
            }

            Assert.NotEqual(expectedResult, selector1 != selector2);
        }

        [Fact]
        public void ShouldNotCompareElementsOfDifferentType()
        {
            var selector1 = By.SizzleSelector("div");
            var selector2 = new object();

#pragma warning disable 252,253
            Assert.False(selector1 == selector2);
            Assert.True(selector1 != selector2);
#pragma warning restore 252,253
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingNestedSelectorWithNull()
        {
            var selector = new SizzleSelector("div");
            
            var ex = Assert.Throws<ArgumentNullException>(() => selector.Create(null));
            Assert.Equal("root", ex.ParamName);
        }

        [Fact]
        public void ShouldFindElementWithSizzle()
        {
            var selector = By.SizzleSelector("div");

            var rootElement = new Mock<IWebElement>();
            rootElement.SetupGet(x => x.TagName).Returns("div");

            var element = new Mock<IWebElement>();
            element.SetupGet(x => x.TagName).Returns("span");

            var rootList = new List<IWebElement> { rootElement.Object };
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return Sizzle('div');"))
                .Returns(new ReadOnlyCollection<IWebElement>(rootList));
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)"))).Returns("body > div");
            var elementList = new List<IWebElement> { element.Object };
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return Sizzle('span', Sizzle('body > div')[0]);"))
                .Returns(new ReadOnlyCollection<IWebElement>(elementList));

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(this.driverMock.Object);

            var result = webElement.Object.FindElement(By.SizzleSelector("span"));

            Assert.NotNull(result);
            Assert.Equal("span", result.TagName);
        }

        [Fact]
        public void ShouldFindElementsWithSizzle()
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
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript("return Sizzle('div');"))
                .Returns(new ReadOnlyCollection<IWebElement>(rootList));
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("body > div");
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return Sizzle('span', Sizzle('body > div')[0]);"))
                .Returns(new ReadOnlyCollection<IWebElement>(elementList));

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(this.driverMock.Object);

            var result = webElement.Object.FindElements(By.SizzleSelector("span"));

            Assert.Equal(2, result.Count);

            Assert.Equal("span", result[0].TagName);
            Assert.Equal("test1", result[0].GetAttribute("class"));

            Assert.Equal("span", result[1].TagName);
            Assert.Equal("test2", result[1].GetAttribute("class"));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.driverMock = null;
            }
        }
    }
}
