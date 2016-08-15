namespace OpenQA.Selenium.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using OpenQA.Selenium;
    using Xunit;
    using By = OpenQA.Selenium.Extensions.By;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class JQuerySelectorTests
    {
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static IEnumerable<object[]> SelectorsTests
        {
            get
            {
                // simple selector
                yield return new object[]
                {
                    By.JQuerySelector("div"),
                    "jQuery('div')"
                };

                // constructor
                yield return new object[]
                {
                    new JQuerySelector("div"),
                    "jQuery('div')"
                };
                yield return new object[]
                {
                    new JQuerySelector("div", new JQuerySelector("body"), "$", ".children()"),
                    "$('div', jQuery('body')).children()"
                };

                // escaping
                yield return new object[]
                {
                    By.JQuerySelector("[name='foo']"),
                    "jQuery('[name=\"foo\"]')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("[name=\"foo\"]"),
                    "jQuery('[name=\"foo\"]')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Add("[name='foo']"),
                    "jQuery('div').add('[name=\"foo\"]')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Add("[name=\"foo\"]"),
                    "jQuery('div').add('[name=\"foo\"]')"
                };

                // chained methods
                yield return new object[]
                {
                    By.JQuerySelector("div").Add("span"),
                    "jQuery('div').add('span')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Add("span", By.JQuerySelector("#id")),
                    "jQuery('div').add('span', jQuery('#id'))"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").AddBack(),
                    "jQuery('div').addBack()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").AddBack("span"),
                    "jQuery('div').addBack('span')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").AndSelf(),
                    "jQuery('div').andSelf()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Children(),
                    "jQuery('div').children()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Children("span"),
                    "jQuery('div').children('span')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Closest("span"),
                    "jQuery('div').closest('span')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Closest("span", By.JQuerySelector("#id")),
                    "jQuery('div').closest('span', jQuery('#id'))"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Contents(),
                    "jQuery('div').contents()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").End(),
                    "jQuery('div').end()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Eq(1),
                    "jQuery('div').eq(1)"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Filter(".test"),
                    "jQuery('div').filter('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Find(".test"),
                    "jQuery('div').find('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").First(),
                    "jQuery('div').first()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Last(),
                    "jQuery('div').last()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Has(".test"),
                    "jQuery('div').has('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Is(".test"),
                    "jQuery('div').is('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Next(),
                    "jQuery('div').next()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Next(".test"),
                    "jQuery('div').next('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").NextAll(),
                    "jQuery('div').nextAll()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").NextAll(".test"),
                    "jQuery('div').nextAll('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").NextUntil(),
                    "jQuery('div').nextUntil()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").NextUntil(".test"),
                    "jQuery('div').nextUntil('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").NextUntil(".test", "div"),
                    "jQuery('div').nextUntil('.test', 'div')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").NextUntil(null, "div"),
                    "jQuery('div').nextUntil('', 'div')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Prev(),
                    "jQuery('div').prev()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Prev(".test"),
                    "jQuery('div').prev('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").PrevAll(),
                    "jQuery('div').prevAll()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").PrevAll(".test"),
                    "jQuery('div').prevAll('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").PrevUntil(),
                    "jQuery('div').prevUntil()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").PrevUntil(".test"),
                    "jQuery('div').prevUntil('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").PrevUntil(".test", "div"),
                    "jQuery('div').prevUntil('.test', 'div')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").PrevUntil(null, "div"),
                    "jQuery('div').prevUntil('', 'div')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Not(".test"),
                    "jQuery('div').not('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").OffsetParent(),
                    "jQuery('div').offsetParent()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Parent(),
                    "jQuery('div').parent()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Parent(".test"),
                    "jQuery('div').parent('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Parents(),
                    "jQuery('div').parents()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Parents(".test"),
                    "jQuery('div').parents('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").ParentsUntil(),
                    "jQuery('div').parentsUntil()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").ParentsUntil(".test"),
                    "jQuery('div').parentsUntil('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").ParentsUntil(".test", "div"),
                    "jQuery('div').parentsUntil('.test', 'div')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").ParentsUntil(null, "div"),
                    "jQuery('div').parentsUntil('', 'div')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Siblings(),
                    "jQuery('div').siblings()"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Siblings(".test"),
                    "jQuery('div').siblings('.test')"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Slice(0),
                    "jQuery('div').slice(0)"
                };
                yield return new object[]
                {
                    By.JQuerySelector("div").Slice(0, 1),
                    "jQuery('div').slice(0, 1)"
                };

                // chained methods with context
                yield return new object[]
                {
                    By.JQuerySelector("div", By.JQuerySelector("#id")).Children().First(),
                    "jQuery('div', jQuery('#id')).children().first()"
                };
            }
        }

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static IEnumerable<object[]> SelectorExceptionTests
        {
            get
            {
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector("div").Add(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Add(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector("div").Add(null, By.JQuerySelector("#id")))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Add(string.Empty, By.JQuerySelector("#id")))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector("div").Add("span", null))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").AddBack(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Children(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector("div").Closest(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Closest(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector("div").Closest(null, By.JQuerySelector("#id")))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Closest(string.Empty, By.JQuerySelector("#id")))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector("div").Closest("span", null))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector("div").Filter(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Filter(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector("div").Find(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Find(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector("div").Has(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Has(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector("div").Is(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Is(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Next(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").NextAll(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").NextUntil(string.Empty, ".test"))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").NextUntil("span", string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").NextUntil(null, string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Prev(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").PrevAll(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").PrevUntil(string.Empty, ".test"))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").PrevUntil("span", string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").PrevUntil(null, string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentNullException),
                    (Action)(() => By.JQuerySelector("div").Not(null))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Not(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Parent(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Parents(string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").ParentsUntil(string.Empty, ".test"))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").ParentsUntil("span", string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").ParentsUntil(null, string.Empty))
                };
                yield return new object[]
                {
                    typeof(ArgumentException),
                    (Action)(() => By.JQuerySelector("div").Siblings(string.Empty))
                };
            }
        }

        [Theory]
        [MemberData(nameof(SelectorsTests))]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public void ShouldCreateCorrectSelector(JQuerySelector selector, string expectedSelector)
        {
            // Given
            // When
            // Then
            selector.Selector.Should().Be(expectedSelector);
        }

        [Theory]
        [MemberData(nameof(SelectorExceptionTests))]
        public void ShouldThrowExceptionForInvalidSelectors(Type exceptionType, Action selectorAction)
        {
            Assert.Throws(exceptionType, selectorAction);
        }

        [Fact]
        public void ShouldCreateJQuerySelector()
        {
            // Given
            // When
            var selector = By.JQuerySelector("div");

            // Then
            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be("div");
        }

        [Fact]
        public void ShouldCreateJQuerySelectorWithContext()
        {
            // Given
            var context = By.JQuerySelector("body");

            // When
            var selector = By.JQuerySelector("div", context);

            // Then
            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be("div");
            selector.Context.RawSelector.Should().Be("body");
        }

        [Fact]
        public void ShouldCreateJQuerySelectorWithJQueryVariable()
        {
            // Given
            const string Variable = "test";

            // When
            var selector = By.JQuerySelector("div", variable: Variable);

            // Then
            selector.Should().NotBeNull();
            selector.RawSelector.Should().Be("div");
            selector.Variable.Should().Be("test");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithNullValue()
        {
            // Given
            // When
            Action action = () => By.JQuerySelector(null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithEmptyValue()
        {
            // Given
            // When
            Action action = () => By.JQuerySelector(string.Empty);

            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithWhiteSpaceOnlyValue()
        {
            // Given
            // When
            Action action = () => By.JQuerySelector(" ");

            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("selector");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithNullVariableValue()
        {
            // Given
            // When
            Action action = () => By.JQuerySelector("div", variable: null);

            // Then
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("variable");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithEmptyVariableValue()
        {
            // Given
            // When
            Action action = () => By.JQuerySelector("div", variable: string.Empty);

            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("variable");
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingJQuerySelectorWithWhiteSpaceOnlyVariableValue()
        {
            // Given
            // When
            Action action = () => By.JQuerySelector("div", variable: " ");

            // Then
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("variable");
        }

        [Fact]
        public void ShouldFindElementByJQuerySelector()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasJQueryLoaded().ThatContainsElementLocatedByJQuery("div")
                .Build();
            var selector = By.JQuerySelector("div");

            // When
            var result = selector.FindElement(driver);

            // Then
            result.Should().NotBeNull();
        }

        [Fact]
        public void ShouldFindElementsByJQuerySelector()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasJQueryLoaded().ThatContainsElementsLocatedByJQuery("div")
                .Build();
            var selector = By.JQuerySelector("div");

            // When
            var result = selector.FindElements(driver);

            // Then
            result.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void ShouldThrowExceptionWhenElementIsNotFoundWithJQuerySelector()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasJQueryLoaded().ThatDoesNotContainElementLocatedByJQuery("div")
                .Build();
            var selector = By.JQuerySelector("div");

            // When
            Action action = () => selector.FindElement(driver);

            // Then
            action.ShouldThrow<NoSuchElementException>();
        }

        [Fact]
        public void ShouldReturnEmptyResultWhenNoElementsAreFoundWithJQuerySelector()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasJQueryLoaded().ThatDoesNotContainElementLocatedByJQuery("div")
                .Build();
            var selector = By.JQuerySelector("div");

            // When
            var result = selector.FindElements(driver);

            // Then
            result.Should().NotBeNull().And.HaveCount(0);
        }

        [Fact]
        public void ShouldFindElementWithNestedJQuerySelector()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasJQueryLoaded().ThatContainsElementLocatedByJQuery("div")
                .ThatContainsElementLocatedByJQuery("body > div").ThatCanResolvePathToElement("div")
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).ThatIsWebElement().Build();
            var selector = By.JQuerySelector("div");

            // When
            var result = selector.FindElement(element);

            // Then
            result.Should().NotBeNull();
        }

        [Fact]
        public void ShouldThrowExceptionWhenSearchContextIsNotWebElement()
        {
            // Given
            var driver = new WebDriverBuilder().ThatHasJQueryLoaded().ThatContainsElementLocatedByJQuery("div")
                .ThatContainsElementLocatedByJQuery("body > div").ThatCanResolvePathToElement("div")
                .Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).Build();

            var selector = By.JQuerySelector("div");

            // When
            Action action = () => selector.FindElement(element);

            // Then
            action.ShouldThrow<NotSupportedException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenSearchContextDoesNotWrapDriver()
        {
            // Given
            var element = new SearchContextBuilder().ThatIsWebElement().Build();

            var selector = By.JQuerySelector("div");

            // When
            Action action = () => selector.FindElement(element);

            // Then
            action.ShouldThrow<NotSupportedException>();
        }
    }
}
