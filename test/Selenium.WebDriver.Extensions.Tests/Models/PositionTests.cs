namespace Selenium.WebDriver.Extensions.Tests.Models
{
    using System.Diagnostics.CodeAnalysis;
    using NUnit.Framework;
    using Selenium.WebDriver.Extensions.JQuery;
    
    /// <summary>
    /// Position tests.
    /// </summary>
    [TestFixture]
    [Category("Unit Tests")]
#if !NET35
    [ExcludeFromCodeCoverage]
#endif
    public class PositionTests
    {
        /// <summary>
        /// Tests hash code generation.
        /// </summary>
        [Test]
        public void HashCodeTest()
        {
            var position1 = new Position(0, 0);
            var position2 = new Position(0, 1);
            var position3 = new Position(0, 0);
            var position4 = new Position(1, 0);

            Assert.IsFalse(position1.Equals(position2));
            Assert.IsTrue(position1.Equals(position3));
            Assert.IsFalse(position1.Equals(position4));

            Assert.IsFalse(position1.Equals((object)position2));
            Assert.IsTrue(position1.Equals((object)position3));
            Assert.IsFalse(position1.Equals((object)position4));
            Assert.IsFalse(position1.Equals(new object()));
            
            Assert.AreNotEqual(position1.GetHashCode(), position2.GetHashCode());
            Assert.AreEqual(position1.GetHashCode(), position3.GetHashCode());
            Assert.AreNotEqual(position1.GetHashCode(), position4.GetHashCode());
        }
    }
}
