namespace Selenium.WebDriver.Extensions
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using static Selenium.WebDriver.Extensions.Suppress.Category;
    using static Selenium.WebDriver.Extensions.Suppress.CodeCracker;
    using static Selenium.WebDriver.Extensions.Suppress.FxCop;

    internal static class Suppress
    {
        [PublicAPI]
        [SuppressMessage(FXCOP, CA1034)]
        [SuppressMessage(CODE_CRACKER, CC0021)]
        public static class Category
        {
            public const string CODE_CRACKER = "CodeCracker.CSharp";
            public const string FXCOP = "FxCop";
            public const string SONARQUBE = "SonarQube";
            public const string STYLECOP = "StyleCop.CSharp";
        }

        [PublicAPI]
        [SuppressMessage(FXCOP, CA1034)]
        public static class CodeCracker
        {
            public const string CC0001 = "CC0001:AlwaysUseVarAnalyzer_NonPrimitives";
            public const string CC0002 = "CC0002:ArgumentExceptionAnalyzer";
            public const string CC0003 = "CC0003:CatchEmptyAnalyzer";
            public const string CC0004 = "CC0004:EmptyCatchBlockAnalyzer";
            public const string CC0005 = "CC0005:EmptyObjectInitializerAnalyzer";
            public const string CC0006 = "CC0006:ForInArrayAnalyzer";
            public const string CC0007 = "CC0007:IfReturnTrueAnalyzer";
            public const string CC0008 = "CC0008:ObjectInitializerAnalyzer (local declaration)";
            public const string CC0009 = "CC0009:ObjectInitializerAnalyzer (assignment)";
            public const string CC0010 = "CC0010:RegexAnalyzer";
            public const string CC0011 = "CC0011:RemoveWhereWhenItIsPossibleAnalyzer";
            public const string CC0012 = "CC0012:RethrowExceptionAnalyzer";
            public const string CC0013 = "CC0013:TernaryOperatorAnalyzer (return)";
            public const string CC0014 = "CC0014:TernaryOperatorAnalyzer (assignment)";
            public const string CC0015 = "CC0015:UnnecessaryParenthesisAnalyzer";
            public const string CC0017 = "CC0017:AutoPropertyAnalyzer";
            public const string CC0018 = "CC0018:ExistenceOperatorAnalyzer";
            public const string CC0019 = "CC0019:ConvertToSwitchAnalyzer";
            public const string CC0020 = "CC0020:Convert Lambda to Method Group";
            public const string CC0021 = "CC0021:NameOfAnalyzer";
            public const string CC0022 = "CC0022:IDisposable not assigned to a field is not being disposed";
            public const string CC0023 = "CC0023:SealedAttributeAnalyzer";
            public const string CC0024 = "CC0024:StaticConstructorExceptionAnalyzer";
            public const string CC0025 = "CC0025:EmptyFinalizerAnalyzer";
            public const string CC0026 = "CC0026:CallExtensionMethodAsExtensionAnalyzer";
            public const string CC0027 = "CC0027:Implement IEquatable<T> on Value Types";
            public const string CC0028 = "CC0028:Change from as operator to direct cast";
            public const string CC0029 = "CC0029:DisposablesShouldCallSuppressFinalizeAnalyzer";
            public const string CC0030 = "CC0030:MakeLocalVariableConstWhenItIsPossibleAnalyzer";
            public const string CC0031 = "CC0031:UseInvokeMethodToFireEventAnalyzer";
            public const string CC0032 = "CC0032:DisposableFieldNotDisposedAnalyzer.Info";
            public const string CC0033 = "CC0033:DisposableFieldNotDisposedAnalyzer.Warning";
            public const string CC0034 = "CC0034:Supress assignment of default value";
            public const string CC0035 = "CC0035:Reorder class";
            public const string CC0036 = "CC0036:Improve double/float comparisons";
            public const string CC0037 = "CC0037:RemoveCommentedCodeAnalyzer";
            public const string CC0038 = "CC0038:ConvertToExpressionBodiedMemberAnalyzer";
            public const string CC0039 = "CC0039:StringBuilderInLoopAnalyzer";
            public const string CC0040 = "CC0040:Warning potential null in fields, variables and arguments";
            public const string CC0041 = "CC0041:Align Equals on Variable Assignment statements";
            public const string CC0042 = "CC0042:InvertForAnalyzer";
            public const string CC0043 = "CC0043:Not Any to All";
            public const string CC0044 = "CC0044:Excess parameters in methods";
            public const string CC0045 = "CC0045:StringRepresentationAnalyzer.RegularString";
            public const string CC0046 = "CC0046:StringRepresentationAnalyzer.VerbatimString";
            public const string CC0047 = "CC0047:PropertyPrivateSetAnalyzer";
            public const string CC0048 = "CC0048:StringFormatAnalyzer";
            public const string CC0049 = "CC0049:SimplifyRedundantBooleanComparisonsAnalyzer";
            public const string CC0050 = "CC0050:Convert loop to linq expression";
            public const string CC0051 = "CC0051:Remove async and return task directly";
            public const string CC0052 = "CC0052:ReadOnlyField";
            public const string CC0053 = "CC0053:ColorTranslator.FromHtml";
            public const string CC0054 = "CC0054:JsonConvert.DeserializeObject";
            public const string CC0055 = "CC0055:Unreachable code";
            public const string CC0056 = "CC0056:Check arguments in String.Format";
            public const string CC0057 = "CC0057:Remove unused parameters";
            public const string CC0058 = "CC0058:Encapsulate field as read-only or write-only";
            public const string CC0059 = "CC0059:Generate Equals() and GetHashCode() for reference types";
            public const string CC0060 = "CC0060:Abstract class ctors should not have public constructors";
            public const string CC0061 = "CC0061:If method returns a Task it should have the postfix Async";
            public const string CC0062 = "CC0062:Interfaces should start with an I";
            public const string CC0063 = "CC0063:Validate Uri from System.Uri";
            public const string CC0064 = "CC0064:Validate IPAddress.Parse from System.Net";
            public const string CC0065 = "CC0065:Remove trailling whitespace";
            public const string CC0066 = "CC0066:Remove trailling end of line";
            public const string CC0067 = "CC0067:Virtual method call in constructor";
            public const string CC0068 = "CC0068:Remove private method is never used in a class";
            public const string CC0069 = "CC0069:Forward cancellation token to awaited methods";
            public const string CC0070 = "CC0070:Use ConfigureAwait(false) on awaited task";
            public const string CC0071 = "CC0071:Introduce field from constructor";
            public const string CC0072 = "CC0072:If method does not return a Task it shouldn't end with Async";
            public const string CC0073 = "CC0073:Add braces to switch case";
            public const string CC0074 = "CC0074:ReadonlyFieldAnalyzer";
            public const string CC0075 = "CC0075:Merge nested if statements";
            public const string CC0076 = "CC0076:Split 'if' with '&&' condition into nested 'if'-statements";
            public const string CC0077 = "CC0077:async void should not be used";
            public const string CC0078 = "CC0078:Verifies if reference type parameters are null";
            public const string CC0079 = "CC0079:Convert numerical literal from decimal to hex and hex to decimal";
            public const string CC0080 = "CC0080:Change IIF to If to short circuit evaulations";
            public const string CC0081 = "CC0081:Use static Regex.IsMatch";
            public const string CC0082 = "CC0082:Compute Constant Value of an expression";
            public const string CC0083 = "CC0083:Add property to constructor";
            public const string CC0084 = "CC0084:Use String.Empty";
            public const string CC0085 = "CC0085:Convert '==' to 'Equals'";
            public const string CC0086 = "CC0086:Convert 'Equals' to '=='";
            public const string CC0087 = "CC0087:Invert if";
            public const string CC0088 = "CC0088:Use \"\" instead of String.Empty";
            public const string CC0089 = "CC0089:Remove Redundant Else Clause";
            public const string CC0090 = "CC0090:XmlDocumentationAnalyzer - Incorrect params";
            public const string CC0091 = "CC0091:Make method static if possible";
            public const string CC0092 = "CC0092:All to Not Any";
            public const string CC0093 = "CC0093:Remove virtual modifier if possible";
            public const string CC0094 = "CC0094:Seal member if possible";
            public const string CC0095 = "CC0095:ChangeConsoleWriteLineToStringInterpolation";
            public const string CC0096 = "CC0096:Extract class to a new file";
            public const string CC0097 = "CC0097:XmlDocumentationAnalyzer - Missing params";
            public const string CC0098 = "CC0098:Prefer Count to Count()";
            public const string CC0099 = "CC0099:Prefer Any to Count() > 0";
            public const string CC0100 = "CC0100:IEnumerable possibly being enumerated more than once";
            public const string CC0101 = "CC0101:Convert abstract class to interface";
            public const string CC0102 = "CC0102:Convert Interface to abstract class";
            public const string CC0104 = "CC0104:Convert to block bodied method from expression bodied method";
            public const string CC0105 = "CC0105:AlwaysUseVarAnalyzer_Primitives";
            public const string CC0106 = "CC0106:Create PropertyChangedEventArgs statically";
            public const string CC0107 = "CC0107:Convert anonymous delegate to lambda expression";
            public const string CC0108 = "CC0108:NameOfAnalyzer_External";
            public const string CC0109 = "CC0109:Implement interface and delegate calls to decorate";
            public const string CC0110 = "CC0110:Check consistency of optional parameter default value";
            public const string CC0111 = "CC0111:Check arguments in String.Format (Warning)";
            public const string CC0112 = "CC0112:Readonly reference field is never assigned and is used";
            public const string CC0113 = "CC0113:IsNullOrWhiteSpace or IsNullOrEmpty";
            public const string CC0114 = "CC0114:Convert assignment to function name to return statement";
            public const string CC0115 = "CC0115:Hoist common sub-expression";
            public const string CC0116 = "CC0116:Replace assignment to variable with increment of variable";
            public const string CC0117 = "CC0117:Remove @ from variables that are not keywords";
            public const string CC0118 = "CC0118:Remove Unnecessary ToString in String Concatenation";
            public const string CC0119 = "CC0119:If statement can be replaced by null coalescing operator";
            public const string CC0120 = "CC0120:Suggest Case Else for Select Case statements";
            public const string CC0121 = "CC0121:ReadOnlyField_ComplexValueTypes";
            public const string CC0122 = "CC0122:Replace Task.Result with await Task";
            public const string CC0123 = "CC0123:Rewrite a call using named arguments";
            public const string CC0124 = "CC0124:Replace if statement or operator with call to Math.Max";

            public const string CC0125 =
                "CC0125:Replace getter only properties with backing readonly field with getter-only auto-property";

            public const string CC0126 = "CC0126:Left and right side of assignment must not be the same entity";
        }

        [PublicAPI]
        [SuppressMessage(FXCOP, CA1034)]
        public static class FxCop
        {
            public const string CA1000 = "CA1000:Do not declare static members on generic types";
            public const string CA1001 = "CA1001:Types that own disposable fields should be disposable";
            public const string CA1002 = "CA1002:Do not expose generic lists";
            public const string CA1003 = "CA1003:Use generic event handler instances";
            public const string CA1004 = "CA1004:Generic methods should provide type parameter";
            public const string CA1005 = "CA1005:Avoid excessive parameters on generic types";
            public const string CA1006 = "CA1006:Do not nest generic types in member signatures";
            public const string CA1007 = "CA1007:Use generics where appropriate";
            public const string CA1008 = "CA1008:Enums should have zero value";
            public const string CA1009 = "CA1009:Declare event handlers correctly";
            public const string CA1010 = "CA1010:Collections should implement generic interface";
            public const string CA1011 = "CA1011:Consider passing base types as parameters";
            public const string CA1012 = "CA1012:Abstract types should not have constructors";
            public const string CA1013 = "CA1013:Overload operator equals on overloading add and subtract";
            public const string CA1014 = "CA1014:Mark assemblies with CLSCompliantAttribute";
            public const string CA1016 = "CA1016:Mark assemblies with AssemblyVersionAttribute";
            public const string CA1017 = "CA1017:Mark assemblies with ComVisibleAttribute";
            public const string CA1018 = "CA1018:Mark attributes with AttributeUsageAttribute";
            public const string CA1019 = "CA1019:Define accessors for attribute arguments";
            public const string CA1020 = "CA1020:Avoid namespaces with few types";
            public const string CA1021 = "CA1021:Avoid out parameters";
            public const string CA1023 = "CA1023:Indexers should not be multidimensional";
            public const string CA1024 = "CA1024:Use properties where appropriate";
            public const string CA1025 = "CA1025:Replace repetitive arguments with params array";
            public const string CA1026 = "CA1026:Default parameters should not be used";
            public const string CA1027 = "CA1027:Mark enums with FlagsAttribute";
            public const string CA1028 = "CA1028:Enum storage should be Int32";
            public const string CA1030 = "CA1030:Use events where appropriate";
            public const string CA1031 = "CA1031:Do not catch general exception types";
            public const string CA1032 = "CA1032:Implement standard exception constructors";
            public const string CA1033 = "CA1033:Interface methods should be callable by child types";
            public const string CA1034 = "CA1034:Nested types should not be visible";
            public const string CA1035 = "CA1035:ICollection implementations have strongly typed members";
            public const string CA1036 = "CA1036:Override methods on comparable types";
            public const string CA1038 = "CA1038:Enumerators should be strongly typed";
            public const string CA1039 = "CA1039:Lists are strongly typed";
            public const string CA1040 = "CA1040:Avoid empty interfaces";
            public const string CA1041 = "CA1041:Provide ObsoleteAttribute message";
            public const string CA1043 = "CA1043:Use integral or string argument for indexers";
            public const string CA1044 = "CA1044:Properties should not be write only";
            public const string CA1045 = "CA1045:Do not pass types by reference";
            public const string CA1046 = "CA1046:Do not overload operator equals on reference types";
            public const string CA1047 = "CA1047:Do not declare protected members in sealed types";
            public const string CA1048 = "CA1048:Do not declare virtual members in sealed types";
            public const string CA1049 = "CA1049:Types that own native resources should be disposable";
            public const string CA1050 = "CA1050:Declare types in namespaces";
            public const string CA1051 = "CA1051:Do not declare visible instance fields";
            public const string CA1052 = "CA1052:Static holder types should be sealed";
            public const string CA1053 = "CA1053:Static holder types should not have constructors";
            public const string CA1054 = "CA1054:URI parameters should not be strings";
            public const string CA1055 = "CA1055:URI return values should not be strings";
            public const string CA1056 = "CA1056:URI properties should not be strings";
            public const string CA1057 = "CA1057:String URI overloads call System.Uri overloads";
            public const string CA1058 = "CA1058:Types should not extend certain base types";
            public const string CA1059 = "CA1059:Members should not expose certain concrete types";
            public const string CA1060 = "CA1060:Move P/Invokes to NativeMethods class";
            public const string CA1061 = "CA1061:Do not hide base class methods";
            public const string CA1062 = "CA1062:Validate arguments of public methods";
            public const string CA1063 = "CA1063:Implement IDisposable correctly";
            public const string CA1064 = "CA1064:Exceptions should be public";
            public const string CA1065 = "CA1065:Do not raise exceptions in unexpected locations";
            public const string CA1300 = "CA1300:Specify MessageBoxOptions";
            public const string CA1301 = "CA1301:Avoid duplicate accelerators";
            public const string CA1302 = "CA1302:Do not hardcode locale specific strings";
            public const string CA1303 = "CA1303:Do not pass literals as localized parameters";
            public const string CA1304 = "CA1304:Specify CultureInfo";
            public const string CA1305 = "CA1305:Specify IFormatProvider";
            public const string CA1306 = "CA1306:Set locale for data types";
            public const string CA1307 = "CA1307:Specify StringComparison";
            public const string CA1308 = "CA1308:Normalize strings to uppercase";
            public const string CA1309 = "CA1309:Use ordinal StringComparison";
            public const string CA1400 = "CA1400:P/Invoke entry points should exist";
            public const string CA1401 = "CA1401:P/Invokes should not be visible";
            public const string CA1402 = "CA1402:Avoid overloads in COM visible interfaces";
            public const string CA1403 = "CA1403:Auto layout types should not be COM visible";
            public const string CA1404 = "CA1404:Call GetLastError immediately after P/Invoke";
            public const string CA1405 = "CA1405:COM visible type base types should be COM visible";
            public const string CA1406 = "CA1406:Avoid Int64 arguments for Visual Basic 6 clients";
            public const string CA1407 = "CA1407:Avoid static members in COM visible types";
            public const string CA1408 = "CA1408:Do not use AutoDual ClassInterfaceType";
            public const string CA1409 = "CA1409:Com visible types should be creatable";
            public const string CA1410 = "CA1410:COM registration methods should be matched";
            public const string CA1411 = "CA1411:COM registration methods should not be visible";
            public const string CA1412 = "CA1412:Mark ComSource Interfaces as IDispatch";
            public const string CA1413 = "CA1413:Avoid non-public fields in COM visible value types";
            public const string CA1414 = "CA1414:Mark boolean P/Invoke arguments with MarshalAs";
            public const string CA1415 = "CA1415:Declare P/Invokes correctly";
            public const string CA1500 = "CA1500:Variable names should not match field names";
            public const string CA1501 = "CA1501:Avoid excessive inheritance";
            public const string CA1502 = "CA1502:Avoid excessive complexity";
            public const string CA1504 = "CA1504:Review misleading field names";
            public const string CA1505 = "CA1505:Avoid unmaintainable code";
            public const string CA1506 = "CA1506:Avoid excessive class coupling";
            public const string CA1600 = "CA1600:Do not use idle process priority";
            public const string CA1601 = "CA1601:Do not use timers that prevent power state changes";
            public const string CA1700 = "CA1700:Do not name enum values 'Reserved'";
            public const string CA1701 = "CA1701:Resource string compound words should be cased correctly";
            public const string CA1702 = "CA1702:Compound words should be cased correctly";
            public const string CA1703 = "CA1703:Resource strings should be spelled correctly";
            public const string CA1704 = "CA1704:Identifiers should be spelled correctly";
            public const string CA1707 = "CA1707:Identifiers should not contain underscores";
            public const string CA1708 = "CA1708:Identifiers should differ by more than case";
            public const string CA1709 = "CA1709:Identifiers should be cased correctly";
            public const string CA1710 = "CA1710:Identifiers should have correct suffix";
            public const string CA1711 = "CA1711:Identifiers should not have incorrect suffix";
            public const string CA1712 = "CA1712:Do not prefix enum values with type name";
            public const string CA1713 = "CA1713:Events should not have before or after prefix";
            public const string CA1714 = "CA1714:Flags enums should have plural names";
            public const string CA1715 = "CA1715:Identifiers should have correct prefix";
            public const string CA1716 = "CA1716:Identifiers should not match keywords";
            public const string CA1717 = "CA1717:Only FlagsAttribute enums should have plural names";
            public const string CA1719 = "CA1719:Parameter names should not match member names";
            public const string CA1720 = "CA1720:Identifiers should not contain type names";
            public const string CA1721 = "CA1721:Property names should not match get methods";
            public const string CA1722 = "CA1722:Identifiers should not have incorrect prefix";
            public const string CA1724 = "CA1724:Type Names Should Not Match Namespaces";
            public const string CA1725 = "CA1725:Parameter names should match base declaration";
            public const string CA1726 = "CA1726:Use preferred terms";
            public const string CA1800 = "CA1800:Do not cast unnecessarily";
            public const string CA1801 = "CA1801:Review unused parameters";
            public const string CA1802 = "CA1802:Use Literals Where Appropriate";
            public const string CA1804 = "CA1804:Remove unused locals";
            public const string CA1806 = "CA1806:Do not ignore method results";
            public const string CA1809 = "CA1809:Avoid excessive locals";
            public const string CA1810 = "CA1810:Initialize reference type static fields inline";
            public const string CA1811 = "CA1811:Avoid uncalled private code";
            public const string CA1812 = "CA1812:Avoid uninstantiated internal classes";
            public const string CA1813 = "CA1813:Avoid unsealed attributes";
            public const string CA1814 = "CA1814:Prefer jagged arrays over multidimensional";
            public const string CA1815 = "CA1815:Override equals and operator equals on value types";
            public const string CA1816 = "CA1816:Call GC.SuppressFinalize correctly";
            public const string CA1819 = "CA1819:Properties should not return arrays";
            public const string CA1820 = "CA1820:Test for empty strings using string length";
            public const string CA1821 = "CA1821:Remove empty finalizers";
            public const string CA1822 = "CA1822:Mark members as static";
            public const string CA1823 = "CA1823:Avoid unused private fields";
            public const string CA1824 = "CA1824:Mark assemblies with NeutralResourcesLanguageAttribute";
            public const string CA1900 = "CA1900:Value type fields should be portable";
            public const string CA1901 = "CA1901:P/Invoke declarations should be portable";
            public const string CA1903 = "CA1903:Use only API from targeted framework";
            public const string CA2000 = "CA2000:Dispose objects before losing scope";
            public const string CA2001 = "CA2001:Avoid calling problematic methods";
            public const string CA2002 = "CA2002:Do not lock on objects with weak identity";
            public const string CA2003 = "CA2003:Do not treat fibers as threads";
            public const string CA2004 = "CA2004:Remove calls to GC.KeepAlive";
            public const string CA2006 = "CA2006:Use SafeHandle to encapsulate native resources";
            public const string CA2100 = "CA2100:Review SQL queries for security vulnerabilities";
            public const string CA2101 = "CA2101:Specify marshaling for P/Invoke string arguments";
            public const string CA2102 = "CA2102:Catch non-CLSCompliant exceptions in general handlers";
            public const string CA2103 = "CA2103:Review imperative security";
            public const string CA2104 = "CA2104:Do not declare read only mutable reference types";
            public const string CA2105 = "CA2105:Array fields should not be read only";
            public const string CA2106 = "CA2106:Secure asserts";
            public const string CA2107 = "CA2107:Review deny and permit only usage";
            public const string CA2108 = "CA2108:Review declarative security on value types";
            public const string CA2109 = "CA2109:Review visible event handlers";
            public const string CA2111 = "CA2111:Pointers should not be visible";
            public const string CA2112 = "CA2112:Secured types should not expose fields";
            public const string CA2114 = "CA2114:Method security should be a superset of type";
            public const string CA2115 = "CA2115:Call GC.KeepAlive when using native resources";
            public const string CA2116 = "CA2116:APTCA methods should only call APTCA methods";
            public const string CA2117 = "CA2117:APTCA types should only extend APTCA base types";
            public const string CA2118 = "CA2118:Review SuppressUnmanagedCodeSecurityAttribute usage";
            public const string CA2119 = "CA2119:Seal methods that satisfy private interfaces";
            public const string CA2120 = "CA2120:Secure serialization constructors";
            public const string CA2121 = "CA2121:Static constructors should be private";
            public const string CA2122 = "CA2122:Do not indirectly expose methods with link demands";
            public const string CA2123 = "CA2123:Override link demands should be identical to base";
            public const string CA2124 = "CA2124:Wrap vulnerable finally clauses in outer try";
            public const string CA2126 = "CA2126:Type link demands require inheritance demands";
            public const string CA2130 = "CA2130:Security critical constants should be transparent";
            public const string CA2131 = "CA2131:Security critical types may not participate in type equivalence";

            public const string CA2132 =
                "CA2132:Default constructors must be at least as critical as base type default constructors";

            public const string CA2133 = "CA2133:Delegates must bind to methods with consistent transparency";

            public const string CA2134 =
                "CA2134:Methods must keep consistent transparency when overriding base methods";

            public const string CA2135 = "CA2135:Level 2 assemblies should not contain LinkDemands";
            public const string CA2136 = "CA2136:Members should not have conflicting transparency annotations";
            public const string CA2137 = "CA2137:Transparent methods must contain only verifiable IL";

            public const string CA2138 =
                "CA2138:Transparent methods must not call methods with the SuppressUnmanagedCodeSecurity attribute";

            public const string CA2139 =
                "CA2139:Transparent methods may not use the HandleProcessCorruptingExceptions attribute";

            public const string CA2140 = "CA2140:Transparent code must not reference security critical items";
            public const string CA2141 = "CA2141:Transparent methods must not satisfy LinkDemands";
            public const string CA2142 = "CA2142:Transparent code should not be protected with LinkDemands";
            public const string CA2143 = "CA2143:Transparent methods should not use security demands";
            public const string CA2144 = "CA2144:Transparent code should not load assemblies from byte arrays";

            public const string CA2145 =
                "CA2145:Transparent methods should not be decorated with the SuppressUnmanagedCodeSecurityAttribute";

            public const string CA2146 = "CA2146:Types must be at least as critical as their base types and interfaces";
            public const string CA2147 = "CA2147:Transparent methods may not use security asserts";
            public const string CA2149 = "CA2149:Transparent methods must not call into native code";
            public const string CA2151 = "CA2151:Fields with critical types should be security critical";
            public const string CA2200 = "CA2200:Rethrow to preserve stack details";
            public const string CA2201 = "CA2201:Do not raise reserved exception types";
            public const string CA2202 = "CA2202:Do not dispose objects multiple times";
            public const string CA2204 = "CA2204:Literals should be spelled correctly";
            public const string CA2205 = "CA2205:Use managed equivalents of Win32 API";
            public const string CA2207 = "CA2207:Initialize value type static fields inline";
            public const string CA2208 = "CA2208:Instantiate argument exceptions correctly";
            public const string CA2210 = "CA2210:Assemblies should have valid strong names";
            public const string CA2211 = "CA2211:Non-constant fields should not be visible";
            public const string CA2212 = "CA2212:Do not mark serviced components with WebMethod";
            public const string CA2213 = "CA2213:Disposable fields should be disposed";
            public const string CA2214 = "CA2214:Do not call overridable methods in constructors";
            public const string CA2215 = "CA2215:Dispose methods should call base class dispose";
            public const string CA2216 = "CA2216:Disposable types should declare finalizer";
            public const string CA2217 = "CA2217:Do not mark enums with FlagsAttribute";
            public const string CA2218 = "CA2218:Override GetHashCode on overriding Equals";
            public const string CA2219 = "CA2219:Do not raise exceptions in exception clauses";
            public const string CA2220 = "CA2220:Finalizers should call base class finalizer";
            public const string CA2221 = "CA2221:Finalizers should be protected";
            public const string CA2222 = "CA2222:Do not decrease inherited member visibility";
            public const string CA2223 = "CA2223:Members should differ by more than return type";
            public const string CA2224 = "CA2224:Override equals on overloading operator equals";
            public const string CA2225 = "CA2225:Operator overloads have named alternates";
            public const string CA2226 = "CA2226:Operators should have symmetrical overloads";
            public const string CA2227 = "CA2227:Collection properties should be read only";
            public const string CA2228 = "CA2228:Do not ship unreleased resource formats";
            public const string CA2229 = "CA2229:Implement serialization constructors";
            public const string CA2230 = "CA2230:Use params for variable arguments";
            public const string CA2231 = "CA2231:Overload operator equals on overriding ValueType.Equals";
            public const string CA2232 = "CA2232:Mark Windows Forms entry points with STAThread";
            public const string CA2233 = "CA2233:Operations should not overflow";
            public const string CA2234 = "CA2234:Pass System.Uri objects instead of strings";
            public const string CA2235 = "CA2235:Mark all non-serializable fields";
            public const string CA2236 = "CA2236:Call base class methods on ISerializable types";
            public const string CA2237 = "CA2237:Mark ISerializable types with SerializableAttribute";
            public const string CA2238 = "CA2238:Implement serialization methods correctly";
            public const string CA2239 = "CA2239:Provide deserialization methods for optional fields";
            public const string CA2240 = "CA2240:Implement ISerializable correctly";
            public const string CA2241 = "CA2241:Provide correct arguments to formatting methods";
            public const string CA2242 = "CA2242:Test for NaN correctly";
            public const string CA2243 = "CA2243:Attribute string literals should parse correctly";
            public const string CA5122 = "CA5122 P/Invoke declarations should not be safe critical";
        }

        [PublicAPI]
        [SuppressMessage(FXCOP, CA1034)]
        public static class SonarQube
        {
            public const string S3884 = "S3884:CoSetProxyBlanket and CoInitializeSecurity should not be used";
            public const string S3649 = "S3649:User-provided values should be sanitized before use in SQL statements";
            public const string S2278 = "S2278:Neither DES (Data Encryption Standard) nor DESede (3DES) should be used";
            public const string S2068 = "S2068:Credentials should not be hard-coded";
            public const string S4159 = "S4159:Classes should implement their ExportAttribute interfaces";
            public const string S3889 = "S3889:Neither Thread.Resume nor Thread.Suspend should be used";
            public const string S3869 = "S3869:SafeHandle.DangerousGetHandle should not be called";
            public const string S3693 = "S3693:Exception constructors should not throw exceptions";
            public const string S3464 = "S3464:Type inheritance should not be recursive";
            public const string S2930 = "S2930:IDisposables should be disposed";
            public const string S2275 = "S2275:Composite format strings should not lead to unexpected behavior at runtime";
            public const string S2190 = "S2190:Recursion should not be infinite";
            public const string S3877 = "S3877:Exceptions should not be thrown from unexpected methods";
            public const string S3875 = "S3875:operator== should not be overloaded on reference types";
            public const string S3443 = "S3443:Type should not be examined on System.Type instances";
            public const string S3433 = "S3433:Test method signatures should be correct";
            public const string S3427 = "S3427:Method overloads with default parameter values should not overlap ";
            public const string S3237 = "S3237:value parameters should be used";
            public const string S3060 = "S3060:is should not be used with this";
            public const string S2953 = "S2953:Methods named Dispose should implement IDisposable.Dispose";
            public const string S2437 = "S2437:Silly bit operations should not be performed";
            public const string S2368 = "S2368:Public methods should not have multidimensional array parameters";
            public const string S2306 = "S2306:async and await should not be used as identifiers";
            public const string S2187 = "S2187:TestCases should contain tests";
            public const string S2178 = "S2178:Short-circuit logic should be used in boolean contexts";
            public const string S3449 = "S3449:Right operands of shift operators should be integers";
            public const string S927 = "S927:parameter names should match base declaration and other partial definitions";
            public const string S4019 = "S4019:Base class methods should not be hidden";
            public const string S4015 = "S4015:Inherited member visibility should not be decreased";
            public const string S3998 = "S3998:Threads should not lock on objects with weak identity";
            public const string S3972 = "S3972:Conditionals should start on new lines";
            public const string S3966 = "S3966:Objects should not be disposed more than once";
            public const string S3904 = "S3904:Assemblies should have version information";
            public const string S3871 = "S3871:Exception types should be public";
            public const string S3776 = "S3776:Cognitive Complexity of methods should not be too high";
            public const string S3600 = "S3600:params should not be introduced on overrides";
            public const string S3451 = "S3451:[DefaultValue] should not be used when [DefaultParameterValue] is meant";
            public const string S3447 = "S3447:[Optional] should not be used on ref or out parameters";
            public const string S3265 = "S3265:Non-flags enums should not be used in bitwise operations";
            public const string S3218 = "S3218:Inner class members should not shadow outer class static or type members";
            public const string S3217 = "S3217:Explicit conversions of foreach loops should not be used";
            public const string S2696 = "S2696:Instance members should not write to static fields";
            public const string S2692 = "S2692:IndexOf checks should not be for positive numbers";
            public const string S2365 = "S2365:Properties should not make collection or array copies";
            public const string S2346 = "S2346:Flags enumerations zero-value members should be named None";
            public const string S2291 = "S2291:Overflow checking should not be disabled for Enumerable.Sum";
            public const string S2290 = "S2290:Field-like events should not be virtual";
            public const string S2223 = "S2223:Non-constant static fields should not be visible";
            public const string S1944 = "S1944:Inappropriate casts should not be made";
            public const string S1699 = "S1699:Constructors should only call non-overridable methods";
            public const string S1215 = "S1215:GC.Collect should not be called";
            public const string S1186 = "S1186:Methods should not be empty";
            public const string S1163 = "S1163:Exceptions should not be thrown in finally blocks";
            public const string S1006 = "S1006:Method overrides should not change parameter defaults";
            public const string S4260 = "S4260:ConstructorArgument parameters should exist in constructors";
            public const string S4210 = "S4210:Windows Forms entry points should be marked with STAThread";
            public const string S3984 = "S3984:Exception should not be created without being thrown";
            public const string S3981 = "S3981:Collection sizes and array length comparisons should make sense";
            public const string S3927 = "S3927:Serialization event handlers should be implemented correctly";
            public const string S3926 = "S3926:Deserialization methods should be provided for OptionalField members";
            public const string S3903 = "S3903:Types should be defined in named namespaces";
            public const string S3655 = "S3655:Empty nullable value should not be accessed";
            public const string S3610 = "S3610:Nullable type comparison should not be redundant";
            public const string S3603 = "S3603:Methods with Pure attribute should return a value ";
            public const string S3598 = "S3598:One-way OperationContract methods should have void return type";
            public const string S3466 = "S3466:Optional parameters should be passed to base calls";
            public const string S3453 = "S3453:Classes should not have only private constructors";
            public const string S3346 = "S3346:Expressions used in Debug.Assert should not produce side effects";
            public const string S3343 = "S3343:Caller information parameters should come at the end of the parameter list";
            public const string S3263 = "S3263:Static fields should appear in the order they must be initialized ";
            public const string S3249 = "S3249:Classes directly extending object should not call base in GetHashCode or Equals";
            public const string S3244 = "S3244:Anonymous delegates should not be used to unsubscribe from Events";
            public const string S3172 = "S3172:Delegates should not be subtracted";
            public const string S3168 = "S3168:async methods should not return void";
            public const string S3005 = "S3005:ThreadStatic should not be used on non-static fields";
            public const string S2997 = "S2997:IDisposables created in a using statement should not be returned";
            public const string S2996 = "S2996:ThreadStatic fields should not be initialized";
            public const string S2995 = "S2995:Object.ReferenceEquals should not be used for value types";
            public const string S2761 = "S2761:Doubled prefix operators !! and ~~ should not be used";

            public const string S2758 =
                "S2758:The ternary operator should not return the same value regardless of the condition";

            public const string S2757 = "S2757:=+ should not be used instead of +=";
            public const string S2688 = "S2688:NaN should not be used in comparisons";
            public const string S2583 = "S2583:Conditionally executed blocks should be reachable";
            public const string S2259 = "S2259:Null pointers should not be dereferenced";
            public const string S2225 = "S2225:ToString() method should not return null";
            public const string S2201 = "S2201:Return values from functions without side effects should not be ignored";
            public const string S2123 = "S2123:Values should not be uselessly incremented";
            public const string S2114 = "S2114:Collections should not be passed as arguments to their own methods";
            public const string S1862 = "S1862:Related if/else if statements should not have the same condition";
            public const string S1848 = "S1848:Objects should not be created to be dropped immediately without being used";
            public const string S1764 = "S1764:Identical expressions should not be used on both sides of a binary operator";
            public const string S1656 = "S1656:Variables should not be self-assigned";
            public const string S907 = "S907:goto statement should not be used";
            public const string S4277 = "S4277:Shared parts should not be created with new";
            public const string S4220 = "S4220:Events should have proper arguments";
            public const string S4214 = "S4214:P/Invoke methods should not be visible";
            public const string S4200 = "S4200:Native methods should be wrapped";
            public const string S4144 = "S4144:Methods should not have identical implementations";
            public const string S4035 = "S4035:Classes implementing IEquatable<T> should be sealed";
            public const string S4016 = "S4016:Enumeration members should not be named Reserved";
            public const string S3971 = "S3971:GC.SuppressFinalize should not be called";

            public const string S3928 =
                "S3928:Parameter names used into ArgumentException constructors should match an existing one ";

            public const string S3925 = "S3925:ISerializable should be implemented correctly";
            public const string S3885 = "S3885:Assembly.Load should be used";
            public const string S3881 = "S3881:IDisposable should be implemented correctly";
            public const string S3597 = "S3597:ServiceContract and OperationContract attributes should be used together";
            public const string S3457 = "S3457:Composite format strings should be used correctly";
            public const string S3445 = "S3445:Exceptions should not be explicitly rethrown";
            public const string S3442 = "S3442:abstract classes should not have public constructors";
            public const string S3415 = "S3415:Assertion arguments should be passed in the correct order";
            public const string S3358 = "S3358:Ternary operators should not be nested";
            public const string S3264 = "S3264:Events should be invoked";
            public const string S3262 = "S3262:params should be used on overrides";
            public const string S3246 = "S3246:Generic type parameters should be co/contravariant when possible";
            public const string S3169 = "S3169:Multiple OrderBy calls should not be used";
            public const string S3010 = "S3010:Static fields should not be updated in constructors";
            public const string S2971 = "S2971:IEnumerable LINQs should be simplified";
            public const string S2933 = "S2933:Fields that are only assigned in the constructor should be readonly";
            public const string S2743 = "S2743:Static fields should not be used in generic types";
            public const string S2681 = "S2681:Multiline blocks should be enclosed in curly braces";
            public const string S2589 = "S2589:Boolean expressions should not be gratuitous";
            public const string S2436 = "S2436:Classes and methods should not have too many generic parameters";
            public const string S2376 = "S2376:Write-only properties should not be used";
            public const string S2372 = "S2372:Exceptions should not be thrown from property getters";
            public const string S2326 = "S2326:Unused type parameters should be removed";
            public const string S2234 = "S2234:Parameters should be passed in the correct order";

            public const string S1871 =
                "S1871:Two branches in a conditional structure should not have exactly the same implementation";

            public const string S1854 = "S1854:Dead stores should be removed";
            public const string S1751 = "S1751:Jump statements should not be used unconditionally";
            public const string S1607 = "S1607:Tests should not be ignored";
            public const string S1479 = "S1479:switch statements should not have too many case clauses";
            public const string S125 = "S125:Sections of code should not be commented out";
            public const string S1172 = "S1172:Unused method parameters should be removed";
            public const string S1168 = "S1168:Empty arrays and collections should be returned instead of null";
            public const string S1144 = "S1144:Unused private types or members should be removed";
            public const string S1134 = "S1134:Track uses of FIXME tags";
            public const string S1123 = "S1123:Obsolete attributes should include explanations";
            public const string S1121 = "S1121:Assignments should not be made from within sub-expressions";
            public const string S112 = "S112:General exceptions should never be thrown";
            public const string S1118 = "S1118:Utility classes should not have public constructors";
            public const string S1117 = "S1117:Local variables should not shadow class fields";
            public const string S1110 = "S1110:Redundant pairs of parentheses should be removed";
            public const string S110 = "S110:Inheritance tree of classes should not be too deep";
            public const string S108 = "S108:Nested blocks of code should not be left empty";
            public const string S107 = "S107:Methods should not have too many parameters";
            public const string S1066 = "S1066:Collapsible if statements should be merged";
            public const string S2386 = "S2386:Mutable fields should not be public static";
            public const string S1104 = "S1104:Fields should not have public accessibility";
            public const string S4158 = "S4158:Empty collections should not be accessed or iterated";
            public const string S3887 = "S3887:Mutable, non-private fields should not be readonly";
            public const string S3456 = "S3456:string.ToCharArray() should not be called redundantly";

            public const string S3397 =
                "S3397:base.Equals should not be used to check for reference equality in Equals if base is not object";

            public const string S2934 =
                "S2934:Property assignments should not be made for readonly fields not constrained to reference types";

            public const string S2345 = "S2345:Flags enumerations should explicitly initialize all their members";
            public const string S2328 = "S2328:GetHashCode should not reference mutable fields";
            public const string S2184 = "S2184:Results of integer division should not be assigned to floating point variables";
            public const string S2183 = "S2183:Ints and longs should not be shifted by zero or more than their number of bits-1";
            public const string S1206 = "S1206:Equals(Object) and GetHashCode() should be overridden in pairs";
            public const string S818 = "S818:Literal suffixes should be upper case";
            public const string S3897 = "S3897:Classes that provide Equals(<T>) should implement IEquatable<T>";
            public const string S3626 = "S3626:Jump statements should not be redundant";
            public const string S3604 = "S3604:Member initializer values should not be redundant";
            public const string S3459 = "S3459:Unassigned members should be removed";
            public const string S3458 = "S3458:Empty case clauses that fall through to the default should be omitted";

            public const string S3450 =
                "S3450:Parameters with [DefaultParameterValue] attributes should also be marked [Optional]";

            public const string S3444 = "S3444:Interfaces should not simply inherit from base interfaces with colliding members";
            public const string S3440 = "S3440:Variables should not be checked against the values they're about to be assigned";

            public const string S3376 =
                "S3376:Attribute, EventArgs, and Exception type names should end with the type being extended";

            public const string S3261 = "S3261:Namespaces should not be empty";
            public const string S3256 = "S3256:string.IsNullOrEmpty should be used";
            public const string S3251 = "S3251:Implementations should be provided for partial methods";
            public const string S3247 = "S3247:Duplicate casts should not be made";
            public const string S3241 = "S3241:Methods should not return values that are never used";
            public const string S3236 = "S3236:Caller information arguments should not be provided explicitly";
            public const string S3220 = "S3220:Method calls should not resolve ambiguously to overloads with params";
            public const string S2737 = "S2737:catch clauses should do more than rethrow";
            public const string S2486 = "S2486:Generic exceptions should not be ignored";
            public const string S2344 = "S2344:Enumeration type names should not have Flags or Enum suffixes";
            public const string S2342 = "S2342:Enumeration types should comply with a naming convention";
            public const string S2292 = "S2292:Trivial properties should be auto-implemented";
            public const string S2219 = "S2219:Runtime type checking should be simplified";
            public const string S1940 = "S1940:Boolean checks should not be inverted";
            public const string S1939 = "S1939:Inheritance list should not be redundant";
            public const string S1905 = "S1905:Redundant casts should not be used";
            public const string S1643 = "S1643:Strings should not be concatenated using '+' in a loop";
            public const string S1481 = "S1481:Unused local variables should be removed";

            public const string S1450 =
                "S1450:Private fields only used as local variables in methods should become local variables";

            public const string S1210 =
                "S1210:Equals and the comparison operators should be overridden when implementing IComparable";

            public const string S1185 =
                "S1185:Overriding members should do more than simply call the same member in the base class";

            public const string S1155 = "S1155:Any() should be used to test for emptiness";
            public const string S1125 = "S1125:Boolean literals should not be redundant";
            public const string S1116 = "S1116:Empty statements should be removed";
            public const string S1075 = "S1075:URIs should not be hardcoded";
            public const string S101 = "S101:Types should be named in camel case";
            public const string S1135 = "S1135:Track uses of TODO tags";

            public const string S2931 =
                "S2931:Classes with IDisposable members or native resources should implement IDisposable";

            public const string S2699 = "S2699:Tests should include assertions";
            public const string S2387 = "S2387:Child class fields should not shadow parent class fields";
            public const string S1451 = "S1451:Track lack of copyright and license headers";
            public const string S1147 = "S1147:Exit methods should not be called";
            public const string S4212 = "S4212:Serialization constructors should be secured";
            public const string S2070 = "S2070:SHA-1 and Message-Digest hash algorithms should not be used";
            public const string S2952 = "S2952:Classes should Dispose of members from the classes' own Dispose methods";
            public const string S2551 = "S2551:Types and this should not be used for locking";
            public const string S4039 = "S4039:Interface methods should be callable by derived types";

            public const string S4025 =
                "S4025:Child class fields should not differ from parent class fields only by capitalization";

            public const string S4000 = "S4000:Pointers to unmanaged memory should not be visible";
            public const string S3874 = "S3874:out and ref parameters should not be used";
            public const string S3353 = "S3353:Unchanged local variables should be const";
            public const string S3216 = "S3216:ConfigureAwait(false) should be used";
            public const string S3215 = "S3215:interface instances should not be cast to concrete types";
            public const string S2701 = "S2701:Literal boolean values should not be used in assertions";
            public const string S2360 = "S2360:Optional parameters should not be used";
            public const string S2339 = "S2339:Public constant members should not be used";
            public const string S2330 = "S2330:Array covariance should not be used";
            public const string S2302 = "S2302:nameof should be used";
            public const string S2197 = "S2197:Modulus results should not be checked for direct equality";
            public const string S1994 = "S1994:for loop increment clauses should modify the loops' counters";
            public const string S1541 = "S1541:Methods and properties should not be too complex";

            public const string S134 =
                "S134:Control flow statements if, switch, for, foreach, while, do  and try should not be nested too deeply";

            public const string S131 = "S131:switch/Select statements should end with default/Case Else clauses";
            public const string S126 = "S126:if ... else if constructs should end with else clauses";
            public const string S121 = "S121:Control structures should use curly braces";
            public const string S1067 = "S1067:Expressions should not be too complex";
            public const string S1313 = "S1313:IP addresses should not be hardcoded";

            public const string S1697 =
                "S1697:Short-circuit logic should be used to prevent null pointer dereferences in conditionals";

            public const string S1244 = "S1244:Floating point numbers should not be tested for equality";
            public const string S1145 = "S1145:Useless if(true) {...} and if(false){...} blocks should be removed";
            public const string S4142 = "S4142:Duplicate values should not be passed as arguments";
            public const string S4070 = "S4070:Non-flags enums should not be marked with FlagsAttribute";
            public const string S4059 = "S4059:Property names should not match get methods";
            public const string S4057 = "S4057:Locales should be set for data types";
            public const string S4055 = "S4055:Literals should not be passed as localized parameters";
            public const string S4050 = "S4050:Operators should be overloaded consistently";
            public const string S4017 = "S4017:Method signatures should not contain nested generic types";
            public const string S4005 = "S4005:System.Uri arguments should be used instead of strings";
            public const string S4004 = "S4004:Collection properties should be readonly";
            public const string S4002 = "S4002:Disposable types should declare finalizers";
            public const string S3997 = "S3997:String URI overloads should call System.Uri overloads";
            public const string S3996 = "S3996:URI properties should not be strings";
            public const string S3995 = "S3995:URI return values should not be strings";
            public const string S3994 = "S3994:URI Parameters should not be strings";
            public const string S3993 = "S3993:Custom attributes should be marked with System.AttributeUsageAttribute";
            public const string S3992 = "S3992:Assemblies should explicitly specify COM visibility";
            public const string S3990 = "S3990:Assemblies should be marked as CLS compliant";
            public const string S3956 = "S3956:Generic.List instances should not be part of public APIs";
            public const string S3909 = "S3909:Collections should implement the generic interface";
            public const string S3908 = "S3908:Generic event handlers should be used";
            public const string S3906 = "S3906:Event Handlers should have the correct signature";
            public const string S3902 = "S3902:Assembly.GetExecutingAssembly should not be called";
            public const string S3900 = "S3900:Arguments of public methods should be validated against null";
            public const string S3898 = "S3898:Value types should implement IEquatable<T>";
            public const string S3880 = "S3880:Finalizers should not be empty";
            public const string S3431 = "S3431:[ExpectedException] should not be used";
            public const string S3366 = "S3366:this should not be exposed from constructors";
            public const string S2357 = "S2357:Fields should be private";
            public const string S1696 = "S1696:NullReferenceException should not be caught";
            public const string S138 = "S138:Functions should not have too many lines of code";
            public const string S127 = "S127:for loop stop conditions should be invariant";
            public const string S122 = "S122:Statements should be on separate lines";

            public const string S1200 =
                "S1200:Classes should not be coupled to too many other classes (Single Responsibility Principle)";

            public const string S104 = "S104:Files should not have too many lines of code";
            public const string S103 = "S103:Lines should not be too long";
            public const string S2228 = "S2228:Console logging should not be used";

            public const string S2955 =
                "S2955:Generic parameters not constrained to reference types should not be compared to null";

            public const string S2674 = "S2674:The length returned from a stream read should be checked";

            public const string S1226 =
                "S1226:Method parameters, caught exceptions and foreach variables' initial values should not be ignored";

            public const string S4226 = "S4226:Extensions should be in separate namespaces";
            public const string S4225 = "S4225:Extension methods should not extend object";
            public const string S4069 = "S4069:Operator overloads should have named alternatives";
            public const string S4061 = "S4061:params should be used instead of varargs";
            public const string S4060 = "S4060:Non-abstract attributes should be sealed";
            public const string S4058 = "S4058:Overloads with a StringComparison parameter should be used";
            public const string S4056 = "S4056:Overloads with a CultureInfo or an IFormatProvider parameter should be used";
            public const string S4052 = "S4052:Types should not extend outdated base types";
            public const string S4049 = "S4049:Properties should be preferred";
            public const string S4047 = "S4047:Generics should be used when appropriate";
            public const string S4041 = "S4041:Type names should not match namespaces";
            public const string S4040 = "S4040:Strings should be normalized to uppercase";
            public const string S4027 = "S4027:Exceptions should provide standard constructors";
            public const string S4026 = "S4026:Assemblies should be marked with NeutralResourcesLanguageAttribute";
            public const string S4023 = "S4023:Interfaces should not be empty";
            public const string S4022 = "S4022:Enumerations should have Int32 storage";
            public const string S4018 = "S4018:Generic methods should provide type parameters";
            public const string S3967 = "S3967:Multidimensional arrays should not be used";
            public const string S3963 = "S3963:static fields should be initialized inline";
            public const string S3962 = "S3962:static readonly constants should be const instead";
            public const string S3876 = "S3876:Strings or integral types should be used for indexers";
            public const string S3872 = "S3872:Parameter names should not duplicate the names of their methods";
            public const string S3717 = "S3717:Track use of NotImplementedException";
            public const string S3532 = "S3532:Empty default clauses should be removed";
            public const string S3441 = "S3441:Redundant property names should be omitted in anonymous classes";
            public const string S3257 = "S3257:Declarations and initializations should be as concise as possible";
            public const string S3254 = "S3254:Default parameter values should not be passed as arguments";
            public const string S3253 = "S3253:Constructor and destructor declarations should not be redundant";
            public const string S3242 = "S3242:Method parameters should be declared with base types";
            public const string S3240 = "S3240:The simplest possible condition syntax should be used";
            public const string S3235 = "S3235:Redundant parentheses should not be used";
            public const string S3234 = "S3234:GC.SuppressFinalize should not be invoked for types without destructors";
            public const string S3052 = "S3052:Members should not be initialized to default values";
            public const string S2760 = "S2760:Sequential tests should not check the same condition";
            public const string S2333 = "S2333:Redundant modifiers should not be used";
            public const string S2325 = "S2325:Methods and properties that don't access instance data should be static";
            public const string S2221 = "S2221:Exception should not be caught when not required by called methods";
            public const string S2156 = "S2156:sealed classes should not have protected members";
            public const string S1858 = "S1858:ToString() calls should not be redundant";
            public const string S1698 = "S1698:== should not be used when Equals is overridden";
            public const string S1694 = "S1694:An abstract class should have both abstract and concrete methods";
            public const string S1659 = "S1659:Multiple variables should not be declared on the same line";
            public const string S1449 = "S1449:Culture should be specified for string operations";
            public const string S1301 = "S1301:switch statements should have at least 3 case clauses";
            public const string S1227 = "S1227:break statements should not be used except for switch cases";
            public const string S113 = "S113:Files should contain an empty newline at the end";
            public const string S1109 = "S1109:A close curly brace should be located at the beginning of a line";
            public const string S105 = "S105:Tabulation characters should not be used";
            public const string S100 = "S100:Methods and properties should be named in camel case";
            public const string S1309 = "S1309:Track uses of in-source issue suppressions";
        }

        [PublicAPI]
        [SuppressMessage(FXCOP, CA1034)]
        public static class StyleCop
        {
            public const string SA0001 = "SA0001:XmlCommentAnalysisDisabled";
            public const string SA0002 = "SA0002:InvalidSettingsFile";
            public const string SA1000 = "SA1000:KeywordsMustBeSpacedCorrectly";
            public const string SA1001 = "SA1001:CommasMustBeSpacedCorrectly";
            public const string SA1002 = "SA1002:SemicolonsMustBeSpacedCorrectly";
            public const string SA1003 = "SA1003:SymbolsMustBeSpacedCorrectly";
            public const string SA1004 = "SA1004:DocumentationLinesMustBeginWithSingleSpace";
            public const string SA1005 = "SA1005:SingleLineCommentsMustBeginWithSingleSpace";
            public const string SA1006 = "SA1006:PreprocessorKeywordsMustNotBePrecededBySpace";
            public const string SA1007 = "SA1007:OperatorKeywordMustBeFollowedBySpace";
            public const string SA1008 = "SA1008:OpeningParenthesisMustBeSpacedCorrectly";
            public const string SA1009 = "SA1009:ClosingParenthesisMustBeSpacedCorrectly";
            public const string SA1010 = "SA1010:OpeningSquareBracketsMustBeSpacedCorrectly";
            public const string SA1011 = "SA1011:ClosingSquareBracketsMustBeSpacedCorrectly";
            public const string SA1012 = "SA1012:OpeningBracesMustBeSpacedCorrectly";
            public const string SA1013 = "SA1013:ClosingBracesMustBeSpacedCorrectly";
            public const string SA1014 = "SA1014:OpeningGenericBracketsMustBeSpacedCorrectly";
            public const string SA1015 = "SA1015:ClosingGenericBracketsMustBeSpacedCorrectly";
            public const string SA1016 = "SA1016:OpeningAttributeBracketsMustBeSpacedCorrectly";
            public const string SA1017 = "SA1017:ClosingAttributeBracketsMustBeSpacedCorrectly";
            public const string SA1018 = "SA1018:NullableTypeSymbolsMustNotBePrecededBySpace";
            public const string SA1019 = "SA1019:MemberAccessSymbolsMustBeSpacedCorrectly";
            public const string SA1020 = "SA1020:IncrementDecrementSymbolsMustBeSpacedCorrectly";
            public const string SA1021 = "SA1021:NegativeSignsMustBeSpacedCorrectly";
            public const string SA1022 = "SA1022:PositiveSignsMustBeSpacedCorrectly";
            public const string SA1023 = "SA1023:DereferenceAndAccessOfMustBeSpacedCorrectly";
            public const string SA1024 = "SA1024:ColonsMustBeSpacedCorrectly";
            public const string SA1025 = "SA1025:CodeMustNotContainMultipleWhitespaceInARow";
            public const string SA1026 = "SA1026:CodeMustNotContainSpaceAfterNewKeywordInImplicitlyTypedArrayAllocation";
            public const string SA1027 = "SA1027:UseTabsCorrectly";
            public const string SA1028 = "SA1028:CodeMustNotContainTrailingWhitespace";
            public const string SA1100 = "SA1100:DoNotPrefixCallsWithBaseUnlessLocalImplementationExists";
            public const string SA1101 = "SA1101:PrefixLocalCallsWithThis";
            public const string SA1106 = "SA1106:CodeMustNotContainEmptyStatements";
            public const string SA1107 = "SA1107:CodeMustNotContainMultipleStatementsOnOneLine";
            public const string SA1108 = "SA1108:BlockStatementsMustNotContainEmbeddedComments";
            public const string SA1109 = "SA1109:BlockStatementsMustNotContainEmbeddedRegions";
            public const string SA1110 = "SA1110:OpeningParenthesisMustBeOnDeclarationLine";
            public const string SA1111 = "SA1111:ClosingParenthesisMustBeOnLineOfLastParameter";
            public const string SA1112 = "SA1112:ClosingParenthesisMustBeOnLineOfOpeningParenthesis";
            public const string SA1113 = "SA1113:CommaMustBeOnSameLineAsPreviousParameter";
            public const string SA1114 = "SA1114:ParameterListMustFollowDeclaration";
            public const string SA1115 = "SA1115:ParameterMustFollowComma";
            public const string SA1116 = "SA1116:SplitParametersMustStartOnLineAfterDeclaration";
            public const string SA1117 = "SA1117:ParametersMustBeOnSameLineOrSeparateLines";
            public const string SA1118 = "SA1118:ParameterMustNotSpanMultipleLines";
            public const string SA1119 = "SA1119:StatementMustNotUseUnnecessaryParenthesis";
            public const string SA1120 = "SA1120:CommentsMustContainText";
            public const string SA1121 = "SA1121:UseBuiltInTypeAlias";
            public const string SA1122 = "SA1122:UseStringEmptyForEmptyStrings";
            public const string SA1123 = "SA1123:DoNotPlaceRegionsWithinElements";
            public const string SA1124 = "SA1124:DoNotUseRegions";
            public const string SA1125 = "SA1125:UseShorthandForNullableTypes";
            public const string SA1126 = "SA1126:PrefixCallsCorrectly";
            public const string SA1127 = "SA1127:GenericTypeConstraintsMustBeOnOwnLine";
            public const string SA1128 = "SA1128:ConstructorInitializerMustBeOnOwnLine";
            public const string SA1129 = "SA1129:DoNotUseDefaultValueTypeConstructor";
            public const string SA1130 = "SA1130:UseLambdaSyntax";
            public const string SA1131 = "SA1131:UseReadableConditions";
            public const string SA1132 = "SA1132:DoNotCombineFields";
            public const string SA1133 = "SA1133:DoNotCombineAttributes";
            public const string SA1134 = "SA1134:AttributesMustNotShareLine";
            public const string SA1136 = "SA1136:EnumValuesShouldBeOnSeparateLines";
            public const string SA1137 = "SA1137:ElementsShouldHaveTheSameIndentation";
            public const string SA1139 = "SA1139:UseLiteralsSuffixNotationInsteadOfCasting";
            public const string SA1200 = "SA1200:UsingDirectivesMustBePlacedCorrectly";
            public const string SA1201 = "SA1201:ElementsMustAppearInTheCorrectOrder";
            public const string SA1202 = "SA1202:ElementsMustBeOrderedByAccess";
            public const string SA1203 = "SA1203:ConstantsMustAppearBeforeFields";
            public const string SA1204 = "SA1204:StaticElementsMustAppearBeforeInstanceElements";
            public const string SA1205 = "SA1205:PartialElementsMustDeclareAccess";
            public const string SA1206 = "SA1206:DeclarationKeywordsMustFollowOrder";
            public const string SA1207 = "SA1207:ProtectedMustComeBeforeInternal";
            public const string SA1208 = "SA1208:SystemUsingDirectivesMustBePlacedBeforeOtherUsingDirectives";
            public const string SA1209 = "SA1209:UsingAliasDirectivesMustBePlacedAfterOtherUsingDirectives";
            public const string SA1210 = "SA1210:UsingDirectivesMustBeOrderedAlphabeticallyByNamespace";
            public const string SA1211 = "SA1211:UsingAliasDirectivesMustBeOrderedAlphabeticallyByAliasName";
            public const string SA1212 = "SA1212:PropertyAccessorsMustFollowOrder";
            public const string SA1213 = "SA1213:EventAccessorsMustFollowOrder";
            public const string SA1214 = "SA1214:ReadonlyElementsMustAppearBeforeNonReadonlyElements";
            public const string SA1215 = "SA1215:InstanceReadonlyElementsMustAppearBeforeInstanceNonReadonlyElements";
            public const string SA1216 = "SA1216:UsingStaticDirectivesMustBePlacedAtTheCorrectLocation";
            public const string SA1217 = "SA1217:UsingStaticDirectivesMustBeOrderedAlphabetically";
            public const string SA1300 = "SA1300:ElementMustBeginWithUpperCaseLetter";
            public const string SA1301 = "SA1301:ElementMustBeginWithLowerCaseLetter";
            public const string SA1302 = "SA1302:InterfaceNamesMustBeginWithI";
            public const string SA1303 = "SA1303:ConstFieldNamesMustBeginWithUpperCaseLetter";
            public const string SA1304 = "SA1304:NonPrivateReadonlyFieldsMustBeginWithUpperCaseLetter";
            public const string SA1305 = "SA1305:FieldNamesMustNotUseHungarianNotation";
            public const string SA1306 = "SA1306:FieldNamesMustBeginWithLowerCaseLetter";
            public const string SA1307 = "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter";
            public const string SA1308 = "SA1308:VariableNamesMustNotBePrefixed";
            public const string SA1309 = "SA1309:FieldNamesMustNotBeginWithUnderscore";
            public const string SA1310 = "SA1310:FieldNamesMustNotContainUnderscore";
            public const string SA1311 = "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter";
            public const string SA1312 = "SA1312:VariableNamesMustBeginWithLowerCaseLetter";
            public const string SA1313 = "SA1313:ParameterNamesMustBeginWithLowerCaseLetter";
            public const string SA1314 = "SA1314:TypeParameterNamesMustBeginWithT";
            public const string SA1400 = "SA1400:AccessModifierMustBeDeclared";
            public const string SA1401 = "SA1401:FieldsMustBePrivate";
            public const string SA1402 = "SA1402:FileMayOnlyContainASingleType";
            public const string SA1403 = "SA1403:FileMayOnlyContainASingleNamespace";
            public const string SA1404 = "SA1404:CodeAnalysisSuppressionMustHaveJustification";
            public const string SA1405 = "SA1405:DebugAssertMustProvideMessageText";
            public const string SA1406 = "SA1406:DebugFailMustProvideMessageText";
            public const string SA1407 = "SA1407:ArithmeticExpressionsMustDeclarePrecedence";
            public const string SA1408 = "SA1408:ConditionalExpressionsMustDeclarePrecedence";
            public const string SA1409 = "SA1409:RemoveUnnecessaryCode";
            public const string SA1410 = "SA1410:RemoveDelegateParenthesisWhenPossible";
            public const string SA1411 = "SA1411:AttributeConstructorMustNotUseUnnecessaryParenthesis";
            public const string SA1412 = "SA1412:StoreFilesAsUtf8";
            public const string SA1413 = "SA1413:UseTrailingCommasInMultiLineInitializers";
            public const string SA1500 = "SA1500:BracesForMultiLineStatementsMustNotShareLine";
            public const string SA1501 = "SA1501:StatementMustNotBeOnSingleLine";
            public const string SA1502 = "SA1502:ElementMustNotBeOnSingleLine";
            public const string SA1503 = "SA1503:BracesMustNotBeOmitted";
            public const string SA1504 = "SA1504:AllAccessorsMustBeSingleLineOrMultiLine";
            public const string SA1505 = "SA1505:OpeningBracesMustNotBeFollowedByBlankLine";
            public const string SA1506 = "SA1506:ElementDocumentationHeadersMustNotBeFollowedByBlankLine";
            public const string SA1507 = "SA1507:CodeMustNotContainMultipleBlankLinesInARow";
            public const string SA1508 = "SA1508:ClosingBracesMustNotBePrecededByBlankLine";
            public const string SA1509 = "SA1509:OpeningBracesMustNotBePrecededByBlankLine";
            public const string SA1510 = "SA1510:ChainedStatementBlocksMustNotBePrecededByBlankLine";
            public const string SA1511 = "SA1511:WhileDoFooterMustNotBePrecededByBlankLine";
            public const string SA1512 = "SA1512:SingleLineCommentsMustNotBeFollowedByBlankLine";
            public const string SA1513 = "SA1513:ClosingBraceMustBeFollowedByBlankLine";
            public const string SA1514 = "SA1514:ElementDocumentationHeaderMustBePrecededByBlankLine";
            public const string SA1515 = "SA1515:SingleLineCommentMustBePrecededByBlankLine";
            public const string SA1516 = "SA1516:ElementsMustBeSeparatedByBlankLine";
            public const string SA1517 = "SA1517:CodeMustNotContainBlankLinesAtStartOfFile";
            public const string SA1518 = "SA1518:UseLineEndingsCorrectlyAtEndOfFile";
            public const string SA1519 = "SA1519:BracesMustNotBeOmittedFromMultiLineChildStatement";
            public const string SA1520 = "SA1520:UseBracesConsistently";
            public const string SA1600 = "SA1600:ElementsMustBeDocumented";
            public const string SA1601 = "SA1601:PartialElementsMustBeDocumented";
            public const string SA1602 = "SA1602:EnumerationItemsMustBeDocumented";
            public const string SA1603 = "SA1603:DocumentationMustContainValidXml";
            public const string SA1604 = "SA1604:ElementDocumentationMustHaveSummary";
            public const string SA1605 = "SA1605:PartialElementDocumentationMustHaveSummary";
            public const string SA1606 = "SA1606:ElementDocumentationMustHaveSummaryText";
            public const string SA1607 = "SA1607:PartialElementDocumentationMustHaveSummaryText";
            public const string SA1608 = "SA1608:ElementDocumentationMustNotHaveDefaultSummary";
            public const string SA1609 = "SA1609:PropertyDocumentationMustHaveValue";
            public const string SA1610 = "SA1610:PropertyDocumentationMustHaveValueText";
            public const string SA1611 = "SA1611:ElementParametersMustBeDocumented";
            public const string SA1612 = "SA1612:ElementParameterDocumentationMustMatchElementParameters";
            public const string SA1613 = "SA1613:ElementParameterDocumentationMustDeclareParameterName";
            public const string SA1614 = "SA1614:ElementParameterDocumentationMustHaveText";
            public const string SA1615 = "SA1615:ElementReturnValueMustBeDocumented";
            public const string SA1616 = "SA1616:ElementReturnValueDocumentationMustHaveText";
            public const string SA1617 = "SA1617:VoidReturnValueMustNotBeDocumented";
            public const string SA1618 = "SA1618:GenericTypeParametersMustBeDocumented";
            public const string SA1619 = "SA1619:GenericTypeParametersMustBeDocumentedPartialClass";
            public const string SA1620 = "SA1620:GenericTypeParameterDocumentationMustMatchTypeParameters";
            public const string SA1621 = "SA1621:GenericTypeParameterDocumentationMustDeclareParameterName";
            public const string SA1622 = "SA1622:GenericTypeParameterDocumentationMustHaveText";
            public const string SA1623 = "SA1623:PropertySummaryDocumentationMustMatchAccessors";
            public const string SA1624 = "SA1624:PropertySummaryDocumentationMustOmitSetAccessorWithRestrictedAccess";
            public const string SA1625 = "SA1625:ElementDocumentationMustNotBeCopiedAndPasted";
            public const string SA1626 = "SA1626:SingleLineCommentsMustNotUseDocumentationStyleSlashes";
            public const string SA1627 = "SA1627:DocumentationTextMustNotBeEmpty";
            public const string SA1628 = "SA1628:DocumentationTextMustBeginWithACapitalLetter";
            public const string SA1629 = "SA1629:DocumentationTextMustEndWithAPeriod";
            public const string SA1630 = "SA1630:DocumentationTextMustContainWhitespace";
            public const string SA1631 = "SA1631:DocumentationMustMeetCharacterPercentage";
            public const string SA1632 = "SA1632:DocumentationTextMustMeetMinimumCharacterLength";
            public const string SA1633 = "SA1633:FileMustHaveHeader";
            public const string SA1634 = "SA1634:FileHeaderMustShowCopyright";
            public const string SA1635 = "SA1635:FileHeaderMustHaveCopyrightText";
            public const string SA1636 = "SA1636:FileHeaderCopyrightTextMustMatch";
            public const string SA1637 = "SA1637:FileHeaderMustContainFileName";
            public const string SA1638 = "SA1638:FileHeaderFileNameDocumentationMustMatchFileName";
            public const string SA1639 = "SA1639:FileHeaderMustHaveSummary";
            public const string SA1640 = "SA1640:FileHeaderMustHaveValidCompanyText";
            public const string SA1641 = "SA1641:FileHeaderCompanyNameTextMustMatch";
            public const string SA1642 = "SA1642:ConstructorSummaryDocumentationMustBeginWithStandardText";
            public const string SA1643 = "SA1643:DestructorSummaryDocumentationMustBeginWithStandardText";
            public const string SA1644 = "SA1644:DocumentationHeadersMustNotContainBlankLines";
            public const string SA1645 = "SA1645:IncludedDocumentationFileDoesNotExist";
            public const string SA1646 = "SA1646:IncludedDocumentationXPathDoesNotExist";
            public const string SA1647 = "SA1647:IncludeNodeDoesNotContainValidFileAndPath";
            public const string SA1648 = "SA1648:InheritDocMustBeUsedWithInheritingClass";
            public const string SA1649 = "SA1649:FileNameMustMatchTypeName";
            public const string SA1650 = "SA1650:ElementDocumentationMustBeSpelledCorrectly";
            public const string SA1651 = "SA1651:DoNotUsePlaceholderElements";
            public const string SA1652 = "SA1652:EnableXmlDocumentationOutput";
        }
    }
}