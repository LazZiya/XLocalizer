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
            // invoke user provided inline options
            var ops = new XLocalizerOptions();
            options.Invoke(ops);

#if !NETCOREAPP2_0
            // get options from appsettings.json and override inline options
            var sp = builder.Services.BuildServiceProvider();
            var conf = sp.GetRequiredService(typeof(IConfiguration)) as IConfiguration;
            conf.GetSection("XLocalizer:Options").Bind(conf);
#endif
            builder.Services.Configure<XLocalizerOptions>(o => o = ops);

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

            return builder.AddDataAnnotationsLocalization<TResource>(options)
                          .AddModelBindingLocalization()
                          .AddIdentityErrorsLocalization()
                          .WithTranslationService<TTranslator>();
        }
    }
}