using XLocalizer.Common;
using XLocalizer.Translate;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Reflection;
using Microsoft.AspNetCore.Builder;

namespace XLocalizer
{
    /// <summary>
    /// Factory to create <see cref="XStringLocalizer{TResource}"/>
    /// </summary>
    public class XStringLocalizerFactory<TResource> : IXStringLocalizerFactory
        where TResource : class
    {
        private readonly ExpressMemoryCache _cache;
        private readonly ITranslatorFactory _translatorFactory;
        private readonly IXResourceProvider _provider;
        private readonly IOptions<XLocalizerOptions> _options;
        private readonly IOptions<RequestLocalizationOptions> _localizationOptions;
        private readonly ILoggerFactory _loggerFactory;

        private readonly ConcurrentDictionary<string, IStringLocalizer> _localizerCache = 
            new ConcurrentDictionary<string, IStringLocalizer>();

        /// <summary>
        /// Initialize a new instance of <see cref="XStringLocalizerFactory{TResource}"/>
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="translatorFactory"></param>
        /// <param name="provider"></param>
        /// <param name="options"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="localizationOptions"></param>
        public XStringLocalizerFactory(ExpressMemoryCache cache,
                                       ITranslatorFactory translatorFactory,
                                       IXResourceProvider provider,
                                       IOptions<XLocalizerOptions> options,
                                       IOptions<RequestLocalizationOptions> localizationOptions,
                                       ILoggerFactory loggerFactory)
        {
            _cache = cache;
            _options = options;
            _provider = provider;
            _loggerFactory = loggerFactory;
            _translatorFactory = translatorFactory;
            _localizationOptions = localizationOptions;
        }

        /// <summary>
        /// Create a new <see cref="XStringLocalizer{TResource}"/> 
        /// based on the default resource type
        /// </summary>
        /// <returns></returns>
        public IStringLocalizer Create()
        {
            return _localizerCache.GetOrAdd(typeof(TResource).FullName, _ =>
            {
                return new XStringLocalizer<TResource>(_cache, _translatorFactory, _provider, _options, _localizationOptions, _loggerFactory);
            });
        }

        /// <summary>
        /// Create a new instance of <see cref="XStringLocalizer{TResource}"/> based on provided resource type
        /// </summary>
        /// <param name="resourceSource"></param>
        /// <returns></returns>
        public IStringLocalizer Create(Type resourceSource)
        {
            if (resourceSource == null)
                throw new NotImplementedException(nameof(resourceSource));

            return _localizerCache.GetOrAdd(resourceSource.FullName, _ =>
            {
                return CreateStringLocalizer(resourceSource);
            });
        }

        /// <summary>
        /// Create a new instance of <see cref="XStringLocalizer{TResource}"/>
        /// based on the provided baseName and localiztion
        /// </summary>
        /// <param name="baseName"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public IStringLocalizer Create(string baseName, string location)
        {
            if (baseName == null)
            {
                throw new ArgumentNullException(nameof(baseName));
            }

            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            return _localizerCache.GetOrAdd($"B={baseName},L={location}", _ =>
            {
                var assemblyName = new AssemblyName(location);
                var assembly = Assembly.Load(assemblyName);
                var type = assembly.GetType(baseName);

                return CreateStringLocalizer(type);
            });            
        }

        /// <summary>
        /// Create new instance of <see cref="XStringLocalizer{TResource}"/>
        /// </summary>
        /// <param name="resourceSource"></param>
        /// <returns></returns>
        private IStringLocalizer CreateStringLocalizer(Type resourceSource)
        {
            Type xLocalizerType = typeof(XStringLocalizer<>);
            Type genericType = xLocalizerType.MakeGenericType(new[] { resourceSource });
            object o = Activator.CreateInstance(genericType, _cache, _translatorFactory, _provider, _options, _localizationOptions, _loggerFactory);

            return (IStringLocalizer)o;
        }
    }
}