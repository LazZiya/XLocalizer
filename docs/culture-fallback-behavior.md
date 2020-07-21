Asp.Net Core uses [localization culture providers][5] to detect the request culture and respond accordingly. The culture checking process goes one by one through all registered providers, whenever a request culture is detected the check process stops and the localization process starts accordingly.

If the request culture is not found in the first provider, next provider will be checked. Finally if no culture is detected the default culture will be used.

`XLocalizer` is using the order defined in `startup` for configuring request localization options. for example given the below setup:
````cs
services.Configure<RequestLocalizationOptions>(ops =>
{
    ops.SupportedCultures = cultures;
    ops.SupportedUICultures = cultures;
    ops.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
    ops.RequestCultureProviders.Insert(0, new RouteSegmentRequestCultureProvider(cultures));
});
````

`XLocalizer` will use below order:
1) [RouteSegmentRequestCultureProvider][6]
2) [QueryStringRequestCultureProvider][7]
3) [CookieRequestCultureProvider][3]
4) [AcceptedLanguageHeaderRequestCultureProvider][4]

[6]: https://github.com/LazZiya/XLocalizer/blob/master/XLocalizer/Routing/RouteSegmentRequestCultureProvider.cs
[7]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.localization.querystringrequestcultureprovider
[3]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.localization.cookierequestcultureprovider
[4]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.localization.acceptlanguageheaderrequestcultureprovider
[5]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization-extensibility?view=aspnetcore-3.1#localization-culture-providers
