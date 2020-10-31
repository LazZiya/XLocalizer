using Microsoft.AspNetCore.Builder;
using System;
using XLocalizer.ModelBinding;

namespace XLocalizer
{
    /// <summary>
    /// Extension methods for configuring services to work with XLocalizer
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configure the app to use localized model binding errors, and configure cookie
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseXLocalizer(this IApplicationBuilder app)
        {
            if(app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app;
        }
    }
}
