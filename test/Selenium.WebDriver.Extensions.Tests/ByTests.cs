namespace Selenium.WebDriver.Extensions.Tests
{
    [Trait(CATEGORY, UNIT)]
    [ExcludeFromCodeCoverage]
    public class ByTests
    {
        private static readonly IFixture _fixture = new Fixture();

        public static TheoryData<SeleniumBy> CoreSelectors
        {
            get
            {
                return new TheoryData<SeleniumBy>
                {
                    ClassName($"{nameof(ClassName)}{_fixture.Create<string>()}"),
                    CssSelector(_fixture.Create<string>()),
                    Id(_fixture.Create<string>()),
                    LinkText(_fixture.Create<string>()),
                    Name(_fixture.Create<string>()),
                    PartialLinkText(_fixture.Create<string>()),
                    TagName(_fixture.Create<string>()),
                    XPath(_fixture.Create<string>())
                };
            }
        }

        [Theory]
        [MemberData(nameof(CoreSelectors))]
        public void Selector_creation_works(SeleniumBy sut) => sut.Should().NotBeNull();
    }
}
