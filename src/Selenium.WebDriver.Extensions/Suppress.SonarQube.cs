namespace Selenium.WebDriver.Extensions
{
    internal static partial class Suppress
    {
        public const string S100 = "S100:Methods and properties should be named in camel case";
        public const string S1006 = "S1006:Method overrides should not change parameter defaults";
        public const string S101 = "S101:Types should be named in camel case";
        public const string S103 = "S103:Lines should not be too long";
        public const string S104 = "S104:Files should not have too many lines of code";
        public const string S1048 = "S1048:Destructors should not throw exceptions";
        public const string S105 = "S105:Tabulation characters should not be used";
        public const string S1066 = "S1066:Collapsible if statements should be merged";
        public const string S1067 = "S1067:Expressions should not be too complex";
        public const string S107 = "S107:Methods should not have too many parameters";
        public const string S1075 = "S1075:URIs should not be hardcoded";
        public const string S108 = "S108:Nested blocks of code should not be left empty";
        public const string S109 = "S109:Magic numbers should not be used";
        public const string S110 = "S110:Inheritance tree of classes should not be too deep";
        public const string S1104 = "S1104:Fields should not have public accessibility";
        public const string S1109 = "S1109:A close curly brace should be located at the beginning of a line";
        public const string S1110 = "S1110:Redundant pairs of parentheses should be removed";
        public const string S1116 = "S1116:Empty statements should be removed";
        public const string S1117 = "S1117:Local variables should not shadow class fields";
        public const string S1118 = "S1118:Utility classes should not have public constructors";
        public const string S112 = "S112:General exceptions should never be thrown";
        public const string S1121 = "S1121:Assignments should not be made from within sub-expressions";
        public const string S1123 = "S1123:Obsolete attributes should include explanations";
        public const string S1125 = "S1125:Boolean literals should not be redundant";
        public const string S113 = "S113:Files should contain an empty newline at the end";
        public const string S1134 = "S1134:Track uses of FIXME tags";
        public const string S1135 = "S1135:Track uses of TODO tags";
        public const string S1144 = "S1144:Unused private types or members should be removed";
        public const string S1145 = "S1145:Useless if(true) {...} and if(false){...} blocks should be removed";
        public const string S1147 = "S1147:Exit methods should not be called";
        public const string S1151 = "S1151:switch case clauses should not have too many lines of code";
        public const string S1155 = "S1155:Any() should be used to test for emptiness";
        public const string S1163 = "S1163:Exceptions should not be thrown in finally blocks";
        public const string S1168 = "S1168:Empty arrays and collections should be returned instead of null";
        public const string S1172 = "S1172:Unused method parameters should be removed";

        public const string S1185 =
            "S1185:Overriding members should do more than simply call the same member in the base class";

        public const string S1186 = "S1186:Methods should not be empty";
        public const string S1192 = "S1192:String literals should not be duplicated";

        public const string S1200 =
            "S1200:Classes should not be coupled to too many other classes (Single Responsibility Principle)";

        public const string S1206 = "S1206:Equals(Object) and GetHashCode() should be overridden in pairs";
        public const string S121 = "S121:Control structures should use curly braces";

        public const string S1210 =
            "S1210:Equals and the comparison operators should be overridden when implementing IComparable";

        public const string S1215 = "S1215:GC.Collect should not be called";
        public const string S122 = "S122:Statements should be on separate lines";

        public const string S1226 =
            "S1226:Method parameters, caught exceptions and foreach variables' initial values should not be ignored";

        public const string S1227 = "S1227:break statements should not be used except for switch cases";
        public const string S1244 = "S1244:Floating point numbers should not be tested for equality";
        public const string S125 = "S125:Sections of code should not be commented out";
        public const string S126 = "S126:if ... else if constructs should end with else clauses";
        public const string S1264 = "S1264:A while loop should be used instead of a for loop";
        public const string S127 = "S127:for loop stop conditions should be invariant";
        public const string S1301 = "S1301:switch statements should have at least 3 case clauses";
        public const string S1309 = "S1309:Track uses of in-source issue suppressions";
        public const string S131 = "S131:switch/Select statements should contain a default/Case Else clauses";
        public const string S1313 = "S1313:IP addresses should not be hardcoded";

        public const string S134 =
            "S134:Control flow statements if, switch, for, foreach, while, do  and try should not be nested too deeply";

        public const string S138 = "S138:Functions should not have too many lines of code";
        public const string S1449 = "S1449:Culture should be specified for string operations";

        public const string S1450 =
            "S1450:Private fields only used as local variables in methods should become local variables";

        public const string S1451 = "S1451:Track lack of copyright and license headers";
        public const string S1479 = "S1479:switch statements should not have too many case clauses";
        public const string S1481 = "S1481:Unused local variables should be removed";
        public const string S1541 = "S1541:Methods and properties should not be too complex";
        public const string S1607 = "S1607:Tests should not be ignored";
        public const string S1643 = "S1643:Strings should not be concatenated using '+' in a loop";
        public const string S1656 = "S1656:Variables should not be self-assigned";
        public const string S1659 = "S1659:Multiple variables should not be declared on the same line";
        public const string S1694 = "S1694:An abstract class should have both abstract and concrete methods";
        public const string S1696 = "S1696:NullReferenceException should not be caught";

        public const string S1697 =
            "S1697:Short-circuit logic should be used to prevent null pointer dereferences in conditionals";

        public const string S1698 = "S1698:== should not be used when Equals is overridden";
        public const string S1699 = "S1699:Constructors should only call non-overridable methods";
        public const string S1751 = "S1751:Loops with at most one iteration should be refactored";

        public const string S1764 =
            "S1764:Identical expressions should not be used on both sides of a binary operator";

        public const string S1821 = "S1821:switch statements should not be nested";
        public const string S1848 = "S1848:Objects should not be created to be dropped immediately without being used";
        public const string S1854 = "S1854:Dead stores should be removed";
        public const string S1858 = "S1858:ToString() calls should not be redundant";
        public const string S1862 = "S1862:Related if/else if statements should not have the same condition";

        public const string S1871 =
            "S1871:Two branches in a conditional structure should not have exactly the same implementation";

        public const string S1905 = "S1905:Redundant casts should not be used";
        public const string S1939 = "S1939:Inheritance list should not be redundant";
        public const string S1940 = "S1940:Boolean checks should not be inverted";
        public const string S1944 = "S1944:Inappropriate casts should not be made";
        public const string S1994 = "S1994:for loop increment clauses should modify the loops' counters";
        public const string S2068 = "S2068:Credentials should not be hard-coded";
        public const string S2070 = "S2070:SHA-1 and Message-Digest hash algorithms should not be used";
        public const string S2092 = "S2092:Cookies should be secure";
        public const string S2114 = "S2114:Collections should not be passed as arguments to their own methods";
        public const string S2123 = "S2123:Values should not be uselessly incremented";
        public const string S2156 = "S2156:sealed classes should not have protected members";
        public const string S2178 = "S2178:Short-circuit logic should be used in boolean contexts";

        public const string S2183 =
            "S2183:Ints and longs should not be shifted by zero or more than their number of bits-1";

        public const string S2184 =
            "S2184:Results of integer division should not be assigned to floating point variables";

        public const string S2187 = "S2187:TestCases should contain tests";
        public const string S2190 = "S2190:Recursion should not be infinite";
        public const string S2197 = "S2197:Modulus results should not be checked for direct equality";
        public const string S2201 = "S2201:Return values from functions without side effects should not be ignored";
        public const string S2219 = "S2219:Runtime type checking should be simplified";
        public const string S2221 = "S2221:Exception should not be caught when not required by called methods";
        public const string S2223 = "S2223:Non-constant static fields should not be visible";
        public const string S2225 = "S2225:ToString() method should not return null";
        public const string S2228 = "S2228:Console logging should not be used";
        public const string S2234 = "S2234:Parameters should be passed in the correct order";

        public const string S2245 =
            "S2245:Pseudorandom number generators (PRNGs) should not be used in secure contexts";

        public const string S2255 = "S2255:Cookies should not be used to store sensitive information";
        public const string S2259 = "S2259:Null pointers should not be dereferenced";
        public const string S2275 = "S2275:Composite format strings should not lead to unexpected behavior at runtime";
        public const string S2278 = "S2278:Neither DES (Data Encryption Standard) nor DESede (3DES) should be used";
        public const string S2290 = "S2290:Field-like events should not be virtual";
        public const string S2291 = "S2291:Overflow checking should not be disabled for Enumerable.Sum";
        public const string S2292 = "S2292:Trivial properties should be auto-implemented";
        public const string S2302 = "S2302:nameof should be used";
        public const string S2306 = "S2306:async and await should not be used as identifiers";
        public const string S2325 = "S2325:Methods and properties that don't access instance data should be static";
        public const string S2326 = "S2326:Unused type parameters should be removed";
        public const string S2328 = "S2328:GetHashCode should not reference mutable fields";
        public const string S2330 = "S2330:Array covariance should not be used";
        public const string S2333 = "S2333:Redundant modifiers should not be used";
        public const string S2339 = "S2339:Public constant members should not be used";
        public const string S2342 = "S2342:Enumeration types should comply with a naming convention";
        public const string S2344 = "S2344:Enumeration type names should not have Flags or Enum suffixes";
        public const string S2345 = "S2345:Flags enumerations should explicitly initialize all their members";
        public const string S2346 = "S2346:Flags enumerations zero-value members should be named None";
        public const string S2357 = "S2357:Fields should be private";
        public const string S2360 = "S2360:Optional parameters should not be used";
        public const string S2365 = "S2365:Properties should not make collection or array copies";
        public const string S2368 = "S2368:Public methods should not have multidimensional array parameters";
        public const string S2372 = "S2372:Exceptions should not be thrown from property getters";
        public const string S2376 = "S2376:Write-only properties should not be used";
        public const string S2386 = "S2386:Mutable fields should not be public static";
        public const string S2387 = "S2387:Child class fields should not shadow parent class fields";
        public const string S2436 = "S2436:Classes and methods should not have too many generic parameters";
        public const string S2437 = "S2437:Silly bit operations should not be performed";
        public const string S2486 = "S2486:Generic exceptions should not be ignored";
        public const string S2551 = "S2551:Types and this should not be used for locking";
        public const string S2583 = "S2583:Conditionally executed blocks should be reachable";
        public const string S2589 = "S2589:Boolean expressions should not be gratuitous";
        public const string S2674 = "S2674:The length returned from a stream read should be checked";
        public const string S2681 = "S2681:Multiline blocks should be enclosed in curly braces";
        public const string S2688 = "S2688:NaN should not be used in comparisons";
        public const string S2692 = "S2692:IndexOf checks should not be for positive numbers";
        public const string S2696 = "S2696:Instance members should not write to static fields";
        public const string S2699 = "S2699:Tests should include assertions";
        public const string S2701 = "S2701:Literal boolean values should not be used in assertions";
        public const string S2737 = "S2737:catch clauses should do more than rethrow";
        public const string S2743 = "S2743:Static fields should not be used in generic types";
        public const string S2757 = "S2757:=+ should not be used instead of +=";

        public const string S2758 =
            "S2758:The ternary operator should not return the same value regardless of the condition";

        public const string S2760 = "S2760:Sequential tests should not check the same condition";
        public const string S2761 = "S2761:Doubled prefix operators !! and ~~ should not be used";
        public const string S2930 = "S2930:IDisposables should be disposed";

        public const string S2931 =
            "S2931:Classes with IDisposable members or native resources should implement IDisposable";

        public const string S2933 = "S2933:Fields that are only assigned in the constructor should be readonly";

        public const string S2934 =
            "S2934:Property assignments should not be made for readonly fields not constrained to reference types";

        public const string S2952 = "S2952:Classes should Dispose of members from the classes' own Dispose methods";
        public const string S2953 = "S2953:Methods named Dispose should implement IDisposable.Dispose";

        public const string S2955 =
            "S2955:Generic parameters not constrained to reference types should not be compared to null";

        public const string S2971 = "S2971:IEnumerable LINQs should be simplified";
        public const string S2995 = "S2995:Object.ReferenceEquals should not be used for value types";
        public const string S2996 = "S2996:ThreadStatic fields should not be initialized";
        public const string S2997 = "S2997:IDisposables created in a using statement should not be returned";
        public const string S3005 = "S3005:ThreadStatic should not be used on non-static fields";
        public const string S3010 = "S3010:Static fields should not be updated in constructors";
        public const string S3052 = "S3052:Members should not be initialized to default values";
        public const string S3060 = "S3060:is should not be used with this";
        public const string S3168 = "S3168:async methods should not return void";
        public const string S3169 = "S3169:Multiple OrderBy calls should not be used";
        public const string S3172 = "S3172:Delegates should not be subtracted";
        public const string S3215 = "S3215:interface instances should not be cast to concrete types";
        public const string S3216 = "S3216:ConfigureAwait(false) should be used";
        public const string S3217 = "S3217:Explicit conversions of foreach loops should not be used";
        public const string S3218 = "S3218:Inner class members should not shadow outer class static or type members";
        public const string S3220 = "S3220:Method calls should not resolve ambiguously to overloads with params";
        public const string S3234 = "S3234:GC.SuppressFinalize should not be invoked for types without destructors";
        public const string S3235 = "S3235:Redundant parentheses should not be used";
        public const string S3236 = "S3236:Caller information arguments should not be provided explicitly";
        public const string S3237 = "S3237:value parameters should be used";
        public const string S3240 = "S3240:The simplest possible condition syntax should be used";
        public const string S3241 = "S3241:Methods should not return values that are never used";
        public const string S3242 = "S3242:Method parameters should be declared with base types";
        public const string S3244 = "S3244:Anonymous delegates should not be used to unsubscribe from Events";
        public const string S3246 = "S3246:Generic type parameters should be co/contravariant when possible";
        public const string S3247 = "S3247:Duplicate casts should not be made";

        public const string S3249 =
            "S3249:Classes directly extending object should not call base in GetHashCode or Equals";

        public const string S3251 = "S3251:Implementations should be provided for partial methods";
        public const string S3253 = "S3253:Constructor and destructor declarations should not be redundant";
        public const string S3254 = "S3254:Default parameter values should not be passed as arguments";
        public const string S3256 = "S3256:string.IsNullOrEmpty should be used";
        public const string S3257 = "S3257:Declarations and initializations should be as concise as possible";
        public const string S3261 = "S3261:Namespaces should not be empty";
        public const string S3262 = "S3262:params should be used on overrides";
        public const string S3263 = "S3263:Static fields should appear in the order they must be initialized ";
        public const string S3264 = "S3264:Events should be invoked";
        public const string S3265 = "S3265:Non-flags enums should not be used in bitwise operations";
        public const string S3330 = "S3330:HttpOnly should be set on cookies";
        public const string S3343 = "S3343:Caller information parameters should come at the end of the parameter list";
        public const string S3346 = "S3346:Expressions used in Debug.Assert should not produce side effects";
        public const string S3353 = "S3353:Unchanged local variables should be const";
        public const string S3358 = "S3358:Ternary operators should not be nested";
        public const string S3366 = "S3366:this should not be exposed from constructors";

        public const string S3376 =
            "S3376:Attribute, EventArgs, and Exception type names should end with the type being extended";

        public const string S3397 =
            "S3397:base.Equals should not be used to check for reference equality in Equals if base is not object";

        public const string S3400 = "S3400:Methods should not return constants";
        public const string S3415 = "S3415:Assertion arguments should be passed in the correct order";
        public const string S3427 = "S3427:Method overloads with default parameter values should not overlap ";
        public const string S3431 = "S3431:[ExpectedException] should not be used";
        public const string S3433 = "S3433:Test method signatures should be correct";

        public const string S3440 =
            "S3440:Variables should not be checked against the values they're about to be assigned";

        public const string S3441 = "S3441:Redundant property names should be omitted in anonymous classes";
        public const string S3442 = "S3442:abstract classes should not have public constructors";
        public const string S3443 = "S3443:Type should not be examined on System.Type instances";

        public const string S3444 =
            "S3444:Interfaces should not simply inherit from base interfaces with colliding members";

        public const string S3445 = "S3445:Exceptions should not be explicitly rethrown";
        public const string S3447 = "S3447:[Optional] should not be used on ref or out parameters";
        public const string S3449 = "S3449:Right operands of shift operators should be integers";

        public const string S3450 =
            "S3450:Parameters with [DefaultParameterValue] attributes should also be marked [Optional]";

        public const string S3451 = "S3451:[DefaultValue] should not be used when [DefaultParameterValue] is meant";
        public const string S3453 = "S3453:Classes should not have only private constructors";
        public const string S3456 = "S3456:string.ToCharArray() should not be called redundantly";
        public const string S3457 = "S3457:Composite format strings should be used correctly";
        public const string S3458 = "S3458:Empty case clauses that fall through to the default should be omitted";
        public const string S3459 = "S3459:Unassigned members should be removed";
        public const string S3464 = "S3464:Type inheritance should not be recursive";
        public const string S3466 = "S3466:Optional parameters should be passed to base calls";
        public const string S3532 = "S3532:Empty default clauses should be removed";
        public const string S3597 = "S3597:ServiceContract and OperationContract attributes should be used together";
        public const string S3598 = "S3598:One-way OperationContract methods should have void return type";
        public const string S3600 = "S3600:params should not be introduced on overrides";
        public const string S3603 = "S3603:Methods with Pure attribute should return a value ";
        public const string S3604 = "S3604:Member initializer values should not be redundant";
        public const string S3610 = "S3610:Nullable type comparison should not be redundant";
        public const string S3626 = "S3626:Jump statements should not be redundant";
        public const string S3649 = "S3649:SQL queries should not be vulnerable to injection attacks";
        public const string S3655 = "S3655:Empty nullable value should not be accessed";
        public const string S3693 = "S3693:Exception constructors should not throw exceptions";
        public const string S3717 = "S3717:Track use of NotImplementedException";
        public const string S3776 = "S3776:Cognitive Complexity of methods should not be too high";
        public const string S3869 = "S3869:SafeHandle.DangerousGetHandle should not be called";
        public const string S3871 = "S3871:Exception types should be public";
        public const string S3872 = "S3872:Parameter names should not duplicate the names of their methods";
        public const string S3874 = "S3874:out and ref parameters should not be used";
        public const string S3875 = "S3875:operator== should not be overloaded on reference types";
        public const string S3876 = "S3876:Strings or integral types should be used for indexers";
        public const string S3877 = "S3877:Exceptions should not be thrown from unexpected methods";
        public const string S3880 = "S3880:Finalizers should not be empty";
        public const string S3881 = "S3881:IDisposable should be implemented correctly";
        public const string S3884 = "S3884:CoSetProxyBlanket and CoInitializeSecurity should not be used";
        public const string S3885 = "S3885:Assembly.Load should be used";
        public const string S3887 = "S3887:Mutable, non-private fields should not be readonly";
        public const string S3889 = "S3889:Neither Thread.Resume nor Thread.Suspend should be used";
        public const string S3897 = "S3897:Classes that provide Equals(<T>) should implement IEquatable<T>";
        public const string S3898 = "S3898:Value types should implement IEquatable<T>";
        public const string S3900 = "S3900:Arguments of public methods should be validated against null";
        public const string S3902 = "S3902:Assembly.GetExecutingAssembly should not be called";
        public const string S3903 = "S3903:Types should be defined in named namespaces";
        public const string S3904 = "S3904:Assemblies should have version information";
        public const string S3906 = "S3906:Event Handlers should have the correct signature";
        public const string S3908 = "S3908:Generic event handlers should be used";
        public const string S3909 = "S3909:Collections should implement the generic interface";

        public const string S3923 =
            "S3923:All branches in a conditional structure should not have exactly the same implementation";

        public const string S3925 = "S3925:ISerializable should be implemented correctly";
        public const string S3926 = "S3926:Deserialization methods should be provided for OptionalField members";
        public const string S3927 = "S3927:Serialization event handlers should be implemented correctly";

        public const string S3928 =
            "S3928:Parameter names used into ArgumentException constructors should match an existing one ";

        public const string S3956 = "S3956:Generic.List instances should not be part of public APIs";
        public const string S3962 = "S3962:static readonly constants should be const instead";
        public const string S3963 = "S3963:static fields should be initialized inline";
        public const string S3966 = "S3966:Objects should not be disposed more than once";
        public const string S3967 = "S3967:Multidimensional arrays should not be used";
        public const string S3971 = "S3971:GC.SuppressFinalize should not be called";
        public const string S3972 = "S3972:Conditionals should start on new lines";
        public const string S3981 = "S3981:Collection sizes and array length comparisons should make sense";
        public const string S3984 = "S3984:Exception should not be created without being thrown";
        public const string S3990 = "S3990:Assemblies should be marked as CLS compliant";
        public const string S3992 = "S3992:Assemblies should explicitly specify COM visibility";
        public const string S3993 = "S3993:Custom attributes should be marked with System.AttributeUsageAttribute";
        public const string S3994 = "S3994:URI Parameters should not be strings";
        public const string S3995 = "S3995:URI return values should not be strings";
        public const string S3996 = "S3996:URI properties should not be strings";
        public const string S3997 = "S3997:String URI overloads should call System.Uri overloads";
        public const string S3998 = "S3998:Threads should not lock on objects with weak identity";
        public const string S4000 = "S4000:Pointers to unmanaged memory should not be visible";
        public const string S4002 = "S4002:Disposable types should declare finalizers";
        public const string S4004 = "S4004:Collection properties should be readonly";
        public const string S4005 = "S4005:System.Uri arguments should be used instead of strings";
        public const string S4015 = "S4015:Inherited member visibility should not be decreased";
        public const string S4016 = "S4016:Enumeration members should not be named Reserved";
        public const string S4017 = "S4017:Method signatures should not contain nested generic types";
        public const string S4018 = "S4018:Generic methods should provide type parameters";
        public const string S4019 = "S4019:Base class methods should not be hidden";
        public const string S4022 = "S4022:Enumerations should have Int32 storage";
        public const string S4023 = "S4023:Interfaces should not be empty";

        public const string S4025 =
            "S4025:Child class fields should not differ from parent class fields only by capitalization";

        public const string S4026 = "S4026:Assemblies should be marked with NeutralResourcesLanguageAttribute";
        public const string S4027 = "S4027:Exceptions should provide standard constructors";
        public const string S4035 = "S4035:Classes implementing IEquatable<T> should be sealed";
        public const string S4039 = "S4039:Interface methods should be callable by derived types";
        public const string S4040 = "S4040:Strings should be normalized to uppercase";
        public const string S4041 = "S4041:Type names should not match namespaces";
        public const string S4047 = "S4047:Generics should be used when appropriate";
        public const string S4049 = "S4049:Properties should be preferred";
        public const string S4050 = "S4050:Operators should be overloaded consistently";
        public const string S4052 = "S4052:Types should not extend outdated base types";
        public const string S4055 = "S4055:Literals should not be passed as localized parameters";

        public const string S4056 =
            "S4056:Overloads with a CultureInfo or an IFormatProvider parameter should be used";

        public const string S4057 = "S4057:Locales should be set for data types";
        public const string S4058 = "S4058:Overloads with a StringComparison parameter should be used";
        public const string S4059 = "S4059:Property names should not match get methods";
        public const string S4060 = "S4060:Non-abstract attributes should be sealed";
        public const string S4061 = "S4061:params should be used instead of varargs";
        public const string S4069 = "S4069:Operator overloads should have named alternatives";
        public const string S4070 = "S4070:Non-flags enums should not be marked with FlagsAttribute";
        public const string S4142 = "S4142:Duplicate values should not be passed as arguments";
        public const string S4144 = "S4144:Methods should not have identical implementations";
        public const string S4158 = "S4158:Empty collections should not be accessed or iterated";
        public const string S4159 = "S4159:Classes should implement their ExportAttribute interfaces";
        public const string S4200 = "S4200:Native methods should be wrapped";
        public const string S4210 = "S4210:Windows Forms entry points should be marked with STAThread";
        public const string S4211 = "S4211:Members should not have conflicting transparency annotations";
        public const string S4212 = "S4212:Serialization constructors should be secured";
        public const string S4214 = "S4214:P/Invoke methods should not be visible";
        public const string S4220 = "S4220:Events should have proper arguments";
        public const string S4225 = "S4225:Extension methods should not extend object";
        public const string S4226 = "S4226:Extensions should be in separate namespaces";
        public const string S4260 = "S4260:ConstructorArgument parameters should exist in constructors";
        public const string S4261 = "S4261:Methods should be named according to their synchronicities";
        public const string S4277 = "S4277:Shared parts should not be created with new";
        public const string S4426 = "S4426:Cryptographic keys should not be too short";
        public const string S4428 = "S4428:PartCreationPolicyAttribute should be used with ExportAttribute";
        public const string S4432 = "S4432:AES encryption algorithm should be used with secured mode";
        public const string S4433 = "S4433:LDAP connections should be authenticated";
        public const string S4456 = "S4456:Parameter validation in yielding methods should be wrapped";
        public const string S4457 = "S4457:Parameter validation in async/await methods should be wrapped";
        public const string S4462 = "S4462:Calls to async methods should not be blocking";
        public const string S4524 = "S4524:default clauses should be first or last";
        public const string S4564 = "S4564:ASP.NET HTTP request validation feature should not be disabled";
        public const string S4581 = "S4581:new Guid() should not be used";
        public const string S4586 = "S4586:Non-async Task/Task<T> methods should not return null";
        public const string S818 = "S818:Literal suffixes should be upper case";

        public const string S881 =
            "S881:Increment (++) and decrement (--) operators should not be used in a method call or mixed with other "
            + "operators in an expression";

        public const string S907 = "S907:goto statement should not be used";
        public const string S927 = "S927:parameter names should match base declaration and other partial definitions";
    }
}
