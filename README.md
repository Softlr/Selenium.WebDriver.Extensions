[![Build status](https://ci.appveyor.com/api/projects/status/xva7kjm1lyi3fqcu)](https://ci.appveyor.com/project/RaYell/selenium-helpers)
[![Build Status](https://travis-ci.org/RaYell/selenium-webdriver-extensions.svg)](https://travis-ci.org/RaYell/selenium-webdriver-extensions)
[![Coverage Status](https://coveralls.io/repos/RaYell/selenium-webdriver-extensions/badge.svg?branch=master)](https://coveralls.io/r/RaYell/selenium-webdriver-extensions?branch=master)

# Description
Extensions for Selenium WebDriver.

# Version 2.0
The work on the second major version of this extensions library has started. Some of the features that are planned in this version are:
* completely rework the selectors to inherit from standard Selenium `By` class
* support for page objects
* support for `ExpectedConditions`
* removal of some of the hacks the extensions library performs in favor of actual solutions for the problems

No release date for version 2.0 has been set yet. More details can be found [here](https://github.com/RaYell/selenium-webdriver-extensions/wiki/V2).

# Features
* Main
 * Support for nested selectors
 * Very easy setup: install packages with NuGet, include a namespace and start using it with your existing Selenium solution
 * High quality ensured by continuous integration setup with Appveyor, unit and integration testing and high code coverage
 * Well documented code following strict StyleCop and FxCop rules
* jQuery support
 * jQuery selectors support for Selenium WebDriver to perform DOM-element selections that CSS can't do
 * jQuery auto-load on pages on sites that don't use jQuery
 * Support for jQuery context switching
 * Support for jQuery traversing methods for generation of complex selector chains
 * Support for jQuery setter and event triggering methods
* Sizzle support
 * Sizzle selectors support for Selenium WebDriver to perform DOM-element selections that CSS can't do
 * Sizzle auto-load on pages on sites that don't use Sizzle
 * Support for Sizzle context switching

# Installation
Run the following command in Visual Studio Package Manager Console.
```posh
Install-Package Selenium.WebDriver.Extensions
```

This will install the full package containing jQuery, Sizzle and core selectors support. If you want to use only specific extensions you can do this by installing a specific package in Package Manager Console.

```posh
Install-Package Selenium.WebDriver.Extensions.JQuery
Install-Package Selenium.WebDriver.Extensions.Sizzle
Install-Package Selenium.WebDriver.Extensions.Core
```

# Documentation
API documentation can be found [here](https://rayell.github.io/selenium-webdriver-extensions/api) and user guide is on the [wiki](https://github.com/RaYell/selenium-webdriver-extensions/wiki).

# Usage

#### Include extensions
Include extensions namespace and set the derived `By` to be used.
```csharp
using Selenium.WebDriver.Extensions;
using By = Selenium.WebDriver.Extensions.By;
```

If you have installed support for just some of the extensions you need to adjust the namespace of the `By` type accordingly.

```csharp
using Selenium.WebDriver.Extensions.JQuery;
using By = Selenium.WebDriver.Extensions.JQuery.By;
```

#### Basic jQuery example
Invoke jQuery selectors on the WebDriver.
```csharp
driver.FindElements(By.JQuerySelector("input:visible"))
```

#### Chaining jQuery methods
You can also chain jQuery traversing methods.
```csharp
var selector = By.JQuerySelector("div.myclass").Parents(".someClass").NextAll();
driver.FindElement(selector);
```

#### jQuery loading
If the site that you are testing with Selenium does not include jQuery this extension will automatically load the latest version when you run any of the `Find*` methods. If you want you can choose to load a different version of jQuery. The library uses jQuery CDN by default, but if you want to use a completely different source, that's also supported

```csharp
driver.JQuery().Load("1.11.0"); // load specific version from default CDN
driver.JQuery().Load(new Uri("http://some.server/jquery.js")); // load a library from other source
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

#### jQuery helper methods
You can have instant access to values of the getter jQuery methods.

```csharp
var value = driver.JQuery("input").Value();
```

You can also set the values and trigger events using the API.
```csharp
driver.JQuery("input").Value("new value");
driver.JQuery("button:submit").Click();
```

#### Basic Sizzle example
Invoke Sizzle selectors on the WebDriver.
```csharp
driver.FindElements(By.SizzleSelector("input:visible"))
```

#### Sizzle loading
If the site that you are testing with Selenium does not include Sizzle this extension will automatically load the 2.0.0 version when you run any of the `Find*` methods. If you want you can choose to load a different version of Sizzle. The library used CloudFlare CDN by default, but if you want to use a completely different source, that's also supported

```csharp
driver.Sizzle().Load("1.11.1"); // load specific version from default CDN
driver.Sizzle().Load(new Uri("http://some.server/sizzle.js")); // load a library from other source
```

#### Sizzle context switch
You can use one `SizzleSelector` instance as a context of another `SizzleSelector`. Contrary to jQuery equivalent of this method, only first element from the context is used. This is because it's a limitation of Sizzle.

```csharp
var context = By.SizzleSelector("div.myClass");
var selector = By.SizzleSelector("ol li", context);
driver.FindElements(selector);
```
