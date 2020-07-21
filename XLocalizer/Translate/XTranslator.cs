using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace XLocalizer.Translate
{
    /// <summary>
    /// XTranslator to get a translated text from the default translation service
    /// </summary>
    public class XTranslator<TTranslator> : IXTranslator<TTranslator>
        where TTranslator : IStringTranslator
    {
        private readonly IStringTranslator _translator;
        private readonly RequestLocalizationOptions _options;
        private readonly ILogger _logger;

        /// <summary>
        /// Initialize a new instance of ExpressTranslator
        /// </summary>
        /// <param name="translationServices"></param>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public XTranslator(IEnumerable<IStringTranslator> translationServices,
                                 IOptions<RequestLocalizationOptions> options,
                                 ILogger<XTranslator<TTranslator>> logger)
        {
            _translator = translationServices.FirstOrDefault(x => x.GetType() == typeof(TTranslator));
            _options = options.Value;
            _logger = logger;
        }

        /// <summary>
        /// Try translate a text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="format">text ot html</param>
        /// <param name="translation"></param>
        /// <returns></returns>
        public bool TryTranslate(string text, string from, string to, string format, out string translation)
        {
            var trans = _translator.TranslateAsync(from, to, text, format).GetAwaiter().GetResult();

            if (trans.StatusCode == HttpStatusCode.OK)
            {
                translation = trans.Text;
                return true;
            }

            translation = text;
            return false;
        }

        /// <summary>
        /// Try translate a text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format">text ot html</param>
        /// <param name="translation"></param>
        /// <returns></returns>
        public bool TryTranslate(string text, string format, out string translation)
        {
            var from = _options.DefaultRequestCulture.Culture.Name;

            var to = CultureInfo.CurrentCulture.Name;

            return TryTranslate(text, from, to, format, out translation);
        }
    }
}
