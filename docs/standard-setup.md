By default, XLocalizer will work with _.resx_ resource files.

### 1- Install nuget package
````
PM > Install-Package XLocalizer
````

### 2- Create resources folder
Before creating the settings in `startup` we need to create a folder and a dummy class for our localized resources.

- Create a new folder under the root of the project and name it **`LocalizationResources`** or anything else...
- Create a new class inside **`LocalizationResources`** folder and name it **`LocSource`** or anything else...

The folder structure will be like below:
> - ProjectRoot/
>   - LocalizationResources/
>     - LocSource.cs

`LocSource` class is an empty class, it will be used only to refere to _.resx_ resource files inside the code.
````cs
public class LocSource
{
}
````

### 3- Startup settings
Goto startup and configure localization settings
````cs
using XLocalizer;
using XLocalizer.Routing;

public class startup 
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        // other code omitted for simplification...
        // ...
        
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
            
            // optionally, add route based request localization
            // so the localization middleware will look for the `{culture}` in the route
            ops.RequestCultureProviders.Insert(0, new RouteSegmentRequestCultureProvider(cultures));
        });

        services.AddRazorPages()
                // Optionally, add `{culture}` route parameter to all razor page routes
                // so we will have urls like http://localhost:1234/{culture}/
                // for MVC replace with: `RouteTemplateModelConventionMvc`
                .AddRazorPagesOptions(ops => { ops.Conventions?.Insert(0, new RouteTemplateModelConventionRazorPages()); })
                
                // finally we are here :)
                .AddXLocalizer<LocSource>((x) =>
                {
                    x.ResourcesPath = "LocalizationResources";
                });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ...
            // other code omitted for simplification...
            // ...
            
            // use request localization middleware
            app.UseRequestLocalization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
````

### 4- Create resource files
This step is required only if you will work with default _.resx_ files. If you will go with _xml_ or _DB_ based localization the resource files will be created automatically by `XLocalizer`.

Under **`LocalizationResources`** folder create a resource file for each culture. No need to create a resource file for the default culture "en":
- LocSource.tr.resx
- LocSource.ar.resx
