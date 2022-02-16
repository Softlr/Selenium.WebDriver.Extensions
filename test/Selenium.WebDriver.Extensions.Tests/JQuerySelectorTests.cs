namespace Selenium.WebDriver.Extensions.Tests
{
    [Trait(CATEGORY, UNIT)]
    [ExcludeFromCodeCoverage]
    [SuppressMessage(SONARQUBE, S109)]
    [SuppressMessage(SONARQUBE, S3900)]
    public class JQuerySelectorTests
    {
        private static readonly Fixture _fixture = new();

        public static TheoryData<Action> SelectorArgumentExceptionTests =>
            new()
            {
                () => JQuerySelector(_fixture.Create<string>()).AddBack(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).Children(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).Next(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).NextAll(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).NextUntil(string.Empty, _fixture.Create<string>()),
                () => JQuerySelector(_fixture.Create<string>()).NextUntil(_fixture.Create<string>(), string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).NextUntil(null, string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).Prev(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).PrevAll(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).PrevUntil(string.Empty, _fixture.Create<string>()),
                () => JQuerySelector(_fixture.Create<string>()).PrevUntil(_fixture.Create<string>(), string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).PrevUntil(null, string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).Parent(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).Parents(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).ParentsUntil(string.Empty, _fixture.Create<string>()),
                () => JQuerySelector(_fixture.Create<string>()).ParentsUntil(_fixture.Create<string>(), string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).ParentsUntil(null, string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).Siblings(string.Empty),
            };

        [SuppressMessage(FXCOP, CA1806)]
        public static TheoryData<Action> SelectorNullArgumentExceptionTests =>
            new()
            {
                () => JQuerySelector(_fixture.Create<string>()).Add(_fixture.Create<string>(), null),
                () => JQuerySelector(_fixture.Create<string>()).Add(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).Add(string.Empty, JQuerySelector(_fixture.Create<string>())),
                () => JQuerySelector(_fixture.Create<string>()).Add(null),
                () => JQuerySelector(_fixture.Create<string>()).Add(null, JQuerySelector(_fixture.Create<string>())),
                () => JQuerySelector(_fixture.Create<string>()).Closest(_fixture.Create<string>(), null),
                () => JQuerySelector(_fixture.Create<string>()).Closest(string.Empty),
                () => JQuerySelector(_fixture.Create<string>())
                    .Closest(string.Empty, JQuerySelector(_fixture.Create<string>())),
                () => JQuerySelector(_fixture.Create<string>()).Closest(null),
                () => JQuerySelector(_fixture.Create<string>())
                    .Closest(null, JQuerySelector(_fixture.Create<string>())),
                () => JQuerySelector(_fixture.Create<string>()).Filter(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).Filter(null),
                () => JQuerySelector(_fixture.Create<string>()).Find(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).Find(null),
                () => JQuerySelector(_fixture.Create<string>()).Has(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).Has(null),
                () => JQuerySelector(_fixture.Create<string>()).Is(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).Is(null),
                () => JQuerySelector(_fixture.Create<string>()).Not(string.Empty),
                () => JQuerySelector(_fixture.Create<string>()).Not(null),
                () => new JQuerySelector(_fixture.Create<string>(), null, _fixture.Create<string>(), null)
            };

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
                        new JQuerySelector(tag, new JQuerySelector(parentTag)),
                        $"jQuery('{tag}', jQuery('{parentTag}'))"
                    },
                    {
                        new JQuerySelector(tag, new JQuerySelector(parentTag), variable, chain),
                        $"{variable}('{tag}', jQuery('{parentTag}')){chain}"
                    },
                    { new JQuerySelector(tag, variable), $"{variable}('{tag}'))" },

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
        [AutoData]
        public void Context_without_wrapped_driver_throws_exception(string rawSelector)
        {
            var element = new SearchContextBuilder().AsWebElement().Build();
            var sut = JQuerySelector(rawSelector);

            FluentActions.Invoking(() => sut.FindElement(element)).Should().Throw<InvalidCastException>();
        }

        [Theory]
        [AutoData]
        public void Creating_selector_sets_correct_property_values(string rawSelector)
        {
            var sut = JQuerySelector(rawSelector);

            sut.Should().NotBeNull();
            sut.RawSelector.Should().Be(rawSelector);
        }

        [Theory]
        [AutoData]
        public void Creating_selector_with_context_sets_correct_property_values(
            string contextRawSelector, string rawSelector)
        {
            var sut = JQuerySelector(rawSelector, JQuerySelector(contextRawSelector));

            sut.Should().NotBeNull();
            sut.RawSelector.Should().Be(rawSelector);
            sut.Context.RawSelector.Should().Be(contextRawSelector);
        }

        [Theory]
        [AutoData]
        public void Creating_selector_with_custom_variable_sets_correct_property_values(
            string rawSelector, string variable)
        {
            var sut = JQuerySelector(rawSelector, variable: variable);

            sut.Should().NotBeNull();
            sut.RawSelector.Should().Be(rawSelector);
            sut.Variable.Should().Be(variable);
        }

        [Fact]
        public void Creating_selector_with_empty_value_is_invalid() =>
            FluentActions.Invoking(() => JQuerySelector(string.Empty)).Should().Throw<ArgumentException>().And
                .ParamName.Should().Be("selector");

        [Fact]
        public void Creating_selector_with_null_value_is_invalid() =>
            FluentActions.Invoking(() => JQuerySelector(null)).Should().Throw<ArgumentNullException>().And.ParamName
                .Should().Be("selector");

        [Fact]
        public void Creating_selector_with_whitespace_value_is_invalid() =>
            FluentActions.Invoking(() => JQuerySelector(" ")).Should().Throw<ArgumentException>().And.ParamName
                .Should().Be("selector");

        [Theory]
        [AutoData]
        public void Empty_variable_value_throws_exception(string rawSelector) =>
            FluentActions.Invoking(() => JQuerySelector(rawSelector, variable: string.Empty)).Should()
                .Throw<ArgumentException>().And.ParamName.Should().Be("variable");

        [Theory]
        [MemberData(nameof(SelectorArgumentExceptionTests))]
        public void Invalid_argument_throws_exception(Action sut) =>
            FluentActions.Invoking(sut).Should().Throw<ArgumentException>();

        [Theory]
        [AutoData]
        public void Nested_selector_finds_element(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementLocatedByJQuery(rawSelector)
                .WithElementLocatedByJQuery($"body > {rawSelector}").WithPathToElement(rawSelector).Build();
            var element = new SearchContextBuilder().AsWebElement().WithWrappedDriver(driver).Build();
            var selector = JQuerySelector(rawSelector);
            var sut = selector.FindElement(element);

            sut.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void Non_web_element_throws_exception(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementLocatedByJQuery(rawSelector)
                .WithElementLocatedByJQuery($"body > {rawSelector}").WithPathToElement(rawSelector).Build();
            var element = new SearchContextBuilder().WithWrappedDriver(driver).Build();
            var sut = JQuerySelector(rawSelector);

            FluentActions.Invoking(() => sut.FindElement(element)).Should().Throw<NotSupportedException>();
        }

        [Theory]
        [AutoData]
        public void Not_found_element_throws_exception(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithNoElementLocatedByJQuery(rawSelector).Build();
            var sut = JQuerySelector(rawSelector);

            FluentActions.Invoking(() => sut.FindElement(driver)).Should().Throw<NoSuchElementException>();
        }

        [Theory]
        [MemberData(nameof(SelectorNullArgumentExceptionTests))]
        public void Null_argument_throws_exception(Action sut) =>
            FluentActions.Invoking(sut).Should().Throw<ArgumentNullException>();

        [Theory]
        [AutoData]
        public void Null_variable_value_throws_exception(string rawSelector) =>
            FluentActions.Invoking(() => JQuerySelector(rawSelector, variable: null)).Should()
                .Throw<ArgumentNullException>().And.ParamName.Should().Be("variable");

        [Theory]
        [AutoData]
        public void Selector_does_not_find_non_matching_elements(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithNoElementLocatedByJQuery(rawSelector).Build();
            var selector = JQuerySelector(rawSelector);
            var sut = selector.FindElements(driver);

            sut.Should().NotBeNull().And.HaveCount(0);
        }

        [Theory]
        [AutoData]
        public void Selector_finds_element(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementLocatedByJQuery(rawSelector).Build();
            var selector = JQuerySelector(rawSelector);
            var sut = selector.FindElement(driver);

            sut.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void Selector_finds_elements(string rawSelector)
        {
            var driver = new WebDriverBuilder().WithJQueryLoaded().WithElementsLocatedByJQuery(rawSelector).Build();
            var selector = JQuerySelector(rawSelector);
            var sut = selector.FindElements(driver);

            sut.Should().NotBeNull().And.HaveCount(2);
        }

        [Theory]
        [MemberData(nameof(SelectorsTests))]
        [SuppressMessage(SONARQUBE, S3242)]
        public void Selector_value_should_be_correct(JQuerySelector sut, string expectedSelector) =>
            sut.Selector.Should().Be(expectedSelector);

        [Theory]
        [AutoData]
        public void Whitespace_variable_value_throws_exception(string rawSelector) =>
            FluentActions.Invoking(() => JQuerySelector(rawSelector, variable: " ")).Should()
                .Throw<ArgumentException>().And.ParamName.Should().Be("variable");
    }
}
