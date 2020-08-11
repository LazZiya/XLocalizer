using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Registeres express valdiation attributes
    /// </summary>
    public class ExpressValidationAttributeAdapterProvider : ValidationAttributeAdapterProvider, IValidationAttributeAdapterProvider
    {
        /// <summary>
        /// Initialize a new instance of <see cref="ExpressValidationAttributeAdapterProvider"/>
        /// </summary>
        public ExpressValidationAttributeAdapterProvider()
        {
        }

        IAttributeAdapter IValidationAttributeAdapterProvider.GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            return ExAttributeAdapterSwitch.GetAttributeAdapter(attribute, stringLocalizer) ?? base.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
