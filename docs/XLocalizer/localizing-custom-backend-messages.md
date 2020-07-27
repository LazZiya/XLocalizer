## Localizing Custom Backend Messages
Custom backend error messages can be localized by injecting `IStringLocalizer`, `IHtmlLocalizer`, `IStringLocalizerFactory` or `IHtmlLocalizerFactory` to the controller or PageModel as below:

````cs
using LazZiya.ExpressLocalization

public class IndexModel : PageModel
{
    private readonly IStringLocalizer _loc;

    public string CustomMessage { get; set; }

    public IndexModel(IStringLocalizer loc)
    {
        _loc = loc;
    }

    public void OnGet() 
    {
        CustomMessage = _loc["Localized custom backend message"];
    }
}
````

By default, XLocalizer will use one shared resource _the one we used in startup setup **LocSource**_.

If you want to use a different resource, just pass its type into the localizer interface, :
````cs
private readonly IStringLocalizer _loc;

public IndexModel(IStringLocalizer<IndexModel> loc)
{
    _loc = loc;
}
```` 

Or create the localizer using the factory:
````cs
private readonly IStringLocalizer _loc;

public IndexModel(IStringLocalizerFactory factory)
{
    _loc = factory.Create(typeof(MyResourcetype));
}
```` 

Notices
 - **XML based localization:** If the resource file is not found it will be created automatically by `XLocalizer`, but the folder must exists.
 - **RESX based localization:** The resource file must be created manually, or can be created automatically by exporting from XML or DB.
 - **DB based localization:** The type passed must be relevant to an existing DB table that implements [`IXDbResource`][1] interface.


#
### Next: [Add language navigation][2]
#

[1]:https://github.com/LazZiya/XLocalizer.DB/blob/master/XLocalizer.DB/Models/IXDbResource.cs
[2]:../XLocalizer/language-navigation.md