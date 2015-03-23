namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using Moq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.Core.By;

    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebElementTests
    {
        private Mock<IWebDriver> driverMock;

        public WebElementTests()
        {
            this.driverMock = new Mock<IWebDriver>();
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("\\(document.querySelectorAll\\)"))).Returns(true);
        }

        public void Dispose()
        {
            this.driverMock = null;
        }

        [Fact]
        public void ShouldGetPath()
        {
            var selector = new Mock<ISelector>();
            selector.SetupGet(x => x.Selector).Returns("div");
            selector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)"))).Returns("body > div");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(selector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(this.driverMock.Object);
            
            Assert.Equal("body > div", element.Object.Path);
        }

        [Fact]
        public void ShouldGetXPath()
        {
            var selector = new Mock<ISelector>();
            selector.SetupGet(x => x.Selector).Returns("div");
            selector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)"))).Returns("html[1]/body");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(selector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(this.driverMock.Object);

            Assert.Equal("html[1]/body", element.Object.XPath);
        }

        [Fact]
        public void ShouldFindElementWithXPath()
        {
            var element = new Mock<IWebElement>();
            element.SetupGet(x => x.TagName).Returns("body");

            var list = new List<IWebElement> { element.Object };
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("/html/body");
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("document\\.evaluate")))
                .Returns(new ReadOnlyCollection<IWebElement>(list));

            var result = this.driverMock.Object.FindElement(By.XPath("/html/body"));

            Assert.NotNull(result);
            Assert.Equal("body", result.TagName);
        }

        [Fact]
        public void ShouldFindElementWithQuerySelector()
        {
            var selector = By.QuerySelector("div");

            var rootElement = new Mock<IWebElement>();
            rootElement.SetupGet(x => x.TagName).Returns("div");

            var element = new Mock<IWebElement>();
            element.SetupGet(x => x.TagName).Returns("span");

            var rootList = new List<IWebElement> { rootElement.Object };
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return document.querySelectorAll('div');"))
                .Returns(new ReadOnlyCollection<IWebElement>(rootList));
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("body > div");
            var elementList = new List<IWebElement> { element.Object };
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("document.querySelectorAll\\('body > div'\\).length === 0")))
                .Returns(new ReadOnlyCollection<IWebElement>(elementList));

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(this.driverMock.Object);

            var result = webElement.Object.FindElement(By.QuerySelector("span"));

            Assert.NotNull(result);
            Assert.Equal("span", result.TagName);
        }

        [Fact]
        public void ShouldFindElementsWithQuerySelector()
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
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript("return document.querySelectorAll('div');"))
                .Returns(new ReadOnlyCollection<IWebElement>(rootList));
            this.driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("body > div");
            this.driverMock.As<IJavaScriptExecutor>()
                .Setup(x => x.ExecuteScript(It.IsRegex("document.querySelectorAll\\('body > div'\\).length === 0")))
                .Returns(new ReadOnlyCollection<IWebElement>(elementList));

            var webElement = new Mock<WebElement>();
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Selector).Returns(selector);
            webElement.SetupGet(x => x.WrappedDriver).Returns(this.driverMock.Object);

            var result = webElement.Object.FindElements(By.QuerySelector("span"));

            Assert.Equal(2, result.Count);

            Assert.Equal("span", result[0].TagName);
            Assert.Equal("test1", result[0].GetAttribute("class"));
            
            Assert.Equal("span", result[1].TagName);
            Assert.Equal("test2", result[1].GetAttribute("class"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenFindingElementWithNullSelector()
        {
            var webElement = new Mock<IWebElement>();
            var selector = new Mock<ISelector>();
            var element = new WebElement(webElement.Object, selector.Object);
            Assert.Throws<ArgumentNullException>(() => element.FindElement((ISelector)null));
        }

        [Fact]
        public void ShouldThrowExceptionWhenFindingElementsWithNullSelector()
        {
            var webElement = new Mock<IWebElement>();
            var selector = new Mock<ISelector>();
            var element = new WebElement(webElement.Object, selector.Object);
            Assert.Throws<ArgumentNullException>(() => element.FindElements((ISelector)null));
        }

        [Fact]
        public void ShouldInitializeInnerElementCorrectly()
        {
            var findElementResult = false;
            var findElementsResult = false;
            var clearResult = false;
            var submitResult = false;
            var sendKeysResult = false;
            var clickResult = false;
            var getAtrributeResult = false;
            var getCssValueResult = false;
            var webElement = new Mock<IWebElement>();
            webElement.As<IWrapsDriver>().SetupGet(x => x.WrappedDriver).Returns(this.driverMock.Object);
            webElement.SetupGet(x => x.TagName).Returns("div");
            webElement.SetupGet(x => x.Text).Returns("test");
            webElement.SetupGet(x => x.Enabled).Returns(true);
            webElement.SetupGet(x => x.Selected).Returns(false);
            webElement.SetupGet(x => x.Displayed).Returns(true);
            webElement.SetupGet(x => x.Location).Returns(new Point(10, 20));
            webElement.SetupGet(x => x.Size).Returns(new Size(100, 200));
            webElement.Setup(x => x.FindElement(It.IsAny<OpenQA.Selenium.By>()))
                .Callback(() => { findElementResult = true; });
            webElement.Setup(x => x.FindElements(It.IsAny<OpenQA.Selenium.By>()))
                .Callback(() => { findElementsResult = true; });
            webElement.Setup(x => x.Clear()).Callback(() => { clearResult = true; });
            webElement.Setup(x => x.Submit()).Callback(() => { submitResult = true; });
            webElement.Setup(x => x.SendKeys(It.IsAny<string>())).Callback(() => { sendKeysResult = true; });
            webElement.Setup(x => x.Click()).Callback(() => { clickResult = true; });
            webElement.Setup(x => x.GetAttribute(It.IsAny<string>()))
                .Callback(() => { getAtrributeResult = true; });
            webElement.Setup(x => x.GetCssValue(It.IsAny<string>())).Callback(() => { getCssValueResult = true; });

            var element = new WebElement(webElement.Object, By.TagName("div"));

            Assert.Same(this.driverMock.Object, element.WrappedDriver);
            Assert.Equal(webElement.Object.TagName, element.TagName);
            Assert.Equal(webElement.Object.Text, element.Text);
            Assert.Equal(webElement.Object.Enabled, element.Enabled);
            Assert.Equal(webElement.Object.Selected, element.Selected);
            Assert.Equal(webElement.Object.Displayed, element.Displayed);
            Assert.Equal(webElement.Object.Location, element.Location);
            Assert.Equal(webElement.Object.Size, element.Size);

            element.FindElement(OpenQA.Selenium.By.TagName("div"));
            Assert.True(findElementResult);
            
            element.FindElements(OpenQA.Selenium.By.TagName("div"));
            Assert.True(findElementsResult);

            element.Clear();
            Assert.True(clearResult);

            element.Submit();
            Assert.True(submitResult);

            element.Click();
            Assert.True(clickResult);

            element.SendKeys("abc");
            Assert.True(sendKeysResult);

            element.GetAttribute("class");
            Assert.True(getAtrributeResult);

            element.GetCssValue("display");
            Assert.True(getCssValueResult);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingWebElementWithNullInnerElement()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WebElement(null, By.TagName("div")));
            Assert.Equal("webElement", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingWebElementWithNullSelector()
        {
            var webElement = new Mock<IWebElement>();
            var ex = Assert.Throws<ArgumentNullException>(() => new WebElement(webElement.Object, null));
            Assert.Equal("selector", ex.ParamName);
        }
    }
}
