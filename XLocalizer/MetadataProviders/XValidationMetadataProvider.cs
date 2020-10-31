using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Options;
using XLocalizer.DataAnnotations;
using XLocalizer.Messages;

namespace XLocalizer.MetadataProviders
{
    /// <summary>
    /// ModelBinding Metadata Provider
    /// </summary>
    public class XValidationMetadataProvider : IValidationMetadataProvider
    {
        private readonly DefaultDataAnnotationsErrorMessages errorMessages;

        /// <summary>
        /// Initialize a new instance of <see cref="XValidationMetadataProvider"/>
        /// </summary>
        /// <param name="options"></param>
        public XValidationMetadataProvider(IOptions<XLocalizerOptions> options)
        {
            errorMessages = options.Value.DefaultDataAnnotationsErrorMessages;
        }

        /// <summary>
        /// Gets the values for properties of Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata.
        /// </summary>
        /// <param name="context"></param>
        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            foreach (var attribute in context.ValidationMetadata.ValidatorMetadata)
            {
                if (attribute is ValidationAttribute tAttr)
                {
                    switch (tAttr.GetType().Name)
                    {
                        case nameof(RequiredAttribute):
                        case nameof(ExRequiredAttribute):
                            tAttr.ErrorMessage = errorMessages.RequiredAttribute_ValidationError;
                            break;

                        case nameof(StringLengthAttribute):
                        case nameof(ExStringLengthAttribute):
                            if (((StringLengthAttribute)tAttr).MinimumLength > 0)
                                tAttr.ErrorMessage = errorMessages.StringLengthAttribute_ValidationErrorIncludingMinimum;
                            else
                                tAttr.ErrorMessage = errorMessages.StringLengthAttribute_ValidationError;
                            break;

                        case nameof(CustomValidationAttribute):
                            tAttr.ErrorMessage = errorMessages.CustomValidationAttribute_ValidationError;
                            break;

                        case nameof(RangeAttribute):
                        case nameof(ExRangeAttribute):
                            tAttr.ErrorMessage = errorMessages.RangeAttribute_ValidationError;
                            break;

                        case nameof(RegularExpressionAttribute):
                        case nameof(ExRegularExpressionAttribute):
                            tAttr.ErrorMessage = errorMessages.RegexAttribute_ValidationError;
                            break;

                        case nameof(CompareAttribute):
                        case nameof(ExCompareAttribute):
                            tAttr.ErrorMessage = errorMessages.CompareAttribute_MustMatch;
                            break;

                        case nameof(MaxLengthAttribute):
                        case nameof(ExMaxLengthAttribute):
                            tAttr.ErrorMessage = errorMessages.MaxLengthAttribute_ValidationError;
                            break;

                        case nameof(MinLengthAttribute):
                        case nameof(ExMinLengthAttribute):
                            tAttr.ErrorMessage = errorMessages.MinLengthAttribute_ValidationError;
                            break;

                        case nameof(CreditCardAttribute):
                            tAttr.ErrorMessage = errorMessages.CreditCardAttribute_Invalid;
                            break;

                        case nameof(PhoneAttribute):
                            tAttr.ErrorMessage = errorMessages.PhoneAttribute_Invalid;
                            break;

                        case nameof(EmailAddressAttribute):
                            tAttr.ErrorMessage = errorMessages.EmailAddressAttribute_Invalid;
                            break;

                        case nameof(DataTypeAttribute):
                            tAttr.ErrorMessage = errorMessages.DataTypeAttribute_EmptyDataTypeString;
                            break;

                        case nameof(FileExtensionsAttribute):
                            tAttr.ErrorMessage = errorMessages.FileExtensionsAttribute_Invalid;
                            break;

                        case nameof(UrlAttribute):
                            tAttr.ErrorMessage = errorMessages.UrlAttribute_Invalid;
                            break;

                        case nameof(ValidationAttribute):
                            tAttr.ErrorMessage = errorMessages.ValidationAttribute_ValidationError;
                            break;

                        default: break;
                    }
                }
            }
        }
    }
}