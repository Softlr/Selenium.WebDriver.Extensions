namespace OpenQA.Selenium.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Seterlund.CodeGuard;

    /// <summary>
    /// The guard extensions.
    /// </summary>
    internal static class GuardExtensions
    {
        /// <summary>
        /// Checks if the argument is either <see langword="null"/> or not-empty string.
        /// </summary>
        /// <param name="arg">The argument to check.</param>
        /// <returns>The guard object.</returns>
        [SuppressMessage(
            "Microsoft.Globalization",
            "CA1303:Do not pass literals as localized parameters",
            MessageId = "Seterlund.CodeGuard.Internals.IMessageHandler<System.String>.Set(System.String)")]
        [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
        public static IArg<string> IsNullOrIsNotWhitespace(this IArg<string> arg)
        {
            if (arg.Value != null && arg.Value.IsNullOrWhiteSpace())
            {
                arg.Message.Set("Argument must be null or not-empty");
            }

            return arg;
        }
    }
}
