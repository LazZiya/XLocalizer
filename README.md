## XLocalizer for Asp.Net Core 
Say bye-bye to manually creating localization resources...! 

**- Online Translation :** Auto translation of missed localized values.

**- Auto Key Adding :** Auto adding missing keys to the resources files.

**- Multiple Resource Type Support :** Built-in localization support based on _.RESX_, _.XML_, _DB_. Extendable localization support based on any custom file/db type.

**- Export to Resx :** Resources from any source type can be exported to _.RESX_ files via built-in exporters.

**- Do it Fast :** Custom cache support for speeding up the process of getting localized values from sources.

**- Standard interfaces :** Easy to use due to using the standard localization interfaces: `IStringLocalizer`, `IHtmlLocalizer`, `IStringLocalizerFactory` and `IHtmlLocalizerFactory`.

### Setup
Install from nuget :
````
Install-Package XLocalizer
````

Add localization settings in `startup.cs`:
````cs
using XLocalizer;
using XLocalizer.Xml;
using XLocalizer.Routing;
using XLocalizer.Translate;
using XLocalizer.Translate.GoogleTranslate;

public void ConfigureServices(IServiceCollection services)
{
    // Register a translation service
    services.AddHttpClient<ITranslator, GoogleTranslateService>();
    
    // Define supported cultures
    var cultures = new CultureInfo[]
    {
        new CultureInfo("en"),
        new CultureInfo("tr"),
        new CultureInfo("ar")
    };
    
    // Configure request localization options
    services.Configure<RequestLocalizationOptions>(ops =>
    {
        ops.SupportedCultures = cultures;
        ops.SupportedUICultures = cultures;
        ops.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
        ops.RequestCultureProviders.Insert(0, new RouteSegmentRequestCultureProvider(cultures));
    });
    
    // Register the built-in Xml resource provider
    services.AddSingleton<IXResourceProvider, XmlResourceProvider>();   

    // Add XLocalizer
    services.AddRazorPages()
            .AddRazorPagesOptions(ops => { ops.Conventions?.Insert(0, new RouteTemplateModelConventionRazorPages()); })
            .AddXLocalizer<LocSource, GoogleTranslateService>((x) =>
            {
                x.ResourcesPath = "LocalizationResources";
                x.AutoTranslate = true;
                x.AutoAddKeys = true;
            });
}
````

Then configure the app to use `RequestLocalization` middleware :
````cs
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // Other codes...
    
    // Add localization middleware to the app
    app.UseRequestLocalization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapRazorPages();
    });
}
````

### For more details goto [docs website](http://docs.ziyad.info/XLocalizer)

### Step by step tutorial 
 * coming soon...

### Sample projects
 * [XML based localization sample](https://github.com/LazZiya/XLocalizer.Samples/tree/master/XmlLocalizationSample)

### License
MIT

[1]:https://github.com/LazZiya/TranslationServices
