namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;
    using static Suppress.Category;
    using static Suppress.SonarQube;

    internal class DirectCastParser : ParserBase
    {
        [SuppressMessage(SONARQUBE, S4018)]
        public override TResult Parse<TResult>(object rawResult) => (TResult)rawResult;
    }
}
