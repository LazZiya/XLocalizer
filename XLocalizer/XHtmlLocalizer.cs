using XLocalizer.Common;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace XLocalizer
{
    /// <summary>
    /// Html localizer
    /// </summary>
    /// <typeparam name="TResource"></typeparam>
    public class XHtmlLocalizer<TResource> : XHtmlLocalizer, IHtmlLocalizer<TResource>
        where TResource : class
    {
        /// <summary>
        /// Initialize a new instance of <see cref="XHtmlLocalizer"/> based on the default resource type
        /// </summary>
        /// <param name="stringLocalizerFactory"></param>
        public XHtmlLocalizer(IStringLocalizerFactory stringLocalizerFactory)
            : base(stringLocalizerFactory.Create(typeof(TResource)))
        {

        }
    }

    /// <summary>
    /// XHtml localizer
    /// </summary>
    public class XHtmlLocalizer : IHtmlLocalizer
    {
        private readonly IStringLocalizer _strLocalizer;

        /// <summary>
        /// Create a new instance of <see cref="XHtmlLocalizer{TResource}"/>
        /// </summary>
        /// <param name="strLocalizer"></param>
        public XHtmlLocalizer(IStringLocalizer strLocalizer)
        {
            _strLocalizer = strLocalizer;
        }

        /// <summary>
        /// Get localized html string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public LocalizedHtmlString this[string name] => GetHtmlString(name);

        /// <summary>
        /// Get localized html string with arguments
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public LocalizedHtmlString this[string name, params object[] arguments] => GetHtmlString(name, arguments);

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
        /// Get localizes string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public LocalizedString GetString(string name)
        {
            return _strLocalizer[name];
        }

        /// <summary>
        /// Get localized string
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public LocalizedString GetString(string name, params object[] arguments)
        {
            return _strLocalizer[name, arguments];
        }

        /// <summary>
        /// Get localized html string
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        private LocalizedHtmlString GetHtmlString(string name, params object[] arguments)
        {
            var locStr = _strLocalizer[name, arguments];

            return new LocalizedHtmlString(name, locStr.Value, locStr.ResourceNotFound, locStr.SearchedLocation);
        }

        /// <summary>
        /// NOT IMPLEMENTED! use <see cref="CultureSwitcher"/> instead.
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        public IHtmlLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
