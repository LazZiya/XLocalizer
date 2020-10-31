using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Extesnions for adding DataAnnotation Localization
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add DataAnnotations localization with specified resource type.
        /// </summary>
        /// <typeparam name="TResource">Type of DataAnnotations localization resource</typeparam>
        /// <param name="builder"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IMvcBuilder AddDataAnnotationsLocalization<TResource>(this IMvcBuilder builder, Action<XLocalizerOptions> options)
            where TResource : class
        {
            /*
            var o = new XLocalizerOptions();
            options.Invoke(o);

            if (o.UseExpressValidationAttributes)
            {
                // Add ExpressValdiationAttributes to provide error messages by default without using ErrorMessage="..."
                builder.Services.AddTransient<IValidationAttributeAdapterProvider, ExpressValidationAttributeAdapterProvider>();
            }
            */
            // Add data annotations locailzation
            builder.AddDataAnnotationsLocalization(ops =>
            {
                // This will look for localization resource with type of T (shared resource)
                ops.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(TResource));

                // This will look for localization resources depending on specific type, e.g. LoginModel.en.xml
                //ops.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(t);
            });

            return builder;
        }
    }
}
