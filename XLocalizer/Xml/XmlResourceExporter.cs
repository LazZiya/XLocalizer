using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using XLocalizer.Common;
using XLocalizer.Resx;

namespace XLocalizer.Xml
{
    /// <summary>
    /// Export Xml resources to resx
    /// </summary>
    public class XmlResourceExporter : IXResourceExporter
    {
        private readonly XLocalizerOptions _options;
        private readonly ILogger _logger;
        private readonly ILoggerFactory _loggerFactory;

        /// <summary>
        /// Initialize a new instance of <see cref="XmlResourceExporter"/>
        /// </summary>
        public XmlResourceExporter(IOptions<XLocalizerOptions> options, ILoggerFactory loggerFactory)
        {
            _options = options.Value;
            _logger = loggerFactory.CreateLogger<XmlResourceExporter>();
            _loggerFactory = loggerFactory;
        }

        /// <summary>
        /// Export xml data to resx
        /// </summary>
        /// <typeparam name="TResource"></typeparam>
        /// <param name="culture"></param>
        /// <param name="approvedOnly"></param>
        /// <param name="overwriteExistingKeys"></param>
        /// <returns></returns>
        public async Task<int> ExportToResxAsync<TResource>(string culture, bool approvedOnly, bool overwriteExistingKeys)
            where TResource : class
        {
            return await ExportToResxAsync(typeof(TResource), culture, approvedOnly, overwriteExistingKeys);
        }

        /// <summary>
        /// Export xml data to resx
        /// </summary>
        /// <param name="type"></param>
        /// <param name="culture"></param>
        /// <param name="approvedOnly"></param>
        /// <param name="overwriteExistingKeys"></param>
        /// <returns></returns>
        public async Task<int> ExportToResxAsync(Type type, string culture, bool approvedOnly, bool overwriteExistingKeys)
        {
            string resFileName = ResourceTypeHelper.CreateResourceName(type, _options.ResourcesPath);
            var filePath = Path.Combine(_options.ResourcesPath, $"{resFileName}.{culture}");
            var xmlFilePath = $"{filePath}.xml";
            var resxFilePath = $"{filePath}.resx";

            var _xd = XDocument.Load(xmlFilePath);

            var elements = approvedOnly
                ? _xd.Root.Descendants("data")
                             .Where(x => x.Attribute("isActive").Value == "true")
                             .Select(x => new ResxElement
                             {
                                 Key = x.Element("key")?.Value,
                                 Value = x.Element("value")?.Value,
                                 Comment = x.Element("comment")?.Value
                             })
                : _xd.Root.Descendants("data")
                             .Select(x => new ResxElement
                             {
                                 Key = x.Element("key")?.Value,
                                 Value = x.Element("value")?.Value,
                                 Comment = x.Element("comment")?.Value
                             });

            var resxWriter = new ResxWriter(resxFilePath, _loggerFactory);
            var totalExported = await resxWriter.AddRangeAsync(elements.Where(x => x.Key != null && x.Value != null), overwriteExistingKeys);

            if (totalExported > 0)
            {
                var saved = await resxWriter.SaveAsync();
                if (saved)
                    _logger.LogInformation($"Total '{totalExported}' resources exported to '{resxFilePath}'");
                else
                    _logger.LogError($"Exported not successful to '{resxFilePath}'");

            }

            return totalExported;
        }
    }
}
