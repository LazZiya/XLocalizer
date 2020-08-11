using XLocalizer.DataAnnotations.Adapters;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System;
using System.ComponentModel.DataAnnotations;

#if NETCOREAPP2_0 || NETCOREAPP2_1 || NETCOREAPP2_2
using Microsoft.AspNetCore.Mvc.DataAnnotations.Internal;
#endif

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
            if (attribute == null)
                throw new ArgumentNullException(nameof(attribute));

            var type = attribute.GetType();

            if (type == typeof(ExRequiredAttribute))
                return new RequiredAttributeAdapter((RequiredAttribute)attribute, stringLocalizer);

            if (type == typeof(ExMaxLengthAttribute))
                return new ExMaxLengthAttributeAdapter((ExMaxLengthAttribute)attribute, stringLocalizer);

            if (type == typeof(ExMinLengthAttribute))
                return new ExMinLengthAttributeAdapter((ExMinLengthAttribute)attribute, stringLocalizer);
            
            if (type == typeof(ExCompareAttribute))
                return new ExCompareAttributeAdapter((ExCompareAttribute)attribute, stringLocalizer);
            
            if (type == typeof(ExRangeAttribute))
                return new ExRangeAttributeAdapter((ExRangeAttribute)attribute, stringLocalizer);

            if (type == typeof(ExRegularExpressionAttribute))
                return new ExRegularExpressionAttributeAdapter((ExRegularExpressionAttribute)attribute, stringLocalizer);
                
            if (type == typeof(ExStringLengthAttribute))
                return new ExStringLengthAttributeAdapter((ExStringLengthAttribute)attribute, stringLocalizer);

            return base.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
