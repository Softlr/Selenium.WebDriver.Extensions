namespace Selenium.WebDriver.Extensions.Tests
{
    using AutoFixture;
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using JetBrains.Annotations;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using static By;
    using static Shared.Trait;
    using static Softlr.Suppress;
    using static System.String;

    [Trait(CATEGORY, UNIT)]
    [ExcludeFromCodeCoverage]
    [SuppressMessage(SONARQUBE, S3900)]
    public class JQuerySelectorTests
    {
        private static readonly Fixture _fixture = new Fixture();

        [PublicAPI]
        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        public static IEnumerable<object[]> SelectorArgumentExceptionTests
        {
            get
            {
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).AddBack(Empty))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).Children(Empty))
                };
                yield return new object[] { (Action)(() => JQuerySelector(_fixture.Create<string>()).Next(Empty)) };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).NextAll(Empty))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(
                        _fixture.Create<string>()).NextUntil(Empty, _fixture.Create<string>()))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(
                        _fixture.Create<string>()).NextUntil(_fixture.Create<string>(), Empty))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).NextUntil(null, Empty))
                };
                yield return new object[] { (Action)(() => JQuerySelector(_fixture.Create<string>()).Prev(Empty)) };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).PrevAll(Empty))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>())
                        .PrevUntil(Empty, _fixture.Create<string>()))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>())
                        .PrevUntil(_fixture.Create<string>(), Empty))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).PrevUntil(null, Empty))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).Parent(Empty))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).Parents(Empty))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>())
                        .ParentsUntil(Empty, _fixture.Create<string>()))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>())
                        .ParentsUntil(_fixture.Create<string>(), Empty))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).ParentsUntil(null, Empty))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).Siblings(Empty))
                };
            }
        }

        [PublicAPI]
        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        public static IEnumerable<object[]> SelectorNullArgumentExceptionTests
        {
            get
            {
                yield return new object[]
                {
                    (Action)(() => new JQuerySelector(
                        _fixture.Create<string>(),
                        null,
                        _fixture.Create<string>(),
                        null))
                };
                yield return new object[] { (Action)(() => JQuerySelector(_fixture.Create<string>()).Add(null)) };
                yield return new object[] { (Action)(() => JQuerySelector(_fixture.Create<string>()).Add(Empty)) };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>())
                        .Add(null, JQuerySelector(_fixture.Create<string>())))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>())
                        .Add(Empty, JQuerySelector(_fixture.Create<string>())))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).Add(_fixture.Create<string>(), null))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).Closest(null))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).Closest(Empty))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>())
                        .Closest(null, JQuerySelector(_fixture.Create<string>())))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>())
                        .Closest(Empty, JQuerySelector(_fixture.Create<string>())))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(
                        _fixture.Create<string>()).Closest(_fixture.Create<string>(), null))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).Filter(null))
                };
                yield return new object[]
                {
                    (Action)(() => JQuerySelector(_fixture.Create<string>()).Filter(Empty))
                };
                yield return new object[] { (Action)(() => JQuerySelector(_fixture.Create<string>()).Find(null)) };
                yield return new object[] { (Action)(() => JQuerySelector(_fixture.Create<string>()).Find(Empty)) };
                yield return new object[] { (Action)(() => JQuerySelector(_fixture.Create<string>()).Has(null)) };
                yield return new object[] { (Action)(() => JQuerySelector(_fixture.Create<string>()).Has(Empty)) };
                yield return new object[] { (Action)(() => JQuerySelector(_fixture.Create<string>()).Is(null)) };
                yield return new object[] { (Action)(() => JQuerySelector(_fixture.Create<string>()).Is(Empty)) };
                yield return new object[] { (Action)(() => JQuerySelector(_fixture.Create<string>()).Not(null)) };
                yield return new object[] { (Action)(() => JQuerySelector(_fixture.Create<string>()).Not(Empty)) };
            }
        }

        [PublicAPI]
        public static IEnumerable<object[]> SelectorsTests
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

                // simple selector
                yield return new object[] { JQuerySelector(tag), $"jQuery('{tag}')" };

                // constructor
                yield return new object[] { new JQuerySelector(tag), $"jQuery('{tag}')" };
                yield return new object[]
                {
                    new JQuerySelector(tag, new JQuerySelector(parentTag), variable, chain),
                    $"{variable}('{tag}', jQuery('{parentTag}')){chain}"
                };

                // escaping
                yield return new object[]
                {
                    JQuerySelector($"[{attrName}='{attrValue}']"),
                    $"jQuery('[{attrName}=\"{attrValue}\"]')"
                };
                yield return new object[]
                {
                    JQuerySelector($"[{attrName}=\"{attrValue}\"]"),
                    $"jQuery('[{attrName}=\"{attrValue}\"]')"
                };
                yield return new object[]
                {
                    JQuerySelector(tag).Add($"[{attrName}='{attrValue}']"),
                    $"jQuery('{tag}').add('[{attrName}=\"{attrValue}\"]')"
                };
                yield return new object[]
                {
                    JQuerySelector(tag).Add($"[{attrName}=\"{attrValue}\"]"),
                    $"jQuery('{tag}').add('[{attrName}=\"{attrValue}\"]')"
                };

                // chained methods
                yield return new object[]
                {
                    JQuerySelector(tag).Add(innerTag),
                    $"jQuery('{tag}').add('{innerTag}')"
                };
                yield return new object[]
                {
                    JQuerySelector(tag).Add(innerTag, JQuerySelector(selector)),
                    $"jQuery('{tag}').add('{innerTag}', jQuery('{selector}'))"
                };
                yield return new object[] { JQuerySelector(tag).AddBack(), $"jQuery('{tag}').addBack()" };
                yield return new object[]
                {
                    JQuerySelector(tag).AddBack(innerTag),
                    $"jQuery('{tag}').addBack('{innerTag}')"
                };
                yield return new object[] { JQuerySelector(tag).AndSelf(), $"jQuery('{tag}').andSelf()" };
                yield return new object[] { JQuerySelector(tag).Children(), $"jQuery('{tag}').children()" };
                yield return new object[]
                {
                    JQuerySelector(tag).Children(innerTag),
                    $"jQuery('{tag}').children('{innerTag}')"
                };
                yield return new object[]
                {
                    JQuerySelector(tag).Closest(innerTag),
                    $"jQuery('{tag}').closest('{innerTag}')"
                };
                yield return new object[]
                {
                    JQuerySelector(tag).Closest(innerTag, JQuerySelector(selector)),
                    $"jQuery('{tag}').closest('{innerTag}', jQuery('{selector}'))"
                };
                yield return new object[] { JQuerySelector(tag).Contents(), $"jQuery('{tag}').contents()" };
                yield return new object[] { JQuerySelector(tag).End(), $"jQuery('{tag}').end()" };
                yield return new object[] { JQuerySelector(tag).Eq(index1), $"jQuery('{tag}').eq({index1})" };
                yield return new object[]
                {
                    JQuerySelector(tag).Filter(selector),
                    $"jQuery('{tag}').filter('{selector}')"
                };
                yield return new object[]
                {
                    JQuerySelector(tag).Find(selector),
                    $"jQuery('{tag}').find('{selector}')"
                };
                yield return new object[] { JQuerySelector(tag).First(), $"jQuery('{tag}').first()" };
                yield return new object[] { JQuerySelector(tag).Last(), $"jQuery('{tag}').last()" };
                yield return new object[]
                {
                    JQuerySelector(tag).Has(selector),
                    $"jQuery('{tag}').has('{selector}')"
                };
                yield return new object[] { JQuerySelector(tag).Is(selector), $"jQuery('{tag}').is('{selector}')" };
                yield return new object[] { JQuerySelector(tag).Next(), $"jQuery('{tag}').next()" };
                yield return new object[]
                {
                    JQuerySelector(tag).Next(selector),
                    $"jQuery('{tag}').next('{selector}')"
                };
                yield return new object[] { JQuerySelector(tag).NextAll(), $"jQuery('{tag}').nextAll()" };
                yield return new object[]
                {
                    JQuerySelector(tag).NextAll(selector),
                    $"jQuery('{tag}').nextAll('{selector}')"
                };
                yield return new object[] { JQuerySelector(tag).NextUntil(), $"jQuery('{tag}').nextUntil()" };
                yield return new object[]
                {
                    JQuerySelector(tag).NextUntil(selector),
                    $"jQuery('{tag}').nextUntil('{selector}')"
                };
                yield return new object[]
                {
                    JQuerySelector(tag).NextUntil(selector, filter),
                    $"jQuery('{tag}').nextUntil('{selector}', '{filter}')"
                };
                yield return new object[]
                {
                    JQuerySelector(tag).NextUntil(null, filter),
                    $"jQuery('{tag}').nextUntil('', '{filter}')"
                };
                yield return new object[] { JQuerySelector(tag).Prev(), $"jQuery('{tag}').prev()" };
                yield return new object[]
                {
                    JQuerySelector(tag).Prev(selector),
                    $"jQuery('{tag}').prev('{selector}')"
                };
                yield return new object[] { JQuerySelector(tag).PrevAll(), $"jQuery('{tag}').prevAll()" };
                yield return new object[]
                {
                    JQuerySelector(tag).PrevAll(selector),
                    $"jQuery('{tag}').prevAll('{selector}')"
                };
                yield return new object[] { JQuerySelector(tag).PrevUntil(), $"jQuery('{tag}').prevUntil()" };
                yield return new object[]
                {
                    JQuerySelector(tag).PrevUntil(selector),
                    $"jQuery('{tag}').prevUntil('{selector}')"
                };
                yield return new object[]
                {
                    JQuerySelector(tag).PrevUntil(selector, filter),
                    $"jQuery('{tag}').prevUntil('{selector}', '{filter}')"
                };
                yield return new object[]
                {
                    JQuerySelector(tag).PrevUntil(null, filter),
                    $"jQuery('{tag}').prevUntil('', '{filter}')"
                };
                yield return new object[]
                {
                    JQuerySelector(tag).Not(selector),
                    $"jQuery('{tag}').not('{selector}')"
                };
                yield return new object[] { JQuerySelector(tag).OffsetParent(), $"jQuery('{tag}').offsetParent()" };
                yield return new object[] { JQuerySelector(tag).Parent(), $"jQuery('{tag}').parent()" };
                yield return new object[]
                {
                    JQuerySelector(tag).Parent(selector),
                    $"jQuery('{tag}').parent('{selector}')"
                };
                yield return new object[] { JQuerySelector(tag).Parents(), $"jQuery('{tag}').parents()" };
                yield return new object[]
                {
                    JQuerySelector(tag).Parents(selector),
                    $"jQuery('{tag}').parents('{selector}')"
                };
                yield return new object[] { JQuerySelector(tag).ParentsUntil(), $"jQuery('{tag}').parentsUntil()" };
                yield return new object[]
                {
                    JQuerySelector(tag).ParentsUntil(selector),
                    $"jQuery('{tag}').parentsUntil('{selector}')"
                };
                yield return new object[]
                {
                    JQuerySelector(tag).ParentsUntil(selector, filter),
                    $"jQuery('{tag}').parentsUntil('{selector}', '{filter}')"
                };
                yield return new object[]
                {
                    JQuerySelector(tag).ParentsUntil(null, filter),
                    $"jQuery('{tag}').parentsUntil('', '{filter}')"
                };
                yield return new object[] { JQuerySelector(tag).Siblings(), $"jQuery('{tag}').siblings()" };
                yield return new object[]
                {
                    JQuerySelector(tag).Siblings(selector),
                    $"jQuery('{tag}').siblings('{selector}')"
                };
                yield return new object[] { JQuerySelector(tag).Slice(index1), $"jQuery('{tag}').slice({index1})" };
                yield return new object[]
                {
                    JQuerySelector(tag).Slice(index1, index2),
                    $"jQuery('{tag}').slice({index1}, {index2})"
                };

                // chained methods with context
                yield return new object[]
                {
                    JQuerySelector(tag, JQuerySelector(selector)).Children().First(),
                    $"jQuery('{tag}', jQuery('{selector}')).children().first()"
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
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementLocatedByJQuery(rawSelector)
                .Build();
            var selector = JQuerySelector(rawSelector);
            var sut = selector.FindElement(driver);

            sut.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementsByJQuerySelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementsLocatedByJQuery(rawSelector)
                .Build();
            var selector = JQuerySelector(rawSelector);
            var sut = selector.FindElements(driver);

            sut.Should().NotBeNull().And.HaveCount(2);
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementWithNestedJQuerySelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementLocatedByJQuery(rawSelector)
                .WithElementLocatedByJQuery($"body > {rawSelector}").WithPathToElement(rawSelector)
                .Build();
            var element = new SearchContextBuilder().AsWebElement().WithWrappedDriver(driver).Build();
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
        public void ShouldThrowExceptionForInvalidArguments(Action sut) => sut.Should().Throw<ArgumentException>();

        [Theory]
        [MemberData(nameof(SelectorNullArgumentExceptionTests))]
        public void ShouldThrowExceptionForNullArguments(Action sut) => sut.Should().Throw<ArgumentNullException>();

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithEmptyValue() =>
            ((Action)(() => JQuerySelector(Empty))).Should().Throw<ArgumentException>()
            .And.ParamName.Should().Be("selector");

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithEmptyVariableValue(string rawSelector) =>
            ((Action)(() => JQuerySelector(rawSelector, variable: Empty))).Should().Throw<ArgumentException>()
            .And.ParamName.Should().Be("variable");

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithNullValue() =>
            ((Action)(() => JQuerySelector(null))).Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("selector");

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithNullVariableValue(string rawSelector) =>
            ((Action)(() => JQuerySelector(rawSelector, variable: null))).Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("variable");

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithWhiteSpaceOnlyValue() =>
            ((Action)(() => JQuerySelector(" "))).Should().Throw<ArgumentException>()
            .And.ParamName.Should().Be("selector");

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithWhiteSpaceOnlyVariableValue(
            string rawSelector) =>
            ((Action)(() => JQuerySelector(rawSelector, variable: " "))).Should().Throw<ArgumentException>()
            .And.ParamName.Should().Be("variable");

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenElementIsNotFoundWithJQuerySelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithNoElementLocatedByJQuery(rawSelector)
                .Build();
            var sut = JQuerySelector(rawSelector);

            ((Action)(() => sut.FindElement(driver))).Should().Throw<NoSuchElementException>();
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenSearchContextDoesNotWrapDriver(string rawSelector)
        {
            var element = new SearchContextBuilder().AsWebElement().Build();
            var sut = JQuerySelector(rawSelector);

            ((Action)(() => sut.FindElement(element))).Should().Throw<InvalidCastException>();
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenSearchContextIsNotWebElement(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementLocatedByJQuery(rawSelector)
                .WithElementLocatedByJQuery($"body > {rawSelector}").WithPathToElement(rawSelector)
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).Build();
            var sut = JQuerySelector(rawSelector);

            ((Action)(() => sut.FindElement(element))).Should().Throw<NotSupportedException>();
        }
    }
}
