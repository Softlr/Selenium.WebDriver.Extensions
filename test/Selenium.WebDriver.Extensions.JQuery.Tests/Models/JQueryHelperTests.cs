namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Moq;
    using OpenQA.Selenium;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class JQueryHelperTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenCreatingHelperWithNullDriver()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new JQueryHelper(null));
            Assert.Equal("driver", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingJQueryOfNullVersion()
        {
            var driver = new Mock<IWebDriver>();
            var helper = new JQueryHelper(driver.Object);
            var ex = Assert.Throws<ArgumentNullException>(() => helper.Load((string)null));
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingJQueryOfEmptyVersion()
        {
            var driver = new Mock<IWebDriver>();
            var helper = new JQueryHelper(driver.Object);
            var ex = Assert.Throws<ArgumentException>(() => helper.Load(string.Empty));
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingJQueryOfWhiteSpaceOnlyVersion()
        {
            var driver = new Mock<IWebDriver>();
            var helper = new JQueryHelper(driver.Object);
            var ex = Assert.Throws<ArgumentException>(() => helper.Load(" "));
            Assert.Equal("version", ex.ParamName);
        }
    }
}
