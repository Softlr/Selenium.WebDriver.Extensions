namespace Selenium.WebDriver.Extensions.Contracts
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using PostSharp.Aspects;
    using PostSharp.Patterns.Contracts;
    using PostSharp.Reflection;

    /// <summary>
    /// The attribute to validate null or not-empty string.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class VersionOrLatestAttribute : LocationContractAttribute, ILocationValidationAspect<string>
    {
        /// <inheritdoc/>
        public Exception ValidateValue(string value, string locationName, LocationKind locationKind)
        {
            return value == "latest" || Version.TryParse(value, out var version)
                ? null
                : CreateArgumentException(value, locationName, locationKind);
        }

        /// <inheritdoc/>
        protected override string GetErrorMessage() => "Argument is not a valid library version";
    }
}