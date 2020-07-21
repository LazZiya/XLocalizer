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
        private string _keyFormat = "_Ex_Loc_{0}:{1}";

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
        public void Set(string key, string value)
        {
            if (_options.UseExpressMemoryCache)
            {
                var k = CreateFormattedKey(key);

                _cache.Set<string>(k, value, _entryOps);
            }
        }

        /// <summary>
        /// Remove entry from cache
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            if (_options.UseExpressMemoryCache)
            {
                var k = CreateFormattedKey(key);

                _cache.Remove(k);
            }
        }

        /// <summary>
        /// Get a cached item from the memory cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(string key, out string value)
        {
            if (_options.UseExpressMemoryCache)
            {
                var k = CreateFormattedKey(key);

                return _cache.TryGetValue(k, out value);
            }

            value = key;
            return false;
        }

        private string CreateFormattedKey(string key)
        {
            return string.Format(_keyFormat, CultureInfo.CurrentCulture.Name, key);
        }
    }
}