namespace Selenium.WebDriver.Extensions.Tests
{
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using NUnit.Framework;

    /// <summary>
    /// JQuery selector tests.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class JQuerySelectorTests
    {
        /// <summary>
        /// Gets the selector test cases.
        /// </summary>
        private IEnumerable SelectorTestCases
        {
            get
            {
                // basic tests
                yield return new TestCaseData(By.JQuerySelector("div"))
                    .Returns("jQuery('div')");

                // functions tests
                yield return new TestCaseData(By.JQuerySelector("div").Add("span"))
                    .Returns("jQuery('div').add('span')");
                yield return new TestCaseData(By.JQuerySelector("div").AddBack())
                    .Returns("jQuery('div').addBack()");
                yield return new TestCaseData(By.JQuerySelector("div").AddBack("span"))
                    .Returns("jQuery('div').addBack('span')");
                yield return new TestCaseData(By.JQuerySelector("div").AndSelf())
                    .Returns("jQuery('div').andSelf()");
                yield return new TestCaseData(By.JQuerySelector("div").Children())
                    .Returns("jQuery('div').children()");
                yield return new TestCaseData(By.JQuerySelector("div").Children("span"))
                    .Returns("jQuery('div').children('span')");
                yield return new TestCaseData(By.JQuerySelector("div").Closest("span"))
                    .Returns("jQuery('div').closest('span')");
                yield return new TestCaseData(By.JQuerySelector("div").Closest("span"))
                    .Returns("jQuery('div').closest('span')");
                yield return new TestCaseData(By.JQuerySelector("div").Contents())
                    .Returns("jQuery('div').contents()");
                yield return new TestCaseData(By.JQuerySelector("div").End())
                    .Returns("jQuery('div').end()");
                yield return new TestCaseData(By.JQuerySelector("div").Eq(0))
                    .Returns("jQuery('div').eq(0)");
                yield return new TestCaseData(By.JQuerySelector("div").Eq(-2))
                    .Returns("jQuery('div').eq(-2)");
                yield return new TestCaseData(By.JQuerySelector("div").Filter(".empty"))
                    .Returns("jQuery('div').filter('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").Find(".empty"))
                    .Returns("jQuery('div').find('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").First())
                    .Returns("jQuery('div').first()");
                yield return new TestCaseData(By.JQuerySelector("div").Has(".empty"))
                    .Returns("jQuery('div').has('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").Is(".empty"))
                    .Returns("jQuery('div').is('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").Last())
                    .Returns("jQuery('div').last()");
                yield return new TestCaseData(By.JQuerySelector("div").Next(".empty"))
                    .Returns("jQuery('div').next('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").NextAll(".empty"))
                    .Returns("jQuery('div').nextAll('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").NextUntil(".empty"))
                    .Returns("jQuery('div').nextUntil('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").NextUntil(".empty", "span"))
                    .Returns("jQuery('div').nextUntil('.empty', 'span')");
                yield return new TestCaseData(By.JQuerySelector("div").Not(".empty"))
                    .Returns("jQuery('div').not('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").OffsetParent())
                    .Returns("jQuery('div').offsetParent()");
                yield return new TestCaseData(By.JQuerySelector("div").Parent(".parent"))
                    .Returns("jQuery('div').parent('.parent')");
                yield return new TestCaseData(By.JQuerySelector("div").Parents(".parent"))
                    .Returns("jQuery('div').parents('.parent')");
                yield return new TestCaseData(By.JQuerySelector("div").ParentsUntil(".parent"))
                    .Returns("jQuery('div').parentsUntil('.parent')");
                yield return new TestCaseData(By.JQuerySelector("div").ParentsUntil(".parent", "body"))
                    .Returns("jQuery('div').parentsUntil('.parent', 'body')");
                yield return new TestCaseData(By.JQuerySelector("div").Prev(".empty"))
                    .Returns("jQuery('div').prev('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").PrevAll(".empty"))
                    .Returns("jQuery('div').prevAll('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").PrevUntil(".empty"))
                    .Returns("jQuery('div').prevUntil('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").PrevUntil(".empty", "span"))
                    .Returns("jQuery('div').prevUntil('.empty', 'span')");
                yield return new TestCaseData(By.JQuerySelector("div").Siblings(".empty"))
                    .Returns("jQuery('div').siblings('.empty')");
                yield return new TestCaseData(By.JQuerySelector("div").Slice(1))
                    .Returns("jQuery('div').slice(1)");
                yield return new TestCaseData(By.JQuerySelector("div").Slice(1, 3))
                    .Returns("jQuery('div').slice(1, 3)");
                yield return new TestCaseData(By.JQuerySelector("div").Slice(-3, -1))
                    .Returns("jQuery('div').slice(-3, -1)");

                // additional tests
                yield return new TestCaseData(By.JQuerySelector("div").AddBack(string.Empty))
                    .Returns("jQuery('div').addBack()");
                yield return new TestCaseData(By.JQuerySelector("div").AddBack(" "))
                    .Returns("jQuery('div').addBack()");
                yield return new TestCaseData(By.JQuerySelector("div").AddBack(" span "))
                    .Returns("jQuery('div').addBack('span')");
            }
        }

        /// <summary>
        /// Tests if the proper selector is generated.
        /// </summary>
        /// <param name="selector">The jQuery selector.</param>
        /// <returns>The generated jQuery selector.</returns>
        [TestCaseSource(typeof(JQuerySelectorTests), "SelectorTestCases")]
        public string Selector(JQuerySelector selector)
        {
            return selector.Selector;
        }
    }
}
