namespace Selenium.WebDriver.Extensions.Tests.Extensions
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
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
                yield return new object[] { By.CssSelector("div") };
                yield return new object[] { By.TagName("div") };
                yield return new object[] { By.Id("test") };
                yield return new object[] { By.Name("test") };
                yield return new object[] { By.ClassName("test") };
                yield return new object[] { By.LinkText("test") };
                yield return new object[] { By.PartialLinkText("test") };
                yield return new object[] { By.XPath("//div") };
            }
        }

        [Theory]
        [MemberData(nameof(CoreSelectors))]
        public void ShouldCreateSelector(OpenQA.Selenium.By selector)
        {
            // Assert
            selector.Should().NotBeNull();
        }
    }
}
