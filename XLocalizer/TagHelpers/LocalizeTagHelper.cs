using XLocalizer.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace XLocalizer.TagHelpers
{
    /// <summary>
    /// Localization tag helper, localize text inside <![CDATA[<localize>Hellow</localize>]]>
    /// </summary>
    public class LocalizeTagHelper : LocalizationTagHelperBase
    {
        /// <summary>
        /// Initialize a new instance of LocalizeTagHelper
        /// </summary>
        /// <param name="localizerFactory"></param>
        public LocalizeTagHelper(IExpressHtmlLocalizerFactory localizerFactory) 
            : base(localizerFactory)
        {
        }

        /// <summary>
        /// process localize tag helper
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //replace <localize> tag with <span>
            output.TagName = "";
            await base.ProcessAsync(context, output);
        }
    }
}
