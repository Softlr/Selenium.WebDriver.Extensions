namespace Selenium.WebDriver.Extensions.Sizzle.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Moq;
    using OpenQA.Selenium;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class SizzleHelperTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenCreatingHelperWithNullDriver()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new SizzleHelper(null));
            Assert.Equal("driver", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleOfNullVersion()
        {
            var driver = new Mock<IWebDriver>();
            var helper = new SizzleHelper(driver.Object);
            var ex = Assert.Throws<ArgumentNullException>(() => helper.Load((string)null));
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleOfEmptyVersion()
        {
            var driver = new Mock<IWebDriver>();
            var helper = new SizzleHelper(driver.Object);
            var ex = Assert.Throws<ArgumentException>(() => helper.Load(string.Empty));
            Assert.Equal("version", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLoadingSizzleOfWhiteSpaceOnlyVersion()
        {
            var driver = new Mock<IWebDriver>();
            var helper = new SizzleHelper(driver.Object);
            var ex = Assert.Throws<ArgumentException>(() => helper.Load(" "));
            Assert.Equal("version", ex.ParamName);
        }
    }
}
