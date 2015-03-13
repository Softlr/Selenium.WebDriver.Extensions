namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using OpenQA.Selenium;
    using Xunit;
    using Xunit.Extensions;
    using By = Selenium.WebDriver.Extensions.Core.By;

    [Trait("Category", "Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class LinkTextSelectorTests
    {
        public static IEnumerable<object[]> EqualityData
        {
            get
            {
                yield return new object[] { By.LinkText("test"), By.LinkText("test"), true };
                yield return new object[] { By.LinkText("test"), By.LinkText("test2"), false };
                yield return new object[] { By.LinkText("test"), null, false };
                yield return new object[] { null, By.LinkText("test"), false };
                yield return new object[] { By.LinkText("test", "body"), By.LinkText("test"), false };
                yield return new object[] { By.LinkText("test", "body"), By.LinkText("test", "body"), true };
            }
        }

        [Fact]
        public void ShouldGenerateCorrectSelector()
        {
            var selector = By.LinkText("test");
            Assert.Equal(selector.Selector, selector.ToString());
        }

        [Fact]
        public void ShouldThrowExceptionForNullSelector()
        {
            Assert.Throws<ArgumentNullException>(() => By.LinkText(null));
        }

        [Fact]
        public void ShouldThrowExceptionForNullBaseElement()
        {
            Assert.Throws<ArgumentNullException>(() => By.LinkText("test", null));
        }

        [Fact]
        public void ShouldPopulateFormatStringProperty()
        {
            var formatString = By.LinkText("test").CallFormatString;
            Assert.NotNull(formatString);
        }

        [Theory]
        [PropertyData("EqualityData")]
        public void ShouldProperlyCompareSelectors(
            LinkTextSelector selector1, 
            LinkTextSelector selector2, 
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
            var selector1 = By.LinkText("text");
            var selector2 = new object();

#pragma warning disable 252,253
            Assert.False(selector1 == selector2);
            Assert.True(selector1 != selector2);
#pragma warning restore 252,253
        }

        [Fact]
        public void ShouldHaveProperRunnerType()
        {
            var selector = new LinkTextSelector("test");

            Assert.Equal(typeof(QuerySelectorRunner), selector.RunnerType);
        }

        [Fact]
        public void ShouldCreateNestedSelector()
        {
            var rootSelector = new Mock<ISelector>();
            rootSelector.SetupGet(x => x.Selector).Returns("div");
            rootSelector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driver = new Mock<IWebDriver>();
            driver.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("body > div");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(rootSelector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driver.Object);

            var selector = By.LinkText("test").Create(element.Object);
            Assert.IsType<LinkTextSelector>(selector);

            var linkTextSelector = (LinkTextSelector)selector;
            Assert.Equal("test", linkTextSelector.RawSelector);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingNestedSelectorWithNull()
        {
            var selector = new LinkTextSelector("test");

            Assert.Throws<ArgumentNullException>(() => selector.Create(null));
        }
    }
}
