using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace XLocalizer.Translate
{
    /// <summary>
    /// Extensions to use translation services with XLocalizer
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add XLocalizer with Xml based resources.
        /// </summary>
        /// <param name="builder"></param>
        /// <typeparam name="TTranslator">IStringTranslator</typeparam>
        /// <returns></returns>
        public static IMvcBuilder WithTranslationService<TTranslator>(this IMvcBuilder builder)
            where TTranslator : ITranslator
        {
            // Register string translator factory to create StringTranslator on demand
            builder.Services.AddSingleton<ITranslatorFactory, TranslatorFactory<TTranslator>>();

            // Try register a dummy translation service if no other service is registered
            // This dummy service will throw an exception to direct the developer to register
            // the necessary translation service
            builder.Services.TryAddSingleton<ITranslator, DummyTranslator>();

            return builder;
        }
    }
}
