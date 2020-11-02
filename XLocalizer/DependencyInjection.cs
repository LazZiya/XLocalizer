using XLocalizer.Common;
using XLocalizer.DataAnnotations;
using XLocalizer.Identity;
using XLocalizer.ModelBinding;
using XLocalizer.Resx;
using XLocalizer.Translate;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using System;
using XLocalizer.Xml;
using Microsoft.Extensions.Configuration;
using XLocalizer.Routing;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using XLocalizer.MetadataProviders;

namespace XLocalizer
{
    /// <summary>
    /// DI
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Register all XLocalization services...
        /// </summary>
        /// <typeparam name="TResource">Resource file type</typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IMvcBuilder AddXLocalizer<TResource>(this IMvcBuilder builder)
            where TResource : class
        {
            return builder.AddXLocalizer<TResource, DummyTranslator>(o => o = new XLocalizerOptions());
        }

        /// <summary>
        /// Register all XLocalization services...
        /// </summary>
        /// <typeparam name="TResource">Resource file type</typeparam>
        /// <typeparam name="TTranslator">Translation service type</typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IMvcBuilder AddXLocalizer<TResource, TTranslator>(this IMvcBuilder builder)
            where TResource : class
            where TTranslator : ITranslator
        {
            return builder.AddXLocalizer<TResource, TTranslator>(o => o = new XLocalizerOptions());
        }

        /// <summary>
        /// Register all XLocalization services...
        /// </summary>
        /// <typeparam name="TResource">Resource file type</typeparam>
        /// <param name="builder"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IMvcBuilder AddXLocalizer<TResource>(this IMvcBuilder builder, Action<XLocalizerOptions> options)
            where TResource : class
        {
            return builder.AddXLocalizer<TResource, DummyTranslator>(options);
        }

        /// <summary>
        /// Register all XLocalization services...
        /// </summary>
        /// <typeparam name="TResource">Resource file type</typeparam>
        /// <typeparam name="TTranslator">Translation service type</typeparam>
        /// <param name="builder"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IMvcBuilder AddXLocalizer<TResource, TTranslator>(this IMvcBuilder builder, Action<XLocalizerOptions> options)
            where TResource : class
            where TTranslator : ITranslator
        {
            // Configure XLocalizer options
            builder.Services.Configure<XLocalizerOptions>(options);

            // ExpressMemoryCache for caching localized values
            builder.Services.AddSingleton<ExpressMemoryCache>();

            // Try add a default resx service.
            // if another service has been registered this will be bypassed, and the other service will be in use.
            builder.Services.TryAddSingleton<IXResourceProvider, ResxResourceProvider>();
            builder.Services.TryAddTransient<IXResourceExporter, XmlResourceExporter>();

            builder.Services.AddSingleton<IStringLocalizer, XStringLocalizer<TResource>>();
            builder.Services.AddSingleton<IHtmlLocalizer, XHtmlLocalizer<TResource>>();

            builder.Services.AddTransient(typeof(IStringLocalizer<>), typeof(XStringLocalizer<>));
            builder.Services.AddTransient(typeof(IHtmlLocalizer<>), typeof(XHtmlLocalizer<>));

            builder.Services.AddSingleton<IStringLocalizerFactory, XStringLocalizerFactory<TResource>>();
            builder.Services.AddSingleton<IHtmlLocalizerFactory, XHtmlLocalizerFactory<TResource>>();

            builder.Services.AddSingleton<IXStringLocalizerFactory, XStringLocalizerFactory<TResource>>();
            builder.Services.AddSingleton<IXHtmlLocalizerFactory, XHtmlLocalizerFactory<TResource>>();

            // Add custom providers for overriding default modelbinding and data annotations errors
            builder.Services.AddSingleton<IConfigureOptions<MvcOptions>, ConfigureMvcOptions>();

            return builder.AddIdentityErrorsLocalization()
                          .WithTranslationService<TTranslator>();
        }
    }
}