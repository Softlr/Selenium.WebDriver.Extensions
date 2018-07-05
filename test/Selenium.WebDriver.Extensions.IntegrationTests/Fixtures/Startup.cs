namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Builder;
    using Nancy.Owin;
    using static Softlr.Suppress;

    [PublicAPI]
    public class Startup
    {
        [SuppressMessage(SONARQUBE, S2325)]
        [SuppressMessage(CODE_CRACKER, CC0091)]
        public void Configure(IApplicationBuilder app) => app.UseOwin().UseNancy();
    }
}
