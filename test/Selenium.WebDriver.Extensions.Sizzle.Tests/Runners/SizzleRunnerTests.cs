namespace Selenium.WebDriver.Extensions.Sizzle.Tests
{
    using System;
    using Selenium.WebDriver.Extensions.Sizzle;
    using Xunit;

    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class SizzleRunnerTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenSelectorIsNull()
        {
            var runner = new SizzleRunner();

            Assert.Throws<ArgumentNullException>(() => runner.Find<object>(null, null));
        }
    }
}
