namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture;
    using FluentAssertions;
    using JetBrains.Annotations;
    using Xunit;

    [Trait(Trait.Name.CATEGORY, Trait.Category.UNIT)]
    [ExcludeFromCodeCoverage]
    public class ByTests
    {
        [PublicAPI]
        public static IEnumerable<object[]> CoreSelectors
        {
            get
            {
                var fixture = new Fixture();
                yield return new object[] { By.CssSelector(fixture.Create<string>()) };
                yield return new object[] { By.TagName(fixture.Create<string>()) };
                yield return new object[] { By.Id(fixture.Create<string>()) };
                yield return new object[] { By.Name(fixture.Create<string>()) };
                yield return new object[] { By.ClassName(fixture.Create<string>()) };
                yield return new object[] { By.LinkText(fixture.Create<string>()) };
                yield return new object[] { By.PartialLinkText(fixture.Create<string>()) };
                yield return new object[] { By.XPath(fixture.Create<string>()) };
            }
        }

        [Theory]
        [MemberData(nameof(CoreSelectors))]
        public void ShouldCreateSelector(OpenQA.Selenium.By sut) => sut.Should().NotBeNull();
    }
}