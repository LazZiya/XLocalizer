## XLocalizer for Asp.Net Core 
Say bye-bye to manually creating localization resources...! 

- Online Translation: Auto translation of missed localized values.
- Auto Key Adding: Auto adding missing keys to the resources files.
- Multiple Resource Type Support: Built-in localization support based on _.RESX_, _.XML_, _DB_. Extendable localization support based on any custom file/db type.
- Export to Resx: Resources from any source type can be exported to _.RESX_ files via built-in exporters.
- Do it Fast: Custom cache support for speeding up the process of getting localized values from sources.
- Standard interfaces: Easy to use due to using the standard localization interfaces: `IStringLocalizer`, `IHtmlLocalizer`, `IStringLocalizerFactory` and `IHtmlLocalizerFactory`.

## How it works:

![XLocalizer Simplified Workflow](https://github.com/LazZiya/Docs/raw/master/XLocalizer/v1.0/images/xlocalizer-flowchart-sample.jpg)

### Setup
Install latest preview from nuget :
````
Install-Package XLocalizer
````

Add localization settings in `startup.cs`:
````cs

// Add XLocalizer
services.AddRazorPages()
    .AddXLocalizer<LocSource, GoogleTranslateService>(ops =>
    {
        ops.ResourcesPath = "LocalizationResources";
        ops.AutoTranslate = true;
        ops.AutoAddKeys = true;
        ops.TranslateFromCulture = "en";
    });
````

### For more details goto [DOCS.Ziyad.info](https://docs.ziyad.info)

### Step by step tutorial 
 * [XLocalizer for Asp Net Core](http://ziyad.info/en/articles/1040-XLocalizer_for_Asp_Net_Core)

### Sample projects
 * [XML based localization sample](https://github.com/LazZiya/XLocalizer.Samples/tree/master/XmlLocalizationSample)
 * [DB based localization sample](https://github.com/LazZiya/XLocalizer.Samples/tree/master/DbLocalizationSample)
 * [Blazor localization sample](https://github.com/LazZiya/XLocalizer.Samples/tree/master/BlazorLocalizationSample)

### License
MIT

[1]:https://github.com/LazZiya/XLocalizer.Translate
