namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Builder;
    using Nancy.Owin;
    using System.Diagnostics.CodeAnalysis;
    using static Softlr.Suppress;

    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        [SuppressMessage(SONARQUBE, S2325)]
        [SuppressMessage(CODE_CRACKER, CC0091)]
        public void Configure(IApplicationBuilder app) => app.UseOwin().UseNancy();
    }
}
