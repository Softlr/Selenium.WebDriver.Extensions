namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture;
    using FluentAssertions;
    using JetBrains.Annotations;
    using Xunit;
    using static By;
    using static Shared.Trait;
    using SeleniumBy = OpenQA.Selenium.By;

    [Trait(CATEGORY, UNIT)]
    [ExcludeFromCodeCoverage]
    public class ByTests
    {
        private static readonly IFixture _fixture = new Fixture();

        [PublicAPI]
        public static TheoryData<SeleniumBy> CoreSelectors =>
            new TheoryData<SeleniumBy>
            {
                ClassName(_fixture.Create<string>()),
                CssSelector(_fixture.Create<string>()),
                Id(_fixture.Create<string>()),
                LinkText(_fixture.Create<string>()),
                Name(_fixture.Create<string>()),
                PartialLinkText(_fixture.Create<string>()),
                TagName(_fixture.Create<string>()),
                XPath(_fixture.Create<string>())
            };

        [Theory]
        [MemberData(nameof(CoreSelectors))]
        public void ShouldCreateSelector(SeleniumBy sut) => sut.Should().NotBeNull();
    }
}