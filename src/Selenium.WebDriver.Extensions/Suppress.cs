namespace Selenium.WebDriver.Extensions
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;

    [PublicAPI]
    [ExcludeFromCodeCoverage]
    internal static partial class Suppress
    {
        public const string CODE_CRACKER = "CodeCracker.CSharp";
        public const string FXCOP = "FxCop";
        public const string SONARQUBE = "SonarQube";
        public const string STYLECOP = "StyleCop.CSharp";
    }
}
