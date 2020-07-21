using XLocalizer.Common;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace XLocalizer.TagHelpers
{
    /// <summary>
    /// base class for localize tag helpers
    /// </summary>
    public class LocalizationTagHelperBase : TagHelper
    {
        private readonly IExpressHtmlLocalizerFactory _localizerFactory;

        /// <summary>
        /// pass array of objects for arguments
        /// </summary>
        [HtmlAttributeName("localize-args")]
        public object[] Args { get; set; }

        /// <summary>
        /// Localize or translate contents to the specified target culture. Default is current culture.
        /// </summary>
        [HtmlAttributeName("localize-culture")]
        public string Culture { get; set; } = string.Empty;

        /// <summary>
        /// Type of the localized resource
        /// </summary>
        [HtmlAttributeName("localize-source")]
        public Type ResourceSource { get; set; }

        /// <summary>
        /// Initialize a new instance of LocaizationTagHelperBase
        /// </summary>
        /// <param name="localizerFactory"></param>
        public LocalizationTagHelperBase(IExpressHtmlLocalizerFactory localizerFactory)
        {
            _localizerFactory = localizerFactory;
        }

        /// <summary>
        /// process localize tag helper
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();

            if (!string.IsNullOrWhiteSpace(content.GetContent()))
            {
                var str = content.GetContent().ReplaceWhitespace(" ");

                LocalizedHtmlString _localStr;

                if (string.IsNullOrWhiteSpace(Culture))
                {
                    _localStr = GetLocalizedHtmlString(str);
                }
                else
                {
                    using (var cs = new CultureSwitcher(Culture))
                    {
                        _localStr = GetLocalizedHtmlString(str);
                    }
                }

                output.Content.SetHtmlContent(_localStr.Value);
            }
        }

        private LocalizedHtmlString GetLocalizedHtmlString(string str)
        {
            var _loc = ResourceSource == null
                ? _localizerFactory.Create()
                : _localizerFactory.Create(ResourceSource);

            return Args == null
                ? _loc[str]
                : _loc[str, Args];
        }
    }
}
