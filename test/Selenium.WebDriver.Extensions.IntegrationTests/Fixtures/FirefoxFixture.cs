namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Text;
    using OpenQA.Selenium.Firefox;

    [ExcludeFromCodeCoverage]
    public class FirefoxFixture : FixtureBase
    {
        public FirefoxFixture()
        {
            // .Net Core workaround #1: Slow Firefox webdriver
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string geckoDriverDirectory = projectFolder + "\\net5.0\\";
            FirefoxDriverService geckoService =
            FirefoxDriverService.CreateDefaultService(geckoDriverDirectory);
            geckoService.Host = "::1";

            var ffOptions = new FirefoxOptions();
            ffOptions.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\Firefox.exe";
            ffOptions.AcceptInsecureCertificates = true;

            // This profile will by-pass *ALL* credentials. Note that Chrome uses Internet Explorer settings, so it does not need this.
            // You must pre-setup the profile, by launching Firefox and doing phone authentication
            // The profile's location is: C:\Users\<windows logon>\AppData\Local\Mozilla\Firefox\Profiles
            // Without this, if your AUT uses SSO, you will always get prompted for the PIN or Two factor authentication
            FirefoxProfile profile = new FirefoxProfileManager().GetProfile("Selenium");
            ffOptions.Profile = profile;

            // DotNet Core workaround #2- Code page
            // https://stackoverflow.com/questions/56802715/firefoxwebdriver-no-data-is-available-for-encoding-437
            // https://stackoverflow.com/questions/50858209/system-notsupportedexception-no-data-is-available-for-encoding-1252
            CodePagesEncodingProvider.Instance.GetEncoding(437);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Browser = new FirefoxDriver(geckoService, ffOptions);
        }
    }
}
