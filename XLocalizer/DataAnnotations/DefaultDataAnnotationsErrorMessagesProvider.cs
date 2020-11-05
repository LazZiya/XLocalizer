using System;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Express validation attributes are deprected. Use default attributes instead. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md">Localizing Data Annotations</a>
    /// </summary>
    [Obsolete("Express validation attributes are deprected. Use default attributes instead. See https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md")]
    public class DefaultDataAnnotationsErrorMessagesProvider : IDataAnnotationsMessagesProvider
    {
        string IDataAnnotationsMessagesProvider.CompareAttribute_MustMatch => "'{0}' and '{1}' do not match.";

        string IDataAnnotationsMessagesProvider.CreditCardAttribute_Invalid => "The {0} field is not a valid credit card number.";

        string IDataAnnotationsMessagesProvider.CustomValidationAttribute_ValidationError => "{0} is not valid.";

        string IDataAnnotationsMessagesProvider.DataTypeAttribute_EmptyDataTypeString => "The custom DataType string cannot be null or empty.";

        string IDataAnnotationsMessagesProvider.EmailAddressAttribute_Invalid => "The {0} field is not a valid e-mail address.";

        string IDataAnnotationsMessagesProvider.FileExtensionsAttribute_Invalid => "The {0} field only accepts files with the following extensions: {1}";

        string IDataAnnotationsMessagesProvider.MaxLengthAttribute_ValidationError => "The field {0} must be a string or array type with a maximum length of '{1}'.";

        string IDataAnnotationsMessagesProvider.MinLengthAttribute_ValidationError => "The field {0} must be a string or array type with a minimum length of '{1}'.";

        string IDataAnnotationsMessagesProvider.PhoneAttribute_Invalid => "The {0} field is not a valid phone number.";

        string IDataAnnotationsMessagesProvider.RangeAttribute_ValidationError => "The field {0} must be between {1} and {2}.";

        string IDataAnnotationsMessagesProvider.RegexAttribute_ValidationError => "The field {0} must match the regular expression '{1}'.";

        string IDataAnnotationsMessagesProvider.RequiredAttribute_ValidationError => "The {0} field is required.";

        string IDataAnnotationsMessagesProvider.StringLengthAttribute_ValidationError => "The field {0} must be a string with a maximum length of {1}.";

        string IDataAnnotationsMessagesProvider.StringLengthAttribute_ValidationErrorIncludingMinimum => "The field {0} must be a string with a minimum length of {2} and a maximum length of {1}.";

        string IDataAnnotationsMessagesProvider.UrlAttribute_Invalid => "The {0} field is not a valid fully-qualified http, https, or ftp URL.";

        string IDataAnnotationsMessagesProvider.ValidationAttribute_ValidationError => "The field {0} is invalid.";
    }
}
