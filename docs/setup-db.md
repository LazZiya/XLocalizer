# XLocalizer.DB
This pacakge adds database support for `XLocalizer`.

### Table of contents
- [Install](#install)
- [Startup settings](#startup-settings)
- [User secrets](#user-secrets)
- [Caching](#caching)
- [Localization stores setup](#localization-stores-setup)
- [Full startup code for DB setup](#full-startup-code-for-db-setup)

#### Install
Install nuget package:
````
PM > Install-Package XLocalizer
PM > Install-Package XLocalizer.DB
PM > Install-Package XLocalizer.Translate.MymemoryTranslate
````

#### Startup settings
First we need to change the `ApplicationDbContext` life time, by default it is scoped, but all localization interfaces are singleton or transient, so we have to change the `ApplciationDbContext` to avoid scoped and singleton conflicts.
````csharp
services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), 
                ServiceLifetime.Transient, 
                ServiceLifetime.Transient);
````

Then we can add DB localization setup:
````csharp
using XLocalizer.DB;

// Register translation service
services.AddHttpClient<ITranslator, MyMemoryTranslateService>();

services.AddRazorPages()
        .AddXDbLocalizer<ApplicationDbContext>(ops =>
        {
            ops.AutoAddKeys = true;
            ops.AutoTranslate = true;
        });
````


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
Read more about translation services in [Translation services](translate-services.md).

##### Caching
`XLocalizer` has built-in caching enabled by default. Caching helps to speedup the retriving of localized resources. But, it is recommended to switch caching off during development to avoid caching values that are subject to change frequently.

````csharp
ops.UseExpressMemoryCache = false;
```` 

#### Localization stores setup
DB localization requires two stores in the database; one for the cultures, and one for the resources. The default models are already defined in `XLocalizer.DB.Models`, we only need to add them to our context:

Open `ApplicationDbContext.cs` file and add below setup:
````csharp
using XLocalizer.DB.Models;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }
        
    // Cultures table will hold the supported cultures entities
    public DbSet<XDbCulture> XDbCultures { get; set; }

    // All resources will be saved in this table
    public DbSet<XDbResource> XDbResources { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<XDbResource>()
            .HasKey(r => r.ID);

        builder.Entity<XDbResource>()
            .HasIndex(r => new { r.CultureID, r.Key })
            .IsUnique();

        builder.Entity<XDbResource>()
            .HasOne(t => t.Culture)
            .WithMany(c => c.Translations as IEnumerable<XDbResource>)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.SeedCultures();
        builder.SeedResourceData();

        base.OnModelCreating(builder);
    }
}
````

> If you want to add more tables for resources similar to [`XDbResource`][3], just implement [`IXDbResource`][2] interface and add the relevant setup to `ApplicationDbContext`.

Just for starting with some data, create an extension method to seed initial data:
````csharp
public static class SeedXLocalizerValues
{
    public static void SeedCultures(this ModelBuilder modelBuilder)
    {
        // Seed initial data for localization stores
        modelBuilder.Entity<XDbCulture>().HasData(
                new XDbCulture { IsActive = true, IsDefault = true, ID = "en", EnglishName = "English" },
                new XDbCulture { IsActive = true, IsDefault = false, ID = "tr", EnglishName = "Turkish" },
                new XDbCulture { IsActive = true, IsDefault = false, ID = "ar", EnglishName = "Arabic" }
                );
    }

    public static void SeedResourceData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<XDbResource>().HasData(
                new XDbResource { ID = 1, Key = "Welcome", Value = "Hoşgeldin", CultureID = "tr", IsActive = true, Comment = "Created by XLocalizer" }
            );
    }
}
````

Finally, create a migration and update the database:
````
PM > add-migration XLocalizerStores
PM > update-databse
````

#### Full startup code for DB setup
````csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using XmlLocalizationSample.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XLocalizer.Translate;
using XLocalizer;
using XLocalizer.DB;
using System.Globalization;
using XLocalizer.Routing;
using XLocalizer.Translate.MyMemoryTranslate;
using DbLocalizationSample.LocalizationResources;

namespace DbLocalizationSample
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
            // Change DbContext lifetime to transient.
            // By default it is scoped, but this conflicts with singleton lifetime of localization services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), 
                ServiceLifetime.Transient, ServiceLifetime.Transient);

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

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

            services.AddRazorPages()
                // Optional: Add {culture} route template to all razor pages routes e.g. /en/Index
                .AddRazorPagesOptions(ops => { ops.Conventions.Insert(0, new RouteTemplateModelConventionRazorPages()); })

                // Add XLocalization with and specify a service for handling translation requests
                .AddXDbLocalizer<ApplicationDbContext, MyMemoryTranslateService>(ops =>
                {
                    // Resources folder path required in case of 
                    // exporting db resources to resx resource files.
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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRequestLocalization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

````
[2]:https://github.com/LazZiya/XLocalizer/blob/master/XLocalizer.DB/Models/IXDbResource.cs
[3]:https://github.com/LazZiya/XLocalizer/blob/master/XLocalizer.DB/Models/XDbResource.cs
