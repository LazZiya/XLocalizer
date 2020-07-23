### XLocalizer.Translate.MyMemoryTranslate
This nuget is based on the free plan of [MyMemory Translate via RapidAPI](https://rapidapi.com/translated/api/mymemory-translation-memory).

> See [GitHub repo](https://github.com/LazZiya/XLocalizer.Translate.MyMemoryTranslate)

**Install**
````
PM > Install-Package XLocalizer.Translate.MyMemoryTranslate
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
using XLocalizer.Translate.MyMemoryTranslate

services.AddHttpClient<ITranslator, MyMemoryTranslateService>();
````

**Use with XLocalizer**
````csharp
// Configure XLocalizer to use the translation service 
// and enable online translation
services.AddRazorPages()
        .AddXLocalizer<LocSource, MymemoryTranslateService>(ops =>
        {
            // ...
            ops.AutoTranslate = true;
        });
````