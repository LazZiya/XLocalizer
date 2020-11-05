using System;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Express validation attributes are deprected. Use default attributes instead. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md">Localizing Data Annotations</a>
    /// </summary>
    [Obsolete("Express validation attributes are deprected. Use default attributes instead. See https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md")]
    public struct DataAnnotationsErrorMessages
    {
        /// <summary>
        /// '{0}' and '{1}' do not match.
        /// </summary>
        public const string CompareAttribute_MustMatch = "'{0}' and '{1}' do not match.";

        /// <summary>
        /// Could not find a property named {0}.
        /// </summary>
        public const string CompareAttribute_UnknownProperty = "Could not find a property named {0}.";

        /// <summary>
        /// The {0} field is not a valid credit card number.
        /// </summary>
        public const string CreditCardAttribute_Invalid = "The {0} field is not a valid credit card number.";

        /// <summary>
        /// {0} is not valid.
        /// </summary>
        public const string CustomValidationAttribute_ValidationError = "{0} is not valid.";

        /// <summary>
        /// The custom DataType string cannot be null or empty.
        /// </summary>
        public const string DataTypeAttribute_EmptyDataTypeString = "The custom DataType string cannot be null or empty.";

        /// <summary>
        /// The {0} field is not a valid e-mail address.
        /// </summary>
        public const string EmailAddressAttribute_Invalid = "The {0} field is not a valid e-mail address.";

        /// <summary>
        /// The {0} field only accepts files with the following extensions: {1}
        /// </summary>
        public const string FileExtensionsAttribute_Invalid = "The {0} field only accepts files with the following extensions: {1}";

        /// <summary>
        /// The field {0} must be a string or array type with a maximum length of '{1}'.
        /// </summary>
        public const string MaxLengthAttribute_ValidationError = "The field {0} must be a string or array type with a maximum length of '{1}'.";

        /// <summary>
        /// The field {0} must be a string or array type with a minimum length of '{1}'.
        /// </summary>
        public const string MinLengthAttribute_ValidationError = "The field {0} must be a string or array type with a minimum length of '{1}'.";

        /// <summary>
        /// The {0} field is not a valid phone number.
        /// </summary>
        public const string PhoneAttribute_Invalid = "The {0} field is not a valid phone number.";

        /// <summary>
        /// The field {0} must be between {1} and {2}.
        /// </summary>
        public const string RangeAttribute_ValidationError = "The field {0} must be between {1} and {2}.";

        /// <summary>
        /// The field {0} must match the regular expression '{1}'.
        /// </summary>
        public const string RegexAttribute_ValidationError = "The field {0} must match the regular expression '{1}'.";

        /// <summary>
        /// The {0} field is required.
        /// </summary>
        public const string RequiredAttribute_ValidationError = "The {0} field is required.";

        /// <summary>
        /// The field {0} must be a string with a maximum length of {1}.
        /// </summary>
        public const string StringLengthAttribute_ValidationError = "The field {0} must be a string with a maximum length of {1}.";

        /// <summary>
        /// The field {0} must be a string with a minimum length of {2} and a maximum length of {1}.
        /// </summary>
        public const string StringLengthAttribute_ValidationErrorIncludingMinimum = "The field {0} must be a string with a minimum length of {2} and a maximum length of {1}.";

        /// <summary>
        /// The {0} field is not a valid fully-qualified http, https, or ftp URL.
        /// </summary>
        public const string UrlAttribute_Invalid = "The {0} field is not a valid fully-qualified http, https, or ftp URL.";

        /// <summary>
        /// <summary>
        /// The field {0} is invalid.
        /// </summary>
        public const string ValidationAttribute_ValidationError = "The field {0} is invalid.";
    }
}
