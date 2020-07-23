# XLocalizer for Asp.Net Core
Fastest localization process for Asp.Net Core web applications, powered by online translation and auto resource creating.

## What is XLocalizer 
A nuget package that offers localization based on _.resx_, _.xml_, _db_ or any other custom _file/db_ type. XLocalizer has many powerful features and can be extended with custom tools.

#### Install & setup
Easy setup and customizable services, See [Quick start](setup-quick-start.md) & [Detailed setup](setup.md) for more details.
````csharp
services.AddRazorPages()
        .AddXLocalizer<LocSource>(ops => 
        {
            ops.AutoTranslate = true;
            ops.AutoAddKeys = true;
        });
````

#### Online translation
Translate missing resource values using the already [available online translation services](translate-services.md) or using custom service that implements [`ITranslator`](https://github.com/LazZiya/XLocalizer.Translate/blob/master/XLocalizer.Translate/ITranslator.cs) interface.

#### Auto key adding
Add missing resources to the source file/db by enabling `AutoAddKeys` option. 

#### Multiple resource type support
Built-in support for localizing via _.RESX_ and _.XML_ file types. Additionally it can use any custom file type for storing localized values by implementing [`IXResourceProvider`](https://github.com/LazZiya/XLocalizer/blob/master/XLocalizer/IXResourceProvider.cs) interface, This allows to create custom resource providers (e.g. json, csv, ...etc).

#### Database support
Localization via database using [XLocalizer.DB](setup-db.md). 

#### Export to resx
Either you have used _XML_, _DB_ or any other custom localization provider, all resources can be exported to _.RESX_ easily, see [Export](export.md).

#### Do it fast
Custom cache support for speeding up the process of getting localized values from localization stores. Cache support can be turned on/off so during development mode you can turn it off to temporarily avoid caching values that are subject to change.

#### Customization
Support to use custom resource providers, data exporters or online translation services.

#### Flexibility
All above features developed with the standard localizing interfaces in the center. So, you will keep using `IStringLocalizer`, `IHtmlLocalizer`, `IStringLocalizerFactory` and `IHtmlLocalizerFactory` as usual localization interfaces in the application. This makes it so flexible to switch from the default localization system to XLocalizer or vice versa without the need to change any code except localization setup in the startup.
