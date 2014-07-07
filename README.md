[![Build status](https://ci.appveyor.com/api/projects/status/xva7kjm1lyi3fqcu)](https://ci.appveyor.com/project/RaYell/selenium-helpers)

### Description

Extensions for Selenium WebDriver including jQuery selector support for FindElement and FindElements methods.

### Installation

Run the following command in Visual Studio's Packet Manager Console.
```
Install-Package Selenium.WebDriver.Extensions
```

### Usage

Include extensions namespace and set the derived `By` to be used.
```
using Selenium.WebDriver.Extensions;
using By = Selenium.WebDriver.Extensions.By;
```

Invoke jQuery selectors on the WebDriver.
```
Driver.FindElements(By.JQuerySelector("input:visible"))
```
