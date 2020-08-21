using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
            // Try register a service for providing default model binding error messages
            builder.Services.TryAddSingleton<IModelBindingErrorMessagesProvider, DefaultModelBindingErrorMessagesProvider>();

            // Add ModelBinding errors localization
            builder.AddMvcOptions(ops =>
            {
                var serviceBuilder = builder.Services.BuildServiceProvider();

                var localizer = serviceBuilder.GetRequiredService(typeof(IStringLocalizer)) as IStringLocalizer;
                var mbErrMsgProvider = serviceBuilder.GetRequiredService(typeof(IModelBindingErrorMessagesProvider)) as IModelBindingErrorMessagesProvider;

                ops.ModelBindingMessageProvider.SetLocalizedModelBindingErrorMessages(localizer, mbErrMsgProvider);
            });


            return builder;
        }
    }
}
