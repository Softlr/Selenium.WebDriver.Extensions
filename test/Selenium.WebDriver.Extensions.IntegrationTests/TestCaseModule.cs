namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using Nancy;
    using static Softlr.Suppress;

    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class TestCaseModule : NancyModule
    {
        public const string JQUERY_LOADED = "/jQueryLoaded";
        public const string SIZZLE_LOADED = "/SizzleLoaded";
        public const string UNLOADED = "/Unloaded";

        [SuppressMessage(CODE_CRACKER, CC0067)]
        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public TestCaseModule()
        {
            Get(JQUERY_LOADED, x => View["JQueryLoaded"]);
            Get(SIZZLE_LOADED, x => View["SizzleLoaded"]);
            Get(UNLOADED, x => View["Unloaded"]);
        }
    }
}
