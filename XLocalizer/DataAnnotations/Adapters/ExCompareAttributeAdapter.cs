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
    public class ExCompareAttributeAdapter : AttributeAdapterBase<ExCompareAttribute>
    {
        // name of the other attribute
        private string _att { get; set; }
        private readonly IStringLocalizer Localizer;

        /// <summary>
        /// Initialize a new instance of <see cref="ExCompareAttributeAdapter"/>
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="stringLocalizer"></param>
        public ExCompareAttributeAdapter(ExCompareAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {
            _att = attribute.OtherProperty;
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
            MergeAttribute(context.Attributes, "data-val-equalto", GetErrorMessage(context));
            MergeAttribute(context.Attributes, "data-val-equalto-other", $"*.{_att}");
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

            var _locAtt = Localizer[_att].Value;

            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName(), _locAtt);
        }
    }
}
