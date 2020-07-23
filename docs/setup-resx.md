# Setup localization based on RESX
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
Add `XLocalizer` setup:
````csharp
using XLocalizer;

services.AddRazorPages()
        .AddXLocalizer<LocSource>(ops => 
        {
            ops.ResourcesPath = "LocalizationResources";
        });
````

Then we can create our localized resources files under **`LocalizationResources`** folder as below:

 - LocSource.tr.resx
 - LocSource.ar.resx
 - ...

> **RECOMMENDATION:**
> 
> _RESX_ files do not support editing at runtime! So if you do not want to fill them manually, start localization setup based on XML or DB, then export the resources to _RESX_ files.

See:
- [Localization setup based on XML](setup-xml.md)
- [Localization setup based on DB](setup-db.md)
- [Export XML to RESX](export-xml-to-resx.md)
- [Export DB to RESX](export-db-to-resx.md)


Full startup file code for _resx_ setup:
````csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using XLocalizer;
using XLocalizer.Routing;
using SampleProject.LocalizationResources;

namespace SampleProject
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
            
            services.AddRazorPages()
                // Optional: Add {culture} route template to all razor pages routes e.g. /en/Index
                .AddRazorPagesOptions(ops => { ops.Conventions.Insert(0, new RouteTemplateModelConventionRazorPages()); })

                // Add XLocalizer with a default resource <LocSource>
                .AddXLocalizer<LocSource>(ops =>
                {
                    ops.ResourcesPath = "LocalizationResources";
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