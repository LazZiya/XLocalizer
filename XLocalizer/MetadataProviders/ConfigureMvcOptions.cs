using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace XLocalizer.MetadataProviders
{
    /// <summary>
    /// Configure MvcOptions to add custom model binding and validator providers.
    /// see <a href="https://andrewlock.net/access-services-inside-options-and-startup-using-configureoptions/#the-new-improved-answer">Access Services Inside Startup</a>
    /// </summary>
    public class ConfigureMvcOptions : IConfigureOptions<MvcOptions>
    {
        private readonly IServiceScopeFactory _sf;

        /// <summary>
        /// Initialize a new instance of <see cref="ConfigureMvcOptions"/>
        /// </summary>
        /// <param name="serviceScopeFactory"></param>
        public ConfigureMvcOptions(IServiceScopeFactory serviceScopeFactory)
        {
            _sf = serviceScopeFactory;
        }

        /// <summary>
        /// Add <see cref="XModelBindingMetadataProvider"/> and <see cref="XValidationMetadataProvider"/> to <see cref="MvcOptions"/>
        /// </summary>
        /// <param name="options"></param>
        public void Configure(MvcOptions options)
        {
            using(var scope = _sf.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var localizer = provider.GetRequiredService<IStringLocalizer>();
                var ops = provider.GetRequiredService<IOptions<XLocalizerOptions>>();
                {
                    options.ModelMetadataDetailsProviders.Add(new XModelBindingMetadataProvider(localizer, ops));
                    options.ModelMetadataDetailsProviders.Add(new XValidationMetadataProvider(ops));
                }
            }
        }
    }
}
