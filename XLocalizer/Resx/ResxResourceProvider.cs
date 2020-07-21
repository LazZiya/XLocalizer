using XLocalizer.Common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Resources;

namespace XLocalizer.Resx
{
    /// <summary>
    /// Localization provider to read localized values from resx files
    /// </summary>
    public class ResxResourceProvider : IXResourceProvider
    {
        private readonly XLocalizerOptions _options;
        private readonly ILogger _logger;
        private readonly ConcurrentDictionary<string, ResourceManager> _cache = new ConcurrentDictionary<string, ResourceManager>();

        /// <summary>
        /// Initialize a new instance of <see cref="ResxResourceProvider"/>
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public ResxResourceProvider(IOptions<XLocalizerOptions> options,
                                        ILogger<ResxResourceProvider> logger)
        {
            _options = options.Value;
            _logger = logger;
        }

        private ResourceManager ResourceManager<TResource>()
            where TResource : class
        {
            return _cache.GetOrAdd($"_resMan_{typeof(TResource).FullName}", _ =>
            {
                // Create a fully qualified resource name
                var typeName = ResourceTypeHelper.CreateCompiledResourceName(typeof(TResource), _options.ResourcesPath);

                return new ResourceManager($"{typeName}", typeof(TResource).Assembly);
            });
        }

        /// <summary>
        /// Get value from resource
        /// </summary>
        /// <typeparam name="TResource"></typeparam>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue<TResource>(string name, out string value) 
            where TResource : class
        {
            var _manager = ResourceManager<TResource>();

            try
            {
                value = _manager.GetString(name, CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                value = null;
                _logger.LogError(e.Message);
            }

            return value != null;
        }

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <typeparam name="TResource"></typeparam>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="comment"></param>
        /// <param name="isApproved"></param>
        /// <returns></returns>
        public bool TrySetValue<TResource>(string name, string value, string comment, bool isApproved = false) 
            where TResource : class
        {
            _logger.LogWarning("Adding new keys is not supported with '.resx' resource files! Switch to another supported type e.g. Xml or DB localization to insert new keys automatically.");

            return false;
        }
    }
}
