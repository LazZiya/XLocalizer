using XLocalizer.Common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace XLocalizer.Xml
{
    /// <summary>
    /// Initialize a new instance of <see cref="XmlResourceProvider"/>
    /// </summary>
    public class XmlResourceProvider : IXResourceProvider
    {
        private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private readonly XLocalizerOptions _options;
        private readonly ILogger _logger;
        private readonly ConcurrentDictionary<string, string> _cache = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// Initialize a new instance of <see cref="XmlResourceProvider"/>
        /// </summary>
        public XmlResourceProvider(IOptions<XLocalizerOptions> options,
                                       ILogger<XmlResourceProvider> logger)
        {
            _logger = logger;
            _options = options.Value;
        }

        private string ResourcePath<TResource>()
            where TResource : class
        {
            return _cache.GetOrAdd($"_xml_{typeof(TResource).FullName}", _ =>
            {
                string typeName = ResourceTypeHelper.CreateResourceName(typeof(TResource), _options.ResourcesPath);

                return $".\\{_options.ResourcesPath}\\{typeName}.{{0}}.xml";
            });
        }

        /// <summary>
        /// Get a localized value from Xml source
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue<TResource>(string name, out string value)
            where TResource : class
        {
            var _path = ResourcePath<TResource>();

            var path = string.Format(_path, CultureInfo.CurrentCulture.Name);


            _lock.EnterReadLock();
            try
            {
                var _doc = GetXmlDocument(path);
                var elmnt = Find(name, _doc);
                value = elmnt?.Element("value").Value;
            }
            catch
            {
                value = null;
            }
            finally
            {
                _lock.ExitReadLock();
            }

            return value != null;
        }

        /// <summary>
        /// Set a localized value into Xml source
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="comment"></param>
        /// <param name="isApproved">boolean value for automatically created resource keys. False by default.</param>
        /// <returns></returns>
        public bool TrySetValue<TResource>(string name, string value, string comment, bool isApproved = false)
            where TResource : class
        {
            var _path = ResourcePath<TResource>();

            var path = string.Format(_path, CultureInfo.CurrentCulture.Name);


            var xElement = CreateXElement(name, value, comment, isApproved);

            var success = false;

            _lock.EnterUpgradeableReadLock();
            try
            {
                var _doc = GetXmlDocument(path);
                if (Find(name, _doc) == null)
                {
                    _lock.EnterWriteLock();
                    try
                    {
                        _doc.Root.Add(xElement);
                        _doc.Save(path);
                        success = true;
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
                    _logger.LogInformation($"New key adding result: '{success}', key name: '{name}', path: '{path}'");
                }
            }
            catch
            {
                value = null;
            }
            finally
            {
                _lock.ExitUpgradeableReadLock();
            }

            return success;
        }

        private XElement Find(string name, XDocument doc)
        {
            return doc.Root.Descendants("data").FirstOrDefault(x => x.Element("key").Value.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        private XElement CreateXElement(string name, string value, string comment, bool isApproved)
        {
            return new XElement("data", new XAttribute("isActive", isApproved),
                                        new XElement("key", name),
                                        new XElement("value", value),
                                        new XElement("comment", comment ?? "Created by XLocalizer"));
        }

        /// <summary>
        /// Helper method to create Xml resource file
        /// </summary>
        /// <param name="fPath"></param>
        /// <returns></returns>
        private XDocument GetXmlDocument(string fPath)
        {
            if (!File.Exists(fPath))
            {
                try
                {
                    // Create a copy of the template xml resource
                    var assemblyPath = typeof(XmlTemplate).Assembly.Location;
                    var path = assemblyPath.Substring(0, assemblyPath.LastIndexOf('\\'));
                    File.Copy($"{path}\\Xml\\XmlTemplate.xml", fPath);
                }
                catch (Exception e)
                {
                    throw new FileLoadException($"Can't load or create resource file. {e.Message}");
                }
            }

            return XDocument.Load(fPath);
        }

        /// <summary>
        /// Dispose _lock;
        /// </summary>
        ~XmlResourceProvider()
        {
            if (_lock != null) _lock.Dispose();
        }
    }
}
