namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.InteropServices;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    using Selenium.WebDriver.Extensions.JQuery;
    using Selenium.WebDriver.Extensions.Sizzle;

    /// <summary>
    /// Web driver extensions.
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Returns the query selector helper, that can be used to access query selector specific functionalities.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <returns>The query selector helper.</returns>
        /// <exception cref="ArgumentNullException">Driver is null.</exception>
        public static QuerySelectorHelper QuerySelector(this IWebDriver driver)
        {
            return Core.WebDriverExtensions.QuerySelector(driver);
        }

        /// <summary>
        /// Searches for DOM element using given selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The Selenium selector.</param>
        /// <returns>The first DOM element matching given JavaScript query selector.</returns>
        /// <exception cref="ArgumentNullException">
        /// Driver is null.
        /// -or- Selector is null.
        /// </exception>
        /// <exception cref="NoSuchElementException">The requested element is not found.</exception>
        /// <exception cref="InvalidOperationException">The source sequence is empty.</exception>
        /// <exception cref="TargetInvocationException">The constructor being called throws an exception.</exception>
        /// <exception cref="MethodAccessException">
        /// The caller does not have permission to call this constructor.
        /// </exception>
        /// <exception cref="MemberAccessException">
        /// Cannot create an instance of an abstract class, or this member was invoked with a late-binding mechanism.
        /// </exception>
        /// <exception cref="InvalidComObjectException">
        /// The COM type was not obtained through <see cref="Type.GetTypeFromProgID(string)" /> or 
        /// <see cref="Type.GetTypeFromCLSID(System.Guid)" />.
        /// </exception>
        /// <exception cref="MissingMethodException">No matching public constructor was found.</exception>
        /// <exception cref="COMException">
        /// Type is a COM object but the class identifier used to obtain the type is invalid, or the identified class 
        /// is not registered.
        /// </exception>
        /// <exception cref="TypeLoadException">Type is not a valid type.</exception>
        /// <exception cref="ArgumentException">
        /// Type is not a RuntimeType.
        /// -or- Type is an open generic type (that is, the <see cref="P:System.Type.ContainsGenericParameters" /> 
        /// property returns true).
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// Type cannot be a <see cref="TypeBuilder" />.
        /// -or- Creation of <see cref="TypedReference" />, <see cref="ArgIterator" />, <see cref="Void" />, and 
        /// <see cref="RuntimeArgumentHandle" /> types, or arrays of those types, is not supported.
        /// -or- The assembly that contains type is a dynamic assembly that was created with 
        /// <see cref="F:System.Reflection.Emit.AssemblyBuilderAccess.Save" />.
        /// </exception>
        public static WebElement FindElement(this IWebDriver driver, ISelector selector)
        {
            return Core.WebDriverExtensions.FindElement(driver, selector);
        }

        /// <summary>
        /// Searches for DOM elements using given selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The DOM elements matching given JavaScript query selector.</returns>
        /// <exception cref="ArgumentNullException">
        /// Driver is null.
        /// -or- Selector is null.
        /// </exception>
        /// <exception cref="TargetInvocationException">The constructor being called throws an exception.</exception>
        /// <exception cref="MethodAccessException">
        /// The caller does not have permission to call this constructor.
        /// </exception>
        /// <exception cref="MemberAccessException">
        /// Cannot create an instance of an abstract class, or this member was invoked with a late-binding mechanism.
        /// </exception>
        /// <exception cref="InvalidComObjectException">
        /// The COM type was not obtained through <see cref="Type.GetTypeFromProgID(string)" /> or 
        /// <see cref="Type.GetTypeFromCLSID(System.Guid)" />.
        /// </exception>
        /// <exception cref="MissingMethodException">No matching public constructor was found.</exception>
        /// <exception cref="COMException">
        /// Type is a COM object but the class identifier used to obtain the type is invalid, or the identified class 
        /// is not registered.
        /// </exception>
        /// <exception cref="TypeLoadException">Type is not a valid type.</exception>
        /// <exception cref="ArgumentException">
        /// Type is not a RuntimeType.
        /// -or- Type is an open generic type (that is, the <see cref="P:System.Type.ContainsGenericParameters" /> 
        /// property returns true).
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// Type cannot be a <see cref="TypeBuilder" />.
        /// -or- Creation of <see cref="TypedReference" />, <see cref="ArgIterator" />, <see cref="Void" />, and 
        /// <see cref="RuntimeArgumentHandle" /> types, or arrays of those types, is not supported.
        /// -or- The assembly that contains type is a dynamic assembly that was created with 
        /// <see cref="F:System.Reflection.Emit.AssemblyBuilderAccess.Save" />.
        /// </exception>
        public static ReadOnlyCollection<WebElement> FindElements(this IWebDriver driver, ISelector selector)
        {
            return Core.WebDriverExtensions.FindElements(driver, selector);
        }

        /// <summary>
        /// Executes JavaScript in the context of the currently selected frame or window.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="script">The script to be executed.</param>
        /// <param name="args">The arguments to the script.</param>
        /// <exception cref="ArgumentNullException">Driver is null.</exception>
        /// <exception cref="ArgumentException">Script is empty.</exception>
        public static void ExecuteScript(this IWebDriver driver, string script, params object[] args)
        {
            Core.WebDriverExtensions.ExecuteScript(driver, script, args);
        }

        /// <summary>
        /// Executes JavaScript in the context of the currently selected frame or window.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="script">The script to be executed.</param>
        /// <param name="args">The arguments to the script.</param>
        /// <returns>The value returned by the script.</returns>
        /// <remarks>
        /// For an HTML element, this method returns a <see cref="IWebElement"/>.
        /// For a number, a <see cref="long"/> is returned.
        /// For a boolean, a <see cref="bool"/> is returned.
        /// For all other cases a <see cref="string"/> is returned.
        /// For an array,we check the first element, and attempt to return a <see cref="List{T}"/> of that type, 
        /// following the rules above. Nested lists are not supported.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Driver is null.
        /// -or- Script is null.
        /// </exception>
        /// <exception cref="ArgumentException">Script is empty.</exception>
        public static T ExecuteScript<T>(this IWebDriver driver, string script, params object[] args)
        {
            return Core.WebDriverExtensions.ExecuteScript<T>(driver, script, args);
        }

        /// <summary>
        /// Checks if prerequisites for the selector has been met.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="loader">The loader.</param>
        /// <returns><c>true</c> if prerequisites are met; otherwise, <c>false</c></returns>
        /// <exception cref="ArgumentNullException">
        /// Driver is null.
        /// -or- Loader is null.
        /// </exception>
        /// <exception cref="ArgumentException">Script is empty.</exception>
        public static bool CheckSelectorPrerequisites(this IWebDriver driver, ILoader loader)
        {
            return Core.WebDriverExtensions.CheckSelectorPrerequisites(driver, loader);
        }

        /// <summary>
        /// Checks if external library is loaded and loads it if needed.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="loader">The loader.</param>
        /// <param name="libraryUri">
        /// The URI of external library to load if it's not already loaded on the tested page.
        /// </param>
        /// <param name="timeout">The timeout value for the load.</param>
        /// <remarks>
        /// If external library is already loaded on a page this method will do nothing, even if the loaded version 
        /// and version requested by invoking this method have different versions.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Driver is null.
        /// -or- Loader is null.
        /// </exception>
        /// <exception cref="OverflowException">
        /// Value is less than <see cref="TimeSpan.MinValue" /> or greater than <see cref="TimeSpan.MaxValue" />.
        /// -or- Value is <see cref="double.PositiveInfinity" />.
        /// -or- Value is <see cref="double.NegativeInfinity" />.
        /// </exception>
        /// <exception cref="ArgumentException">Value is equal to <see cref="double.NaN" />.</exception>
        /// <exception cref="InvalidOperationException">
        /// This instance represents a relative URI, and this property is valid only for absolute URIs.
        /// </exception>
        public static void LoadExternalLibrary(
            this IWebDriver driver,
            ILoader loader,
            Uri libraryUri,
            TimeSpan? timeout = null)
        {
            Core.WebDriverExtensions.LoadExternalLibrary(driver, loader, libraryUri, timeout);
        }

        /// <summary>
        /// Returns the jQuery helper, that can be used to access jQuery-specific functionalities.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <returns>The jQuery helper.</returns>
        /// <exception cref="ArgumentNullException">Driver is null.</exception>
        public static JQueryHelper JQuery(this IWebDriver driver)
        {
            return Extensions.JQuery.WebDriverExtensions.JQuery(driver);
        }

        /// <summary>
        /// Returns the jQuery helper, that can be used to access jQuery-specific functionalities.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The jQuery helper.</returns>
        /// <exception cref="ArgumentNullException">Driver is null.</exception>
        public static ChainJQueryHelper JQuery(this IWebDriver driver, string selector)
        {
            return Extensions.JQuery.WebDriverExtensions.JQuery(driver, selector);
        }

        /// <summary>
        /// Returns the jQuery helper, that can be used to access jQuery-specific functionalities.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The jQuery helper.</returns>
        /// <exception cref="ArgumentNullException">Driver is null.</exception>
        public static ChainJQueryHelper JQuery(this IWebDriver driver, JQuerySelector selector)
        {
            return Extensions.JQuery.WebDriverExtensions.JQuery(driver, selector);
        }

        /// <summary>
        /// Returns the Sizzle helper, that can be used to access Sizzle-specific functionalities.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <returns>The Sizzle helper.</returns>
        /// <exception cref="ArgumentNullException">Driver is null.</exception>
        public static SizzleHelper Sizzle(this IWebDriver driver)
        {
            return Extensions.Sizzle.WebDriverExtensions.Sizzle(driver);
        }
    }
}
