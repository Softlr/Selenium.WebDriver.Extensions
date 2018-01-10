namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using Nancy;

    [ExcludeFromCodeCoverage]
    public class TestCaseModule : NancyModule
    {
        private const string JQUERY_LOADED = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>Selenium.WebDriver.Extensions Tests</title>
</head>
<body>
    <h1 class=""main"">H1 Header</h1>
    <div class=""main"" id=""id1"">jQuery Selector</div>
    <div class=""main"">Selenium WebDriver Extensions</div>
    <script src = ""https://code.jquery.com/jquery-2.1.1.min.js"" type=""text/javascript""></script>
</body>
</html>";

        private const string JQUERY_UNLOADED = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>Selenium.WebDriver.Extensions Tests</title>
</head>
<body>
    <h1 class=""main"">H1 Header</h1>
    <div class=""main"" id=""id1"">jQuery Selector</div>
    <div class=""main"">Selenium WebDriver Extensions</div>
</body>
</html>";

        private const string SIZZLE_LOADED = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>Selenium.WebDriver.Extensions Tests</title>
</head>
<body>
    <h1 class=""main"">H1 Header</h1>
    <div class=""main"" id=""id1"">Sizzle Selector</div>
    <div class=""main"">Selenium WebDriver Extensions</div>
    <script src = ""https://cdnjs.cloudflare.com/ajax/libs/sizzle/2.0.0/sizzle.min.js"" type=""text/javascript""></script>
</body>
</html>";

        private const string SIZZLE_UNLOADED = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>Selenium.WebDriver.Extensions Tests</title>
</head>
<body>
    <h1 class=""main"">H1 Header</h1>
    <div class=""main"" id=""id1"">Sizzle Selector</div>
    <div class=""main"">Selenium WebDriver Extensions</div>
</body>
</html>";

        public TestCaseModule()
        {
            Get["/jQueryLoaded"] = _ => JQUERY_LOADED;
            Get["/jQueryUnloaded"] = _ => JQUERY_UNLOADED;
            Get["/SizzleLoaded"] = _ => SIZZLE_LOADED;
            Get["/SizzleUnloaded"] = _ => SIZZLE_UNLOADED;
        }
    }
}