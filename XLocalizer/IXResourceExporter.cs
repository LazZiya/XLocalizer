using System;
using System.Threading.Tasks;

namespace XLocalizer
{
    /// <summary>
    /// Interface to implement resource exporters to .resx file
    /// </summary>
    public interface IXResourceExporter
    {
        /// <summary>
        /// Export resources of specified type and culture to resx
        /// </summary>
        /// <typeparam name="TResource"></typeparam>
        /// <param name="culture"></param>
        /// <param name="approvedOnly"></param>
        /// <param name="overwriteExistingKeys"></param>
        /// <returns></returns>
        Task<int> ExportToResxAsync<TResource>(string culture, bool approvedOnly, bool overwriteExistingKeys)
            where TResource : class;

        /// <summary>
        /// Export xml data to resx
        /// </summary>
        /// <param name="type"></param>
        /// <param name="culture"></param>
        /// <param name="approvedOnly"></param>
        /// <param name="overwriteExistingKeys"></param>
        /// <returns></returns>
        Task<int> ExportToResxAsync(Type type, string culture, bool approvedOnly, bool overwriteExistingKeys);
    }
}
