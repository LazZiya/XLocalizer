using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;

namespace XLocalizer.DataAnnotations.Adapters
{
    /// <summary>
    /// Express validation attributes are deprected. Use default attributes instead. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md">Localizing Data Annotations</a>
    /// </summary>
    [Obsolete("Express validation attributes are deprected. Use default attributes instead. See https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md")]
    public class ExRegularExpressionAttributeAdapter : AttributeAdapterBase<ExRegularExpressionAttribute>
    {
        private readonly string RegexPattern;
        private readonly IStringLocalizer Localizer;

        /// <summary>
        /// Initialize a new instance of <see cref="ExRegularExpressionAttributeAdapter"/>
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="stringLocalizer"></param>
        public ExRegularExpressionAttributeAdapter(ExRegularExpressionAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {
            RegexPattern = attribute.Pattern;
            Localizer = stringLocalizer;
        }

        /// <summary>
        /// Add valdiation context
        /// </summary>
        /// <param name="context"></param>
        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
                throw new NullReferenceException(nameof(context));

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-regex", GetErrorMessage(context));
            MergeAttribute(context.Attributes, "data-val-regex-pattern", RegexPattern);
        }

        /// <summary>
        /// Get localized error message
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            if (validationContext == null)
                throw new NullReferenceException(nameof(validationContext));

            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName(), RegexPattern);
        }
    }
}
