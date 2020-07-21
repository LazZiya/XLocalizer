using XLocalizer.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLocalizer.TagHelpers
{
    /// <summary>
    /// Localization tag helper, localize text inside <![CDATA[<localize>Hellow</localize>]]>
    /// </summary>
    /// 
    [HtmlTargetElement(Attributes = "localize*")]
    public class LocalizeAttributesTagHelper : LocalizationTagHelperBase
    {
        private readonly IExpressStringLocalizerFactory _stringFactory;

        private readonly string _LocalizeAtt = "localize-att-";

        /// <summary>
        /// Bool value, true to localize content
        /// </summary>
        [HtmlAttributeName("localize-content")]
        public bool Localize { get; set; } = true;

        /// <summary>
        /// localize custom attribute fields
        /// </summary>
        [HtmlAttributeName("localize-att-")]
        public string LocalizeAttribute { get; set; }

        /// <summary>
        /// Initialize a new instance of LocaizatAttributesTagHelper
        /// </summary>
        /// <param name="htmlFactory"></param>
        /// <param name="stringFactory"></param>
        public LocalizeAttributesTagHelper(IExpressHtmlLocalizerFactory htmlFactory, IExpressStringLocalizerFactory stringFactory)
            : base(htmlFactory)
        {
            _stringFactory = stringFactory;
        }

        /// <summary>
        /// process localize tag helper
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //if (Localize || (Args != null && Args.Length > 0) || !string.IsNullOrEmpty(Culture) || ResourceSource != null)
            if (output.Attributes.Any(x => x.Name.StartsWith(_LocalizeAtt)))
            {
                //list of attributes to be localized e.g. localize-att-title="Image title"
                var addAttributes = new List<TagHelperAttribute>();

                //list of attributes to be removed
                //technically, the attribute will be renamed by removing localize-att- prefix and the rest will be kept
                //e.g. localize-att-title="Image title" will be title="Resim başlığı"
                var removeAttributes = new List<TagHelperAttribute>();

                foreach (var att in output.Attributes)
                {
                    //find all custom attributes that starts with localize-att-*
                    if (att.Name.StartsWith(_LocalizeAtt))
                    {
                        var _loc = _stringFactory.Create();

                        //get localized attribute value
                        var localAttValue = _loc[att.Value.ToString()];

                        //add new ttribute with new name and locized value to the list
                        addAttributes.Add(new TagHelperAttribute(att.Name.Replace(_LocalizeAtt, ""), localAttValue));

                        //add the attribute to the remove list
                        removeAttributes.Add(att);
                    }
                }

                if (addAttributes.Count > 0)
                    //add new attibutes to the output
                    addAttributes.ForEach(x => output.Attributes.Add(x));

                if (removeAttributes.Count > 0)
                    //remove old attributes from the output
                    removeAttributes.ForEach(x => output.Attributes.Remove(x));

            }

            // Localize contents if localize-content="true"
            // or if there is any localize-* attribute other than localize-att-*
            if (Localize || output.Attributes.Any(x => x.Name.StartsWith("localize-") && !x.Name.StartsWith(_LocalizeAtt)))
            {
                await base.ProcessAsync(context, output);
            }
        }
    }
}
