using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Options;
using XLocalizer.Messages;

namespace XLocalizer.MetadataProviders
{
    /// <summary>
    /// DataAnnotations Metadata Provider
    /// </summary>
    public class XValidationMetadataProvider : IValidationMetadataProvider
    {
        private readonly DefaultDataAnnotationsErrorMessages errorMessages;
        private readonly KeyValuePair<string, string>[] map;

        /// <summary>
        /// Initialize a new instance of <see cref="XValidationMetadataProvider"/>
        /// </summary>
        /// <param name="options"></param>
        public XValidationMetadataProvider(IOptions<XLocalizerOptions> options)
        {
            errorMessages = options.Value.DefaultDataAnnotationsErrorMessages;

            map = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>(typeof(RequiredAttribute).FullName, errorMessages.RequiredAttribute_ValidationError),
                new KeyValuePair<string, string>(typeof(StringLengthAttribute).FullName, errorMessages.StringLengthAttribute_ValidationError),
                new KeyValuePair<string, string>(typeof(CompareAttribute).FullName, errorMessages.CompareAttribute_MustMatch),
                new KeyValuePair<string, string>(typeof(MaxLengthAttribute).FullName, errorMessages.MaxLengthAttribute_ValidationError),
                new KeyValuePair<string, string>(typeof(MinLengthAttribute).FullName, errorMessages.MinLengthAttribute_ValidationError),
                new KeyValuePair<string, string>(typeof(EmailAddressAttribute).FullName, errorMessages.EmailAddressAttribute_Invalid),
                new KeyValuePair<string, string>(typeof(RangeAttribute).FullName, errorMessages.RangeAttribute_ValidationError),
                new KeyValuePair<string, string>(typeof(PhoneAttribute).FullName, errorMessages.PhoneAttribute_Invalid),
                new KeyValuePair<string, string>(typeof(RegularExpressionAttribute).FullName, errorMessages.RegexAttribute_ValidationError),
                new KeyValuePair<string, string>(typeof(CreditCardAttribute).FullName, errorMessages.CreditCardAttribute_Invalid),
                new KeyValuePair<string, string>(typeof(UrlAttribute).FullName, errorMessages.UrlAttribute_Invalid),
                new KeyValuePair<string, string>(typeof(DataTypeAttribute).FullName, errorMessages.DataTypeAttribute_EmptyDataTypeString),
                new KeyValuePair<string, string>(typeof(ValidationAttribute).FullName, errorMessages.ValidationAttribute_ValidationError),
                new KeyValuePair<string, string>(typeof(FileExtensionsAttribute).FullName, errorMessages.FileExtensionsAttribute_Invalid),
                new KeyValuePair<string, string>(typeof(CustomValidationAttribute).FullName, errorMessages.CustomValidationAttribute_ValidationError)
            };
        }

        /// <summary>
        /// Gets the values for properties of Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata.
        /// </summary>
        /// <param name="context"></param>
        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            foreach (var attribute in context.ValidationMetadata.ValidatorMetadata)
            {
                if (attribute is ValidationAttribute vAtt)
                {
                    var type = vAtt.GetType();
                    
                    vAtt.ErrorMessage = (type == typeof(StringLengthAttribute) && ((StringLengthAttribute)vAtt).MinimumLength > 0) 
                        ? errorMessages.StringLengthAttribute_ValidationErrorIncludingMinimum
                        : map.SingleOrDefault(x => x.Key == type.FullName).Value;
                }
            }
        }
    }
}