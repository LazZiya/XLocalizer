using XLocalizer.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace XLocalizer.ModelBinding
{
    /// <summary>
    /// Extesnions for adding DataAnnotation Localization
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add ModelBinding localization to the project.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IMvcBuilder AddModelBindingLocalization(this IMvcBuilder builder)
        {
            // Add ModelBinding errors localization
            builder.AddMvcOptions(ops =>
            {
                var localizer = builder.Services.BuildServiceProvider().GetService(typeof(IStringLocalizer)) as IStringLocalizer;
                ops.ModelBindingMessageProvider.SetLocalizedModelBindingErrorMessages(localizer);
            });

            return builder;
        }
    }
}
