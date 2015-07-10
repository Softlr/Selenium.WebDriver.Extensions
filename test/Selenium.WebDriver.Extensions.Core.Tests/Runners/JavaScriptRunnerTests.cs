namespace Selenium.WebDriver.Extensions.Core.Tests
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
    public class JavaScriptRunnerTests
    {
        [Fact]
        public void ShouldThrowExceptionForRunnerWithNullDriver()
        {
            var runner = new JavaScriptRunner();

            var ex = Assert.Throws<ArgumentNullException>(() => runner.Find<object>(null, null));
            Assert.Equal("driver", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForNullSelector()
        {
            var runner = new JavaScriptRunner();
            var driver = new Mock<IWebDriver>();

            var ex = Assert.Throws<ArgumentNullException>(() => runner.Find<object>(driver.Object, null));
            Assert.Equal("selector", ex.ParamName);
        }
    }
}
