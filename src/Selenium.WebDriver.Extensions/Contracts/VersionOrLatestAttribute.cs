namespace Selenium.WebDriver.Extensions.Contracts
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using PostSharp.Aspects;
    using PostSharp.Patterns.Contracts;
    using PostSharp.Reflection;

    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Parameter)]
    internal sealed class VersionOrLatestAttribute : LocationContractAttribute, ILocationValidationAspect<string>
    {
        public Exception ValidateValue(
            string value, string locationName, LocationKind locationKind, LocationValidationContext context) =>
            value == "latest" || Version.TryParse(value, out _)
                ? null
                : CreateArgumentException(value, locationName, locationKind);

        protected override string GetErrorMessage() => "Argument is not a valid library version";
    }
}