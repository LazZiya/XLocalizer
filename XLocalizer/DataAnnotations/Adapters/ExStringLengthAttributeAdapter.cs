using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;

namespace XLocalizer.DataAnnotations.Adapters
{
    /// <summary>
    /// Adapter for providing a localized error message for <see cref="ExStringLengthAttribute"/>
    /// </summary>
    public class ExStringLengthAttributeAdapter : AttributeAdapterBase<ExStringLengthAttribute>
    {
        private readonly int MaxLenght;
        private readonly IStringLocalizer Localizer;

        /// <summary>
        /// Initialize a new instance of <see cref="ExStringLengthAttributeAdapter"/>
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="stringLocalizer"></param>
        public ExStringLengthAttributeAdapter(ExStringLengthAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {
            MaxLenght = attribute.MaximumLength;
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
            MergeAttribute(context.Attributes, "data-val-length", GetErrorMessage(context));
            MergeAttribute(context.Attributes, "data-val-length-max", $"{MaxLenght}");
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

            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName(), MaxLenght);
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
