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
> **- XML Based Localization Setup:** If the resource file is not found under the resources folder __\LocalizationResoureces\IndexModel.{culture}.xml__ it will be created automatically by `XLocalizer`

> **- RESX Based Localization Setup:** The resource file must be created manually, or can be created automatically by exporting from XML or DB.

> **- DB Based Localization Setup:** The type passed must be relevant to an existing DB table that implements `IXDbResource`.
