namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using Xunit;

    [Trait("Category", "Unit")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class PositionTests
    {
        [Fact]
        public void HashCodeTest()
        {
            var position1 = new Position(0, 0);
            var position2 = new Position(0, 1);
            var position3 = new Position(0, 0);
            var position4 = new Position(1, 0);

            Assert.False(position1.Equals(position2));
            Assert.True(position1.Equals(position3));
            Assert.False(position1.Equals(position4));

            Assert.False(position1 == position2);
            Assert.True(position1 == position3);
            Assert.False(position1 == position4);

            Assert.True(position1 != position2);
            Assert.False(position1 != position3);
            Assert.True(position1 != position4);

            Assert.False(position1.Equals((object)position2));
            Assert.True(position1.Equals((object)position3));
            Assert.False(position1.Equals((object)position4));
            Assert.False(position1.Equals(new object()));
            
            Assert.NotEqual(position1.GetHashCode(), position2.GetHashCode());
            Assert.Equal(position1.GetHashCode(), position3.GetHashCode());
            Assert.NotEqual(position1.GetHashCode(), position4.GetHashCode());
        }
    }
}
