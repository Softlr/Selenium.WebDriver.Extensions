namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using Xunit;

    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class JQueryRunnerTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenSelectorIsNull()
        {
            var runner = new JQueryRunner();

            Assert.Throws<ArgumentNullException>(() => runner.Find<object>(null, null));
        }
    }
}
