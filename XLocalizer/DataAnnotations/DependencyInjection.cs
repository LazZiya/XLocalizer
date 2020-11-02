using Microsoft.Extensions.DependencyInjection;

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
        /// <returns></returns>
        public static IMvcBuilder AddDataAnnotationsLocalization<TResource>(this IMvcBuilder builder)
            where TResource : class
        {
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
