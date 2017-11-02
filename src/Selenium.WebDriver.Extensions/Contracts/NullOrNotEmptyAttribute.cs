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
    /// <inheritdoc cref="LocationContractAttribute" />
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class NullOrNotEmptyAttribute : LocationContractAttribute, ILocationValidationAspect<string>
    {
        /// <inheritdoc/>
        public Exception ValidateValue(
            string value, string locationName, LocationKind locationKind, LocationValidationContext context) =>
            value == null || !string.IsNullOrEmpty(value.Trim())
                ? null
                : CreateArgumentException(value, locationName, locationKind);

        /// <inheritdoc/>
        protected override string GetErrorMessage() => "Argument must be null or not-empty";
    }
}
