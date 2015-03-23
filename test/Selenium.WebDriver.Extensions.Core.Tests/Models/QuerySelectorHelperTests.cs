namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using Xunit;

    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class QuerySelectorHelperTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenCreatingHelperWithNullDriver()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new QuerySelectorHelper(null));
            Assert.Equal("driver", ex.ParamName);
        }
    }
}
