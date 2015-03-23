namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using Moq;
    using OpenQA.Selenium;
    using Xunit;

    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class JQueryRunnerTests
    {
        [Fact]
        public void ShouldThrowExceptionForRunnerWithNullDriver()
        {
            var runner = new JQueryRunner();

            var ex = Assert.Throws<ArgumentNullException>(() => runner.Find<object>(null, null));
            Assert.Equal("driver", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForNullSelector()
        {
            var runner = new JQueryRunner();
            var driver = new Mock<IWebDriver>();

            var ex = Assert.Throws<ArgumentNullException>(() => runner.Find<object>(driver.Object, null));
            Assert.Equal("by", ex.ParamName);
        }
    }
}
