`XLocalizer` will automatically configure app cookie to add culture value to the redirect path when redirect events are invoked.

The default events and paths are: 
- OnRedirectToLogin : `{culture}/Identity/Account/Login/`
- OnRedirectToLogout : `{culture}/Identity/Account/Logout/`
- OnRedirectToAccessDenied : `{culture}/Identity/Account/AccessDenied/`

You can define custom paths for login, logout and access denied using _ExpressLocalization_ as below:

````cs
services.AddRazorPages()
    .AddXLocalizer<LocSource>(
        ops =>
        {
            ops.RedirectToLoginPath = "/CustomLoginPath/";
            ops.RedirectToLogoutPath = "/CustomLogoutPath/";
            ops.RedirectToAcceddDeniedPath = "/CustomAccessDeniedPath/";
        });
````

Or if you need to completely use custom cookie configurations using the identity extensions method, you need to set the value of `ConfigureRedirectPaths` to false as below:

````cs
services.AddRazorPages()
    .AddXLocalizer<LocSource>(
        ops =>
        {            
            // don't configure redirect to paths on redirect events
            ops.ConfigureRedirectPaths = false;
            
            // ...
        });
````

in this case you need to manually configure the app cookie to handle the culture value on redirect events as described in [issue #2][2]

[2]: https://github.com/LazZiya/ExpressLocalization/issues/6
