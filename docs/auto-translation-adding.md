The time and effort saver two features are **Online translation** and **AUto adding missed keys**.

## Installation
Before we enable online translation, we need to install additional nugets:

[LazZiya.TranslationServices][1], This nuget contains the interfaces for communivcating with online translation services.

````
PM > Install-Package LazZiya.TranslationServices
````

And one or more translation service:
````
PM > Install-Package LazZiya.TranslationServices.{service-name}
````

Currently available services are:
- [GoogleTranslate](https://github.com/LazZiya/TranslationServices/blob/master/LazZiya.TranslationServices.GoogleTranslate/)
- [YandexTranslate](https://github.com/LazZiya/TranslationServices/blob/master/LazZiya.TranslationServices.YandexTranslate/)
- [MyMemoryTranslate](https://github.com/LazZiya/TranslationServices/blob/master/LazZiya.TranslationServices.MyMemoryTranslate/)
- [SystranTranslate](https://github.com/LazZiya/TranslationServices/blob/master/LazZiya.TranslationServices.SystranTranslate/)
- [IBMWatsonTranslate](https://github.com/LazZiya/TranslationServices/blob/master/LazZiya.TranslationServices.IBMWatsonTranslate/)

Or you can create your own translation service that implements [`ITranslationService`][2] interface.

## Startup settings
Few changes to the startup must be made to configure online translation services:
#### - Register one or more translation service:
````cs
services.AddSingleton<ITranslationService, IBMWatsonTranslateService>();
services.AddHttpClient<ITranslationService, MyMemoryTranslateService>();
services.AddHttpClient<ITranslationService, SystranTranslateService>();
services.AddHttpClient<ITranslationService, YandexTranslateService>();
services.AddHttpClient<ITranslationService, GoogleTranslateService>();
````

#### - Configure `XLocalizer` setup to use one translation service
XML Based localization setup:
````cs
services.AddSingleton<IXResourceProvider, XmlResourceProvider>();

services.AddRazorPages()
    .AddXLocalizer<LocSource, MyMemoryTranslateService>((x) =>
    {
        x.ResourcesPath = "LocalizationResources";
        x.AutoTranslate = true;
        x.AutoAddKeys = true;
    });
```` 

DB Based localization setup:
````cs
services.AddRazorPages()
    .AddXDbLocalizer<ApplciationDbContext, MyMemoryTranslateService>((x) =>
    {
        x.ResourcesPath = "LocalizationResources";
        x.AutoTranslate = true;
        x.AutoAddKeys = true;
    });
```` 

> NOTICE: Auto key adding and online translation works with XML and DB based localization setup. RESX localization setup can do online translation but can't save to resource. Instead, export the data from DB or XML to RESX.

[1]:https://github.com/LazZiya/TranslationServices
[2]:https://github.com/LazZiya/TranslationServices/blob/master/LazZiya.TranslationServices/ITranslationService.cs
