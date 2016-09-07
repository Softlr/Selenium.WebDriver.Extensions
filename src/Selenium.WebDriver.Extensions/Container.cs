namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Selenium.WebDriver.Extensions.Parsers;
    using SimpleInjector;

    /// <summary>
    /// The dependency container.
    /// </summary>
    public static class Container
    {
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static Container()
        {
            // parsers
            Instance.Register<IDirectCastParser, DirectCastParser>();
            Instance.Register<ILongParser, LongParser>();
            Instance.Register<INullValueParser, NullValueParser>();
            Instance.Register<IWebElementCollectionParser, WebElementCollectionParser>();

            // chain of responsibility
            Instance.RegisterInitializer<NullValueParser>(
                x => x.Successor = Instance.GetInstance<IWebElementCollectionParser>());
            Instance.RegisterInitializer<WebElementCollectionParser>(
                x => x.Successor = Instance.GetInstance<ILongParser>());
            Instance.RegisterInitializer<LongParser>(x => x.Successor = Instance.GetInstance<IDirectCastParser>());

            // initial parser
            Instance.Register<IParser, NullValueParser>();

            Instance.Verify();
        }

        /// <summary>
        /// Gets the dependency container.
        /// </summary>
        public static SimpleInjector.Container Instance { get; } = new SimpleInjector.Container();
    }
}
