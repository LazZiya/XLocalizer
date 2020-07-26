### XLocalizer.Translate.SystranTranslate
This nuget is based on the free plan of [Systran Translate via RapidAPI](https://rapidapi.com/systran/api/systran-io-translation-and-nlp).

> See [GitHub repo](https://github.com/LazZiya/XLocalizer.Translate.SystranTranslate)

**Install**
````
PM > Install-Package XLocalizer.Translate.SystranTranslate
````

**Add RapidAPI key to user secrets**
> Right click on the project name and select _Manage User Secrets_, then add the API key as below:

````json
{
  "XLocalizer.Translate": {
    "RapidApiKey": "xxx-rapid-api-key-xxx",
  }
}
````

**Register in startup**
````csharp
using XLocalizer.Translate
using XLocalizer.Translate.YandexTranslate

services.AddHttpClient<ITranslator, SystranTranslateService>();
````

**Use with XLocalizer**
````csharp
// Configure XLocalizer to use the translation service 
// and enable online translation
services.AddRazorPages()
        .AddXLocalizer<LocSource, SystranTranslateService>(ops =>
        {
            // ...
            ops.AutoTranslate = true;
        });
````