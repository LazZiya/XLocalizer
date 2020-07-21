### XLocalizer Installation
XLocalizer nuget pacakge offers localization based on _.resx_ and _xml_.

Install main package from nuget:
````
PM > Install-Package XLocalizer
````

### Install Database Support Package (optional)
Localization based on _DB_ support requires additional package named `XLocalizer.DB`.
````
PM > Install-Package XLocalizer.DB
````

### Install Translation Services (optional)
In order to enable online translation, install [LazZiya.TranslationServices][1] and one or more translation service as described below.

This package contains a common interface to communicate with online translation services:
````
PM > Install-Package LazZiya.TranslationServices
````

Additionally install one or more translation services:
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


[1]:https://github.com/LazZiya/TranslationServices
[2]:https://github.com/LazZiya/TranslationServices/blob/master/LazZiya.TranslationServices/ITranslationService.cs
