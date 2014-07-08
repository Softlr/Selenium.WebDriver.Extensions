[![Build status](https://ci.appveyor.com/api/projects/status/xva7kjm1lyi3fqcu)](https://ci.appveyor.com/project/RaYell/selenium-helpers)

### Description

Extensions for Selenium WebDriver including jQuery selector support for `FindElement` and `FindElements` methods.

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
driver.FindElements(By.JQuerySelector("input:visible"))
```

### Known Issues
 
Only the basic traversing methods are implemented. This means that only string selectors will work. Also methods like `.map()` or `.each()` are not implemented. You also cannot use JavaScript functions which can be accepted as parameters to some of the methods. And finally you cannot pass an additional parameter as a context (all selectors will be executed in global context).
