using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Linq;
#if NETCOREAPP2_0 || NETCOREAPP2_1 || NETCOREAPP2_2
using Microsoft.AspNetCore.Routing;
#endif

namespace XLocalizer.Routing
{
    /// <summary>
    /// Extension to configure application cookie paths
    /// </summary>
    public static class ConfigureApplicationCookieExtension
    {

        /// <summary>
        /// Configure application cookie and add culture value to redirect path
        /// so unauthorized users will be redirected to login page and the culture will not be lost
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IMvcBuilder ConfigureApplicationCookie(this IMvcBuilder builder)
        {
            var ops = builder.Services.BuildServiceProvider().GetService<XLocalizerOptions>();

            var rlOps = builder.Services.BuildServiceProvider().GetService<RequestLocalizationOptions>();
            var _cultures = rlOps.SupportedCultures;
            var _providers = rlOps.RequestCultureProviders;
            var defCulture = rlOps.DefaultRequestCulture.Culture.Name;


            // add culture value to route when user is redirected to login page
            builder.Services.ConfigureApplicationCookie(o =>
                {
                // Improvment : do we need to check for existing cookie authentication events before?
                o.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = ctx =>
                        {
#if NETCOREAPP2_0 || NETCOREAPP2_1 || NETCOREAPP2_2
                        var culture = ctx.HttpContext.GetRouteValue("culture");
#else
                        var culture = ctx.Request.RouteValues["culture"];
#endif
                        var requestPath = ctx.Request.Path;

                            if (culture == null)
                            {                                
                                culture = DetectCurrentCulture(_providers, ctx.HttpContext, _cultures, defCulture);
                                requestPath = $"/{culture}{requestPath}";
                            }

                            ctx.Response.Redirect($"/{culture}{ops.RedirectToLoginPath}?ReturnUrl={requestPath}{ctx.Request.QueryString}");
                            return Task.CompletedTask;
                        },
                        OnRedirectToLogout = ctx =>
                        {
#if NETCOREAPP2_0 || NETCOREAPP2_1 || NETCOREAPP2_2
                        var culture = ctx.HttpContext.GetRouteValue("culture") ?? defCulture;
#else
                        var culture = ctx.Request.RouteValues["culture"] ?? defCulture;
#endif

                            if (culture == null)
                            {
                                culture = DetectCurrentCulture(_providers, ctx.HttpContext, _cultures, defCulture);
                                ops.RedirectToLogoutPath = $"/{culture}{ops.RedirectToLogoutPath}";
                            }

                            ctx.Response.Redirect($"/{culture}{ops.RedirectToLogoutPath}");
                            return Task.CompletedTask;
                        },
                        OnRedirectToAccessDenied = ctx =>
                        {
#if NETCOREAPP2_0 || NETCOREAPP2_1 || NETCOREAPP2_2
                        var culture = ctx.HttpContext.GetRouteValue("culture") ?? defCulture;
#else
                        var culture = ctx.Request.RouteValues["culture"] ?? defCulture;
#endif

                            if (culture == null)
                            {
                                culture = DetectCurrentCulture(_providers, ctx.HttpContext, _cultures, defCulture);
                                ops.RedirectToAccessDeniedPath = $"/{culture}{ops.RedirectToAccessDeniedPath}";
                            }

                            ctx.Response.Redirect($"/{culture}{ops.RedirectToAccessDeniedPath}");
                            return Task.CompletedTask;
                        }
                    };
                });
            return builder;
        }

        /// <summary>
        /// Detect the culture for the current request according to the available cultures and their availability in the registered culture providers, 
        /// if no culture is detected it will return default culture.
        /// Use to detect the current culture for cookie authentication events.
        /// </summary>
        /// <param name="providers">List of currently registered culture providers</param>
        /// <param name="httpContext">requests HttpContext</param>
        /// <param name="cultures">List of supported cultures</param>
        /// <param name="defCulture">default culture name</param>
        /// <returns>ProviderCultureResult</returns>
        private static string DetectCurrentCulture(IList<IRequestCultureProvider> providers, HttpContext httpContext, IList<CultureInfo> cultures, string defCulture)
        {
            foreach (var p in providers)
            {
                var availableCultures = Task.Run(()=> p.DetermineProviderCultureResult(httpContext)).GetAwaiter().GetResult();

                if (availableCultures != null)
                {
                    foreach (var c in availableCultures.Cultures)
                    {
                        var available = cultures.FirstOrDefault(x => x.Name == c);
                        if (available != null)
                            return available.Name;
                    }
                }
            }

            return defCulture;
        }
    }
}
