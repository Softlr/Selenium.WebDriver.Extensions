namespace Selenium.WebDriver.Extensions.JQuery.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Moq;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    using Xunit;
    using By = Selenium.WebDriver.Extensions.JQuery.By;

    [Trait("Category", "Unit")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class JQuerySelectorTests
    {
        public static IEnumerable<object[]> SelectorData
        {
            get
            {
                // basic tests
                yield return new object[] { By.JQuerySelector("div"), "jQuery('div')" };
                yield return new object[] { By.JQuerySelector("div", jQueryVariable: "$"), "$('div')" };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div", By.JQuerySelector("article")), 
                                     "jQuery('div', jQuery('article'))"
                                 };

                // functions tests
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").Add("span", By.JQuerySelector("body")), 
                                     "jQuery('div').add('span', jQuery('body'))"
                                 };
                yield return new object[] { By.JQuerySelector("div").Add("span"), "jQuery('div').add('span')" };
                yield return new object[] { By.JQuerySelector("div").AddBack(), "jQuery('div').addBack()" };
                yield return new object[] { By.JQuerySelector("div").AddBack("span"), "jQuery('div').addBack('span')" };
                yield return new object[] { By.JQuerySelector("div").AndSelf(), "jQuery('div').andSelf()" };
                yield return new object[] { By.JQuerySelector("div").Children(), "jQuery('div').children()" };
                yield return new object[] { By.JQuerySelector("div").Children("span"), "jQuery('div').children('span')" };
                yield return new object[] { By.JQuerySelector("div").Closest("span"), "jQuery('div').closest('span')" };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").Closest("span", By.JQuerySelector("body")), 
                                     "jQuery('div').closest('span', jQuery('body'))"
                                 };
                yield return new object[] { By.JQuerySelector("div").Contents(), "jQuery('div').contents()" };
                yield return new object[] { By.JQuerySelector("div").End(), "jQuery('div').end()" };
                yield return new object[] { By.JQuerySelector("div").Eq(0), "jQuery('div').eq(0)" };
                yield return new object[] { By.JQuerySelector("div").Eq(-2), "jQuery('div').eq(-2)" };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").Filter(".empty"),
                                     "jQuery('div').filter('.empty')"
                                 };
                yield return new object[] { By.JQuerySelector("div").Find(".empty"), "jQuery('div').find('.empty')" };
                yield return new object[] { By.JQuerySelector("div").First(), "jQuery('div').first()" };
                yield return new object[] { By.JQuerySelector("div").Has(".empty"), "jQuery('div').has('.empty')" };
                yield return new object[] { By.JQuerySelector("div").Is(".empty"), "jQuery('div').is('.empty')" };
                yield return new object[] { By.JQuerySelector("div").Last(), "jQuery('div').last()" };
                yield return new object[] { By.JQuerySelector("div").Next(), "jQuery('div').next()" };
                yield return new object[] { By.JQuerySelector("div").Next(".empty"), "jQuery('div').next('.empty')" };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").NextAll(),
                                     "jQuery('div').nextAll()"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").NextAll(".empty"),
                                     "jQuery('div').nextAll('.empty')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").NextUntil(), 
                                     "jQuery('div').nextUntil()"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").NextUntil(".empty"), 
                                     "jQuery('div').nextUntil('.empty')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").NextUntil(".empty", "span"), 
                                     "jQuery('div').nextUntil('.empty', 'span')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").NextUntil(null, "span"), 
                                     "jQuery('div').nextUntil('', 'span')"
                                 };
                yield return new object[] { By.JQuerySelector("div").Not(".empty"), "jQuery('div').not('.empty')" };
                yield return new object[] { By.JQuerySelector("div").OffsetParent(), "jQuery('div').offsetParent()" };
                yield return new object[] { By.JQuerySelector("div").Parent(), "jQuery('div').parent()" };
                yield return new object[] { By.JQuerySelector("div").Parents(), "jQuery('div').parents()" };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").Parent(".parent"), 
                                     "jQuery('div').parent('.parent')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").Parents(".parent"),
                                     "jQuery('div').parents('.parent')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").ParentsUntil(),
                                     "jQuery('div').parentsUntil()"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").ParentsUntil(".parent"),
                                     "jQuery('div').parentsUntil('.parent')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").ParentsUntil(".parent", "body"),
                                     "jQuery('div').parentsUntil('.parent', 'body')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").ParentsUntil(null, "body"),
                                     "jQuery('div').parentsUntil('', 'body')"
                                 };
                yield return new object[] { By.JQuerySelector("div").Prev(), "jQuery('div').prev()" };
                yield return new object[] { By.JQuerySelector("div").Prev(".empty"), "jQuery('div').prev('.empty')" };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").PrevAll(), 
                                     "jQuery('div').prevAll()"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").PrevAll(".empty"), 
                                     "jQuery('div').prevAll('.empty')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").PrevUntil(), 
                                     "jQuery('div').prevUntil()"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").PrevUntil(".empty"), 
                                     "jQuery('div').prevUntil('.empty')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").PrevUntil(".empty", "span"), 
                                     "jQuery('div').prevUntil('.empty', 'span')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").PrevUntil(null, "span"), 
                                     "jQuery('div').prevUntil('', 'span')"
                                 };
                yield return new object[] { By.JQuerySelector("div").Siblings(), "jQuery('div').siblings()" };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").Siblings(".empty"), 
                                     "jQuery('div').siblings('.empty')"
                                 };
                yield return new object[] { By.JQuerySelector("div").Slice(1), "jQuery('div').slice(1)" };
                yield return new object[] { By.JQuerySelector("div").Slice(1, 3), "jQuery('div').slice(1, 3)" };
                yield return new object[] { By.JQuerySelector("div").Slice(-3, -1), "jQuery('div').slice(-3, -1)" };

                // additional tests
                yield return new object[]
                                 {
                                     By.JQuerySelector("div").AddBack(" span "),
                                     "jQuery('div').addBack('span')"
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("input[type='text']"),
                                     "jQuery('input[type=\"text\"]')"
                                 };
            }
        }

        public static IEnumerable<object[]> EqualityData
        {
            get
            {
                yield return new object[] { By.JQuerySelector("div"), By.JQuerySelector("div"), true };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div"), 
                                     By.JQuerySelector("div", jQueryVariable: "$"), 
                                     false
                                 };
                yield return new object[] { By.JQuerySelector("div"), By.JQuerySelector("span"), false };
                yield return new object[] { By.JQuerySelector("div"), null, false };
                yield return new object[] { null, By.JQuerySelector("div"), false };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div", By.JQuerySelector("body")), 
                                     By.JQuerySelector("div"),
                                     false
                                 };
                yield return new object[]
                                 {
                                     By.JQuerySelector("div", By.JQuerySelector("body")), 
                                     By.JQuerySelector("div", By.JQuerySelector("body")),
                                     true
                                 };
            }
        }

        [Theory]
        [MemberData("SelectorData")]
        public void ShouldGenerateCorrectSelector(JQuerySelector selector, string expectedResult)
        {
            Assert.Equal(expectedResult, selector.Selector);
        }

        [Fact]
        public void ShouldPopulateContextProperty()
        {
            var by = By.JQuerySelector("div", By.JQuerySelector("article"));

            Assert.Equal(by.Selector, "jQuery('div', jQuery('article'))");
            Assert.Equal(by.Context.Selector, "jQuery('article')");
        }

        [Fact]
        public void ShouldPopulateJQueryVariable()
        {
            var by = By.JQuerySelector("div", jQueryVariable: "$");

            Assert.Equal(by.JQueryVariable, "$");
        }

        [Fact]
        public void ShouldPopulateFormatStringProperty()
        {
            var formatString = By.JQuerySelector("div").CallFormatString;

            Assert.NotNull(formatString);
        }

        [Theory]
        [MemberData("EqualityData")]
        public void EqualityOperator(JQuerySelector selector1, JQuerySelector selector2, bool expectedResult)
        {
            Assert.Equal(expectedResult, selector1 == selector2);
            if (selector1 != null)
            {
                Assert.Equal(expectedResult, selector1.Equals(selector2));
                if (selector2 != null)
                {
                    Assert.Equal(expectedResult, selector1.GetHashCode() == selector2.GetHashCode());
                }
            }

            Assert.NotEqual(expectedResult, selector1 != selector2);
        }

        [Fact]
        public void ShouldNotCompareElementsOfDifferentType()
        {
            var selector1 = By.JQuerySelector("div");
            var selector2 = new object();

#pragma warning disable 252,253
            Assert.False(selector1 == selector2);
            Assert.True(selector1 != selector2);
#pragma warning restore 252,253
        }

        [Fact]
        public void ShouldThrowExceptionWhenCreatingNestedSelectorWithNull()
        {
            var selector = new JQuerySelector("div");
            var ex = Assert.Throws<ArgumentNullException>(() => selector.Create(null));
            Assert.Equal("root", ex.ParamName);
        }

        [Fact]
        public void ShouldCreateNestedJQueryElement()
        {
            var rootSelector = new Mock<ISelector>();
            rootSelector.SetupGet(x => x.Selector).Returns("div");
            rootSelector.SetupGet(x => x.CallFormatString).Returns("{0}[{1}]");

            var driverMock = new Mock<IWebDriver>();
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("window.jQuery")))
                .Returns(true); 
            driverMock.As<IJavaScriptExecutor>().Setup(x => x.ExecuteScript(It.IsRegex("function\\(element\\)")))
                .Returns("body > div");

            var element = new Mock<WebElement>();
            element.SetupGet(x => x.Selector).Returns(rootSelector.Object);
            element.SetupGet(x => x.WrappedDriver).Returns(driverMock.Object);

            var selector = By.JQuerySelector("test").Create(element.Object);
            Assert.IsType<JQuerySelector>(selector);

            var jquerySelector = (JQuerySelector)selector;
            Assert.Equal("jQuery", jquerySelector.JQueryVariable);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryAddOperationWithNullSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.JQuerySelector("div").Add(null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryAddOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Add(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryAddOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Add(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryAddWithContextOperationWithNullSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.JQuerySelector("div").Add(null, null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryAddWithContextOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Add(string.Empty, null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryAddWithContextOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Add(" ", null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryAddWithContextOperationWithNullContext()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.JQuerySelector("div").Add("div", null));
            Assert.Equal("context", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryAddBackOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").AddBack(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryAddBackOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").AddBack(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryChildrenOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Children(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryChildrenOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Children(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryClosestOperationWithNullSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.JQuerySelector("div").Closest(null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryClosestOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Closest(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryClosestOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Closest(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryClosestWithContextOperationWithNullSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.JQuerySelector("div").Closest(null, null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryClosestWithContextOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Closest(string.Empty, null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryClosestWithContextOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Closest(" ", null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryClosestWithContextOperationWithNullContext()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.JQuerySelector("div").Closest("div", null));
            Assert.Equal("context", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryFilterOperationWithNullSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.JQuerySelector("div").Filter(null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryFilterOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Filter(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryFilterOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Filter(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryFindOperationWithNullSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.JQuerySelector("div").Find(null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryFindOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Find(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryFindOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Find(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryHasOperationWithNullSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.JQuerySelector("div").Has(null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryHasOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Has(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryHasOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Has(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryIsOperationWithNullSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.JQuerySelector("div").Is(null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryIsOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Is(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryIsOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Is(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryNotOperationWithNullSelector()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => By.JQuerySelector("div").Not(null));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryNotOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Not(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryNotOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Not(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryNextOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Next(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryNextOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Next(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryNextAllOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").NextAll(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryNextAllOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").NextAll(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryPrevOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Prev(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryPrevOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Prev(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryPrevAllOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").PrevAll(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryPrevAllOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").PrevAll(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryParentOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Parent(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryParentOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Parent(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryParentsOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Parents(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryParentsOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Parents(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQuerySiblingsOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Siblings(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQuerySiblingsOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").Siblings(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryNextUntilOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").NextUntil(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryNextUntilOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").NextUntil(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryNextUntilOperationWithEmptyFilter()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").NextUntil("div", string.Empty));
            Assert.Equal("filter", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryNextUntilOperationWithWhiteSpaceOnlyFilter()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").NextUntil("div", " "));
            Assert.Equal("filter", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryPrevUntilOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").PrevUntil(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryPrevUntilOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").PrevUntil(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryPrevUntilOperationWithEmptyFilter()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").PrevUntil("div", string.Empty));
            Assert.Equal("filter", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryPrevUntilOperationWithWhiteSpaceOnlyFilter()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").PrevUntil("div", " "));
            Assert.Equal("filter", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryParentsUntilOperationWithEmptySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").ParentsUntil(string.Empty));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryParentsUntilOperationWithWhiteSpaceOnlySelector()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").ParentsUntil(" "));
            Assert.Equal("selector", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryParentsUntilOperationWithEmptyFilter()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => By.JQuerySelector("div").ParentsUntil("div", string.Empty));
            Assert.Equal("filter", ex.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionForJQueryParentsUntilOperationWithWhiteSpaceOnlyFilter()
        {
            var ex = Assert.Throws<ArgumentException>(() => By.JQuerySelector("div").ParentsUntil("div", " "));
            Assert.Equal("filter", ex.ParamName);
        }
    }
}
