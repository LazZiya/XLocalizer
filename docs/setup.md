# XLocalizer Setup

Install main package from nuget:
````
PM > Install-Package XLocalizer
````

Because XLocalizer supports multiple source types, you can use any of the below setups:

- [Common localization settings](#common-localization-settings)
- [Localization setup based on XML](setup-xml.md)
- [Localization setup based on DB](setup-db.md)
- [Localization setup based on RESX](setup-resx.md)

#### Common localization settings
This is the common configuration for all localization setup types. After finishing this step you can choose the setup mode to use.

````csharp
// Add namespace for optional routing setup
using XLocalizer.Routing;

// Configure request localization options
services.Configure<RequestLocalizationOptions>(ops => 
{
    // Define supported cultures
    var cultures = new CultureInfo[] { new CultureInfo("en"), new CultureInfo("tr"), new CultureInfo("ar") };
    ops.SupportedCultures = cultures;
    ops.SupportedUICultures = cultures;
    ops.DefaultRequestCulture = new RequestCulture("en");

    // Optional: add custom provider to support localization based on {culture} route value
    ops.RequestCultureProviders.Insert(0, new RouteSegmentRequestCultureProvider(cultures));
});        
````

To support route value based localization we need to configure `{culture}` route in every page for razor pages or MVC. So we can have all our routes setup with the culture parameter defined as: *`/{culture}/Index`*

> These optional steps required only for enabling localization based on route value

**- Razor Pages**
````csharp
services.AddRazorPages()
        .AddRazorPagesOptions(ops => { ops.Conventions.Insert(0, new RouteTemplateModelConventionRazorPages()); });
````

**- MVC**
````csharp
services.AddMvc()
        .AddMvcOptions(ops => { ops.Conventions.Insert(0, new RouteTemplateModelConventionMvc()); });
````