By default, XLocalizer will work with _.xml_ resource files just like _.resx_ files, with some minor changes in the setup.

All localization steps are almost the same as in [standard setup][1], I will just mention the changes here.

### 1- Startup settings
Goto startup and configure localization settings
````cs
using XLocalizer.Xml;

public class startup 
{
    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        // other code omitted for simplification...
        // ...
        
        // register `XmlResourceProvider` so XLocalizer will be based on Xml files
        services.AddSingleton<IXResourceProvider, XmlResourceProvider>();
        
        // ...        
        }
    }
}
````

### 2- Create resource files
All resource files will be created automatically by `XLocalizer`.


> NOTICE: Xml may not be the best option for localization due to multi-thread issues, but for single developers and small teams it can be useful when `AutoAddKeys` and `AutoTranslate` options are enabled. At the end of the development process, all the resources data can be exported to _resx_ files, and by ommitting the `XmlResourceProvider` registration all the setup will work with _resx_ files as expected.

[1]:standard-setup.md
