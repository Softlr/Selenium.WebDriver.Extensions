namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Builder;
    using Nancy.Owin;
    using static Suppress;

    [PublicAPI]
    public class Startup
    {
        [SuppressMessage(CODE_CRACKER, CC0091)]
        public void Configure(IApplicationBuilder app) => app.UseOwin().UseNancy();
    }
}
