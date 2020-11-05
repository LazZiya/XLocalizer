using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System;
using System.ComponentModel.DataAnnotations;
using XLocalizer.DataAnnotations.Adapters;

#if NETCOREAPP2_0 || NETCOREAPP2_1 || NETCOREAPP2_2
using Microsoft.AspNetCore.Mvc.DataAnnotations.Internal;
#endif

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Express validation attributes are deprected. Use default attributes instead. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md">Localizing Data Annotations</a>
    /// </summary>
    [Obsolete("Express validation attributes are deprected. Use default attributes instead. See https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md")]
    public class ExAttributeAdapterSwitch
    {
        /// <summary>
        /// Get the ex attribute adapter
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="stringLocalizer"></param>
        /// <returns></returns>
        public static IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
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

            return null;
        }
    }
}