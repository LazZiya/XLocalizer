using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace XLocalizer.Common
{
    /// <summary>
    /// Provides an IMemoryCache service to save localized values in a memory cache
    /// </summary>
    public class ExpressMemoryCache
    {
        private readonly IMemoryCache _cache;
        private readonly XLocalizerOptions _options;
        private readonly MemoryCacheEntryOptions _entryOps;
        /// <summary>
        /// _XL_ : XLocalizer
        /// {0}: resource full name
        /// {1}: culture name
        /// {2}: key name
        /// </summary>
        private readonly string _keyFormat = "_XL_{0}_{1}:{2}";

        /// <summary>
        /// Create a new instance of ExpressMemoryCache
        /// </summary>
        public ExpressMemoryCache(IMemoryCache cache, IOptions<MemoryCacheEntryOptions> entryOptions, IOptions<XLocalizerOptions> options)
        {
            _cache = cache;
            _entryOps = entryOptions.Value;
            _options = options.Value;
        }

        /// <summary>
        /// Add new entry to the cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set<T>(string key, string value) where T : class
        {
            if (_options.UseExpressMemoryCache)
            {
                var k = CreateFormattedKey<T>(key);

                _cache.Set<string>(k, value, _entryOps);
            }
        }

        /// <summary>
        /// Remove entry from cache
        /// </summary>
        /// <param name="key"></param>
        public void Remove<T>(string key) where T : class
        {
            if (_options.UseExpressMemoryCache)
            {
                var k = CreateFormattedKey<T>(key);

                _cache.Remove(k);
            }
        }

        /// <summary>
        /// Get a cached item from the memory cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue<T>(string key, out string value) where T : class
        {
            if (_options.UseExpressMemoryCache)
            {
                var k = CreateFormattedKey<T>(key);

                return _cache.TryGetValue(k, out value);
            }

            value = key;
            return false;
        }

        private string CreateFormattedKey<T>(string key) where T : class
        {
            return string.Format(_keyFormat, typeof(T).FullName, CultureInfo.CurrentCulture.Name, key);
        }
    }
}