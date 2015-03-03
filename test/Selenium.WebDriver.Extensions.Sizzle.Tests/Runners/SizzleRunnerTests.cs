namespace Selenium.WebDriver.Extensions.Sizzle.Tests
{
    using System;
    using NUnit.Framework;
    using Selenium.WebDriver.Extensions.Sizzle;

    /// <summary>
    /// Sizzle runner tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class SizzleRunnerTests
    {
        /// <summary>
        /// Script loading test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindArgumentNull()
        {
            var runner = new SizzleRunner();
            runner.Find<object>(null, null);
        }
    }
}
