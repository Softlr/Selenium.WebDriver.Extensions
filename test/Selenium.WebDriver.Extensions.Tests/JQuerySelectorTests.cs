namespace Selenium.WebDriver.Extensions.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture;
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using JetBrains.Annotations;
    using OpenQA.Selenium;
    using Xunit;
    using static System.String;
    using static By;
    using static Shared.Trait;
    using static Softlr.Suppress;

    [Trait(CATEGORY, UNIT)]
    [ExcludeFromCodeCoverage]
    [SuppressMessage(SONARQUBE, S3900)]
    public class JQuerySelectorTests
    {
        private static readonly Fixture _fixture = new Fixture();

        [PublicAPI]
        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        public static TheoryData<Action> SelectorArgumentExceptionTests =>
            new TheoryData<Action>
            {
                () => JQuerySelector(_fixture.Create<string>()).AddBack(Empty),
                () => JQuerySelector(_fixture.Create<string>()).Children(Empty),
                () => JQuerySelector(_fixture.Create<string>()).Next(Empty),
                () => JQuerySelector(_fixture.Create<string>()).NextAll(Empty),
                () => JQuerySelector(_fixture.Create<string>()).NextUntil(Empty, _fixture.Create<string>()),
                () => JQuerySelector(_fixture.Create<string>()).NextUntil(_fixture.Create<string>(), Empty),
                () => JQuerySelector(_fixture.Create<string>()).NextUntil(null, Empty),
                () => JQuerySelector(_fixture.Create<string>()).Prev(Empty),
                () => JQuerySelector(_fixture.Create<string>()).PrevAll(Empty),
                () => JQuerySelector(_fixture.Create<string>()).PrevUntil(Empty, _fixture.Create<string>()),
                () => JQuerySelector(_fixture.Create<string>()).PrevUntil(_fixture.Create<string>(), Empty),
                () => JQuerySelector(_fixture.Create<string>()).PrevUntil(null, Empty),
                () => JQuerySelector(_fixture.Create<string>()).Parent(Empty),
                () => JQuerySelector(_fixture.Create<string>()).Parents(Empty),
                () => JQuerySelector(_fixture.Create<string>()).ParentsUntil(Empty, _fixture.Create<string>()),
                () => JQuerySelector(_fixture.Create<string>()).ParentsUntil(_fixture.Create<string>(), Empty),
                () => JQuerySelector(_fixture.Create<string>()).ParentsUntil(null, Empty),
                () => JQuerySelector(_fixture.Create<string>()).Siblings(Empty),
            };

        [PublicAPI]
        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        public static TheoryData<Action> SelectorNullArgumentExceptionTests =>
            new TheoryData<Action>
            {
                () => JQuerySelector(_fixture.Create<string>()).Add(_fixture.Create<string>(), null),
                () => JQuerySelector(_fixture.Create<string>()).Add(Empty),
                () => JQuerySelector(_fixture.Create<string>()).Add(Empty, JQuerySelector(_fixture.Create<string>())),
                () => JQuerySelector(_fixture.Create<string>()).Add(null),
                () => JQuerySelector(_fixture.Create<string>()).Add(null, JQuerySelector(_fixture.Create<string>())),
                () => JQuerySelector(_fixture.Create<string>()).Closest(_fixture.Create<string>(), null),
                () => JQuerySelector(_fixture.Create<string>()).Closest(Empty),
                () => JQuerySelector(_fixture.Create<string>())
                    .Closest(Empty, JQuerySelector(_fixture.Create<string>())),
                () => JQuerySelector(_fixture.Create<string>()).Closest(null),
                () => JQuerySelector(_fixture.Create<string>())
                    .Closest(null, JQuerySelector(_fixture.Create<string>())),
                () => JQuerySelector(_fixture.Create<string>()).Filter(Empty),
                () => JQuerySelector(_fixture.Create<string>()).Filter(null),
                () => JQuerySelector(_fixture.Create<string>()).Find(Empty),
                () => JQuerySelector(_fixture.Create<string>()).Find(null),
                () => JQuerySelector(_fixture.Create<string>()).Has(Empty),
                () => JQuerySelector(_fixture.Create<string>()).Has(null),
                () => JQuerySelector(_fixture.Create<string>()).Is(Empty),
                () => JQuerySelector(_fixture.Create<string>()).Is(null),
                () => JQuerySelector(_fixture.Create<string>()).Not(Empty),
                () => JQuerySelector(_fixture.Create<string>()).Not(null),
                () => new JQuerySelector(_fixture.Create<string>(), null, _fixture.Create<string>(), null)
            };

        [PublicAPI]
        public static TheoryData<JQuerySelector, string> SelectorsTests
        {
            get
            {
                var tag = _fixture.Create<string>();
                var parentTag = _fixture.Create<string>();
                var variable = _fixture.Create<string>();
                var chain = _fixture.Create<string>();
                var attrName = _fixture.Create<string>();
                var attrValue = _fixture.Create<string>();
                var innerTag = _fixture.Create<string>();
                var selector = _fixture.Create<string>();
                var index1 = _fixture.Create<int>();
                var index2 = _fixture.Create<int>();
                var filter = _fixture.Create<string>();

                return new TheoryData<JQuerySelector, string>
                {
                    // simple selector
                    { JQuerySelector(tag), $"jQuery('{tag}')" },

                    // constructor
                    { new JQuerySelector(tag), $"jQuery('{tag}')" },
                    {
                        new JQuerySelector(tag, new JQuerySelector(parentTag), variable, chain),
                        $"{variable}('{tag}', jQuery('{parentTag}')){chain}"
                    },

                    // escaping
                    { JQuerySelector($"[{attrName}=\"{attrValue}\"]"), $"jQuery('[{attrName}=\"{attrValue}\"]')" },
                    { JQuerySelector($"[{attrName}='{attrValue}']"), $"jQuery('[{attrName}=\"{attrValue}\"]')" },
                    {
                        JQuerySelector(tag).Add($"[{attrName}=\"{attrValue}\"]"),
                        $"jQuery('{tag}').add('[{attrName}=\"{attrValue}\"]')"
                    },
                    {
                        JQuerySelector(tag).Add($"[{attrName}='{attrValue}']"),
                        $"jQuery('{tag}').add('[{attrName}=\"{attrValue}\"]')"
                    },

                    // chained methods
                    { JQuerySelector(tag).Add(innerTag), $"jQuery('{tag}').add('{innerTag}')" },
                    {
                        JQuerySelector(tag).Add(innerTag, JQuerySelector(selector)),
                        $"jQuery('{tag}').add('{innerTag}', jQuery('{selector}'))"
                    },
                    { JQuerySelector(tag).AddBack(), $"jQuery('{tag}').addBack()" },
                    { JQuerySelector(tag).AddBack(innerTag), $"jQuery('{tag}').addBack('{innerTag}')" },
                    { JQuerySelector(tag).AndSelf(), $"jQuery('{tag}').andSelf()" },
                    { JQuerySelector(tag).Children(), $"jQuery('{tag}').children()" },
                    { JQuerySelector(tag).Children(innerTag), $"jQuery('{tag}').children('{innerTag}')" },
                    { JQuerySelector(tag).Closest(innerTag), $"jQuery('{tag}').closest('{innerTag}')" },
                    {
                        JQuerySelector(tag).Closest(innerTag, JQuerySelector(selector)),
                        $"jQuery('{tag}').closest('{innerTag}', jQuery('{selector}'))"
                    },
                    { JQuerySelector(tag).Contents(), $"jQuery('{tag}').contents()" },
                    { JQuerySelector(tag).End(), $"jQuery('{tag}').end()" },
                    { JQuerySelector(tag).Eq(index1), $"jQuery('{tag}').eq({index1})" },
                    { JQuerySelector(tag).Even(), $"jQuery('{tag}').even()" },
                    { JQuerySelector(tag).Filter(selector), $"jQuery('{tag}').filter('{selector}')" },
                    { JQuerySelector(tag).Find(selector), $"jQuery('{tag}').find('{selector}')" },
                    { JQuerySelector(tag).First(), $"jQuery('{tag}').first()" },
                    { JQuerySelector(tag).Has(selector), $"jQuery('{tag}').has('{selector}')" },
                    { JQuerySelector(tag).Is(selector), $"jQuery('{tag}').is('{selector}')" },
                    { JQuerySelector(tag).Last(), $"jQuery('{tag}').last()" },
                    { JQuerySelector(tag).Next(), $"jQuery('{tag}').next()" },
                    { JQuerySelector(tag).Next(selector), $"jQuery('{tag}').next('{selector}')" },
                    { JQuerySelector(tag).NextAll(), $"jQuery('{tag}').nextAll()" },
                    { JQuerySelector(tag).NextAll(selector), $"jQuery('{tag}').nextAll('{selector}')" },
                    { JQuerySelector(tag).NextUntil(), $"jQuery('{tag}').nextUntil()" },
                    { JQuerySelector(tag).NextUntil(null, filter), $"jQuery('{tag}').nextUntil('', '{filter}')" },
                    { JQuerySelector(tag).NextUntil(selector), $"jQuery('{tag}').nextUntil('{selector}')" },
                    {
                        JQuerySelector(tag).NextUntil(selector, filter),
                        $"jQuery('{tag}').nextUntil('{selector}', '{filter}')"
                    },
                    { JQuerySelector(tag).Not(selector), $"jQuery('{tag}').not('{selector}')" },
                    { JQuerySelector(tag).Odd(), $"jQuery('{tag}').odd()" },
                    { JQuerySelector(tag).OffsetParent(), $"jQuery('{tag}').offsetParent()" },
                    { JQuerySelector(tag).Parent(), $"jQuery('{tag}').parent()" },
                    { JQuerySelector(tag).Parent(selector), $"jQuery('{tag}').parent('{selector}')" },
                    { JQuerySelector(tag).Parents(), $"jQuery('{tag}').parents()" },
                    { JQuerySelector(tag).Parents(selector), $"jQuery('{tag}').parents('{selector}')" },
                    { JQuerySelector(tag).ParentsUntil(), $"jQuery('{tag}').parentsUntil()" },
                    {
                        JQuerySelector(tag).ParentsUntil(null, filter),
                        $"jQuery('{tag}').parentsUntil('', '{filter}')"
                    },
                    { JQuerySelector(tag).ParentsUntil(selector), $"jQuery('{tag}').parentsUntil('{selector}')" },
                    {
                        JQuerySelector(tag).ParentsUntil(selector, filter),
                        $"jQuery('{tag}').parentsUntil('{selector}', '{filter}')"
                    },
                    { JQuerySelector(tag).Prev(), $"jQuery('{tag}').prev()" },
                    { JQuerySelector(tag).Prev(selector), $"jQuery('{tag}').prev('{selector}')" },
                    { JQuerySelector(tag).PrevAll(), $"jQuery('{tag}').prevAll()" },
                    { JQuerySelector(tag).PrevAll(selector), $"jQuery('{tag}').prevAll('{selector}')" },
                    { JQuerySelector(tag).PrevUntil(), $"jQuery('{tag}').prevUntil()" },
                    { JQuerySelector(tag).PrevUntil(null, filter), $"jQuery('{tag}').prevUntil('', '{filter}')" },
                    { JQuerySelector(tag).PrevUntil(selector), $"jQuery('{tag}').prevUntil('{selector}')" },
                    {
                        JQuerySelector(tag).PrevUntil(selector, filter),
                        $"jQuery('{tag}').prevUntil('{selector}', '{filter}')"
                    },
                    { JQuerySelector(tag).Siblings(), $"jQuery('{tag}').siblings()" },
                    { JQuerySelector(tag).Siblings(selector), $"jQuery('{tag}').siblings('{selector}')" },
                    { JQuerySelector(tag).Slice(index1), $"jQuery('{tag}').slice({index1})" },
                    { JQuerySelector(tag).Slice(index1, index2), $"jQuery('{tag}').slice({index1}, {index2})" },

                    // chained methods with context
                    {
                        JQuerySelector(tag, JQuerySelector(selector)).Children().First(),
                        $"jQuery('{tag}', jQuery('{selector}')).children().first()"
                    }
                };
            }
        }

        [Theory]
        [MemberData(nameof(SelectorsTests))]
        [SuppressMessage(SONARQUBE, S3242)]
        public void ShouldCreateCorrectSelector(JQuerySelector sut, string expectedSelector) =>
            sut.Selector.Should().Be(expectedSelector);

        [Theory]
        [AutoData]
        public void ShouldCreateJQuerySelector(string rawSelector)
        {
            var sut = JQuerySelector(rawSelector);

            sut.Should().NotBeNull();
            sut.RawSelector.Should().Be(rawSelector);
        }

        [Theory]
        [AutoData]
        public void ShouldCreateJQuerySelectorWithContext(string contextRawSelector, string rawSelector)
        {
            var sut = JQuerySelector(rawSelector, JQuerySelector(contextRawSelector));

            sut.Should().NotBeNull();
            sut.RawSelector.Should().Be(rawSelector);
            sut.Context.RawSelector.Should().Be(contextRawSelector);
        }

        [Theory]
        [AutoData]
        public void ShouldCreateJQuerySelectorWithJQueryVariable(string rawSelector, string variable)
        {
            var sut = JQuerySelector(rawSelector, variable: variable);

            sut.Should().NotBeNull();
            sut.RawSelector.Should().Be(rawSelector);
            sut.Variable.Should().Be(variable);
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementByJQuerySelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementLocatedByJQuery(rawSelector).Build();
            var selector = JQuerySelector(rawSelector);
            var sut = selector.FindElement(driver);

            sut.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementsByJQuerySelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementsLocatedByJQuery(rawSelector).Build();
            var selector = JQuerySelector(rawSelector);
            var sut = selector.FindElements(driver);

            sut.Should().NotBeNull().And.HaveCount(2);
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementWithNestedJQuerySelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementLocatedByJQuery(rawSelector)
                .WithElementLocatedByJQuery($"body > {rawSelector}").WithPathToElement(rawSelector).Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).Build();
            var selector = JQuerySelector(rawSelector);
            var sut = selector.FindElement(element);

            sut.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void ShouldReturnEmptyResultWhenNoElementsAreFoundWithJQuerySelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithNoElementLocatedByJQuery(rawSelector)
                .Build();
            var selector = JQuerySelector(rawSelector);
            var sut = selector.FindElements(driver);

            sut.Should().NotBeNull().And.HaveCount(0);
        }

        [Theory]
        [MemberData(nameof(SelectorArgumentExceptionTests))]
        public void ShouldThrowExceptionForInvalidArguments(Action sut) =>
            FluentActions.Invoking(sut).Should().Throw<ArgumentException>();

        [Theory]
        [MemberData(nameof(SelectorNullArgumentExceptionTests))]
        public void ShouldThrowExceptionForNullArguments(Action sut) =>
            FluentActions.Invoking(sut).Should().Throw<ArgumentNullException>();

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithEmptyValue() =>
            FluentActions.Invoking(() => JQuerySelector(Empty)).Should().Throw<ArgumentException>().And.ParamName
                .Should().Be("selector");

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithEmptyVariableValue(string rawSelector) =>
            FluentActions.Invoking(() => JQuerySelector(rawSelector, variable: Empty)).Should()
                .Throw<ArgumentException>().And.ParamName.Should().Be("variable");

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithNullValue() =>
            FluentActions.Invoking(() => JQuerySelector(null)).Should().Throw<ArgumentNullException>().And.ParamName
                .Should().Be("selector");

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithNullVariableValue(string rawSelector) =>
            FluentActions.Invoking(() => JQuerySelector(rawSelector, variable: null)).Should()
                .Throw<ArgumentNullException>().And.ParamName.Should().Be("variable");

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithWhiteSpaceOnlyValue() =>
            FluentActions.Invoking(() => JQuerySelector(" ")).Should().Throw<ArgumentException>().And.ParamName
                .Should().Be("selector");

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithWhiteSpaceOnlyVariableValue(
            string rawSelector) =>
            FluentActions.Invoking(() => JQuerySelector(rawSelector, variable: " ")).Should()
                .Throw<ArgumentException>().And.ParamName.Should().Be("variable");

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenElementIsNotFoundWithJQuerySelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithNoElementLocatedByJQuery(rawSelector).Build();
            var sut = JQuerySelector(rawSelector);

            FluentActions.Invoking(() => sut.FindElement(driver)).Should().Throw<NoSuchElementException>();
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenSearchContextDoesNotWrapDriver(string rawSelector)
        {
            var element = new SearchContextBuilder().Build();
            var sut = JQuerySelector(rawSelector);

            FluentActions.Invoking(() => sut.FindElement(element)).Should().Throw<InvalidCastException>();
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenSearchContextIsNotWebElement(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementLocatedByJQuery(rawSelector)
                .WithElementLocatedByJQuery($"body > {rawSelector}").WithPathToElement(rawSelector).Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).Build();
            var sut = JQuerySelector(rawSelector);

            FluentActions.Invoking(() => sut.FindElement(element)).Should().Throw<NotSupportedException>();
        }
    }
}