namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using OpenQA.Selenium;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.Core.By;

    [Trait("Category", "Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class XPathSelectorTests
    {
        public static IEnumerable<object[]> EqualityData
        {
            get
            {
                yield return new object[] { By.XPath("html"), By.XPath("html"), true };
                yield return new object[] { By.XPath("html"), By.XPath("body"), false };
                yield return new object[] { By.XPath("html"), null, false };
                yield return new object[] { null, By.XPath("html"), false };
            }
        }

        [Fact]
        public void ShouldGenerateCorrectSelector()
        {
            var selector = By.XPath("html");
            Assert.Equal(selector.Selector, selector.ToString());
        }

        [Fact]
        public void ShouldThrowErrorForNullSelector()
        {
            Assert.Throws<ArgumentNullException>(() => By.XPath(null));
        }

        [Fact]
        public void ShouldPopulateFormatStringProperty()
        {
            var formatString = By.XPath("html").CallFormatString;
            Assert.NotNull(formatString);
        }

        [Theory]
        [MemberData("EqualityData")]
        public void ShouldProperlyCompareSelectors(
            XPathSelector selector1, 
            XPathSelector selector2, 
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
            var selector1 = By.XPath("text");
            var selector2 = new object();

#pragma warning disable 252,253
            Assert.False(selector1 == selector2);
            Assert.True(selector1 != selector2);
#pragma warning restore 252,253
        }
        
        [Fact]
        public void ShouldHaveProperRunnerType()
        {
            var selector = new XPathSelector("/html");

            Assert.Equal(typeof(JavaScriptRunner), selector.RunnerType);
        }

        [Fact]
        public void ShouldCreateSelectorWithLeadingSlash()
        {
            var rootSelector = new Mock<ISelector>();
            rootSelector.SetupGet(x => x.Selector).Returns("/body");
            rootSelector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("/html[1]/body");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(rootSelector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var selector = By.XPath("/div").Create(element.Object);
            Assert.IsType<XPathSelector>(selector);

            var linkTextSelector = (XPathSelector)selector;
            Assert.Equal("/html[1]/body/div", linkTextSelector.RawSelector);
        }

        [Fact]
        public void ShouldCreateSelectorWithTrailingSlash()
        {
            var rootSelector = new Mock<ISelector>();
            rootSelector.SetupGet(x => x.Selector).Returns("/body");
            rootSelector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("/html[1]/body/");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(rootSelector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var selector = By.XPath("div").Create(element.Object);
            Assert.IsType<XPathSelector>(selector);

            var linkTextSelector = (XPathSelector)selector;
            Assert.Equal("/html[1]/body/div", linkTextSelector.RawSelector);
        }

        [Fact]
        public void ShouldCreateSelectorWithTrailingAndLeadingSlash()
        {
            var rootSelector = new Mock<ISelector>();
            rootSelector.SetupGet(x => x.Selector).Returns("/body");
            rootSelector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("/html[1]/body/");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(rootSelector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var selector = By.XPath("/div").Create(element.Object);
            Assert.IsType<XPathSelector>(selector);

            var linkTextSelector = (XPathSelector)selector;
            Assert.Equal("/html[1]/body//div", linkTextSelector.RawSelector);
        }

        [Fact]
        public void ShouldCreateSelectorWithoutTrailingAndLeadingSlash()
        {
            var rootSelector = new Mock<ISelector>();
            rootSelector.SetupGet(x => x.Selector).Returns("/body");
            rootSelector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("/html[1]/body");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(rootSelector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var selector = By.XPath(".").Create(element.Object);
            Assert.IsType<XPathSelector>(selector);

            var linkTextSelector = (XPathSelector)selector;
            Assert.Equal("/html[1]/body/.", linkTextSelector.RawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingNestedSelectorWithNull()
        {
            var selector = new XPathSelector("//div");

            Assert.Throws<ArgumentNullException>(() => selector.Create(null));
        }
    }
}
