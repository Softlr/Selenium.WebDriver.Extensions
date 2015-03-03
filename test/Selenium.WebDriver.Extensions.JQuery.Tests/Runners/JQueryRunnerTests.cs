namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using NUnit.Framework;
    
    /// <summary>
    /// JQuery runner tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class JQueryRunnerTests
    {
        /// <summary>
        /// Script loading test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindArgumentNull()
        {
            var runner = new JQueryRunner();
            runner.Find<object>(null, null);
        }
    }
}
