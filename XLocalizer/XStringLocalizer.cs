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
        private string _transCulture;

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
            _transCulture = options.Value.TranslateFromCulture ?? localizationOptions.Value.DefaultRequestCulture.Culture.Name;
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
            // Option 0: If current culture is same as translation culture just return the key back
            if (_transCulture.Equals(CultureInfo.CurrentCulture.Name, StringComparison.OrdinalIgnoreCase))
            {
                return new LocalizedString(name, string.Format(name, arguments), true, string.Empty);
            }

            // Option 1: Look in the cache
            bool availableInCache = _cache.TryGetValue<TResource>(name, out string value);
            if (availableInCache)
            {
                return new LocalizedString(name, string.Format(value, arguments), false, string.Empty);
            }

            // Option 2: Look in source file
            bool availableInSource = _provider.TryGetValue<TResource>(name, out value);
            if (availableInSource)
            {
                // Add to cache
                _cache.Set<TResource>(name, value);

                return new LocalizedString(name, string.Format(value, arguments), false, string.Empty);
            }

            // Option 3: Try online translation service
            var availableInTranslate = false;
            if (_options.AutoTranslate)
            {
                availableInTranslate = _translator.TryTranslate(_transCulture, CultureInfo.CurrentCulture.Name, name, out value);
                if (availableInTranslate)
                {
                    // Add to cache
                    _cache.Set<TResource>(name, value);
                }
            }

            // Save to source file when AutoAdd is anebled and
            // translation success or AutoTranslate is off
            if (_options.AutoAddKeys && (availableInTranslate || !_options.AutoTranslate))
            {
                bool savedToResource = _provider.TrySetValue<TResource>(name, value ?? name, "Created by XLocalizer");
                _logger.LogInformation($"Save resource to file, status: '{savedToResource}', key: '{name}', value: '{value ?? name}'");
            }

            return new LocalizedString(name, string.Format(value ?? name, arguments), !availableInTranslate, typeof(TResource).FullName);
        }
    }
}