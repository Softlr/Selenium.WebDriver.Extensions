namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.InteropServices;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

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
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            return new QuerySelectorHelper(driver);
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
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            var runner = CreateRunner(selector.RunnerType);
            var results = runner.Find<IEnumerable<IWebElement>>(driver, selector);
            if (results == null)
            {
                throw new NoSuchElementException("No element found for selector: " + selector.Selector);
            }

            var list = results.ToList();
            if (list.Count > 0)
            {
                return new WebElement(list.First(), selector);
            }

            throw new NoSuchElementException("No element found for selector: " + selector.Selector);
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
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            var runner = CreateRunner(selector.RunnerType);
            var results = runner.Find<IEnumerable<IWebElement>>(driver, selector)
                .Select((value, index) => new WebElement(value, selector, index)).ToList();
            return new ReadOnlyCollection<WebElement>(results);
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
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            driver.ExecuteScript<object>(script, args);
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
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            if (script == null)
            {
                throw new ArgumentNullException("script");
            }

            if (script.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Script cannot be empty", "script");
            }

            return (T)((IJavaScriptExecutor)driver).ExecuteScript(script, args);
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
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            if (loader == null)
            {
                throw new ArgumentNullException("loader");
            }

            var result = driver.ExecuteScript<bool?>("return " + loader.CheckScript + ";");
            return result.HasValue && result.Value;
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
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            if (loader == null)
            {
                throw new ArgumentNullException("loader");
            }

            driver.LoadPrerequisites(
                loader,
                timeout ?? TimeSpan.FromSeconds(3),
                libraryUri == null ? loader.LibraryUri.OriginalString : libraryUri.OriginalString);
        }

        /// <summary>
        /// Loads the prerequisites for the selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="loader">The loader.</param>
        /// <param name="timeout">The timeout value for the prerequisites load.</param>
        /// <param name="loadParams">The additional parameters for load script.</param>
        private static void LoadPrerequisites(
            this IWebDriver driver,
            ILoader loader,
            TimeSpan timeout,
            params string[] loadParams)
        {
            if (driver.CheckSelectorPrerequisites(loader))
            {
                return;
            }

            driver.ExecuteScript(loader.LoadScript(loadParams));
            var wait = new WebDriverWait(driver, timeout);
            wait.Until(d => driver.CheckSelectorPrerequisites(loader));
        }

        /// <summary>
        /// Creates the runner.
        /// </summary>
        /// <param name="runnerType">The runner type.</param>
        /// <returns>The instance of the runner.</returns>
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
        private static IRunner CreateRunner(Type runnerType)
        {
            return (IRunner)Activator.CreateInstance(runnerType);
        }
    }
}
