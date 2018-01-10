namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture;
    using FluentAssertions;
    using Xunit;
    using By = global::Selenium.WebDriver.Extensions.By;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    public class ByTests
    {
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
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
        public void ShouldCreateSelector(OpenQA.Selenium.By selector) => selector.Should().NotBeNull();
    }
}
