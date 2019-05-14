namespace Selenium.WebDriver.Extensions.Tests
{
    using AutoFixture;
    using FluentAssertions;
    using JetBrains.Annotations;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using static By;
    using static Shared.Trait;
    using SeleniumBy = OpenQA.Selenium.By;

    [Trait(CATEGORY, UNIT)]
    [ExcludeFromCodeCoverage]
    public class ByTests
    {
        [PublicAPI]
        public static IEnumerable<object[]> CoreSelectors
        {
            get
            {
                var fixture = new Fixture();
                yield return new object[] { CssSelector(fixture.Create<string>()) };
                yield return new object[] { TagName(fixture.Create<string>()) };
                yield return new object[] { Id(fixture.Create<string>()) };
                yield return new object[] { Name(fixture.Create<string>()) };
                yield return new object[] { ClassName(fixture.Create<string>()) };
                yield return new object[] { LinkText(fixture.Create<string>()) };
                yield return new object[] { PartialLinkText(fixture.Create<string>()) };
                yield return new object[] { XPath(fixture.Create<string>()) };
            }
        }

        [Theory]
        [MemberData(nameof(CoreSelectors))]
        public void ShouldCreateSelector(SeleniumBy sut) => sut.Should().NotBeNull();
    }
}
