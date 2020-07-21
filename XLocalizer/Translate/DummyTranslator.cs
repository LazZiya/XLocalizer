using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace XLocalizer.Translate
{
    /// <summary>
    /// This class has no any trnaslation functionality.
    /// It is provided just to avoid the exceptions where having 
    /// a registered translation service is a must.
    /// </summary>
    public class DummyTranslator : ITranslator
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initialize a new instance of <see cref="DummyTranslator"/>
        /// </summary>
        /// <param name="logger"></param>
        public DummyTranslator(ILogger<DummyTranslator> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Translation service name
        /// </summary>
        public string ServiceName => "No service";

        /// <summary>
        /// This will return the same string with status code 306 (Unused).
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public Task<TranslationResult> TranslateAsync(string source, string target, string text, string format)
        {
            _logger.LogError("No translation service is defined! Please register and define a translation service.");
            throw new NotImplementedException("No translation service is defined! Please register and define a translation service.");
        }

        /// <summary>
        /// Try translate a text value, 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="text"></param>
        /// <param name="translation"></param>
        /// <returns></returns>
        public bool TryTranslate(string source, string target, string text, out string translation)
        {
            _logger.LogError("No translation service is defined! Please register and define a translation service.");
            throw new NotImplementedException("No translation service is defined! Please register and define a translation service.");
        }
    }
}
