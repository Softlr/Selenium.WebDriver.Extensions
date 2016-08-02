[![Build status](https://ci.appveyor.com/api/projects/status/xva7kjm1lyi3fqcu)](https://ci.appveyor.com/project/RaYell/selenium-helpers)
[![Build Status](https://travis-ci.org/RaYell/selenium-webdriver-extensions.svg)](https://travis-ci.org/RaYell/selenium-webdriver-extensions)
[![Coverage Status](https://coveralls.io/repos/RaYell/selenium-webdriver-extensions/badge.svg?branch=master)](https://coveralls.io/r/RaYell/selenium-webdriver-extensions?branch=master)
[![codecov](https://codecov.io/gh/RaYell/selenium-webdriver-extensions/branch/develop/graph/badge.svg)](https://codecov.io/gh/RaYell/selenium-webdriver-extensions)

# Description
Extensions for Selenium WebDriver including jQuery/Sizzle selector support.

# Version 2.0 Released
The version 2.0 of the extensions library has been released. The new features of it include:
* Selectors inheriting from `OpenQA.Selenium.By` class. V1 of the application used the trick to run the custom selectors (extension methods, object wrappers etc.) and in the end it was quite difficult to tell which part it handled by the extensions and which by Selenium core. V2 includes completely rewritten JQuery and Sizzle selectors that inherit from `By` class to avoid those kind of tricks.
* Removal of redundant core selectors. V1 contains implementation of core Selenium selectors using custom QuerySelector class. The purpose of this class is to wrap the results in custom WebElement class for them to be reused while determining the context of the subsequent call. With the implementation of `By` class, they are no longer be needed and has been removed from the library.
* Removal of query selector. As described above, `QuerySelector` class is no longer necessary and has been removed in V2.
* Single NuGet package. There is only one NuGet package containing all of the extenions instead of four separate packages that V1 included. The extensions library is small enough for all of the important code to be merged into one package.
* Support for JQuery getters and setters was dropped. V1 included a mechanism to run JQuery getters and setters as most of the calls used JQueryHelper class as an mediator between Selenium core and extensions library. With the new architecture there is no place for the JQueryHelper anymore and the support for those methods was dropped. The only jQuery methods supported are now [traversing methods](https://api.jquery.com/category/traversing/).
* Semantic versioning. V2 utilizes SemVer from the first release rather than V1's {major}.{minor}.{build} schema.
* Support for `ExpectedConditions`. By implementing the `By` class, V2 of the extensions library comes with the support for `ExpectedConditions`.
* Support for page objects. By implementing the By class, V2 of the exntesions library comes with the support for [Selenium Page Objects](https://code.google.com/p/selenium/wiki/PageObjects).
* Changes to the static `By` implementations. There still is a `By` class provided with static methods for creating all sorts of selectors, however it is now simply be a wrapper on a base class that will also provide methods for the new selectors.
* Namespace change. The namespace of the extensions library is going to be changed from Selenium.WebDriver.Extensions to OpenQA.Selenium which makes integration with Selenium even easier.

# Features
* Main
 * Support for nested selectors
 * Very easy setup: install packages with NuGet and start using it with your existing Selenium solution
 * High quality ensured by continuous integration setup with Appveyor, unit and integration testing and high code coverage
 * Well documented code following strict StyleCop and FxCop rules
* jQuery support
 * jQuery selectors support for Selenium WebDriver to perform DOM-element selections that CSS can't do
 * jQuery auto-load on pages on sites that don't use jQuery
 * Support for jQuery context switching
 * Support for `ExpectedConditions` with jQuery selectors
 * Support for Page Objects with jQuery selectors
* Sizzle support
 * Sizzle selectors support for Selenium WebDriver to perform DOM-element selections that CSS can't do
 * Sizzle auto-load on pages on sites that don't use Sizzle
 * Support for Sizzle context switching
 * Support for `ExpectedConditions` with Sizzle selectors
 * Support for Page Objects with Sizzle selectors

# Installation
Run the following command in Visual Studio Package Manager Console.
```posh
Install-Package Selenium.WebDriver.Extensions
```

# Documentation
API documentation can be found [here](https://rayell.github.io/selenium-webdriver-extensions/api) and user guide is on the [wiki](https://github.com/RaYell/selenium-webdriver-extensions/wiki).

# Usage

#### Include extensions
Create alias for the extension `By` to be used.
```csharp
using By = OpenQA.Selenium.Extensions.By;
```

If you don't want to override the `By` to be used, you can always create `JQuerySelector` and `SizzleSelector` instances with `new` keyword.

#### Basic jQuery example
Invoke jQuery selectors on the WebDriver.
```csharp
driver.FindElements(By.JQuerySelector("input:visible"))
```

#### jQuery Traversing methods
You can also chain jQuery traversing methods.
```csharp
var selector = By.JQuerySelector("div.myclass").Parents(".someClass").NextAll();
driver.FindElement(selector);
```

#### jQuery loading
If the site that you are testing with Selenium does not include jQuery this extension will automatically load the latest version when you run any of the `Find*` methods. If you want you can choose to load a different version of jQuery. The library uses jQuery CDN by default, but if you want to use a completely different source, that's also supported

```csharp
driver.LoadJQuery("1.11.0"); // load specific version from default CDN
driver.LoadJQuery(new Uri("http://some.server/jquery.js")); // load a library from other source
```

#### jQuery variable name
When you create a jQuery selector using `By` helper class the resulting selector will use `jQuery` as library variable name. If you site is using a different variable name for this purpose you can pass this value as an optional parameter.

```csharp
var selector = By.JQuerySelector("div", jQueryVariable: "myJQuery");
```

#### jQuery context switch
You can use one `JQuerySelector` instance as a context of another `JQuerySelector`.

```csharp
var context = By.JQuerySelector("div.myClass");
var selector = By.JQuerySelector("ol li", context);
driver.FindElements(selector);
```

#### Basic Sizzle example
Invoke Sizzle selectors on the WebDriver.
```csharp
driver.FindElements(By.SizzleSelector("input:visible"))
```

#### Sizzle loading
If the site that you are testing with Selenium does not include Sizzle this extension will automatically load the 2.0.0 version when you run any of the `Find*` methods. If you want you can choose to load a different version of Sizzle. The library used CloudFlare CDN by default, but if you want to use a completely different source, that's also supported

```csharp
driver.LoadSizzle("1.11.1"); // load specific version from default CDN
driver.LoadSizzle(new Uri("http://some.server/sizzle.js")); // load a library from other source
```

#### Sizzle context switch
You can use one `SizzleSelector` instance as a context of another `SizzleSelector`. Contrary to jQuery equivalent of this method, only first element from the context is used. This is because it's a limitation of Sizzle.

```csharp
var context = By.SizzleSelector("div.myClass");
var selector = By.SizzleSelector("ol li", context);
driver.FindElements(selector);
```
