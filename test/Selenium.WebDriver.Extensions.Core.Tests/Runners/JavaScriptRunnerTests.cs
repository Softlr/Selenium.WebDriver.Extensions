namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using Xunit;

    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class JavaScriptRunnerTests
    {
        [Fact]
        public void ShouldThrowExceptionForNullSelector()
        {
            var runner = new JavaScriptRunner();
            Assert.Throws<ArgumentNullException>(() => runner.Find<object>(null, null));
        }
    }
}
