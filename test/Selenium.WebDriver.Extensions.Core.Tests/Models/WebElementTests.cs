namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
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
            var driver = new Mock<IWebDriver>();

            var findElementResult = false;
            var findElementsResult = false;
            var clearResult = false;
            var submitResult = false;
            var sendKeysResult = false;
            var clickResult = false;
            var getAtrributeResult = false;
            var getCssValueResult = false;
            var webElement = new Mock<IWebElement>();
            webElement.As<IWrapsDriver>().SetupGet(x => x.WrappedDriver).Returns(driver.Object);
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

            Assert.Same(driver.Object, element.WrappedDriver);
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
    }
}
