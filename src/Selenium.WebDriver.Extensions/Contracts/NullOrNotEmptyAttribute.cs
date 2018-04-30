namespace Selenium.WebDriver.Extensions.Contracts
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using PostSharp.Aspects;
    using PostSharp.Patterns.Contracts;
    using PostSharp.Reflection;

    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Parameter)]
    internal sealed class NullOrNotEmptyAttribute : LocationContractAttribute, ILocationValidationAspect<string>
    {
        public Exception ValidateValue(
            string value, string locationName, LocationKind locationKind, LocationValidationContext context) =>
            value == null || !string.IsNullOrEmpty(value.Trim())
                ? null
                : CreateArgumentException(value, locationName, locationKind);

        protected override string GetErrorMessage() => "Argument must be null or not-empty";
    }
}