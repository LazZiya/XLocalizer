### 1- Install DB support nuget
In addition to the [standard setup][1], database support requires additional nuget.
````
PM > Install-Package XLocalizer.DB
````

### 2- Startup settings
First we need to change the `ApplicationDbContext` life time, by default it is scoped, but all localization interfaces are singleton or transient, so we have to change the `ApplciationDbContext` to avoid scoped and singleton conflicts.
````cs
services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), 
                ServiceLifetime.Transient, 
                ServiceLifetime.Transient);
````

Then we can add DB localization setup:
````cs
services.AddRazorPages()
    .AddRazorPagesOptions(ops => { ops.Conventions?.Insert(0, new RouteTemplateModelConventionRazorPages()); })
    
    // here we use `AddXDbLocalizer` and we pass `ApplicationDbContext`
    .AddXDbLocalizer<ApplicationDbContext>();
````

### 3- Localization stores setup
DB localization requires two stores in the database; one for the cultures, and one for the resources. The default models are already defined in `XLocalizer.DB.Models`, we need to add them to our context:

Open `ApplicationDbContext.cs` file and add below setup:
````cs
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
        
        // optionally add more resource entities just like [`XDbResource`][3] setup if you want to 
        // have more than one table for resources
            
        builder.SeedCultures();
        builder.SeedResourceData();

        base.OnModelCreating(builder);
    }
}
````

> If you want to add more tables for resources similar to [`XDbResource`][3], just implement [`IXDbResource`][2] interface and add the relevant setup to `ApplicationDbContext`.

Just for starting with some data, create an extension method to seed initial data:
````cs
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

[1]:standard-setup.md
[2]:https://github.com/LazZiya/XLocalizer/blob/master/XLocalizer.DB/Models/IXDbResource.cs
[3]:https://github.com/LazZiya/XLocalizer/blob/master/XLocalizer.DB/Models/XDbResource.cs
