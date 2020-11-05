using System;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Express validation attributes are deprected. Use default attributes instead. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md">Localizing Data Annotations</a>
    /// </summary>
    [Obsolete("Express validation attributes are deprected. Use default attributes instead. See https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md")]
    public interface IDataAnnotationsMessagesProvider
    {
        /// <summary>
        /// '{0}' and '{1}' do not match.
        /// </summary>
        string CompareAttribute_MustMatch { get; }

        /// <summary>
        /// The {0} field is not a valid credit card number.
        /// </summary>
        string CreditCardAttribute_Invalid { get; }

        /// <summary>
        /// {0} is not valid.
        /// </summary>
        string CustomValidationAttribute_ValidationError { get; }

        /// <summary>
        /// The custom DataType string cannot be null or empty.
        /// </summary>
        string DataTypeAttribute_EmptyDataTypeString { get; }

        /// <summary>
        /// The {0} field is not a valid e-mail address.
        /// </summary>
        string EmailAddressAttribute_Invalid { get; }
                
        /// <summary>
        /// The {0} field only accepts files with the following extensions: {1}
        /// </summary>
        string FileExtensionsAttribute_Invalid { get; }
                        
        /// <summary>
        /// The field {0} must be a string or array type with a maximum length of '{1}'.
        /// </summary>
        string MaxLengthAttribute_ValidationError { get; }

        /// <summary>
        /// The field {0} must be a string or array type with a minimum length of '{1}'.
        /// </summary>
        string MinLengthAttribute_ValidationError { get; }

        /// <summary>
        /// The {0} field is not a valid phone number.
        /// </summary>
        string PhoneAttribute_Invalid { get; }

        /// <summary>
        /// The field {0} must be between {1} and {2}.
        /// </summary>
        string RangeAttribute_ValidationError { get; }

        /// <summary>
        /// The field {0} must match the regular expression '{1}'.
        /// </summary>
        string RegexAttribute_ValidationError { get; }

        /// <summary>
        /// The {0} field is required.
        /// </summary>
        string RequiredAttribute_ValidationError { get; }

        /// <summary>
        /// The field {0} must be a string with a maximum length of {1}.
        /// </summary>
        string StringLengthAttribute_ValidationError { get; }

        /// <summary>
        /// The field {0} must be a string with a minimum length of {2} and a maximum length of {1}.
        /// </summary>
        string StringLengthAttribute_ValidationErrorIncludingMinimum { get; }

        /// <summary>
        /// The {0} field is not a valid fully-qualified http, https, or ftp URL.
        /// </summary>
        string UrlAttribute_Invalid { get; }

        /// <summary>
        /// The field {0} is invalid.
        /// </summary>
        string ValidationAttribute_ValidationError { get; }
    }
}
