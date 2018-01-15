namespace Selenium.WebDriver.Extensions.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using AutoFixture;
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using JetBrains.Annotations;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions;
    using Xunit;
    using By = By;

    [Trait(Trait.Name.CATEGORY, Trait.Category.UNIT)]
    [ExcludeFromCodeCoverage]
    public class JQuerySelectorTests
    {
        private static readonly Fixture _fixture = new Fixture();

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
                yield return new object[] { By.JQuerySelector(tag), $"jQuery('{tag}')" };

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
                    By.JQuerySelector($"[{attrName}='{attrValue}']"),
                    $"jQuery('[{attrName}=\"{attrValue}\"]')"
                };
                yield return new object[]
                {
                    By.JQuerySelector($"[{attrName}=\"{attrValue}\"]"),
                    $"jQuery('[{attrName}=\"{attrValue}\"]')"
                };
                yield return new object[]
                {
                    By.JQuerySelector(tag).Add($"[{attrName}='{attrValue}']"),
                    $"jQuery('{tag}').add('[{attrName}=\"{attrValue}\"]')"
                };
                yield return new object[]
                {
                    By.JQuerySelector(tag).Add($"[{attrName}=\"{attrValue}\"]"),
                    $"jQuery('{tag}').add('[{attrName}=\"{attrValue}\"]')"
                };

                // chained methods
                yield return new object[] { By.JQuerySelector(tag).Add(innerTag), $"jQuery('{tag}').add('{innerTag}')" };
                yield return new object[]
                {
                    By.JQuerySelector(tag).Add(innerTag, By.JQuerySelector(selector)),
                    $"jQuery('{tag}').add('{innerTag}', jQuery('{selector}'))"
                };
                yield return new object[] { By.JQuerySelector(tag).AddBack(), $"jQuery('{tag}').addBack()" };
                yield return new object[] { By.JQuerySelector(tag).AddBack(innerTag), $"jQuery('{tag}').addBack('{innerTag}')" };
                yield return new object[] { By.JQuerySelector(tag).AndSelf(), $"jQuery('{tag}').andSelf()" };
                yield return new object[] { By.JQuerySelector(tag).Children(), $"jQuery('{tag}').children()" };
                yield return new object[]
                {
                    By.JQuerySelector(tag).Children(innerTag),
                    $"jQuery('{tag}').children('{innerTag}')"
                };
                yield return new object[] { By.JQuerySelector(tag).Closest(innerTag), $"jQuery('{tag}').closest('{innerTag}')" };
                yield return new object[]
                {
                    By.JQuerySelector(tag).Closest(innerTag, By.JQuerySelector(selector)),
                    $"jQuery('{tag}').closest('{innerTag}', jQuery('{selector}'))"
                };
                yield return new object[] { By.JQuerySelector(tag).Contents(), $"jQuery('{tag}').contents()" };
                yield return new object[] { By.JQuerySelector(tag).End(), $"jQuery('{tag}').end()" };
                yield return new object[] { By.JQuerySelector(tag).Eq(index1), $"jQuery('{tag}').eq({index1})" };
                yield return new object[] { By.JQuerySelector(tag).Filter(selector), $"jQuery('{tag}').filter('{selector}')" };
                yield return new object[] { By.JQuerySelector(tag).Find(selector), $"jQuery('{tag}').find('{selector}')" };
                yield return new object[] { By.JQuerySelector(tag).First(), $"jQuery('{tag}').first()" };
                yield return new object[] { By.JQuerySelector(tag).Last(), $"jQuery('{tag}').last()" };
                yield return new object[] { By.JQuerySelector(tag).Has(selector), $"jQuery('{tag}').has('{selector}')" };
                yield return new object[] { By.JQuerySelector(tag).Is(selector), $"jQuery('{tag}').is('{selector}')" };
                yield return new object[] { By.JQuerySelector(tag).Next(), $"jQuery('{tag}').next()" };
                yield return new object[] { By.JQuerySelector(tag).Next(selector), $"jQuery('{tag}').next('{selector}')" };
                yield return new object[] { By.JQuerySelector(tag).NextAll(), $"jQuery('{tag}').nextAll()" };
                yield return new object[] { By.JQuerySelector(tag).NextAll(selector), $"jQuery('{tag}').nextAll('{selector}')" };
                yield return new object[] { By.JQuerySelector(tag).NextUntil(), $"jQuery('{tag}').nextUntil()" };
                yield return new object[]
                {
                    By.JQuerySelector(tag).NextUntil(selector),
                    $"jQuery('{tag}').nextUntil('{selector}')"
                };
                yield return new object[]
                {
                    By.JQuerySelector(tag).NextUntil(selector, filter),
                    $"jQuery('{tag}').nextUntil('{selector}', '{filter}')"
                };
                yield return new object[]
                {
                    By.JQuerySelector(tag).NextUntil(null, filter),
                    $"jQuery('{tag}').nextUntil('', '{filter}')"
                };
                yield return new object[] { By.JQuerySelector(tag).Prev(), $"jQuery('{tag}').prev()" };
                yield return new object[] { By.JQuerySelector(tag).Prev(selector), $"jQuery('{tag}').prev('{selector}')" };
                yield return new object[] { By.JQuerySelector(tag).PrevAll(), $"jQuery('{tag}').prevAll()" };
                yield return new object[] { By.JQuerySelector(tag).PrevAll(selector), $"jQuery('{tag}').prevAll('{selector}')" };
                yield return new object[] { By.JQuerySelector(tag).PrevUntil(), $"jQuery('{tag}').prevUntil()" };
                yield return new object[]
                {
                    By.JQuerySelector(tag).PrevUntil(selector),
                    $"jQuery('{tag}').prevUntil('{selector}')"
                };
                yield return new object[]
                {
                    By.JQuerySelector(tag).PrevUntil(selector, filter),
                    $"jQuery('{tag}').prevUntil('{selector}', '{filter}')"
                };
                yield return new object[]
                {
                    By.JQuerySelector(tag).PrevUntil(null, filter),
                    $"jQuery('{tag}').prevUntil('', '{filter}')"
                };
                yield return new object[] { By.JQuerySelector(tag).Not(selector), $"jQuery('{tag}').not('{selector}')" };
                yield return new object[] { By.JQuerySelector(tag).OffsetParent(), $"jQuery('{tag}').offsetParent()" };
                yield return new object[] { By.JQuerySelector(tag).Parent(), $"jQuery('{tag}').parent()" };
                yield return new object[] { By.JQuerySelector(tag).Parent(selector), $"jQuery('{tag}').parent('{selector}')" };
                yield return new object[] { By.JQuerySelector(tag).Parents(), $"jQuery('{tag}').parents()" };
                yield return new object[] { By.JQuerySelector(tag).Parents(selector), $"jQuery('{tag}').parents('{selector}')" };
                yield return new object[] { By.JQuerySelector(tag).ParentsUntil(), $"jQuery('{tag}').parentsUntil()" };
                yield return new object[]
                {
                    By.JQuerySelector(tag).ParentsUntil(selector),
                    $"jQuery('{tag}').parentsUntil('{selector}')"
                };
                yield return new object[]
                {
                    By.JQuerySelector(tag).ParentsUntil(selector, filter),
                    $"jQuery('{tag}').parentsUntil('{selector}', '{filter}')"
                };
                yield return new object[]
                {
                    By.JQuerySelector(tag).ParentsUntil(null, filter),
                    $"jQuery('{tag}').parentsUntil('', '{filter}')"
                };
                yield return new object[] { By.JQuerySelector(tag).Siblings(), $"jQuery('{tag}').siblings()" };
                yield return new object[]
                {
                    By.JQuerySelector(tag).Siblings(selector),
                    $"jQuery('{tag}').siblings('{selector}')"
                };
                yield return new object[] { By.JQuerySelector(tag).Slice(index1), $"jQuery('{tag}').slice({index1})" };
                yield return new object[]
                {
                    By.JQuerySelector(tag).Slice(index1, index2),
                    $"jQuery('{tag}').slice({index1}, {index2})"
                };

                // chained methods with context
                yield return new object[]
                {
                    By.JQuerySelector(tag, By.JQuerySelector(selector)).Children().First(),
                    $"jQuery('{tag}', jQuery('{selector}')).children().first()"
                };
            }
        }

        [PublicAPI]
        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        public static IEnumerable<object[]> SelectorExceptionTests
        {
            get
            {
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => new JQuerySelector(_fixture.Create<string>(), null, _fixture.Create<string>(), null))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Add(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Add(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>())
                        .Add(null, By.JQuerySelector(_fixture.Create<string>())))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>())
                        .Add(string.Empty, By.JQuerySelector(_fixture.Create<string>())))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Add(_fixture.Create<string>(), null))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).AddBack(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Children(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Closest(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Closest(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>())
                        .Closest(null, By.JQuerySelector(_fixture.Create<string>())))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>())
                        .Closest(string.Empty, By.JQuerySelector(_fixture.Create<string>())))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>())
                        .Closest(_fixture.Create<string>(), null))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Filter(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Filter(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Find(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Find(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Has(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Has(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Is(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Is(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Next(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).NextAll(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>())
                        .NextUntil(string.Empty, _fixture.Create<string>()))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>())
                        .NextUntil(_fixture.Create<string>(), string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).NextUntil(null, string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Prev(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).PrevAll(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>())
                        .PrevUntil(string.Empty, _fixture.Create<string>()))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>())
                        .PrevUntil(_fixture.Create<string>(), string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).PrevUntil(null, string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Not(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Not(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Parent(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Parents(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>())
                        .ParentsUntil(string.Empty, _fixture.Create<string>()))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>())
                        .ParentsUntil(_fixture.Create<string>(), string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).ParentsUntil(null, string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector(_fixture.Create<string>()).Siblings(string.Empty))
                };
            }
        }

        [Theory]
        [MemberData(nameof(SelectorsTests))]
        public void ShouldCreateCorrectSelector(JQuerySelector selector, string expectedSelector) =>
            selector.Selector.Should().Be(expectedSelector);

        [Theory]
        [MemberData(nameof(SelectorExceptionTests))]
        public void ShouldThrowExceptionForInvalidSelectors(Type exceptionType, Action selectorAction) =>
            Assert.Throws(exceptionType, selectorAction);

        [Theory]
        [AutoData]
        public void ShouldCreateJQuerySelector(string rawSelector)
        {
            var selector = By.JQuerySelector(rawSelector);

            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be(rawSelector);
        }

        [Theory]
        [AutoData]
        public void ShouldCreateJQuerySelectorWithContext(string contextRawSelector, string rawSelector)
        {
            var context = By.JQuerySelector(contextRawSelector);

            var selector = By.JQuerySelector(rawSelector, context);

            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be(rawSelector);
            selector.Context.RawSelector.Should().Be(contextRawSelector);
        }

        [Theory]
        [AutoData]
        public void ShouldCreateJQuerySelectorWithJQueryVariable(string rawSelector, string variable)
        {
            var selector = By.JQuerySelector(rawSelector, variable: variable);

            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be(rawSelector);
            selector.Variable.Should().Be(variable);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithNullValue()
        {
            void Action() => By.JQuerySelector(null);

            ((Action)Action).ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithEmptyValue()
        {
            void Action() => By.JQuerySelector(string.Empty);

            ((Action)Action).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithWhiteSpaceOnlyValue()
        {
            void Action() => By.JQuerySelector(" ");

            ((Action)Action).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("selector");
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithNullVariableValue(string rawSelector)
        {
            void Action() => By.JQuerySelector(rawSelector, variable: null);

            ((Action)Action).ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("variable");
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithEmptyVariableValue(string rawSelector)
        {
            void Action() => By.JQuerySelector(rawSelector, variable: string.Empty);

            ((Action)Action).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("variable");
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithWhiteSpaceOnlyVariableValue(string rawSelector)
        {
            void Action() => By.JQuerySelector(rawSelector, variable: " ");

            ((Action)Action).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("variable");
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementByJQuerySelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementLocatedByJQuery(rawSelector)
                .Build();
            var selector = By.JQuerySelector(rawSelector);

            var result = selector.FindElement(driver);

            result.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementsByJQuerySelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementsLocatedByJQuery(rawSelector)
                .Build();
            var selector = By.JQuerySelector(rawSelector);

            var result = selector.FindElements(driver);

            result.Should().NotBeNull().And.HaveCount(2);
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenElementIsNotFoundWithJQuerySelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithNoElementLocatedByJQuery(rawSelector)
                .Build();
            var selector = By.JQuerySelector(rawSelector);

            void Action() => selector.FindElement(driver);

            ((Action)Action).ShouldThrow<NoSuchElementException>();
        }

        [Theory]
        [AutoData]
        public void ShouldReturnEmptyResultWhenNoElementsAreFoundWithJQuerySelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithNoElementLocatedByJQuery(rawSelector)
                .Build();
            var selector = By.JQuerySelector(rawSelector);

            var result = selector.FindElements(driver);

            result.Should().NotBeNull().And.HaveCount(0);
        }

        [Theory]
        [AutoData]
        public void ShouldFindElementWithNestedJQuerySelector(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementLocatedByJQuery(rawSelector)
                .WithElementLocatedByJQuery($"body > {rawSelector}").WithPathToElement(rawSelector)
                .Build();
            var element = new SearchContextBuilder().AsWebElement().WithWrappedDriver(driver).Build();
            var selector = By.JQuerySelector(rawSelector);

            var result = selector.FindElement(element);

            result.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenSearchContextIsNotWebElement(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementLocatedByJQuery(rawSelector)
                .WithElementLocatedByJQuery($"body > {rawSelector}").WithPathToElement(rawSelector)
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).Build();

            var selector = By.JQuerySelector(rawSelector);

            void Action() => selector.FindElement(element);

            ((Action)Action).ShouldThrow<NotSupportedException>();
        }

        [Theory]
        [AutoData]
        public void ShouldThrowExceptionWhenSearchContextDoesNotWrapDriver(string rawSelector)
        {
            var element = new SearchContextBuilder().AsWebElement().Build();

            var selector = By.JQuerySelector(rawSelector);

            void Action() => selector.FindElement(element);

            ((Action)Action).ShouldThrow<InvalidCastException>();
        }
    }
}