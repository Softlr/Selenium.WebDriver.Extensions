namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using Xunit;

    [Trait("Category", "Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class QuerySelectorRunnerTests
    {
        [Fact]
        public void ShouldThrowExceptionForRunnerWithNullSelector()
        {
            var runner = new QuerySelectorRunner();
            Assert.Throws<ArgumentNullException>(() => runner.Find<object>(null, null));
        }
    }
}
