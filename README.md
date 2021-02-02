# This project is no longer maintained!

[![Build Status](https://ci.appveyor.com/api/projects/status/xva7kjm1lyi3fqcu?svg=true)](https://ci.appveyor.com/project/RaYell/Selenium.WebDriver.Extensions)
[![Build Status](https://travis-ci.org/Softlr/Selenium.WebDriver.Extensions.svg?branch=develop)](https://travis-ci.org/Softlr/Selenium.WebDriver.Extensions)
[![Code Coverage](https://codecov.io/gh/Softlr/Selenium.WebDriver.Extensions/branch/develop/graph/badge.svg)](https://codecov.io/gh/Softlr/Selenium.WebDriver.Extensions)
[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=selenium.webdriver.extensions&metric=alert_status)](https://sonarcloud.io/dashboard?id=selenium.webdriver.extensions)

# Description
Extensions for Selenium WebDriver including jQuery/Sizzle selector support.

# Features
## Main
* Support for nested selectors
* Easy setup: install NuGet package and start using it with your existing Selenium solution
* High quality ensured by continuous integration setup with Appveyor, unit and integration tests and high code coverage
* Well documented code using [GitBook](https://legacy.gitbook.com/book/softlr/selenium-webdriver-extensions/details)
## jQuery/Sizzle support
* jQuery/Sizzle selectors support for Selenium WebDriver
* jQuery/Sizzle auto-load on pages on sites that don't use jQuery
* Support for context switching
* Support for `ExpectedConditions`
* Support for Page Objects
 
# Installation
Run the following command in Visual Studio Package Manager Console.
```posh
Install-Package Selenium.WebDriver.Extensions
```

# Documentation
API documentation can be found on [GitBook](https://legacy.gitbook.com/book/softlr/selenium-webdriver-extensions/details) and user guide is on the [wiki](https://github.com/Softlr/Selenium.WebDriver.Extensions/wiki).

# Usage

#### Include extensions
Create alias for the extension `By` to be used.
```csharp
using By = Selenium.WebDriver.Extensions.By;
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
