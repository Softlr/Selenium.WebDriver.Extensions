namespace Selenium.WebDriver.Extensions
{
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.Parsers;

    /// <summary>
    /// The dependency container.
    /// </summary>
    public static class Container
    {
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
        [SuppressMessage(Suppress.Category.CODE_CRACKER, Suppress.CodeCracker.CC0022)]
        public static SimpleInjector.Container Instance { get; } = new SimpleInjector.Container();
    }
}