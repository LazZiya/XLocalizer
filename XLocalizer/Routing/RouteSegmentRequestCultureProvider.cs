using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace XLocalizer.Routing
{
    /// <summary>
    /// Route segment request culture provider
    /// </summary>
    public class RouteSegmentRequestCultureProvider : IRequestCultureProvider
    {
        private readonly IList<CultureInfo> SupportedCultures;

        /// <summary>
        /// Initialize new intance of RouteSegmentRequestCultureProvider
        /// </summary>
        /// <param name="supportedCultures">list of supported cultures</param>
        public RouteSegmentRequestCultureProvider(IList<CultureInfo> supportedCultures)
        {
            SupportedCultures = supportedCultures;
        }

        /// <summary>
        /// Determine the culture resut according to the {culture} route paramter value
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;

            if (string.IsNullOrWhiteSpace(path))
            {
                // Path is empty! returning default culture
                //return Task.FromResult(new ProviderCultureResult(DefaultCulture));
                return Task.FromResult<ProviderCultureResult>(null);
            }

            var routeValues = httpContext.Request.Path.Value.Split('/');
            if (routeValues.Count() <= 1)
            {
                // No path parameter detected! returning default culture
                //return Task.FromResult(new ProviderCultureResult(DefaultCulture));
                return Task.FromResult<ProviderCultureResult>(null);
            }

            if (!SupportedCultures.Any(x =>
                 x.TwoLetterISOLanguageName.ToLower() == routeValues[1].ToLower() ||
                 x.Name.ToLower() == routeValues[1].ToLower()))
            {
                // Path culture not ercognized! returning default culture
                //return Task.FromResult(new ProviderCultureResult(DefaultCulture));
                return Task.FromResult<ProviderCultureResult>(null);
            }

            // culture selected successfuly
            return Task.FromResult(new ProviderCultureResult(routeValues[1]));
        }
    }
}
