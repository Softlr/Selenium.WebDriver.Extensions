namespace Selenium.WebDriver.Extensions.Core.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
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
