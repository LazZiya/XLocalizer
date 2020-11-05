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
    public class ExStringLengthAttributeAdapter : AttributeAdapterBase<ExStringLengthAttribute>
    {
        private readonly int MaxLenght;
        private readonly int MinLength;

        /// <summary>
        /// Initialize a new instance of <see cref="ExStringLengthAttributeAdapter"/>
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="stringLocalizer"></param>
        public ExStringLengthAttributeAdapter(ExStringLengthAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {
            MaxLenght = attribute.MaximumLength;
            MinLength = attribute.MinimumLength;
        }

        /// <summary>
        /// Add validation context
        /// </summary>
        /// <param name="context"></param>
        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
                throw new NullReferenceException(nameof(context));

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-length", GetErrorMessage(context));
            MergeAttribute(context.Attributes, "data-val-length-max", $"{MaxLenght}");
            MergeAttribute(context.Attributes, "data-val-length-min", $"{MinLength}");
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

            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName(), MaxLenght, MinLength);
        }
    }
}
