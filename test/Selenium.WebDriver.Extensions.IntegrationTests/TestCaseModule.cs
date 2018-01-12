namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Nancy;

    [ExcludeFromCodeCoverage]
    public class TestCaseModule : NancyModule
    {
        public TestCaseModule()
        {
            Get["/jQueryLoaded"] = _ => GetHtml(new Uri("https://code.jquery.com/jquery-2.1.1.min.js"));
            Get["/jQueryUnloaded"] = _ => GetHtml();
            Get["/SizzleLoaded"] = _ => GetHtml(new Uri("https://cdnjs.cloudflare.com/ajax/libs/sizzle/2.0.0/sizzle.min.js"));
            Get["/SizzleUnloaded"] = _ => GetHtml();
        }

        private static string GetHtml(Uri externalLibUrl = null) =>
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
                {(externalLibUrl != null ? $@"<script src = ""{externalLibUrl.AbsoluteUri}"" type=""text/javascript""></script>" : string.Empty)}
            </body>
            </html>";
    }
}