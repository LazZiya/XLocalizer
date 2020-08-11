using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;

namespace XLocalizer.DataAnnotations.Adapters
{
    /// <summary>
    /// Adapter for providing a localized error message for <see cref="ExRangeAttribute"/>
    /// </summary>
    public class ExRangeAttributeAdapter : AttributeAdapterBase<ExRangeAttribute>
    {
        private object Min { get; set; }
        private object Max { get; set; }

        private readonly IStringLocalizer Localizer;

        /// <summary>
        /// Initialize a new instance of <see cref="ExRangeAttributeAdapter"/>
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="stringLocalizer"></param>
        public ExRangeAttributeAdapter(ExRangeAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {
            Min = attribute.Minimum;
            Max = attribute.Maximum;
            Localizer = stringLocalizer;
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
            MergeAttribute(context.Attributes, "data-val-range", GetErrorMessage(context));
            MergeAttribute(context.Attributes, "data-val-range-max", $"{Max}");
            MergeAttribute(context.Attributes, "data-val-range-min", $"{Min}");
            MergeAttribute(context.Attributes, "data-val-required", GetRequiredErrorMessage(context));
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

            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName(), Min, Max);
        }

        private string GetRequiredErrorMessage(ModelValidationContextBase validationContext)
        {
            if (validationContext == null)
                throw new NullReferenceException(nameof(validationContext));

            var msg = Localizer[DataAnnotationsErrorMessages.RequiredAttribute_ValidationError, validationContext.ModelMetadata.GetDisplayName()].Value;

            return msg;
        }
    }
}
