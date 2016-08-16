namespace OpenQA.Selenium.Contracts
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Extensions;
    using PostSharp.Aspects;
    using PostSharp.Patterns.Contracts;
    using PostSharp.Reflection;

    /// <summary>
    /// The attribute to validate null or not-empty string.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class NullOrNotEmptyAttribute : LocationContractAttribute, ILocationValidationAspect<string>
    {
        /// <inheritdoc/>
        public Exception ValidateValue(string value, string locationName, LocationKind locationKind) =>
            value != null && string.IsNullOrEmpty(value.Trim())
                ? this.CreateArgumentException(value, locationName, locationKind)
                : null;

        /// <inheritdoc/>
        protected override string GetErrorMessage() => "Argument must be null or not-empty";
    }
}
