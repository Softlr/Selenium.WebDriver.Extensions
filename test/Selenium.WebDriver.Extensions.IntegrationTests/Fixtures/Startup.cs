namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using static Softlr.Suppress;

    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        [SuppressMessage(SONARQUBE, S2325)]
        [SuppressMessage(CODE_CRACKER, CC0091)]
        public void Configure(IApplicationBuilder app) =>
            app.Run(async context =>
            {
                if (context.Request.Path == "/jQueryLoaded")
                {
                    var content = @"<!DOCTYPE html>
                    <html>
                    <head>
                        <meta charset=""utf-8"" />
                        <title>Selenium.WebDriver.Extensions Tests</title>
                    </head>
                    <body>
                        <h1 class=""main"">H1 Header</h1>
                        <div class=""main"" id=""id1"">Selector</div>
                        <div class=""main"">Selenium WebDriver Extensions</div>
                        <script src=""https://code.jquery.com/jquery-2.1.1.min.js"" type=""text/javascript""></script>
                    </body>
                    </html>";
                    await context.Response.WriteAsync(content);
                }
                else if (context.Request.Path == "/SizzleLoaded")
                {
                    var content = @"<!DOCTYPE html>
                    <html>
                    <head>
                        <meta charset=""utf-8"" />
                        <title>Selenium.WebDriver.Extensions Tests</title>
                    </head>
                    <body>
                        <h1 class=""main"">H1 Header</h1>
                        <div class=""main"" id=""id1"">Selector</div>
                        <div class=""main"">Selenium WebDriver Extensions</div>
                        <script src=""https://cdnjs.cloudflare.com/ajax/libs/sizzle/2.0.0/sizzle.min.js"" type=""text/javascript""></script>
                    </body>
                    </html>";
                    await context.Response.WriteAsync(content);
                }
                else
                {
                    var content = @"<!DOCTYPE html>
                    <html>
                    <head>
                        <meta charset=""utf-8"" />
                        <title>Selenium.WebDriver.Extensions Tests</title>
                    </head>
                    <body>
                        <h1 class=""main"">H1 Header</h1>
                        <div class=""main"" id=""id1"">Selector</div>
                        <div class=""main"">Selenium WebDriver Extensions</div>
                    </body>
                    </html>";
                    await context.Response.WriteAsync(content);
                }
            });
    }
}