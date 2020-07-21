using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using XLocalizer.Common;

namespace XLocalizer.Resx
{
    /// <summary>
    /// Create and write to resx resource files
    /// </summary>
    public class ResxWriter
    {
        private readonly XDocument _xd;
        private readonly ILogger _logger;

        /// <summary>
        /// Expose resource file path to external methods...
        /// </summary>
        public string ResourceFilePath;

        /// <summary>
        /// Create a new instance of <see cref="ResxWriter"/>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="location"></param>
        /// <param name="culture"></param>
        /// <param name="loggerFactory"></param>
        public ResxWriter(Type type, string location, string culture, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ResxWriter>();

            string resFileName = ResourceTypeHelper.CreateResourceName(type, location);
            ResourceFilePath = Path.Combine(location, $"{resFileName}.{culture}.resx");

            if (!File.Exists(ResourceFilePath))
                CreateNewResxFile();

            _xd = XDocument.Load(ResourceFilePath);
            _logger.LogInformation($"Resource file loaded: '{ResourceFilePath}'");
        }

        /// <summary>
        /// Create a new instance of <see cref="ResxWriter"/> using the full resource path 
        /// </summary>
        /// <param name="resourceFullPath">Full path and name including culture and extension</param>
        /// <param name="loggerFactory"></param>
        public ResxWriter(string resourceFullPath, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ResxWriter>();
            ResourceFilePath = resourceFullPath;

            if (!File.Exists(ResourceFilePath))
                CreateNewResxFile();

            _xd = XDocument.Load(ResourceFilePath);
            _logger.LogInformation($"Resource file loaded: '{ResourceFilePath}'");
        }

        private bool CreateNewResxFile()
        {
            bool success = false;

            try
            {
                var dummyFileLoc = typeof(ResxTemplate).Assembly.Location;
                var dummyFile = $"{dummyFileLoc.Substring(0, dummyFileLoc.LastIndexOf('\\'))}\\Resx\\{nameof(ResxTemplate)}.resx";
                File.Copy(dummyFile, ResourceFilePath);
                _logger.LogInformation($"Resx file created: '{ResourceFilePath}'");
                success = true;
            }
            catch (Exception e)
            {
                throw new FileLoadException($"Can't create resource file. {e.Message}");
            }

            return success;
        }

        /// <summary>
        /// Add array of elements to the resource file
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="overWriteExistingKeys"></param>
        /// <returns></returns>
        public async Task<int> AddRangeAsync(IEnumerable<ResxElement> elements, bool overWriteExistingKeys)
        {
            var total = 0;

            foreach (var e in elements.Distinct())
            {
                var success = await AddAsync(e, overWriteExistingKeys);

                if (success)
                    total++;
            }

            return total;
        }


        /// <summary>
        /// Add an element to the resource file
        /// </summary>
        /// <param name="element"></param>
        /// <param name="overWriteExistingKeys"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(ResxElement element, bool overWriteExistingKeys = false)
        {
            var elmnt = await FindAsync(element.Key);
            var tsk = new TaskCompletionSource<bool>();

            if (elmnt == null)
            {
                try
                {
                    _xd.Root.Add(element.ToXElement());
                    tsk.SetResult(true);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            if (elmnt != null && overWriteExistingKeys == false)
            {
                tsk.SetResult(false);
            }

            if (elmnt != null && overWriteExistingKeys == true)
            {
                try
                {
                    _xd.Root.Elements("data").FirstOrDefault(x => x == elmnt).ReplaceWith(element.ToXElement());
                    tsk.SetResult(true);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return await tsk.Task;
        }

        /// <summary>
        /// Find resource by its key value
        /// </summary>
        /// <param name="key"></param>
        /// <returns>XElement</returns>
        public async Task<XElement> FindAsync(string key)
        {
            var tsk = new TaskCompletionSource<XElement>();

            await Task.Run(() =>
            {
                var elmnt = _xd.Root.Descendants("data").FirstOrDefault(x => x.Attribute("name").Value.Equals(key, StringComparison.OrdinalIgnoreCase));

                if (elmnt == null)
                    tsk.SetResult(null);

                else
                    tsk.SetResult(elmnt);
            });

            return await tsk.Task;
        }

        /// <summary>
        /// save the resource file
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAsync()
        {
            var tsk = new TaskCompletionSource<bool>();

            await Task.Run(() =>
            {
                try
                {
                    _xd.Save(ResourceFilePath);
                    tsk.SetResult(true);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    tsk.SetResult(false);
                }
            });

            return await tsk.Task;
        }
    }
}
