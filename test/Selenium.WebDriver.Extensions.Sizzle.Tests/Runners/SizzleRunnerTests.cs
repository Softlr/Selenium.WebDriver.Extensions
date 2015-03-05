namespace Selenium.WebDriver.Extensions.Sizzle.Tests
{
    using System;
    using NUnit.Framework;
    using Selenium.WebDriver.Extensions.Sizzle;

    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class SizzleRunnerTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindArgumentNull()
        {
            var runner = new SizzleRunner();
            runner.Find<object>(null, null);
        }
    }
}
