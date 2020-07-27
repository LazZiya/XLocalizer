using XLocalizer.Common;
using XLocalizer.Translate;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace XLocalizer
{
    /// <summary>
    /// This is the place where we get/set localized values
    /// from localization providers.
    /// </summary>
    /// <typeparam name="TResource"></typeparam>
    public class XStringLocalizer<TResource> : IStringLocalizer<TResource>
        where TResource : class
    {
        private readonly ExpressMemoryCache _cache;
        private readonly ITranslator _translator;
        private readonly IXResourceProvider _provider;
        private readonly XLocalizerOptions _options;
        private readonly ILogger _logger;
        private string _defaultCulture;

        /// <summary>
        /// Initialize a new instance of <see cref="XStringLocalizer{TResource}"/>
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="translatorFactory"></param>
        /// <param name="provider"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="localizationOptions"></param>
        /// <param name="options"></param>
        public XStringLocalizer(ExpressMemoryCache cache,
                                ITranslatorFactory translatorFactory,
                                IXResourceProvider provider,
                                IOptions<XLocalizerOptions> options,
                                IOptions<RequestLocalizationOptions> localizationOptions,
                                ILoggerFactory loggerFactory)
        {
            _cache = cache;
            _translator = translatorFactory.Create();
            _provider = provider;
            _options = options.Value;
            _defaultCulture = localizationOptions.Value.DefaultRequestCulture.Culture.Name;
            _logger = loggerFactory.CreateLogger<XStringLocalizer<TResource>>();
        }

        /// <summary>
        /// Get LocalizedString
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public LocalizedString this[string name] => GetLocalizedString(name);

        /// <summary>
        /// Get LocalizedString with arguments
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public LocalizedString this[string name, params object[] arguments] => GetLocalizedString(name, arguments);

        /// <summary>
        /// TODO...
        /// </summary>
        /// <param name="includeParentCultures"></param>
        /// <returns></returns>
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NOT IMPLEMENTED! use <see cref="CultureSwitcher"/> instead.
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private LocalizedString GetLocalizedString(string name, params object[] arguments)
        {
            var availableInTranslate = false;

            // Option 1: Look in the cache
            bool availableInCache = _cache.TryGetValue(name, out string value);

            if (!availableInCache)
            {
                // Option 2: Look in resource
                bool availableInSource = _provider.TryGetValue<TResource>(name, out value);

                if (!availableInSource && _options.AutoTranslate)
                {
                    var culture = CultureInfo.CurrentCulture.Name;

                    if(_defaultCulture != culture)
                        // Option 3: Online translate
                        availableInTranslate = _translator.TryTranslate(_defaultCulture, culture, name, out value);
                }

                // add a resource if it is not available in source and auto add is enabled
                if (!availableInSource && _options.AutoAddKeys)
                {
                    // Add a resource only if auto translate is off or if available in translation
                    if (!_options.AutoTranslate || availableInTranslate)
                    {
                        bool savedToResource = _provider.TrySetValue<TResource>(name, value ?? name, "Created by XLocalizer");
                        _logger.LogInformation($"Save resource to file, status: '{savedToResource}', key: '{name}', value: '{value ?? name}'");
                    }
                }

                if (availableInSource || availableInTranslate)
                {
                    // Save to cache
                    _cache.Set(name, value);

                    // Set availability to true
                    availableInCache = true;
                }
            }

            var val = string.Format(value ?? name, arguments);

            return new LocalizedString(name, val, resourceNotFound: !availableInCache, searchedLocation: typeof(TResource).FullName);
        }
    }
}