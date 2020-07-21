## XLocalizer for Asp.Net Core 
Save ~99% of localization development time by:

#### - Online Translation
Any missed locailzed value can  be translated automatically by turning on `AutoTranslate` option (requires [LazZiya.TranslationServices][1] nuget).

#### - Auto Key Adding
Autoamtically create resource files and insert missed key with their translations to the target resource file by turning on `AutoAddKeys` option. All texts in views, data annotations, model binding error, identity errors and any custom backend messages will be insterted to the resource file automatically.

#### - Multiple Resource Type Support
XLocalizer has built in support for localizing via _.RESX_ files and _.XML_ files. Additionally it can use any custom file type for storing localized values by implementing `IXResourceProvider` interface, so you can develop your custom resource provider to use any file type (e.g. json, csv, ...etc).

#### - Database Support
In addition to storing localized values in files, XLocalizer supports database localization as well. Simply use the built-in database localization provider or extend the `IDbResourceProvider` interface to use your custom database localization provider (requires [XLocalizer.DB][2] nuget).

#### - Export to Resx
Wether you have used _XML_, _DB_ or any other custom localization provider, all localized values can be exported to _.RESX_ using the built-in resource exporters or any custom exporter that implements `IXResourceExporter` for file based localization or `IDbResourceExporter` for DB based localization.

#### - Do it Fast
Custom cache support for speeding up the process of getting localized values from localization stores. Cache support can be turned on/off so during development mode you can turn it off to temporarily avoid caching localized keys.

#### - All With Standard Localization Interfaces
All above features developed with the standard localizing interfaces in the center. So, you will keep using `IStringLocalizer`, `IHtmlLocalizer`, `IStringLocalizerFactory` and `IHtmlLocalizerFactory` as usual localization interfaces in the application. This makes it so easy and effortless to switch from the default localization system to XLocalizer or vice versa without the need to change any code except localization setup in the startup.
