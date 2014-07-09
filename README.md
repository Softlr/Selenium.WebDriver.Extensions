[![Build status](https://ci.appveyor.com/api/projects/status/xva7kjm1lyi3fqcu)](https://ci.appveyor.com/project/RaYell/selenium-helpers)

### Description

Extensions for Selenium WebDriver including jQuery selector support for `FindElement` and `FindElements` methods.

### Installation

Run the following command in Visual Studio Packet Manager Console.
```posh
Install-Package Selenium.WebDriver.Extensions
```

### Usage

#### Include extensions
Include extensions namespace and set the derived `By` to be used.
```csharp
using Selenium.WebDriver.Extensions;
using By = Selenium.WebDriver.Extensions.By;
```

#### Basic example
Invoke jQuery selectors on the WebDriver.
```csharp
var driver = new ChromeDriver();
driver.FindElements(By.JQuerySelector("input:visible"))
```

#### Chaining
You can also chain jQuery traversing methods.
```csharp
var driver = new ChromeDriver();
var selector = By.JQuerySelector("div.myclass").Parents(".someClass").NextAll();
driver.FindElement(selector);
```

#### jQuery loading
If the site that you are testing with Selenium does not include jQuery this extension will automatically load the latest version when you run FindElement or FindElements method. If you want you can choose to load a different version of jQuery.

```csharp
var driver = new ChromeDriver();
driver.LoadJQuery("1.11.0");
```

#### jQuery variable name
When you create a jQuery selector using By helper class the resulting selector will use jQuery as library variable. If you site is using a different variable name for this purpose you can also customize this behavior.

```csharp
var driver = new ChromeDriver();
var selector = By.JQuerySelector("div", jQueryVariable: "myJQuery");
```

### jQuery context switch
Last but not least, you can use one JQuerySelector as a context in another JQuerySelector.

```csharp
var driver = new ChromeDriver();
var context = By.JQuerySelector("div.myClass");
var selector = By.JQuerySelector("ol li", context);
driver.FindElements(selector);
```

### Known Issues
 
Only the basic traversing methods are implemented. This means that only string selectors will work. Also methods like `.map()` or `.each()` are not implemented. You also cannot use JavaScript functions which can be accepted as parameters to some of the methods. And finally you cannot pass an additional parameter as a context (all selectors will be executed in global context).
