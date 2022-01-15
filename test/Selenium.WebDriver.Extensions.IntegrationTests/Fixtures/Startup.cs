namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        [SuppressMessage(FXCOP, CA1822)]
        [SuppressMessage(SONARQUBE, S1075)]
        [SuppressMessage(SONARQUBE, S2325)]
        public void Configure(IApplicationBuilder app) =>
            app.Run(async context =>
            {
                var uri = context.Request.Path.Value switch
                {
                    JQueryTestPath => new Uri("https://code.jquery.com/jquery-3.5.1.min.js"),
                    SizzleTestPath => new Uri("https://cdnjs.cloudflare.com/ajax/libs/sizzle/2.0.0/sizzle.min.js"),
                    _ => null
                };
                await context.Response.WriteAsync(GetHtml(uri));
            });

        private static string GetHtml(Uri uri = null) =>
            $@"<!DOCTYPE html>
            <html>
            <head>
                <meta charset=""utf-8"" />
                <title>Selenium.WebDriver.Extensions Tests</title>
            </head>
            <body>
                <h1 class=""main"">H1 Header</h1>
                <div class=""main"" id=""id1"">Selector</div>
                <div class=""main"">Selenium WebDriver Extensions</div>
                {(uri == null ? string.Empty : $"<script src=\"{uri.AbsoluteUri}\" type=\"text/javascript\"></script>")}
            </body>
            </html>";
    }
}
