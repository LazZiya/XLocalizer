using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace XLocalizer.Identity
{
    /// <summary>
    /// Extesnions for adding Identity errors localization
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add DataAnnotations, ModelBinding and IdentityErrors localization to the project.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IMvcBuilder AddIdentityErrorsLocalization(this IMvcBuilder builder)
        {
            builder.Services.TryAddSingleton<IIdentityErrorMessagesProvider, DefaultIdentityErrorsProvider>();

            // Add Identity Erros localization
            builder.Services.AddScoped<IdentityErrorDescriber, IdentityErrorsLocalizer>();

            return builder;
        }
    }
}
