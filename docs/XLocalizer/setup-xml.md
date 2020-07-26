# Localization setup based on XML
Localization based on _XML_ files works very similar to _RESX_ process, we only use _.xml_ files instead of _.resx_ to store resources. But the ability to edit _XML_ files at run time gives us the flexibility of automtically adding missing resources to _XML_ resource files.

### Table of contents
- [Install](#install)
- [Create resources folder](#create-resources-folder)
- [Startup settings](#startup-settings)
- [User secrets](#user-secrets)
- [Caching](#caching)
- [Full startup code for XML](#full-startup-code-for-xml)


#### Install
Install nuget package:
````
PM > Install-Package XLocalizer
PM > Install-Package XLocalizer.Translate.MyMemoryTranslate
````

#### Create resources folder
Let's start by creating a folder and a dummy class for our localized resources.

- Create a new folder under the root of the project and name it **`LocalizationResources`** or anything else...
- Create a new class inside **`LocalizationResources`** folder and name it **`LocSource`** or anything else...

The folder structure will be like below:
> - ProjectRoot/
>   - LocalizationResources/
>     - LocSource.cs

`LocSource` is empty class, it will be used only to refere to _.resx_ resource files inside the code.
````csharp
public class LocSource
{
}
````

#### Startup settings
Add `XLocalizer` setup and enable `AutoAddKeys` and `AutoTranslate` options:
````csharp
using XLocalizer;
using XLocalizer.Xml;
using XLocalizer.Translate;
using XLocalizer.Translate.MyMemoryTranslate;

// Register xml resource provider
services.AddSingleton<IXResourceProvider, XmlResourceProvider>();

// Register translation service
services.AddHttpClient<ITranslator, MyMemoryTranslateService>();

services.AddRazorPages()
        .AddXLocalizer<LocSource, MyMemoryTranslateService>(ops => 
        {
            ops.ResourcesPath = "LocalizationResources";
            ops.AutoAddKeys = true;
            ops.AutoTranslate = true;
        });
````

> No need to create _XML_ resource files manually, they will be created at runtime by `XLocalizer`. 


#### User secrets
Our translation service is based on RapidAPI, so we need to add the relevant API key to the user secrets file.
> Right click on the project name and select _Manage User Secrets_, then add the API key as below:

````json
{
  "XLocalizer.Translate": {
    "RapidApiKey": "xxx-rapid-api-key-xxx",
  }
}
````
Read more about translation services in [Translation services][1].


##### Caching
`XLocalizer` has built-in caching enabled by default. Caching helps to speedup the retriving of localized resources. But, it is recommended to switch caching off during development to avoid caching values that are subject to change frequently.

````csharp
ops.UseExpressMemoryCache = false;
```` 

#### Full startup code for XML
````csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XLocalizer.Translate;
using XLocalizer;
using XLocalizer.Xml;
using System.Globalization;
using XLocalizer.Routing;
using XLocalizer.Translate.MyMemoryTranslate;
using XmlLocalizationSample.LocalizationResources;

namespace XmlLocalizationSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(ops =>
            {
                var cultures = new CultureInfo[] { new CultureInfo("en"), new CultureInfo("tr"), new CultureInfo("ar") };
                ops.SupportedCultures = cultures;
                ops.SupportedUICultures = cultures;
                ops.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");

                // Optional: add custom provider to support localization based on route value {culture}
                ops.RequestCultureProviders.Insert(0, new RouteSegmentRequestCultureProvider(cultures));
            });
            
            // Optional: To enable online translation register one or more translation services
            services.AddHttpClient<ITranslator, MyMemoryTranslateService>();

            // Comment below line to switch to RESX based localization.
            services.AddSingleton<IXResourceProvider, XmlResourceProvider>();

            services.AddRazorPages()
                // Optional: Add {culture} route template to all razor pages routes e.g. /en/Index
                .AddRazorPagesOptions(ops => { ops.Conventions.Insert(0, new RouteTemplateModelConventionRazorPages()); })

                // Add XLocalization with a default resource <LocSource>
                // and specify a service for handling translation requests
                .AddXLocalizer<LocSource, MyMemoryTranslateService>(ops =>
                {
                    ops.ResourcesPath = "LocalizationResources";
                    ops.AutoAddKeys = true;
                    ops.AutoTranslate = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Use request localization middleware
            app.UseRequestLocalization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

````

[1]:../XLocalizer/translate-services.md