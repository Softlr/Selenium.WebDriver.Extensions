namespace Selenium.WebDriver.Extensions.Contracts
{
    using PostSharp.Aspects;
    using PostSharp.Patterns.Contracts;
    using PostSharp.Reflection;
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The attribute to validate null or not-empty string.
    /// </summary>
    /// <inheritdoc cref="LocationContractAttribute" />
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class VersionAttribute : LocationContractAttribute, ILocationValidationAspect<string>
    {
        /// <inheritdoc/>
        public Exception ValidateValue(
            string value, string locationName, LocationKind locationKind, LocationValidationContext context) =>
            Version.TryParse(value, out var _)
                ? null
                : CreateArgumentException(value, locationName, locationKind);

        /// <inheritdoc/>
        protected override string GetErrorMessage() => "Argument is not a valid library version";
    }
}